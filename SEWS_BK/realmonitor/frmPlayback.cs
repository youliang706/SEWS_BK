using Com.Database;
using Com.SubClass;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using GMap.Extend;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using SEWS_BK.Properties;

namespace SEWS_BK.realmonitor
{
    public partial class frmPlayback : Form
    {
        CDatabase db = new CDatabase();

        private GridColumn colStation;
        private GridColumn colITime;
        private GridColumn colSpeed;
        private GridColumn colCourse;
        private GridColumn colLng;
        private GridColumn colLat;
        private GridColumn colStatusExtra;
        //private GridColumn colStatus;
        //private GridColumn colDirect;

        IList<RealTrackPoint> RowList = new BindingList<RealTrackPoint>();

        public delegate void UpdateTimerDelegate(int p);
        public delegate void PlaybackEndDelegate();

        //private GMapOverlay upRoutesOverlay = new GMapOverlay("upLine");   //上行线路图层
        //private GMapOverlay dnRoutesOverlay = new GMapOverlay("dnLine");    //下行线路图层
        private GMapOverlay trackOverLay = new GMapOverlay("track");        //轨迹图层
        private GMapMarkerImage busMarker;      //车辆位置

        private BackgroundWorker bgWorker;
        private bool displayTrackingLine;
        private bool pauseWhenWarning;
        private System.Timers.Timer timer;

        const int STATUS_IDLE = 1;
        const int STATUS_PLAYING = 2;
        const int STATUS_PAUSED = 3;

        private int playStatus;
        private int curIndex;
        private bool rowChange;

        /// <summary>
        /// key:车辆 busid2, value:车辆的行驶轨迹
        /// </summary>
        private Dictionary<string, List<RealTrackPoint>> dicBusTrack = new Dictionary<string, List<RealTrackPoint>>();

        public frmPlayback()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            InitDgv();
            InitMap();
            SetMisc();

            pnlDgv.Visible = false;
            gmap.Height = pnlDgv.Top + pnlDgv.Height - gmap.Top;

            ttInfo.ShowAlways = true;
        }

        /// <summary>
        /// 初始化轨迹列表
        /// </summary>
        /// <param name="dgv"></param>
        private void InitDgv()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);
            dgvDetail.RowHeight = 20;
            dgvDetail.ColumnPanelRowHeight = 20;

            colStation = CSubClass.CreateColumn("StationName", "位置", 1, 100);
            colITime = CSubClass.CreateColumn("ITime", "时间", 2, 50, HorzAlignment.Center, FormatType.DateTime, "HH:mm:ss");
            colSpeed = CSubClass.CreateColumn("Speed", "速度", 3, 40);
            colCourse = CSubClass.CreateColumn("Course", "角度", 4, 40);
            colLng = CSubClass.CreateColumn("Longitude", "经度", 5, 60);
            colLat = CSubClass.CreateColumn("Latitude", "纬度", 6, 60);
            colStatusExtra = CSubClass.CreateColumn("StatusEx", "超速", 7, 40);
            //colStatus = CSubClass.CreateColumn("Status", "状态", 8, 40);
            //colDirect = CSubClass.CreateColumn("Direct", "方向", 9, 40);

            dgvDetail.Columns.AddRange(new GridColumn[] {
                colStation, colITime, colSpeed, colCourse, colLng, colLat, colStatusExtra //, colStatus, colDirect
            });

            dgvDetail.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgvDetail.Columns)
            {
                c.OptionsColumn.AllowEdit = c.ColumnEdit != null;
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                c.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                c.AppearanceCell.TextOptions.HAlignment = c.AppearanceCell.HAlignment;
            }

            gridList.DataSource = RowList;
            gridList.RefreshDataSource();
        }

        private void InitMap()
        {
            //缓存位置
            gmap.CacheLocation = Environment.CurrentDirectory + "\\GMapCache\\";
            //设置控件显示的地图来源 
            //gmap.MapProvider = AMapProvider.Instance;   //高德地图需要加偏
            gmap.MapProvider = GMapProviders.GoogleChinaMap;
            //设置控件的管理模式  
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            //设置控件显示的当前中心位置
            string centerposition = ConfigurationManager.AppSettings["mapposition"];
            string[] p = centerposition.Split(new char[] { ',' });
            gmap.Position = new PointLatLng(double.Parse(p[1]), double.Parse(p[0]));
            //设置控件最小的缩放比例 
            gmap.MinZoom = 10;
            //设置控件最大的缩放比例 
            gmap.MaxZoom = 20;
            //设置控件当前的缩放比例
            double mapDefZoom = double.Parse(ConfigurationManager.AppSettings["mapzoom"]);
            gmap.Zoom = mapDefZoom;
            //不显示中心十字点
            gmap.ShowCenter = false;
            //左键拖拽地图
            gmap.DragButton = System.Windows.Forms.MouseButtons.Left;

            //gmap.Overlays.Add(upRoutesOverlay);
            //gmap.Overlays.Add(dnRoutesOverlay);
            gmap.Overlays.Add(trackOverLay);

            PointLatLng point = new PointLatLng(0, 0);
            Bitmap bitmap = Properties.Resources.Transport_Van;
            busMarker = new GMapMarkerImage(point, bitmap);
            //busMarker.IsVisible = false;   //默认不显示
            trackOverLay.Markers.Add(busMarker);
        }

        private void SetMisc()
        {
            playStatus = STATUS_IDLE;
            lblProgress.Text = trackBarProgress.Value.ToString() + "%";
            lblSpeed.Text = string.Format("{0:0.0}", 1 - (double)(trackBarSpeed.Value - 1) / 10) + "秒";

            CSubClass.SetXtraDtpStyle(dtpDate, DtType.LongDate);
            dtpDate.EditValue = DateTime.Now;

            dtpStartTime.EditValue = DateTime.Parse("00:00:00");
            dtpEndTime.EditValue = DateTime.Parse("23:59:59");

            displayTrackingLine = tsTrackingLine.IsOn;
            pauseWhenWarning = tsWarningPause.IsOn;

            GetLinesInfo();
        }

        /// <summary>
        /// 获取线路以及车辆信息，上下行站点信息
        /// </summary>
        /// <param name="user"></param>
        private void GetLinesInfo()
        {
            ComboBoxItemCollection coll = cboLine.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();

            try
            {
                for (int i = 0; i < CLineList.LineInfo.Count; i++)
                {
                    coll.Add(new ExComboBox(i, CLineList.LineInfo[i].LineID2.ToString(), CLineList.LineInfo[i].LineName.ToString()));
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            if (cboLine.Properties.Items.Count > 0)
            {
                cboLine.SelectedIndex = 0;
            }
            else
            {
                cboLine.SelectedIndex = -1;
            }
        }

        private void SetDgvSelect(int indexSelected)
        {
            dgvDetail.FocusedRowHandle = indexSelected;

            DrawRealTrack();
            ShowBusPoint(indexSelected);

            //超速报警自动暂停
            if (RowList[indexSelected].StatusExtra == 2 && pauseWhenWarning)
            {
                btnPlayback_Click(null, null);
            }
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                if (dicBusTrack.Count == 0)
                {
                    //MessageBox.Show("无轨迹数据", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblRecords.Text = "无轨迹数据";
                }
                else
                {
                    lblRecords.Text = "轨迹数据加载完毕";
                    cboBusSelected.SelectedIndex = 0;
                }
            }
            else
            {
                lblRecords.Text = "回放数据获取失败";
            }

            LockVideo(true);
            cboBusSelected.Enabled = true;
        }

        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //
        }

        /// <summary>
        /// 从远程数据库获取行车轨迹数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string queryParam = (string)e.Argument;
            string[] queryParams = queryParam.Split(',');

            string startString = dtpStartTime.Text;
            string endString = dtpEndTime.Text;
            string table_name = "tb_a" + ((DateTime)dtpDate.EditValue).ToString("yyyyMMdd");

            string busid2s = "";
            for (int k = 1; k < queryParams.Length; k++)
            {
                if (busid2s.Equals(string.Empty))
                {
                    busid2s = queryParams[k];
                }
                else
                {
                    busid2s = busid2s + "," + queryParams[k];
                }
            }

            try
            {
                string sql = "SELECT a.busid2, a.itime, nvl(a.direct,9) AS direct, a.lon, a.lat, a.course, a.speed, a.status, a.status2, b.stationname " + Environment.NewLine
                            + "FROM " + table_name + " a " + Environment.NewLine
                            + "LEFT JOIN TB_STATIONS b ON a.stationid2 = b.stationid2 AND b.stopsign = 0 " + Environment.NewLine
                            + "WHERE a.lineid2 = " + queryParams[0] + " " + Environment.NewLine
                            + "AND a.busid2 IN (" + busid2s + ") " + Environment.NewLine
                            + "AND a.lon > 0 AND a.lat > 0 " + Environment.NewLine
                            + "AND to_char(a.itime,'hh24:mi:ss') >= '" + startString + "' " + Environment.NewLine
                            + "AND to_char(a.itime,'hh24:mi:ss') <= '" + endString + "' " + Environment.NewLine
                            + "ORDER BY a.itime ";
                DataTable dt = db.GetRs(sql);

                if (dt.Rows.Count >= 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string busid2 = Convert.ToString(dt.Rows[i]["busid2"].ToString());
                        RealTrackPoint pt = new RealTrackPoint()
                        {
                            ITime = DateTime.Parse(dt.Rows[i]["itime"].ToString()),
                            Longitude = double.Parse(dt.Rows[i]["lon"].ToString()),
                            Latitude = double.Parse(dt.Rows[i]["lat"].ToString()),
                            Course = float.Parse(dt.Rows[i]["course"].ToString()),
                            Speed = float.Parse(dt.Rows[i]["speed"].ToString()),
                            DirectNum = int.Parse(dt.Rows[i]["direct"].ToString()),
                            StatusNum = int.Parse(dt.Rows[i]["status"].ToString()),
                            StatusExtra = int.Parse(dt.Rows[i]["status2"].ToString()),
                            StationName = dt.Rows[i]["stationname"].ToString()
                        };

                        if (dicBusTrack.ContainsKey(busid2))
                        {
                            dicBusTrack[busid2].Add(pt);
                        }
                        else
                        {
                            List<RealTrackPoint> lt = new List<RealTrackPoint>();
                            lt.Add(pt);

                            dicBusTrack[busid2] = lt;
                        }
                    }
                }
            }
            catch
            {
                e.Result = false;
            }

            e.Result = true;
        }

        private void PlaybackEnds()
        {
            playStatus = STATUS_IDLE;
            btnPlayback.Text = "播放";
            btnRePlayback.Enabled = true;
            trackBarProgress.Enabled = true;
            //pnlDgv.Enabled = true;
            LockParam(true);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.Invoke(new UpdateTimerDelegate(SetDgvSelect), curIndex);
            }
            catch (Exception)
            {
            }

            if (curIndex < RowList.Count - 1)
            {
                curIndex++;
            }
            else
            {
                try
                {
                    this.Invoke(new PlaybackEndDelegate(PlaybackEnds));
                }
                catch (Exception)
                {
                }

                if (timer != null)
                {
                    timer.Enabled = false;
                }
            }
        }

        private void FillDgv()
        {
            if (dicBusTrack.Count == 0)
            {
                //MessageBox.Show("无轨迹数据", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int cur = cboBusSelected.SelectedIndex;
                if (cur >= 0)
                {
                    BusInfo bi = null;
                    string busid2 = ((ExComboBox)cboBusSelected.SelectedItem).Key;

                    for (int i = 0; i < lstBus.CheckedItems.Count; i++)
                    {
                        if (((BusInfo)lstBus.CheckedItems[i]).BusID2 == busid2)
                        {
                            bi = (BusInfo)lstBus.CheckedItems[i];
                            break;
                        }
                    }

                    if (dicBusTrack.ContainsKey(bi.BusID2))
                    {
                        RowList = dicBusTrack[bi.BusID2];
                        gridList.DataSource = RowList;
                        gridList.RefreshDataSource();

                        double centerX = RowList[0].Longitude;
                        double centerY = RowList[0].Latitude;

                        gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(centerX, centerY));
                        busMarker.Position = new PointLatLng(gps.Y, gps.X);

                        dgvDetail.FocusedRowHandle = 0;
                    }
                    else
                    {
                        CSubClass.ClearRows(dgvDetail);
                        MessageBox.Show("无轨迹数据", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            ShowDistance();
        }

        private void ShowDistance()
        {
            if (dicBusTrack.Count <= 0)
            {
                //MessageBox.Show("无轨迹数据", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int cur = cboBusSelected.SelectedIndex;
                if (cur >= 0)
                {
                    string busid2 = ((ExComboBox)cboBusSelected.SelectedItem).Key;

                    if (dicBusTrack.ContainsKey(busid2))
                    {
                        double dis = GetDistance(dicBusTrack[busid2]);

                        //MessageBox.Show("行驶距离" + Math.Round(dis, 2) + "公里", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblDistence.Text = Math.Round(dis, 2) + "Km";
                    }
                    else
                    {
                        lblDistence.Text = "0Km";
                        //MessageBox.Show("无轨迹数据", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private double GetDistance(List<RealTrackPoint> lt)
        {
            double dis = 0;
            for (int i = 0; i < lt.Count - 1; i++)
            {
                dis += GetDistance(lt[i].Latitude, lt[i].Longitude, lt[i + 1].Latitude, lt[i + 1].Longitude);
            }

            return dis;
        }

        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
            Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }

        private const double EARTH_RADIUS = 6378.137;//地球半径 

        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        private void ExpExcel()
        {
            if (dicBusTrack.Count <= 0)
            {
                MessageBox.Show("无轨迹数据", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("本机未安装Excel,请安装Excel", "报警", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = "C:\\";
                sfd.Filter = "excel文件(*.xls)|*.xls";

                string fileName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfd.FileName;
                }
                else
                {
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = excelApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range;

                worksheet.Cells[1, 1] = "站点";
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
                range.Interior.ColorIndex = 15;

                worksheet.Cells[1, 2] = "经度";
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 2];
                range.Interior.ColorIndex = 15;

                worksheet.Cells[1, 3] = "纬度";
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 3];
                range.Interior.ColorIndex = 15;

                worksheet.Cells[1, 4] = "方向";
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 4];
                range.Interior.ColorIndex = 15;

                int cur = cboBusSelected.SelectedIndex;
                List<RealTrackPoint> excelDataList;

                if (cur >= 0)
                {
                    string busid2 = ((ExComboBox)cboBusSelected.SelectedItem).Key;
                    if (dicBusTrack.ContainsKey(busid2))
                    {
                        excelDataList = dicBusTrack[busid2];
                    }
                    else
                    {
                        MessageBox.Show("无轨迹数据", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("请选择车辆", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                for (int r = 0; r < excelDataList.Count; r++)
                {
                    worksheet.Cells[r + 2, 1] = excelDataList[r].StationName;

                    worksheet.Cells[r + 2, 2] = (excelDataList[r].Longitude).ToString();
                    worksheet.Cells[r + 2, 3] = (excelDataList[r].Latitude).ToString();

                    if (excelDataList[r].DirectNum == 0)//上行
                    {
                        worksheet.Cells[r + 2, 4] = "上行";
                    }
                    else if (excelDataList[r].DirectNum == 1)//下行
                    {
                        worksheet.Cells[r + 2, 4] = "下行";
                    }
                    else
                    {
                        worksheet.Cells[r + 2, 4] = "未知";
                    }
                }

                excelApp.Visible = true;

                workbook.SaveAs(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                workbook.Close(Microsoft.Office.Interop.Excel.XlSaveAction.xlSaveChanges, Missing.Value, Missing.Value);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "报警", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("导出数据成功", "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmPlayback_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void frmPlayback_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Enabled = false;
                timer.Dispose();
                timer.Close();
            }

            //try
            //{
            //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //    config.AppSettings.Settings.Remove("mapposition");
            //    config.AppSettings.Settings.Add("mapposition", Convert.ToString(gmap.Position.Lng) + "," + Convert.ToString(gmap.Position.Lat));

            //    config.AppSettings.Settings.Remove("mapzoom");
            //    config.AppSettings.Settings.Add("mapzoom", Convert.ToString(gmap.Zoom));

            //    config.Save();
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}
        }

        ///// <summary>
        ///// 生成线路站点轨迹图层
        ///// </summary>
        ///// <param name="lineID2">线路ID</param>
        ///// <param name="updown">上下行标记</param>
        //private void GenerateTrackLayer(string lineID2, bool updown)
        //{
        //    bool showline;
        //    if (updown)
        //    {
        //        showline = tsUpLineTrack.IsOn;
        //        upRoutesOverlay.IsVisibile = false;
        //    }
        //    else
        //    {
        //        showline = tsDnLineTrack.IsOn;
        //        dnRoutesOverlay.IsVisibile = false;
        //    }

        //    for (int j = 0; j < CLineList.LineInfo.Count; j++)
        //    {
        //        LineInfo li = CLineList.LineInfo[j];
        //        if (li.LineID2.ToString().Equals(lineID2))
        //        {
        //            try
        //            {
        //                string stag;
        //                Color lineColor;
        //                List<TrackPoint> lst;
        //                List<StationInfo> lst2;
        //                GMarkerGoogleType markerType;
        //                GMapOverlay routesOverlay;

        //                if (updown)
        //                {
        //                    stag = "upline";
        //                    lineColor = Color.MediumSeaGreen;
        //                    lst = li.UpTrackPointList;
        //                    lst2 = li.UpStationList;
        //                    markerType = GMarkerGoogleType.green_small;
        //                    routesOverlay = upRoutesOverlay;
        //                }
        //                else
        //                {
        //                    stag = "dnline";
        //                    lineColor = Color.SteelBlue;
        //                    lst = li.DownTrackPointList;
        //                    lst2 = li.DownStationList;
        //                    markerType = GMarkerGoogleType.blue_small;
        //                    routesOverlay = dnRoutesOverlay;
        //                }

        //                //轨迹
        //                routesOverlay.Routes.Clear();

        //                List<PointLatLng> routes = new List<PointLatLng>();

        //                for (int i = 0; i < lst.Count; i++)
        //                {
        //                    gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(lst[i].Lon, lst[i].Lat));
        //                    routes.Add(new PointLatLng(gps.Y, gps.X));
        //                }

        //                MapRoute route = new MapRoute(routes, stag + "dd");

        //                GMapRoute r = new GMapRoute(route.Points, stag);  //将路转换成线  
        //                r.Stroke = (Pen)r.Stroke.Clone();
        //                r.Stroke.Width = 3;
        //                r.Stroke.Color = lineColor;

        //                routesOverlay.Routes.Add(r);    //将道路加入图层 

        //                //站点
        //                routesOverlay.Markers.Clear();

        //                MarkerTooltipMode tipMode = gmap.Zoom < 13 ? MarkerTooltipMode.OnMouseOver : MarkerTooltipMode.Always;

        //                for (int i = 0; i < lst2.Count; i++)
        //                {
        //                    gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(lst2[i].Longitude, lst2[i].Latitude));
        //                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(gps.Y, gps.X), markerType);
        //                    marker.ToolTipText = lst2[i].Name;
        //                    marker.ToolTipMode = tipMode;
        //                    marker.ToolTip = new GMapTip(marker, lineColor, Color.White);

        //                    routesOverlay.Markers.Add(marker);
        //                }

        //                break;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("加载轨迹时发生错误", ex);
        //            }
        //        }
        //    }

        //    if (showline)
        //    {
        //        if (updown)
        //        {
        //            upRoutesOverlay.IsVisibile = true;
        //        }
        //        else
        //        {
        //            dnRoutesOverlay.IsVisibile = true;
        //        }
        //    }
        //}

        /// <summary>
        /// 显示指定点的车辆位置
        /// </summary>
        /// <param name="indexSelected"></param>
        private void ShowBusPoint(int indexSelected)
        {
            if (RowList.Count == 0)
            {
                return;
            }

            if (RowList.Count != 0)
            {
                trackBarProgress.Value = 100 * (indexSelected + 1) / RowList.Count;
            }

            double lon = RowList[indexSelected].Longitude;
            double lat = RowList[indexSelected].Latitude;

            //位置
            gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(lon, lat));
            busMarker.Position = new PointLatLng(gps.Y, gps.X);

            AdjustBusPlace(lon, lat);

            //系统提示
            ShowTip(indexSelected);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="indexSelected"></param>
        private void ShowTip(int indexSelected)
        {
            if (RowList.Count == 0)
            {
                return;
            }

            if (!pnlDgv.Visible)
            {
                double lon = RowList[indexSelected].Longitude;
                double lat = RowList[indexSelected].Latitude;

                gpsPoint gps = GpsTranslate.GCJ02ToWGS84(new gpsPoint(lon, lat));
                GPoint point = gmap.FromLatLngToLocal(new PointLatLng(gps.Y, gps.X));

                if (point.X <= 0 || point.X >= gmap.ClientSize.Width || point.Y <= 0 || point.Y >= gmap.ClientSize.Height)
                {
                    ttInfo.Hide(gmap);    //不在显示区域内
                }
                else
                {
                    ttInfo.Show("时间：　" + RowList[indexSelected].ITime.ToString("HH:mm:ss") + Environment.NewLine
                            + "经纬度：" + lon.ToString() + ", " + lat.ToString() + Environment.NewLine
                            + "速度：　" + RowList[indexSelected].Speed.ToString() + Environment.NewLine
                            + "位置：　" + RowList[indexSelected].StationName, gmap, (int)point.X + 10, (int)point.Y + 10);
                }
            }
            else
            {
                ttInfo.Hide(gmap);
            }
        }

        private void DrawRealTrack()
        {
            if (!tsTrackingLine.IsOn)
            {
                return;
            }

            //轨迹
            GMapRoute r = trackOverLay.Routes[0];
            List<PointLatLng> routes = r.Points;

            gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(RowList[curIndex].Longitude, RowList[curIndex].Latitude));
            routes.Add(new PointLatLng(gps.Y, gps.X));

            gmap.UpdateRouteLocalPosition(r);

            gmap.Refresh();
        }

        private void DrawRealTrack2()
        {
            if (!tsTrackingLine.IsOn)
            {
                return;
            }

            if (RowList.Count == 0)
            {
                return;
            }

            trackOverLay.Routes.Clear();

            List<PointLatLng> routes = new List<PointLatLng>();

            for (int i = 0; i <= curIndex; i++)
            {
                gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(RowList[i].Longitude, RowList[i].Latitude));
                routes.Add(new PointLatLng(gps.Y, gps.X));
            }

            MapRoute route = new MapRoute(routes, "dd2");

            GMapRoute r = new GMapRoute(route.Points, "realtrack");  //将路转换成线  
            r.Stroke = (Pen)r.Stroke.Clone();
            r.Stroke.Width = 2;
            r.Stroke.Color = Color.Purple;

            trackOverLay.Routes.Add(r);    //将道路加入图层 

            gmap.Refresh();
        }

        /// <summary>
        /// 自动调整地图位置，以保证车辆图元不会超出显示区域
        /// </summary>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        private void AdjustBusPlace(double lon, double lat)
        {
            gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(lon, lat));
            GPoint point = gmap.FromLatLngToLocal(new PointLatLng(gps.Y, gps.X));

            if (point.X <= 16 || point.X >= gmap.ClientSize.Width - 16)
            {
                if (point.Y <= 16 || point.Y >= gmap.ClientSize.Height - 16)
                {
                    gmap.Position = new PointLatLng(gps.Y, gps.X);
                }
                else
                {
                    gmap.Position = new PointLatLng(gmap.Position.Lat, gps.X);
                }
            }
            else
            {
                if (point.Y <= 16 || point.Y >= gmap.ClientSize.Height - 16)
                {
                    gmap.Position = new PointLatLng(gps.Y, gmap.Position.Lng);
                }
            }
        }

        private void mnuShowList_Click(object sender, EventArgs e)
        {
            gmap.Height = pnlDgv.Top - 6 - gmap.Top;
            pnlDgv.Visible = true;

            ShowTip(curIndex);
            mnuHideList.Visible = true;
            mnuShowList.Visible = false;
        }

        private void mnuHideList_Click(object sender, EventArgs e)
        {
            pnlDgv.Visible = false;
            gmap.Height = pnlDgv.Top + pnlDgv.Height - gmap.Top;

            ShowTip(curIndex);
            mnuShowList.Visible = true;
            mnuHideList.Visible = false;
        }

        private void gmap_SizeChanged(object sender, EventArgs e)
        {
            ShowTip(curIndex);
        }

        private void gmap_OnPositionChanged(PointLatLng point)
        {
            ShowTip(curIndex);
        }

        private void gmap_OnMapZoomChanged()
        {
            ShowTip(curIndex);

            ////根据比列决定Marker是否显示
            //MarkerTooltipMode tipMode = gmap.Zoom < 13 ? MarkerTooltipMode.OnMouseOver : MarkerTooltipMode.Always;

            //foreach (GMapMarker marker in upRoutesOverlay.Markers)
            //{
            //    marker.ToolTipMode = tipMode;
            //}
            //foreach (GMapMarker marker in dnRoutesOverlay.Markers)
            //{
            //    marker.ToolTipMode = tipMode;
            //}
        }

        private void trackBarSpeed_EditValueChanged(object sender, EventArgs e)
        {
            lblSpeed.Text = string.Format("{0:0.0}", 1 - (double)(trackBarSpeed.Value - 1) / 10) + "秒";

            if (timer != null)
            {
                timer.Interval = 1000.0 * (1 - (double)(trackBarSpeed.Value - 1) / 10);
            }
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currSel = cboLine.SelectedIndex;

            if (currSel >= 0)
            {
                //处理标准轨迹
                //GenerateTrackLayer(((ExComboBox)cboLine.SelectedItem).Key, true);
                //GenerateTrackLayer(((ExComboBox)cboLine.SelectedItem).Key, false);

                //处理车辆
                lstBus.Items.Clear();
                for (int i = 0; i < ((CLineList.LineInfo[currSel]).BusList.Count); i++)
                {
                    lstBus.Items.Add((CLineList.LineInfo[currSel]).BusList[i]);
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cboLine.SelectedItem == null || lstBus.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择线路以及车辆", "设置警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.TimeSpan TS = new System.TimeSpan(DateTime.Parse(dtpEndTime.EditValue.ToString()).Ticks - DateTime.Parse(dtpStartTime.EditValue.ToString()).Ticks);
            if (TS.TotalMinutes < 0)
            {
                MessageBox.Show("开始时间不得大于等于结束时间", "设置警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (timer != null)
            {
                timer.Enabled = false;
            }
            LockVideo(false);
            trackBarProgress.Value = 0;
            trackBarSpeed.Value = 50;
            lblRecords.Text = "正在查询,请稍候...";

            cboBusSelected.Enabled = false;
            ComboBoxItemCollection coll = cboBusSelected.Properties.Items;
            coll.BeginUpdate();
            coll.Clear();
            try
            {
                for (int i = 0; i < lstBus.CheckedItems.Count; i++)
                {
                    BusInfo bi = lstBus.CheckedItems[i] as BusInfo;
                    coll.Add(new ExComboBox(i, bi.BusID2.ToString(), bi.BusNumber));
                }
            }
            finally
            {
                coll.EndUpdate();
            }

            lblProgress.Text = trackBarProgress.Value.ToString() + "%";
            lblSpeed.Text = string.Format("{0:0.0}", 1 - (double)(trackBarSpeed.Value - 1) / 10) + "秒";
            CSubClass.ClearRows(dgvDetail);
            //trackPointList.Clear();

            dicBusTrack.Clear();

            string lineid2 = ((ExComboBox)cboLine.SelectedItem).Key;
            string busid2 = "";
            for (int i = 0; i < lstBus.CheckedItems.Count; i++)
            {
                busid2 = busid2 + "," + ((BusInfo)lstBus.CheckedItems[i]).BusID2;
            }

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true; // 设置可以通告进度
            bgWorker.WorkerSupportsCancellation = true; // 设置可以取消
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            bgWorker.RunWorkerAsync(lineid2 + busid2);  //lineid和busid之间是有逗号的
        }

        private void tsTrackingLine_Toggled(object sender, EventArgs e)
        {
            if (tsTrackingLine.IsOn)
            {
                DrawRealTrack2();
                ShowBusPoint(curIndex);
            }
        }

        private void tsWarningPause_Toggled(object sender, EventArgs e)
        {
            pauseWhenWarning = tsWarningPause.IsOn;
        }

        private void btnRePlayback_Click(object sender, EventArgs e)
        {
            dgvDetail.FocusedRowHandle = 0;

            btnPlayback_Click(btnPlayback, e);
        }

        private void cboBusSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDgv();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            ExpExcel();
        }

        private void btnPlayback_Click(object sender, EventArgs e)
        {
            if (RowList.Count == 0)
            {
                return;
            }

            if (playStatus == STATUS_IDLE || playStatus == STATUS_PAUSED)
            {
                playStatus = STATUS_PLAYING;
                btnPlayback.Text = "暂停";
                btnRePlayback.Enabled = false;
                trackBarProgress.Enabled = false;
                //pnlDgv.Enabled = false;
                LockParam(false);

                if (timer != null)
                {
                    timer.Enabled = false;
                }

                timer = new System.Timers.Timer(1000.0 * (1 - (double)(trackBarSpeed.Value - 1) / 10));
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.AutoReset = true;
                timer.Enabled = true;
            }
            else if (playStatus == STATUS_PLAYING)
            {
                playStatus = STATUS_PAUSED;
                btnPlayback.Text = "播放";
                btnRePlayback.Enabled = true;
                trackBarProgress.Enabled = true;
                //pnlDgv.Enabled = true;
                LockParam(true);

                if (timer != null)
                {
                    timer.Enabled = false;
                }
            }
        }

        private void trackBarProgress_EditValueChanged(object sender, EventArgs e)
        {
            lblProgress.Text = trackBarProgress.Value.ToString() + "%";

            if (rowChange)
            { return; }

            if (trackBarProgress.Enabled)
            {
                if (RowList.Count > 0)
                {
                    double idx = (RowList.Count - 1) * trackBarProgress.Value / 100;
                    curIndex = (int)Math.Floor(idx);
                    if (curIndex >= RowList.Count)
                    {
                        curIndex = RowList.Count - 1;
                    }

                    dgvDetail.FocusedRowHandle = curIndex;

                    DrawRealTrack2();
                    ShowBusPoint(curIndex);
                }
            }
        }

        //private void tsUpLineTrack_Toggled(object sender, EventArgs e)
        //{
        //    upRoutesOverlay.IsVisibile = tsUpLineTrack.IsOn;
        //}

        //private void tsDnLineTrack_Toggled(object sender, EventArgs e)
        //{
        //    dnRoutesOverlay.IsVisibile = tsDnLineTrack.IsOn;
        //}

        private void frmPlayback_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 960)
            {
                panelMain.Width = this.ClientSize.Width;
            }
            else
            {
                panelMain.Width = 960;
            }
            if (this.ClientSize.Height > 600)
            {
                panelMain.Height = this.ClientSize.Height;
            }
            else
            {
                panelMain.Height = 600;
            }
        }

        private void dgvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                curIndex = e.FocusedRowHandle;
                rowChange = true;

                DrawRealTrack2();
                ShowBusPoint(curIndex);

                rowChange = false;
            }
        }

        private void LockParam(bool bln)
        {
            foreach (Control ctl in pnlSetting.Controls)
            {
                ctl.Enabled = bln;
            }
        }

        private void LockVideo(bool bln)
        {
            foreach (Control ctl in pnlVedio.Controls)
            {
                ctl.Enabled = bln;
            }
        }
    }
}