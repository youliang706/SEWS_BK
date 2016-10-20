using Com.Database;
using Com.SubClass;
using DevExpress.XtraCharts;
using SEWS_BK.generic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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

            UpdateWarning();

            InitGrid();
            FillData();

            tmrRefresh.Interval = 120 * 1000;    //2分钟刷一次
            tmrRefresh.Start();
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

            gridList.Height = panelControl1.ClientSize.Height / 3;
            gridList.Top = panelControl5.Top + panelControl5.Height - gridList.Height;
            pnlRB.Top = gridList.Top - pnlRB.Height - 4;
            panelControl4.Height = pnlRB.Top - panelControl4.Top - 8;

            chartView.Width = (panelControl4.ClientSize.Width - 30) / 2;
            chartView2.Left = chartView.Left + chartView.Width + 10;
            chartView2.Width = chartView.Width;
        }

        private void InitGrid()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);

            colBusNumber = CSubClass.CreateColumn("PLATENUMBER", "车牌号", 1, 100);
            colLine = CSubClass.CreateColumn("LINENAME", "车队", 2, 100);
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

        private void ClearData()
        {
            lbl1st.Text = "N/A";
            pgb1st.EditValue = 0;
            lbl2nd.Text = "N/A";
            pgb2nd.EditValue = 0;
            lbl3rd.Text = "N/A";
            pgb3rd.EditValue = 0;
            lbl4th.Text = "N/A";
            pgb4th.EditValue = 0;
            lbl5th.Text = "N/A";
            pgb5th.EditValue = 0;

            chartView.Series[0].Points.Clear();
            chartView.Series[1].Points.Clear();

            chartView2.Series[0].Points.Clear();

            CSubClass.ClearRows(dgvDetail);
        }

        private void FillData()
        {
            ClearData();

            string sql;
            DataTable dt;

            //报警次数
            sql = "SELECT NVL(SUM(CASE a.WARNINGTYPE WHEN 1 THEN 1 ELSE 0 END),0) AS PCW, " + Environment.NewLine
                + "    NVL(SUM(CASE a.WARNINGTYPE WHEN 2 THEN 1 ELSE 0 END),0) AS FCW, " + Environment.NewLine
                + "    NVL(SUM(CASE a.WARNINGTYPE WHEN 3 THEN 1 ELSE 0 END),0) AS UFCW, " + Environment.NewLine
                + "    NVL(SUM(CASE a.WARNINGTYPE WHEN 4 THEN 1 ELSE 0 END),0) AS LDW, " + Environment.NewLine
                + "    NVL(SUM(CASE a.WARNINGTYPE WHEN 5 THEN 1 ELSE 0 END),0) AS HMW, " + Environment.NewLine
                + "    NVL(SUM(CASE a.WARNINGTYPE WHEN 6 THEN 1 ELSE 0 END),0) AS TSR " + Environment.NewLine
                + "FROM TB_WARNING a INNER JOIN TB_TMPLINES b ON b.LINEID2 = a.LINEID2 " + Environment.NewLine 
                + "WHERE TRUNC(ITIME) = TRUNC(SYSDATE) ";
            dt = db.GetRs(sql);

            lblPCW.Text = dt.Rows[0][0].ToString();
            lblFCW.Text = dt.Rows[0][1].ToString();
            lblUFCW.Text = dt.Rows[0][2].ToString();
            lblLDW.Text = dt.Rows[0][3].ToString();
            lblHMW.Text = dt.Rows[0][4].ToString();
            lblTSR.Text = dt.Rows[0][5].ToString();
            lblFDW.Text = "0";

            //报警排行
            sql = "SELECT * FROM ( " + Environment.NewLine
                + "    SELECT d.ALIAS AS LINENAME, NVL(b.NUM,0) AS NUM FROM TB_LINES a LEFT JOIN ( " + Environment.NewLine
                + "        SELECT LINEID2, COUNT(*) AS NUM FROM TB_WARNING " + Environment.NewLine 
                + "        WHERE TRUNC(ITIME) = TRUNC(SYSDATE) " + Environment.NewLine
                + "        GROUP BY LINEID2 " + Environment.NewLine
                + "    ) b ON b.LINEID2 = a.LINEID2 " + Environment.NewLine
                + "    INNER JOIN TB_TMPLINES d ON d.LINEID2 = a.LINEID2 " + Environment.NewLine
                + "    ORDER BY NVL(b.NUM,0) DESC " + Environment.NewLine
                + ") WHERE ROWNUM <= 5 ";
            dt = db.GetRs(sql);

            int totalNum = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalNum += int.Parse(dt.Rows[i]["NUM"].ToString());
            }
            if (totalNum == 0)
            {
                totalNum = 1;
            }

            if (dt.Rows.Count >= 1)
            {
                lbl1st.Text = string.Format("{0} ({1})", dt.Rows[0]["LINENAME"].ToString(), dt.Rows[0]["NUM"].ToString());
                pgb1st.EditValue = double.Parse(dt.Rows[0]["NUM"].ToString()) / totalNum * 100;
            }
            if (dt.Rows.Count >= 2)
            {
                lbl2nd.Text = string.Format("{0} ({1})", dt.Rows[1]["LINENAME"].ToString(), dt.Rows[1]["NUM"].ToString());
                pgb2nd.EditValue = double.Parse(dt.Rows[1]["NUM"].ToString()) / totalNum * 100;
            }
            if (dt.Rows.Count >= 3)
            {
                lbl3rd.Text = string.Format("{0} ({1})", dt.Rows[2]["LINENAME"].ToString(), dt.Rows[2]["NUM"].ToString());
                pgb3rd.EditValue = double.Parse(dt.Rows[2]["NUM"].ToString()) / totalNum * 100;
            }
            if (dt.Rows.Count >= 4)
            {
                lbl4th.Text = string.Format("{0} ({1})", dt.Rows[3]["LINENAME"].ToString(), dt.Rows[3]["NUM"].ToString());
                pgb4th.EditValue = double.Parse(dt.Rows[3]["NUM"].ToString()) / totalNum * 100;
            }
            if (dt.Rows.Count >= 5)
            {
                lbl5th.Text = string.Format("{0} ({1})", dt.Rows[4]["LINENAME"].ToString(), dt.Rows[4]["NUM"].ToString());
                pgb5th.EditValue = double.Parse(dt.Rows[4]["NUM"].ToString()) / totalNum * 100;
            }

            //上线率
            sql = "SELECT count(a.busid2),count(b.busid2),count(c.busid2) FROM TB_BUSES a " + Environment.NewLine
                + "LEFT JOIN ( " + Environment.NewLine
                + "    SELECT busid2 FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " GROUP BY busid2 " + Environment.NewLine
                + ") b ON b.busid2 = a.busid2 " + Environment.NewLine
                + "LEFT JOIN ( " + Environment.NewLine
                + "    SELECT busid2,max(itime) FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " GROUP BY busid2 HAVING(to_date(to_char(sysdate, 'hh24mi'), 'hh24mi') - to_date(to_char(max(itime), 'hh24mi'), 'hh24mi')) * 1440 < 2  " + Environment.NewLine
                + ") c ON c.busid2 = a.busid2 " + Environment.NewLine
                + "WHERE a.BUSID IN (SELECT BUSID FROM TB_LINE_BUSES a INNER JOIN TB_USER_LINES b ON b.LINEID = a.LINEID WHERE b.USERCODE = '" + CVar.LoginID + "')";
            dt = db.GetRs(sql);

            double rate = double.Parse(dt.Rows[0][2].ToString()) / double.Parse(dt.Rows[0][0].ToString());

            SeriesPoint point2 = new SeriesPoint("未上线");
            double[] vals2 = { Convert.ToDouble(dt.Rows[0][0].ToString()) - Convert.ToDouble(dt.Rows[0][1].ToString()) };
            point2.Values = vals2;
            point2.Color = Color.MediumPurple;

            SeriesPoint point = new SeriesPoint("上线");
            double[] vals = { Convert.ToDouble(dt.Rows[0][1].ToString()) };
            point.Values = vals;

            chartView.Series[0].Points.Add(point2);
            chartView.Series[0].Points.Add(point);

            SeriesPoint point4 = new SeriesPoint("离线");
            double[] vals4 = { Convert.ToDouble(dt.Rows[0][0].ToString()) - Convert.ToDouble(dt.Rows[0][2].ToString()) };
            point4.Values = vals4;

            SeriesPoint point3 = new SeriesPoint("在线");
            double[] vals3 = { Convert.ToDouble(dt.Rows[0][2].ToString()) };
            point3.Values = vals3;

            chartView.Series[1].Points.Add(point4);
            chartView.Series[1].Points.Add(point3);

            chartView.Titles[0].Text = "总车数：" + dt.Rows[0][0].ToString() + "  在线率：" + rate.ToString(("P"));

            //风险指数
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

            AxisRange DIA = ((XYDiagram)chartView2.Diagram).AxisY.Range;
            DIA.SetMinMaxValues(0, 2);

            //报警记录
            sql = "SELECT * FROM ( " + Environment.NewLine
                + "    SELECT b.PLATENUMBER, d.ALIAS AS LINENAME, f.WARNINGNAME AS TYPENAME, a.ITIME, e.STATIONNAME, ROUND(a.SPEED,2) AS SPEED " + Environment.NewLine
                + "    FROM TB_WARNING a " + Environment.NewLine
                + "    INNER JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                + "    INNER JOIN TB_LINES c ON c.LINEID2 = a.LINEID2 " + Environment.NewLine
                + "    INNER JOIN TB_TMPLINES d ON d.LINEID2 = c.LINEID2 " + Environment.NewLine
                + "    LEFT JOIN TB_STATIONS e ON e.STATIONID2 = a.STATIONID2 " + Environment.NewLine
                + "    LEFT JOIN TB_WARNINGTYPE f ON f.WARNINGID2 = a.WARNINGTYPE " + Environment.NewLine
                + "    WHERE TRUNC(a.ITIME) = TRUNC(SYSDATE) "
                + "    ORDER BY a.ITIME DESC " + Environment.NewLine
                + ") WHERE ROWNUM <= 10 ";
            dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridList.DataSource = dt;
                gridList.RefreshDataSource();
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

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            UpdateWarning();
            FillData();
        }

        public void UpdateWarning()
        {
            string sql = "INSERT INTO TB_WARNING (sysid, lineid2, busid2, itime, direct, lon, lat, course, speed, stationid2, warningtype) " + Environment.NewLine
                        + "SELECT FN_GET_UUID, lineid2, busid2, itime, direct, lon, lat, course, speed, stationid2, " + Environment.NewLine
                        + "    CASE WHEN SPEED <= 50 THEN 1 ELSE " + Environment.NewLine
                        + "        CASE WHEN speed > 50 AND speed <= 55 THEN 2 ELSE " + Environment.NewLine
                        + "            CASE WHEN speed > 55 AND speed <= 60 THEN 3 ELSE " + Environment.NewLine
                        + "                CASE WHEN speed > 60 AND speed <= 65 THEN 4 ELSE " + Environment.NewLine
                        + "                    CASE WHEN speed > 65 AND speed <= 70 THEN 5 ELSE " + Environment.NewLine
                        + "                        6 " + Environment.NewLine
                        + "                    END " + Environment.NewLine
                        + "                END " + Environment.NewLine
                        + "            END " + Environment.NewLine
                        + "        END " + Environment.NewLine
                        + "    END " + Environment.NewLine
                        + "FROM TB_A" + DateTime.Now.ToString("yyyyMMdd") + " WHERE STATUS2 = 2 AND ITIME > (SELECT MAX(ITIME) FROM TB_WARNING) ";
            db.Execute(sql);
        }
    }
}
