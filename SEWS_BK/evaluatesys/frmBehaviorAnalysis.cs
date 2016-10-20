using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Database;
using DevExpress.XtraCharts;

namespace SEWS_BK.evaluatesys
{
    public partial class frmBehaviorAnalysis : Form
    {
        private CDatabase db = Program.db;

        private int busID2;
        private DateTime begDate;
        private DateTime endDate;

        public frmBehaviorAnalysis(int busid2, DateTime begdate, DateTime enddate)
        {
            InitializeComponent();

            busID2 = busid2;
            begDate = begdate;
            endDate = enddate;

            FillData();
        }

        private void FillData()
        {
            chartView.Series[0].Points.Clear();
            chartView.Series[1].Points.Clear();

            string sql = "SELECT b.PLATENUMBER, c.DRVNAME FROM VW_BUS_DRV a INNER JOIN tb_buses b ON b.BUSID2 = a.busid2 "
                        + "INNER JOIN tb_drivers c ON c.DRVNUMBER = a.drvnumber "
                        + "WHERE a.BUSID2 = " + busID2.ToString() + " ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                //lblBus.Text = dt.Rows[0]["PLATENUMBER"].ToString();
                //lblDrv.Text = dt.Rows[0]["DRVNAME"].ToString();
                //lblDte.Text = begDate.ToString("yyyy-MM-dd") + "至" + endDate.ToString("yyyy-MM-dd");

                chartView.Titles[0].Text = dt.Rows[0]["DRVNAME"].ToString() + " 各指标评分";
            }

            //用id各位的合计值作为计数值
            int k = 0;
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < busID2.ToString().Length; i++)
            {
                k += int.Parse(busID2.ToString().Substring(i, 1));
                if (!d.ContainsKey(int.Parse(busID2.ToString().Substring(i, 1))))
                {
                    d.Add(int.Parse(busID2.ToString().Substring(i, 1)), i);
                }
            }

            string[] name = new string[] { "工作年限", "驾驶时间", "报警次数", "异常驾驶", "危险行为" };
            double[] value = new double[] { 6, 7.5, 6.5, 7, 7 };

            for (int i = 0; i < 5; i++)
            {
                SeriesPoint point = new SeriesPoint(name[i]);
                double[] vals = { value[i] };
                point.Values = vals;

                chartView.Series[0].Points.Add(point);
            }


            for (int i = 0; i < 5; i++)
            {
                SeriesPoint point = new SeriesPoint(name[i]);
                if (d.ContainsKey(i))
                {
                    double[] vals = { value[i] * (1 - (double)k / 100) };
                    point.Values = vals;
                }
                else
                {
                    double[] vals = { value[i] * (1 + (double)k / 100) };
                    point.Values = vals;
                }
                
                chartView.Series[1].Points.Add(point);
            }
        }
    }
}
