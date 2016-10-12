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
    public partial class frmWarningTrend : Form
    {
        CDatabase db = Program.db;

        public frmWarningTrend()
        {
            InitializeComponent();

            CSubClass.SetXtraDtpStyle(dtpBeg, DtType.LongDate);
            CSubClass.SetXtraDtpStyle(dtpEnd, DtType.LongDate);
            chartView.Series.Clear();

            InitCbo();
            dtpBeg.EditValue = DateTime.Now.Date;
            dtpEnd.EditValue = DateTime.Now;
        }

        private void frmPeccancyTrend_SizeChanged(object sender, EventArgs e)
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
            SetChartStyle();

            for (int i = 0; i < chartView.Series.Count; i++)
            {
                chartView.Series[i].Points.Clear();
            }

            string conStr = "";

            if (cboLine.SelectedItem != null)
            {
                string lineid = ((ExComboBox)cboLine.SelectedItem).Key;
                conStr = "AND a.LINEID2 = " + lineid + " ";
            }

            string sql = "SELECT e.DTE, p.WARNINGID2, NVL(a.NUM,0) AS NUM "
                        + "FROM TABLE(FN_GETDTE(to_date('" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd") + "','yyyy-mm-dd'),to_date('" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd") + "','yyyy-mm-dd'))) e "
                        + "CROSS JOIN TB_WARNINGTYPE p "
                        + "LEFT JOIN ( "
                        + "    SELECT to_char(a.ITIME,'yyyy-mm-dd') AS DTE, a.WARNINGTYPE, COUNT(*) AS NUM "
                        + "    FROM TB_WARNING a LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 "
                        + "    WHERE to_char(a.ITIME, 'yyyy-MM-dd hh24:mi:ss') >= '" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd 00:00:00") + "' "
                        + "    AND to_char(a.ITIME, 'yyyy-MM-dd hh24:mi:ss') <= '" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd 23:59:59") + "' "
                        + "    " + conStr
                        + "    GROUP BY to_char(a.ITIME,'yyyy-mm-dd'), a.WARNINGTYPE "
                        + ") a ON a.DTE = to_char(e.DTE,'yyyy-mm-dd') AND a.WARNINGTYPE = p.WARNINGID2 ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < chartView.Series.Count; i++)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "WARNINGID2 = '" + chartView.Series[i].Tag.ToString() + "'";
                    dv.Sort = "DTE";

                    if (dv.Count > 0)
                    {
                        for (int j = 0; j < dv.Count; j++)
                        {
                            //加上char(0)是为了将日期作为字符串赋给x轴显示
                            SeriesPoint point = new SeriesPoint((char)0 + ((DateTime)dv[j]["DTE"]).ToString("MM/dd"));
                            double[] vals = { Convert.ToDouble(dv[j]["NUM"]) };
                            point.Values = vals;

                            chartView.Series[i].Points.Add(point);
                        }
                    }
                }

                ChangeValueInternal();
            }
        }

        private void Preview()
        {
            this.chartView.ShowPrintPreview();
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void SetChartStyle()
        {
            if (chartView.Series.Count > 0)
            { return; }

            string sql = "SELECT WARNINGID2, WARNINGNAME FROM TB_WARNINGTYPE";
            DataTable dt = db.GetRs(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chartView.Series.Add(dt.Rows[i]["WARNINGNAME"].ToString(), ViewType.Spline);
                chartView.Series[i].Tag = dt.Rows[i]["WARNINGID2"].ToString();
            }

            //设置显示
            for (int i = 0; i < chartView.Series.Count; i++)
            {
                chartView.Series[i].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            }

            XYDiagram diagram = chartView.Diagram as XYDiagram;

            diagram.AxisX.VisualRange.Auto = false; //要开启滚动条必须将其设置为false
            diagram.AxisX.WholeRange.Auto = false;
            diagram.AxisX.WholeRange.AutoSideMargins = true;
            diagram.AxisX.VisualRange.AutoSideMargins = false;
            diagram.AxisX.VisibleInPanesSerializable = "-1";

            diagram.AxisY.VisualRange.Auto = true;
            diagram.AxisY.VisualRange.AutoSideMargins = true;
            diagram.AxisY.WholeRange.AutoSideMargins = true;
            diagram.AxisY.VisibleInPanesSerializable = "-1";

            diagram.EnableAxisXScrolling = true;//启用滚动条

            diagram.AxisX.Label.Angle = -30;
            diagram.AxisX.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
        }

        private void ChangeValueInternal()
        {
            if (chartView.Series.Count == 0)
            { return; }

            XYDiagram diagram = chartView.Diagram as XYDiagram;
            SeriesPointCollection points = chartView.Series[0].Points;

            if (points.Count > 0)
            {
                if ((points.Count + 1) * 40 <= chartView.ClientSize.Width)
                {
                    return;
                }

                int num = chartView.ClientSize.Width / 40 - 1;

                diagram.AxisX.VisualRange.SetMinMaxValues(points[0].Argument, (points.Count > num ? points[num - 1].Argument : points[points.Count - 1].Argument));
                diagram.AxisX.WholeRange.SetMinMaxValues(points[0].Argument, points[points.Count - 1].Argument);
            }
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
            ChangeValueInternal();
        }

        private void mnuChart_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == mnuLine.Name)
            {
                for (int i = 0; i < chartView.Series.Count; i++)
                {
                    chartView.Series[i].ChangeView(ViewType.Spline);
                }
            }
            else if (e.ClickedItem.Name == mnuBar.Name)
            {
                for (int i = 0; i < chartView.Series.Count; i++)
                {
                    chartView.Series[i].ChangeView(ViewType.Bar);
                    BarSeriesView vw = (BarSeriesView)chartView.Series[i].View;
                    vw.Transparency = ((byte)(135));
                }
            }
            else if (e.ClickedItem.Name == mnuArea.Name)
            {
                for (int i = 0; i < chartView.Series.Count; i++)
                {
                    chartView.Series[i].ChangeView(ViewType.Area);
                    AreaSeriesView vw = (AreaSeriesView)chartView.Series[i].View;
                    vw.Transparency = ((byte)(135));
                }
            }
        }

        private void frmPeccancyTrend_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }
    }
}
