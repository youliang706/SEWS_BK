using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.Database;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraCharts;
using Com.SubClass;
using SEWS_BK.generic;

namespace SEWS_BK.datareport
{
    public partial class frmWarningDist : Form
    {
        CDatabase db = Program.db;

        public frmWarningDist()
        {
            InitializeComponent();

            CSubClass.SetXtraDtpStyle(dtpBeg, DtType.LongDate);
            CSubClass.SetXtraDtpStyle(dtpEnd, DtType.LongDate);
            chartView2.Series.Clear();

            InitCbo();
            dtpBeg.EditValue = DateTime.Now.Date;
            dtpEnd.EditValue = DateTime.Now;
        }

        private void frmValidStat_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 800)
            {
                panelControl1.Width = this.ClientSize.Width;
            }
            else
            {
                panelControl1.Width = 800;
            }
            if (this.ClientSize.Height > 400)
            {
                panelControl1.Height = this.ClientSize.Height;
            }
            else
            {
                panelControl1.Height = 400;
            }
        }

        private void InitCbo()
        {
            string sql = "SELECT LINEID2, ALIAS AS LINENAME "
                        + "FROM TB_TMPLINES "
                        + "ORDER BY LINEID2 ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                ComboBoxItemCollection coll = cboLine.Properties.Items;
                coll.BeginUpdate();
                coll.Clear();
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        coll.Add(new ExComboBox(i, dt.Rows[i]["LINEID2"].ToString(), dt.Rows[i]["LINENAME"].ToString()));
                    }
                }
                finally
                {
                    coll.EndUpdate();
                }
                cboLine.SelectedIndex = -1;
            }
        }

        private void FillData()
        {
            chartView.Series[0].Points.Clear();

            SetChartStyle();
            for (int i = 0; i < chartView2.Series.Count; i++)
            {
                chartView2.Series[i].Points.Clear();
            }

            List<string> sqlCon = new List<string>();
            string conStr = "";

            if (cboLine.SelectedItem != null)
            {
                string lineid = ((ExComboBox)cboLine.SelectedItem).Key;
                sqlCon.Add("a.LINEID2 = " + lineid + " ");
            }
            if (dtpBeg.EditValue != null)
            {
                sqlCon.Add("a.ITIME >= to_date('" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (dtpEnd.EditValue != null)
            {
                sqlCon.Add("a.ITIME <= to_date('" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (sqlCon.Count > 0)
            {
                conStr = "WHERE (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT p.WARNINGID2, p.WARNINGNAME, NVL(a.NUM,0) AS NUM " + Environment.NewLine
                        + "FROM TB_WARNINGTYPE p " + Environment.NewLine
                        + "LEFT JOIN ( " + Environment.NewLine
                        + "    SELECT a.WARNINGTYPE, COUNT(*) AS NUM " + Environment.NewLine
                        + "    FROM TB_WARNING a LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                        + "    " + conStr + Environment.NewLine
                        + "    GROUP BY a.WARNINGTYPE " + Environment.NewLine
                        + ") a ON a.WARNINGTYPE = p.WARNINGID2 "
                        + "ORDER BY p.WARNINGID2";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SeriesPoint point = new SeriesPoint(dt.Rows[i]["WARNINGNAME"].ToString());
                    double[] vals = { Convert.ToDouble(dt.Rows[i]["NUM"]) };
                    point.Values = vals;

                    chartView.Series[0].Points.Add(point);
                }

                for (int i = 0; i < chartView2.Series.Count; i++)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "WARNINGID2 = " + chartView2.Series[i].Tag.ToString() + "";

                    if (dv.Count > 0)
                    {
                        SeriesPoint point = new SeriesPoint("次数");
                        double[] vals = { Convert.ToDouble(dv[0]["NUM"]) };
                        point.Values = vals;

                        chartView2.Series[i].Points.Add(point);
                    }
                }
            }
        }

        private void SetChartStyle()
        {
            if (chartView2.Series.Count > 0)
            { return; }

            string sql = "SELECT WARNINGID2, WARNINGNAME FROM TB_WARNINGTYPE ORDER BY WARNINGID2";
            DataTable dt = db.GetRs(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartView2.Series.Add(dt.Rows[i]["WARNINGNAME"].ToString(), ViewType.Bar);
                chartView2.Series[i].Tag = dt.Rows[i]["WARNINGID2"].ToString();

                BarSeriesView vw = (BarSeriesView)chartView2.Series[i].View;
                vw.Transparency = ((byte)(135));
            }

            //设置显示
            for (int i = 0; i < chartView2.Series.Count; i++)
            {
                chartView2.Series[i].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            }

            //XYDiagram diagram = chartView2.Diagram as XYDiagram;

            //diagram.AxisX.VisualRange.Auto = false; //要开启滚动条必须将其设置为false
            //diagram.AxisX.WholeRange.Auto = false;
            //diagram.AxisX.WholeRange.AutoSideMargins = true;
            //diagram.AxisX.VisualRange.AutoSideMargins = false;
            //diagram.AxisX.VisibleInPanesSerializable = "-1";

            //diagram.AxisY.VisualRange.Auto = true;
            //diagram.AxisY.VisualRange.AutoSideMargins = true;
            //diagram.AxisY.WholeRange.AutoSideMargins = true;
            //diagram.AxisY.VisibleInPanesSerializable = "-1";

            //diagram.EnableAxisXScrolling = true;//启用滚动条

            //diagram.AxisX.Label.Angle = -30;
            //diagram.AxisX.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Preview()
        {
            this.chartView.ShowPrintPreview();
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void chartView_SizeChanged(object sender, EventArgs e)
        {
            //ChangeValueInternal();
        }

        private void frmValidStat_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                            this.panel1.ClientRectangle,
                            Color.FromArgb(157,160,170),
                            ButtonBorderStyle.Solid);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            chartView.Width = panel1.ClientSize.Width / 3;
        }
    }
}
