using Com.Database;
using Com.SubClass;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using GMap.Extend;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SEWS_BK.generic;
using System.Collections;

namespace SEWS_BK.realmonitor
{
    public partial class frmMonitor : Form
    {
        CDatabase db = Program.db;

        /// <summary>
        /// 线路图层
        /// </summary>
        private GMapOverlay lineOverLay = new GMapOverlay("line");

        /// <summary>
        /// key:线路的ID，value：上行线路轨迹的图层
        /// </summary>
        private Dictionary<string, CLineLyr> upLyrs = new Dictionary<string, CLineLyr>();

        /// <summary>
        /// key:线路的ID，value：下行线路轨迹的图层
        /// </summary>
        private Dictionary<string, CLineLyr> dnLyrs = new Dictionary<string, CLineLyr>();

        /// <summary>
        /// 车辆位置图层
        /// </summary>
        private GMapOverlay busOverLay = new GMapOverlay("bus");

        /// <summary>
        /// 不在线车辆图元
        /// </summary>
        private GMapMarkerImage offlineBusMarker;

        /// <summary>
        /// 车辆信息
        /// </summary>
        private Dictionary<string, BusInfo> dicBuses = new Dictionary<string, BusInfo>();

        /// <summary>
        /// 车辆是否在线后台任务
        /// </summary>
        private BackgroundWorker busOnOffBackworker = null;

        /// <summary>
        /// 接收数据缓冲区,手机号对应位置对象
        /// </summary>
        private Dictionary<string, BusMonitor.MonitorPosBean> dictMonitor;

        /// <summary>
        /// 车辆当前位置,手机号对应点对象
        /// </summary>
        private Dictionary<string, GMapMarkerImage> dictPosition;

        /// <summary>
        /// 更新界面定时器
        /// </summary>
        private System.Timers.Timer updateUITimer;

        public delegate void UpdateMonitorUIDelegate();
        public delegate void UpdateStatusUIDelegate(string phoneNum);

        /// <summary>
        /// 数据通信接口类
        /// </summary>
        private BusMonitor.BusMonitor busMonitor = null;

        /// <summary>
        /// 更新界面的时间间隔，以秒为单位
        /// </summary>
        private int updateUIInterval = 5;

        /// <summary>
        /// 当前登录用户
        /// </summary>
        private string userCode;

        private int onlineBusCount = 0;
        private int busCount = 0;

        private DevExpress.XtraGrid.Columns.GridColumn colBusNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colSpeed;

        List<RowData> RowList = new List<RowData>();

        public frmMonitor()
        {
            userCode = CVar.LoginID;

            InitializeComponent();

            InitGrid();
            InitSearch();
            InitMap();
            CreateMisc();

            StartMonitorBackworker();
        }

        private void InitGrid()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);

            colBusNumber = CSubClass.CreateColumn("PLATENUMBER", "车牌号", 1, 100);
            colLine = CSubClass.CreateColumn("LINENAME", "车队", 2, 100);
            colType = CSubClass.CreateColumn("TYPENAME", "报警类型", 3, 100);
            colTime = CSubClass.CreateColumn("ITIME", "报警时间", 4, 100);
            colPlace = CSubClass.CreateColumn("PLACE", "位置", 5, 100);
            colSpeed = CSubClass.CreateColumn("SPEED", "速度", 6, 100);

            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colBusNumber, colLine, colType, colTime, colPlace, colSpeed
            });

            foreach (DevExpress.XtraGrid.Columns.GridColumn c in dgvDetail.Columns)
            {
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            gridList.DataSource = RowList;
            gridList.RefreshDataSource();
        }

        private void InitSearch()
        {
            if (CLineList.LineInfo.Count != 0)
            {
                for (int i = 0; i < CLineList.LineInfo.Count; i++)
                {
                    LineInfo li = CLineList.LineInfo[i];

                    txtSearch.Properties.Items.Add(li.LineName);
                }
            }
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
            gmap.MaxZoom = 18;
            //设置控件当前的缩放比例
            double mapDefZoom = double.Parse(ConfigurationManager.AppSettings["mapzoom"]);
            gmap.Zoom = mapDefZoom;
            //不显示中心十字点
            gmap.ShowCenter = false;
            //左键拖拽地图
            gmap.DragButton = System.Windows.Forms.MouseButtons.Left;

            //添加图层
            gmap.Overlays.Add(lineOverLay);
            gmap.Overlays.Add(busOverLay);
        }

        private void CreateMisc()
        {
            GetLinesInfo();
            AddLineBuses();

            dictMonitor = new Dictionary<string, BusMonitor.MonitorPosBean>();
            dictPosition = new Dictionary<string, GMapMarkerImage>();

            busMonitor = new BusMonitor.BusMonitor(CLineList.ManagedLines);
            busMonitor.PosChanged += new BusMonitor.BusMonitor.MonitorEventHandler(PosChanged);
        }

        private void PosChanged(BusMonitor.MonitorPosBean bean)
        {
            Console.WriteLine(bean.PhoneNumber + "," + bean.Direction);
            dictMonitor[bean.PhoneNumber] = bean;

            if (bean.Speed > 50)    
            {
                RowData rd = RowList.Find(delegate (RowData r)
                {
                    return r.PHONENUMBER == bean.PhoneNumber;
                });

                if (rd == null)
                {
                    if (RowList.Count == 10)    //最多显示10条
                    {
                        RowList.RemoveAt(0);
                    }

                    BusInfo bi = CLineList.BusInfo[bean.PhoneNumber];

                    rd = new RowData(bean.PhoneNumber, bi.PlateNumber, bi.LineName, "超速", new DateTime(bean.Year,bean.Month,bean.Day, bean.Hour, bean.Minute, bean.Second).ToString() , "", bean.Speed.ToString());
                    RowList.Add(rd);
                }
                else
                {
                    rd.ITIME = bean.Speed.ToString();
                    rd.SPEED = bean.Speed.ToString();
                    rd.TYPENAME = "超速";
                }

                gridList.RefreshDataSource();
            }
        }

        /// <summary>
        /// 启动监控后台通信服务
        /// </summary>
        public void StartMonitorBackworker()
        {
            busOnOffBackworker = new BackgroundWorker();
            busOnOffBackworker.WorkerReportsProgress = true; // 设置可以通告进度
            busOnOffBackworker.WorkerSupportsCancellation = true; // 设置可以取消
            busOnOffBackworker.DoWork += new DoWorkEventHandler(monitorBackworker_DoWork);

            busOnOffBackworker.RunWorkerAsync();
        }

        void monitorBackworker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (updateUITimer != null)
            {

                updateUITimer.Enabled = false;
                updateUITimer = null;
            }

            updateUITimer = new System.Timers.Timer(1000 * updateUIInterval);
            updateUITimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateUITimer_Elapsed);
            updateUITimer.AutoReset = true;
            updateUITimer.Enabled = true;
        }

        /// <summary>
        /// 从缓冲区里取数据，并进行更新界面功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateUITimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                gmap.Invoke(new UpdateMonitorUIDelegate(UpdateMapBusPos));
                this.Invoke(new UpdateMonitorUIDelegate(UpdateTreeNodesStatus));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 更新地图车辆位置
        /// </summary>
        /// <param name="item"></param>
        private void UpdateMapBusPos()
        {
            ArrayList akeys = new ArrayList(dictMonitor.Keys);
            for (int i = 0; i < akeys.Count; i++)
            {
                BusMonitor.MonitorPosBean bean = dictMonitor[akeys[i].ToString()];

                if (dictPosition.ContainsKey(bean.PhoneNumber))
                {
                    GMapMarkerImage marker = dictPosition[bean.PhoneNumber];

                    //位置
                    gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(bean.Longitude, bean.Latitude));
                    marker.Position = new PointLatLng(gps.Y, gps.X);
                }
            }
        }

        /// <summary>
        /// 更新树节点信息
        /// </summary>
        private void UpdateTreeNodesStatus()
        {
            DateTime now = DateTime.Now;
            onlineBusCount = 0;

            //线路
            TreeListNode allNode = lstTree.Nodes[0];
            for (int i = 0; i < allNode.Nodes.Count; i++)
            {
                TreeListNode tn = allNode.Nodes[i];
                LineInfo li = (LineInfo)tn.Tag;

                int onlineCount = 0;

                for (int j = 0; j < tn.Nodes.Count; j++)
                {
                    BusInfo bi = (BusInfo)tn.Nodes[j].Tag;
                    string phone = bi.PhoneNumber;
                    if (dictMonitor.ContainsKey(phone))
                    {
                        BusMonitor.MonitorPosBean bean = dictMonitor[phone];
                        TimeSpan dt = now - bean.BirthDateTime;
                        if (dt.TotalMinutes > 2)
                        {
                            //Log.WriteLogs("掉线:" + bi.PhoneNumber + " time:" + now.ToLongTimeString());

                            //2分钟未收到新数据，掉线
                            tn.Nodes[j].StateImageIndex = 1;
                            bi.Status = "offline";
                        }
                        else
                        {
                            //Log.WriteLogs("上线:" + bi.PhoneNumber + " time:" + now.ToLongTimeString());

                            tn.Nodes[j].StateImageIndex = 2;
                            bi.Status = "online";
                            onlineCount++;
                        }
                    }
                }

                tn.SetValue(lstTree.Columns[0], li.LineName + " (" + onlineCount + @"/" + tn.Nodes.Count + ")");
                onlineBusCount += onlineCount;
            }


            if (lstTree.Nodes.Count > 0)
            {
                lstTree.Nodes[0].SetValue(lstTree.Columns[0], "全部 (" + onlineBusCount + "/" + busCount + ")");
            }
        }

        /// <summary>
        /// 添加公交线路车辆树节点
        /// </summary>
        private void AddLineBuses()
        {
            TreeListNode RootNode = lstTree.AppendNode(null, null);
            RootNode.SetValue(lstTree.Columns[0], "全部");
            RootNode.SetValue(lstTree.Columns[1], "All");
            RootNode.SetValue(lstTree.Columns[2], "0");
            RootNode.StateImageIndex = 0;

            for (int i = 0; i < CLineList.LineInfo.Count; i++)
            {
                LineInfo li = CLineList.LineInfo[i];

                TreeListNode ParentNode = lstTree.AppendNode(null, RootNode);
                ParentNode.SetValue(lstTree.Columns[0], li.LineName + " (" + @"0/" + li.BusList.Count + ")");
                ParentNode.SetValue(lstTree.Columns[1], li.LineID);
                ParentNode.SetValue(lstTree.Columns[2], "1");
                ParentNode.StateImageIndex = 0;
                ParentNode.Tag = li;

                for (int j = 0; j < li.BusList.Count; j++)
                {
                    BusInfo bi = li.BusList[j];

                    TreeListNode ChildNode = lstTree.AppendNode(new object[] { bi.PlateNumber, bi.PhoneNumber, "2" }, ParentNode.Id);
                    ChildNode.Tag = bi;
                    ChildNode.StateImageIndex = 1;
                }
            }

            RootNode.SetValue(lstTree.Columns[0], "全部 (0/" + busCount + ")");
            RootNode.ExpandAll();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            busMonitor = null;

            if (updateUITimer != null)
            {
                updateUITimer.Stop();
                updateUITimer = null;
            }

            base.OnClosing(e);
        }

        /// <summary>
        /// 获取线路信息以及车辆信息
        /// </summary>
        private void GetLinesInfo()
        {
            try
            {
                //获取线路下公交车数据
                busCount = 0;
                for (int k = 0; k < CLineList.LineInfo.Count; k++)
                {
                    if (CLineList.LineInfo[k].BusList.Count != 0)
                    {
                        for (int i = 0; i < CLineList.LineInfo[k].BusList.Count; i++)
                        {
                            BusInfo bi = CLineList.LineInfo[k].BusList[i];

                            if (!dicBuses.ContainsKey(bi.PhoneNumber))
                            {
                                dicBuses.Add(bi.PhoneNumber, bi);
                                if (bi.PhoneNumber != null && !bi.Equals(""))
                                {
                                    busCount++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("车号重复：" + bi.PhoneNumber);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误: " + ex.Message + Environment.NewLine + "位置:" + ex.StackTrace);
            }

            //刷新显示数据
            if (lstTree.Nodes.Count > 0)
            {
                lstTree.Nodes[0].SetValue(lstTree.Columns[0], "全部 (" + onlineBusCount + "/" + busCount + ")");
            }
        }

        private void frmMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings.Remove("mapposition");
                config.AppSettings.Settings.Add("mapposition", Convert.ToString(gmap.Position.Lng) + "," + Convert.ToString(gmap.Position.Lat));

                config.AppSettings.Settings.Remove("mapzoom");
                config.AppSettings.Settings.Add("mapzoom", Convert.ToString(gmap.Zoom));

                config.Save();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 添加车辆到地图
        /// </summary>
        /// <param name="bi"></param>
        private void AddBusToMap(BusInfo bi)
        {
            if (dictPosition.ContainsKey(bi.PhoneNumber))
            {
                GMapMarkerImage marker = dictPosition[bi.PhoneNumber];
                marker.IsVisible = true;
            }
            else
            {
                MarkerTooltipMode tipMode = gmap.Zoom < 13 ? MarkerTooltipMode.OnMouseOver : MarkerTooltipMode.Always;

                Image img;
                switch (bi.ImgType)
                {
                    case 2:
                        img = Properties.Resources.Transport_Van2;
                        break;

                    case 3:
                        img = Properties.Resources.Transport_Van3;
                        break;

                    case 1:
                    default:
                        img = Properties.Resources.Transport_Van;
                        break;
                }

                GMapMarkerImage marker = new GMapMarkerImage(new PointLatLng(0, 0), img);
                marker.IsVisible = true;
                marker.ToolTipText = bi.PlateNumber;
                marker.ToolTipMode = tipMode;
                marker.ToolTip = new GMapTip(marker, Color.MediumPurple, Color.White);
                busOverLay.Markers.Add(marker);

                dictPosition.Add(bi.PhoneNumber, marker);
            }
        }

        /// <summary>
        /// 从地图删除车辆
        /// </summary>
        /// <param name="bi"></param>
        private void DelBusFromMap(BusInfo bi)
        {
            if (dictPosition.ContainsKey(bi.PhoneNumber))
            {
                dictPosition[bi.PhoneNumber].IsVisible = false;
            }
        }

        /// <summary>
        /// 生成线路轨迹图层
        /// </summary>
        /// <param name="lineID">线路ID</param>
        /// <param name="updown">上下行标记</param>
        private CLineLyr GenerateTrackLayer(string lineID, bool updown)
        {
            CLineLyr lyr = null;

            for (int j = 0; j < CLineList.LineInfo.Count; j++)
            {
                LineInfo li = CLineList.LineInfo[j];
                if (li.LineID.Equals(lineID))
                {
                    lyr = new CLineLyr();

                    try
                    {
                        string stag;
                        Color lineColor;
                        List<TrackPoint> lst;
                        List<StationInfo> lst2;
                        Image img;
                        OffsetType offset;

                        if (updown)
                        {
                            stag = "upline";
                            lineColor = Color.MediumSeaGreen;
                            lst = li.UpTrackPointList;
                            lst2 = li.UpStationList;
                            img = Properties.Resources.pt1;
                            offset = OffsetType.TopRight;
                        }
                        else
                        {
                            stag = "dnline";
                            lineColor = Color.SteelBlue;
                            lst = li.DownTrackPointList;
                            lst2 = li.DownStationList;
                            img = Properties.Resources.pt2;
                            offset = OffsetType.BottomLeft;
                        }

                        //轨迹
                        List<PointLatLng> routes = new List<PointLatLng>();

                        for (int i = 0; i < lst.Count; i++)
                        {
                            gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(lst[i].Lon, lst[i].Lat));
                            routes.Add(new PointLatLng(gps.Y, gps.X));
                        }

                        MapRoute route = new MapRoute(routes, stag + li.LineID);

                        GMapRoute r = new GMapRoute(route.Points, stag + li.LineID);  //将路转换成线  
                        r.Stroke = (Pen)r.Stroke.Clone();
                        r.Stroke.Width = 3;
                        r.Stroke.Color = lineColor;

                        lineOverLay.Routes.Add(r);    //将道路加入图层 
                        lyr.Route = r;  //添加到对象

                        //站点
                        MarkerTooltipMode tipMode = gmap.Zoom < 15 ? MarkerTooltipMode.OnMouseOver : MarkerTooltipMode.Always;

                        for (int i = 0; i < lst2.Count; i++)
                        {
                            gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(lst2[i].Longitude, lst2[i].Latitude));

                            GMapMarkerImage marker = new GMapMarkerImage(new PointLatLng(gps.Y, gps.X), img);
                            marker.ToolTipText = lst2[i].Name;
                            marker.ToolTipMode = tipMode;
                            marker.ToolTip = new GMapTip(marker, lineColor, Color.White, offset);

                            lineOverLay.Markers.Add(marker);
                            lyr.Stations.Add(marker);   //添加到对象
                        }

                        //添加到集合
                        if (updown)
                        {
                            upLyrs.Add(lineID, lyr);
                        }
                        else
                        {
                            dnLyrs.Add(lineID, lyr);
                        }

                        break;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("加载轨迹时发生错误", ex);
                    }
                }
            }

            return lyr;
        }

        /// <summary>
        /// 显示线路图层
        /// </summary>
        /// <param name="lineID">线路ID</param>
        /// <param name="updown">上下行标记</param>
        /// <param name="isShow">显示/隐藏</param>
        /// <param name="isShowMessageBox">是否提示</param>
        private void ShowLineLayer(string lineID, bool updown, bool isShow, bool isShowMessageBox)
        {
            CLineLyr lyr = null;

            if (updown)
            {
                if (upLyrs.ContainsKey(lineID))
                {
                    lyr = upLyrs[lineID];
                }
            }
            else
            {
                if (dnLyrs.ContainsKey(lineID))
                {
                    lyr = dnLyrs[lineID];
                }
            }

            if (lyr == null)
            {
                if (isShow)
                {
                    lyr = GenerateTrackLayer(lineID, updown);
                    lyr.IsVisible = true;
                }
            }
            else
            {
                lyr.IsVisible = isShow;
            }

            if (isShow && isShowMessageBox)
            {
                for (int j = 0; j < CLineList.LineInfo.Count; j++)
                {
                    LineInfo li = CLineList.LineInfo[j];
                    if (li.LineID.Equals(lineID))
                    {
                        List<TrackPoint> lst;
                        if (updown)
                        {
                            lst = li.UpTrackPointList;
                        }
                        else
                        {
                            lst = li.DownTrackPointList;
                        }

                        if (lst.Count == 0)
                        {
                            MessageBox.Show("无线路数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 显示车辆状态
        /// </summary>
        /// <param name="bi"></param>
        private void ShowBusStatus(BusInfo bi, bool showBus)
        {
            try
            {
                if (offlineBusMarker == null)
                {
                    Image img;
                    switch (bi.ImgType)
                    {
                        case 2:
                            img = Properties.Resources.Transport_Van2;
                            break;

                        case 3:
                            img = Properties.Resources.Transport_Van3;
                            break;

                        case 1:
                        default:
                            img = Properties.Resources.Transport_Van;
                            break;
                    }

                    offlineBusMarker = new GMapMarkerImage(new PointLatLng(0, 0), img);
                    offlineBusMarker.IsVisible = false;
                }
            }
            catch
            {
                //忽略错误
            }

            DateTime dte = DateTime.Now;
            double lon = 128;
            double lat = 0;
            double speed = 0;
            string station = "";

            string queryStr = "SELECT t.itime, t.lon, t.lat, t.speed, t.stationname FROM ( "
                            + "    SELECT a.itime, a.lon, a.lat, a.speed, nvl(b.stationname,'未获取站点信息') AS stationname FROM tb_A" + DateTime.Now.ToString("yyyyMMdd") + " a LEFT JOIN TB_STATIONS b ON b.stationid2 = a.stationid2 "
                            + "    WHERE busid2 = " + bi.BusID2 + " ORDER BY itime DESC "
                            + ") t  "
                            + "WHERE rownum = 1";
            DataTable dt = db.GetRs(queryStr);
            if (dt.Rows.Count > 0)
            {
                dte = DateTime.Parse(dt.Rows[0]["itime"].ToString());
                lon = double.Parse(dt.Rows[0]["lon"].ToString());
                lat = double.Parse(dt.Rows[0]["lat"].ToString());
                speed = double.Parse(dt.Rows[0]["speed"].ToString());
                station = dt.Rows[0]["stationname"].ToString();
            }
            else
            {
                if (showBus)
                { MessageBox.Show("车辆当天未上线。"); }
                return;
            }

            gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(lon, lat));

            if (showBus)
            {
                offlineBusMarker.Position = new PointLatLng(gps.Y, gps.X);
                offlineBusMarker.IsVisible = true;
            }

            GPoint point = gmap.FromLatLngToLocal(new PointLatLng(gps.Y, gps.X));

            ////逆地址解析（速度慢，匹配度不高）
            //GeoCoderStatusCode statusCode = GeoCoderStatusCode.Unknow;
            //Placemark? place = GMapProviders.GoogleChinaMap.GetPlacemark(new PointLatLng(gps.Y, gps.X), out statusCode);
            //if (statusCode == GeoCoderStatusCode.G_GEO_SUCCESS)
            //{
            //    station = place.Value.Address;
            //}

            tipInfo.Show("最后上线：" + dte.ToString("HH:mm:ss") + Environment.NewLine
                        + "经纬度：　" + lon.ToString() + ", " + lat.ToString() + Environment.NewLine
                        + "速度：　　" + speed.ToString() + Environment.NewLine
                        + "位置：　　" + station, gmap, (int)point.X + 10, (int)point.Y + 10);

            tmrDelay.Enabled = true;
        }

        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            tmrDelay.Enabled = false;

            tipInfo.Hide(gmap);
            try
            {
                if (offlineBusMarker != null)
                {
                    offlineBusMarker.IsVisible = false;
                }
            }
            catch
            {
                //忽略错误
            }
        }

        private void gmap_OnMapZoomChanged()
        {
            //根据比列决定Marker是否显示
            MarkerTooltipMode tipMode;

            tipMode = gmap.Zoom < 15 ? MarkerTooltipMode.OnMouseOver : MarkerTooltipMode.Always;
            foreach (GMapMarker marker in lineOverLay.Markers)
            {
                marker.ToolTipMode = tipMode;
            }

            tipMode = gmap.Zoom < 13 ? MarkerTooltipMode.OnMouseOver : MarkerTooltipMode.Always;
            foreach (GMapMarker marker in busOverLay.Markers)
            {
                marker.ToolTipMode = tipMode;
            }
        }

        /// <summary>
        /// 设置子节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;

                if (node.Nodes[i].GetValue(2).ToString() == "2")
                {
                    BusInfo bi = node.Nodes[i].Tag as BusInfo;
                    if (bi != null && !string.IsNullOrEmpty(bi.PhoneNumber))
                    {
                        if (node.Checked) //选中
                        {
                            AddBusToMap(bi);
                        }
                        else //取消选中
                        {
                            DelBusFromMap(bi);
                        }
                    }
                }

                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 设置父节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void lstTree_BeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void lstTree_AfterCheckNode(object sender, NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);

            if (e.Node.GetValue(2).ToString() == "2")
            {
                BusInfo bi = e.Node.Tag as BusInfo;
                if (bi != null && !string.IsNullOrEmpty(bi.PhoneNumber))
                {
                    if (e.Node.Checked) //选中
                    {
                        AddBusToMap(bi);
                    }
                    else //取消选中
                    {
                        DelBusFromMap(bi);
                    }
                }
            }
        }

        private void lstTree_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            CSubClass.SetNodeFocus(lstTree, e);
        }

        private void lstTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstTree.FocusedNode.GetValue(2).ToString() == "2")
            {
                BusInfo bi = lstTree.FocusedNode.Tag as BusInfo;

                if (dictMonitor.ContainsKey(bi.PhoneNumber))
                {
                    BusMonitor.MonitorPosBean b = dictMonitor[bi.PhoneNumber];
                    if (bi.Status.Equals("online"))
                    {
                        gpsPoint gps = GpsTranslate.WGS84ToGCJ02(new gpsPoint(b.Longitude, b.Latitude));
                        gmap.Position = new PointLatLng(gps.Y, gps.X);

                        ShowBusStatus(bi, false);
                    }
                    else
                    {
                        ShowBusStatus(bi, true);
                    }
                }
                else
                {
                    ShowBusStatus(bi, true);
                }
            }
        }

        private void lstTree_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    TreeListNode currentNode = lstTree.FocusedNode;

            //    if (currentNode.GetValue(2).ToString() == "2")  //车辆
            //    {
            //        BusInfo bi = currentNode.Tag as BusInfo;
            //        if (bi != null)
            //        {
            //            lstTree.ContextMenuStrip = mnuBusInfo;
            //            mnuBusInfo.Tag = bi;
            //            for (int i = 0; i < mnuBusInfo.Items.Count; i++)
            //            {
            //                mnuBusInfo.Items[i].Tag = bi;
            //            }

            //            //菜单可用性
            //            if (currentNode.RootNode.RootNode == lstTree.Nodes[0])
            //            {
            //                toolStripSpBus.Visible = false;
            //                mnuItemRemoveBus.Visible = false;
            //            }
            //            else
            //            {
            //                toolStripSpBus.Visible = true;
            //                mnuItemRemoveBus.Visible = true;
            //            }
            //        }
            //    }
            //    else if (currentNode.GetValue(2).ToString() == "1") //线路
            //    {
            //        LineInfo li = currentNode.Tag as LineInfo;
            //        if (li != null)
            //        {
            //            lstTree.ContextMenuStrip = mnuLineInfo;
            //            mnuLineInfo.Tag = li;
            //            for (int i = 0; i < mnuLineInfo.Items.Count; i++)
            //            {
            //                mnuLineInfo.Items[i].Tag = li;
            //            }

            //            //菜单可用性控制
            //            if (currentNode.RootNode == lstTree.Nodes[0])
            //            {
            //                mnuItemShowUpLine.Visible = true;
            //                mnuItemShowDownLine.Visible = true;
            //                mnuItemHideUpLine.Visible = true;
            //                mnuItemHideDownLine.Visible = true;

            //                if (upLyrs.ContainsKey(li.LineID))
            //                {
            //                    CLineLyr lyr = upLyrs[li.LineID];
            //                    mnuItemShowUpLine.Enabled = !lyr.IsVisible;
            //                    mnuItemHideUpLine.Enabled = lyr.IsVisible;
            //                }
            //                else
            //                {
            //                    mnuItemShowUpLine.Enabled = true;
            //                    mnuItemHideUpLine.Enabled = false;
            //                }

            //                if (dnLyrs.ContainsKey(li.LineID))
            //                {
            //                    CLineLyr lyr = dnLyrs[li.LineID];
            //                    mnuItemShowDownLine.Enabled = !lyr.IsVisible;
            //                    mnuItemHideDownLine.Enabled = lyr.IsVisible;
            //                }
            //                else
            //                {
            //                    mnuItemShowDownLine.Enabled = true;
            //                    mnuItemHideDownLine.Enabled = false;
            //                }
            //            }
            //            else
            //            {
            //                mnuItemShowUpLine.Visible = false;
            //                mnuItemShowDownLine.Visible = false;
            //                mnuItemHideUpLine.Visible = false;
            //                mnuItemHideDownLine.Visible = false;
            //            }
            //        }
            //    }
            //    else if (currentNode.GetValue(2).ToString() == "0") //全部
            //    {
            //        lstTree.ContextMenuStrip = mnuAll;

            //        //菜单可用性
            //        if (currentNode == lstTree.Nodes[0])
            //        {
            //            mnuItemShowAllUp.Visible = true;
            //            mnuItemShowAllDown.Visible = true;
            //            mnuItemHideAllUp.Visible = true;
            //            mnuItemHideAllDown.Visible = true;
            //        }
            //        else
            //        {
            //            mnuItemShowAllUp.Visible = false;
            //            mnuItemShowAllDown.Visible = false;
            //            mnuItemHideAllUp.Visible = false;
            //            mnuItemHideAllDown.Visible = false;
            //        }
            //    }
            //}
        }

        private void mnuItemShowUpLine_Click(object sender, EventArgs e)
        {
            LineInfo li = ((ToolStripMenuItem)sender).Tag as LineInfo;
            if (li != null)
            {
                ShowLineLayer(li.LineID, true, true, true);
            }
        }

        private void mnuItemHideUpLine_Click(object sender, EventArgs e)
        {
            LineInfo li = ((ToolStripMenuItem)sender).Tag as LineInfo;
            if (li != null)
            {
                ShowLineLayer(li.LineID, true, false, true);
            }
        }

        private void mnuItemShowDownLine_Click(object sender, EventArgs e)
        {
            LineInfo li = ((ToolStripMenuItem)sender).Tag as LineInfo;
            if (li != null)
            {
                ShowLineLayer(li.LineID, false, true, true);
            }
        }

        private void mnuItemHideDownLine_Click(object sender, EventArgs e)
        {
            LineInfo li = ((ToolStripMenuItem)sender).Tag as LineInfo;
            if (li != null)
            {
                ShowLineLayer(li.LineID, false, false, true);
            }
        }

        private void mnuItemShowAllUp_Click(object sender, EventArgs e)
        {
            foreach (var item in CLineList.LineInfo)
            {
                ShowLineLayer(item.LineID, true, true, false);
            }
        }

        private void mnuItemHideAllUp_Click(object sender, EventArgs e)
        {
            foreach (var item in CLineList.LineInfo)
            {
                ShowLineLayer(item.LineID, true, false, false);
            }
        }

        private void mnuItemShowAllDown_Click(object sender, EventArgs e)
        {
            foreach (var item in CLineList.LineInfo)
            {
                ShowLineLayer(item.LineID, false, true, false);
            }
        }

        private void mnuItemHideAllDown_Click(object sender, EventArgs e)
        {
            foreach (var item in CLineList.LineInfo)
            {
                ShowLineLayer(item.LineID, false, false, false);
            }
        }

        private void frmMonitor_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 900)
            {
                pnlCase.Width = this.ClientSize.Width;
            }
            else
            {
                pnlCase.Width = 900;
            }
            if (this.ClientSize.Height > 540)
            {
                pnlCase.Height = this.ClientSize.Height;
            }
            else
            {
                pnlCase.Height = 540;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                //判断是否线路名称
                for (int i = 0; i < CLineList.LineInfo.Count; i++)
                {
                    if (txtSearch.Text == CLineList.LineInfo[i].LineName || txtSearch.Text + "路" == CLineList.LineInfo[i].LineName)
                    {
                        string lineID = CLineList.LineInfo[i].LineID;

                        if (upLyrs.ContainsKey(lineID))
                        {
                            CLineLyr lyr = upLyrs[lineID];
                            GMapRoute r = lyr.Route;
                            gmap.ZoomAndCenterRoute(r);

                            return;
                        }
                    }
                }

                //作为地名定位
                gmap.SetPositionByKeywords(txtSearch.Text);
            }
        }

        private class RowData
        {
            public RowData(string phonenumber, string platenumber, string linename, string typename, string itime, string place, string speed)
            {
                this.PHONENUMBER = phonenumber;
                this.PLATENUMBER = platenumber;
                this.LINENAME = linename;
                this.TYPENAME = typename;
                this.ITIME = itime;
                this.PLACE = place;
                this.SPEED = speed;
            }

            public string PHONENUMBER { get; private set; }
            public string PLATENUMBER { get; private set; }
            public string LINENAME { get; private set; }
            public string TYPENAME { get; set; }
            public string ITIME { get; set; }
            public string PLACE { get; set; }
            public string SPEED { get; set; }
        }
    }

    public class CLineLyr
    {
        public CLineLyr()
        {
            route = null;
            stations = new List<GMapMarkerImage>();
        }

        private GMapRoute route;

        public GMapRoute Route
        {
            get { return route; }
            set { route = value; }
        }


        private List<GMapMarkerImage> stations;

        internal List<GMapMarkerImage> Stations
        {
            get { return stations; }
            set { stations = value; }
        }

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;

                route.IsVisible = isVisible;
                for (int i = 0; i < stations.Count; i++)
                {
                    stations[i].IsVisible = isVisible;
                }
            }
        }
    }
}