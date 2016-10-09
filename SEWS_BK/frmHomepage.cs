using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Database;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraCharts;
using Com.SubClass;

namespace SEWS_BK
{
    public partial class frmHomepage : Form
    {
        CDatabase db = Program.db;

        private DevExpress.XtraGrid.Columns.GridColumn colBusNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colSpeed;

        public frmHomepage()
        {
            InitializeComponent();

            InitGrid();
            FillData();
        }

        private void frmHomepage_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 944)
            {
                panelControl1.Width = this.ClientSize.Width;
            }
            else
            {
                panelControl1.Width = 944;
            }
            if (this.ClientSize.Height > 501)
            {
                panelControl1.Height = this.ClientSize.Height;
            }
            else
            {
                panelControl1.Height = 501;
            }
        }

        private void InitGrid()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);

            colBusNumber = CSubClass.CreateColumn("BUSNUMBER", "车辆编号", 1, 100);
            colLine = CSubClass.CreateColumn("LINENAME", "线路", 2, 100);
            colType = CSubClass.CreateColumn("TYPENAME", "报警类型", 3, 100);
            colTime = CSubClass.CreateColumn("ITIME", "报警时间", 4, 100, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.FormatType.DateTime, "yyyy-MM-dd HH:mm");
            colPlace = CSubClass.CreateColumn("PLACE", "位置", 5, 100);
            colSpeed = CSubClass.CreateColumn("SPEED", "速度", 6, 100);

            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colBusNumber, colLine, colType, colTime, colPlace, colSpeed
            });

            foreach (DevExpress.XtraGrid.Columns.GridColumn c in dgvDetail.Columns)
            {
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void FillData()
        {
            string sql;
            DataTable dt;

            //报警次数
            sql = "SELECT count(*) FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " WHERE STATUS2 = 2 AND SPEED <= 50 "
                + "UNION SELECT count(*) FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " WHERE STATUS2 = 2 AND SPEED > 50 AND SPEED < 70 "
                + "UNION SELECT count(*) FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " WHERE STATUS2 = 2 AND SPEED > 70 ";
            dt = db.GetRs(sql);

            lblCollision.Text = dt.Rows[0][0].ToString();
            lblOffset.Text = dt.Rows[1][0].ToString();
            lblOverspeed.Text = dt.Rows[2][0].ToString();

            //报警排行
            sql = "SELECT * FROM ( " + Environment.NewLine
                + "    SELECT a.LINENAME, b.NUM FROM TB_LINES a INNER JOIN ( " + Environment.NewLine
                + "        SELECT LINEID2, COUNT(*) AS NUM FROM (" + Environment.NewLine
                + "            SELECT LINEID2, WARNINGTYPE, to_char(ITIME, 'yyyy-mm-dd') " + Environment.NewLine
                + "            FROM TB_WARNING " + Environment.NewLine
                + "            GROUP BY LINEID2, WARNINGTYPE, to_char(ITIME, 'yyyy-mm-dd') " + Environment.NewLine
                + "        ) t " + Environment.NewLine
                + "        GROUP BY t.LINEID2 " + Environment.NewLine
                + "    ) b ON b.LINEID2 = a.LINEID2 " + Environment.NewLine
                + "    ORDER BY b.NUM DESC " + Environment.NewLine
                + ") WHERE ROWNUM <= 5 ";
            dt = db.GetRs(sql);

            if (dt.Rows.Count >= 1)
            {
                lbl1st.Text = string.Format("{0} ({1})", dt.Rows[0]["LINENAME"].ToString(), dt.Rows[0]["NUM"].ToString());
                pgb1st.EditValue = int.Parse(dt.Rows[0]["NUM"].ToString());
            }
            if (dt.Rows.Count >= 2)
            {
                lbl2nd.Text = string.Format("{0} ({1})", dt.Rows[1]["LINENAME"].ToString(), dt.Rows[1]["NUM"].ToString());
                pgb2nd.EditValue = int.Parse(dt.Rows[1]["NUM"].ToString());
            }
            if (dt.Rows.Count >= 3)
            {
                lbl3rd.Text = string.Format("{0} ({1})", dt.Rows[2]["LINENAME"].ToString(), dt.Rows[2]["NUM"].ToString());
                pgb3rd.EditValue = int.Parse(dt.Rows[2]["NUM"].ToString());
            }
            if (dt.Rows.Count >= 4)
            {
                lbl4th.Text = string.Format("{0} ({1})", dt.Rows[3]["LINENAME"].ToString(), dt.Rows[3]["NUM"].ToString());
                pgb4th.EditValue = int.Parse(dt.Rows[3]["NUM"].ToString());
            }
            if (dt.Rows.Count >= 5)
            {
                lbl5th.Text = string.Format("{0} ({1})", dt.Rows[4]["LINENAME"].ToString(), dt.Rows[4]["NUM"].ToString());
                pgb5th.EditValue = int.Parse(dt.Rows[4]["NUM"].ToString());
            }

            //上线率
            sql = "SELECT count(a.busid2),count(b.busid2) FROM TB_BUSES a LEFT JOIN ( " + Environment.NewLine
                + "    SELECT busid2 FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " GROUP BY busid2 " + Environment.NewLine
                + ") b ON b.busid2 = a.busid2 ";
            dt = db.GetRs(sql);

            chartView.Series[0].Points.Clear();

            //chartView.Series[0].Points[0].Values = new double[] { double.Parse(dt.Rows[0][0].ToString()), double.Parse(dt.Rows[0][1].ToString()) };
            double rate = double.Parse(dt.Rows[0][1].ToString()) / double.Parse(dt.Rows[0][0].ToString());

            //chartView.Series[0].Points[0].Values = new double[] { (1 - rate) * 100, rate * 100 };

            SeriesPoint point = new SeriesPoint("上线车数");
            double[] vals = { Convert.ToDouble(dt.Rows[0][1].ToString()) };
            point.Values = vals;

            chartView.Series[0].Points.Add(point);

            SeriesPoint point2 = new SeriesPoint("离线车数");
            double[] vals2 = { Convert.ToDouble(dt.Rows[0][0].ToString()) - Convert.ToDouble(dt.Rows[0][1].ToString()) };
            point.Values = vals2;

            chartView.Series[0].Points.Add(point);

            lblBusNum.Text = dt.Rows[0][0].ToString();
            lblOnlineRate.Text = rate.ToString(("P"));

            //风险指数
            chartView2.Series[0].Points.Clear();

            double[] v1 = { 0.4, 0.8, 1.2, 0.6, 1.0, 1.6, 1.2 };
            double[] v2 = { 0.5, 0.6, 0.75, 1.0, 0.75, 0.9, 0.75 };

            for (int i = 0; i < 6; i++)
            {
                SeriesPoint pt = new SeriesPoint((i + 1).ToString());
                double[] vs = { v1[i] };
                pt.Values = vs;

                chartView2.Series[0].Points.Add(pt);

                SeriesPoint pt2 = new SeriesPoint((i + 1).ToString());
                double[] vs2 = { v2[i] };
                pt2.Values = vs2;

                chartView2.Series[1].Points.Add(pt2);
            }

            AxisRange DIA = (AxisRange)((XYDiagram)chartView2.Diagram).AxisY.Range;
            DIA.SetMinMaxValues(0, 2);

            //报警记录
            sql = "SELECT * FROM ( " + Environment.NewLine
                + "    SELECT b.BUSNUMBER, c.LINENAME, '超速' AS TYPENAME, a.ITIME--, e.STATIONNAME, d.SPEED " + Environment.NewLine
                + "    FROM ( " + Environment.NewLine
                + "        SELECT BUSID2, LINEID2, Max(ITIME) AS ITIME FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " WHERE STATUS2 = 2 GROUP BY BUSID2, LINEID2 " + Environment.NewLine
                + "    ) a " + Environment.NewLine
                + "    --INNER JOIN TB_A" + DateTime.Now.ToString("yyyyMMdd") + " d ON d.BUSID2 = a.BUSID2 AND d.LINEID2 = a.LINEID2 AND d.ITIME = a.ITIME " + Environment.NewLine
                + "    INNER JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                + "    INNER JOIN TB_LINES c ON c.LINEID2 = a.LINEID2 " + Environment.NewLine
                + "    --LEFT JOIN TB_STATIONS e ON e.STATIONID2 = d.STATIONID2 " + Environment.NewLine
                + "    ORDER BY a.ITIME DESC " + Environment.NewLine
                + ") WHERE ROWNUM <= 10 ";
            dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridList.DataSource = dt;
                gridList.RefreshDataSource();
            }
            else
            {
                CSubClass.ClearRows(dgvDetail);
            }
        }

        private void frmHomepage_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:           //用户通过UI关闭窗体
                    e.Cancel = true;
                    break;

                case CloseReason.ApplicationExitCall:  //应用程序exit退出
                case CloseReason.FormOwnerClosing:      //窗体的所有者退出，导致子窗体关闭
                case CloseReason.MdiFormClosing:        //Mdi父窗体关闭，导致子窗体关闭
                case CloseReason.TaskManagerClosing:    //任务管理器关闭窗体
                case CloseReason.WindowsShutDown:       //关机导致应用程序关闭
                case CloseReason.None:                  //未知原因导致窗体窗体
                default:                                //未知原因导致窗体窗体
                    break;
            }
        }
    }
}
