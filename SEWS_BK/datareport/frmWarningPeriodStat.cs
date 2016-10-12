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
    public partial class frmWarningPeriodStat : Form
    {
        CDatabase db = Program.db;

        public frmWarningPeriodStat()
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

            string sql = "SELECT e.HOUR, e.TIME, p.WARNINGID2, NVL(a.NUM,0) AS NUM " + Environment.NewLine
                        + "FROM VW_HOUR e " + Environment.NewLine
                        + "CROSS JOIN ( " + Environment.NewLine
                        + "    SELECT WARNINGID2 FROM TB_WARNINGTYPE " + Environment.NewLine
                        + "    UNION ALL SELECT 0 FROM DUAL " + Environment.NewLine
                        + ") p LEFT JOIN ( " + Environment.NewLine
                        + "    SELECT to_char(a.ITIME,'hh24') AS HOUR, a.WARNINGTYPE, COUNT(*) AS NUM " + Environment.NewLine
                        + "    FROM TB_WARNING a " + Environment.NewLine
                        + "    WHERE to_char(a.ITIME, 'yyyy-MM-dd hh24:mi:ss') >= '" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd 00:00:00") + "' " + Environment.NewLine
                        + "    AND to_char(a.ITIME, 'yyyy-MM-dd hh24:mi:ss') <= '" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd 23:59:59") + "' " + Environment.NewLine
                        + "    " + conStr + Environment.NewLine
                        + "    GROUP BY to_char(a.ITIME,'hh24'), a.WARNINGTYPE " + Environment.NewLine
                        + "    UNION ALL " + Environment.NewLine
                        + "    SELECT to_char(a.ITIME,'hh24') AS HOUR, 0, COUNT(*) AS NUM " + Environment.NewLine
                        + "    FROM TB_WARNING a " + Environment.NewLine
                        + "    WHERE to_char(a.ITIME, 'yyyy-MM-dd hh24:mi:ss') >= '" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd 00:00:00") + "' " + Environment.NewLine
                        + "    AND to_char(a.ITIME, 'yyyy-MM-dd hh24:mi:ss') <= '" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd 23:59:59") + "' " + Environment.NewLine
                        + "    " + conStr + Environment.NewLine
                        + "    GROUP BY to_char(a.ITIME,'hh24') " + Environment.NewLine
                        + ") a ON a.HOUR = e.HOUR AND a.WARNINGTYPE = p.WARNINGID2 ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < chartView.Series.Count; i++)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "WARNINGID2 = '" + chartView.Series[i].Tag.ToString() + "'";
                    dv.Sort = "HOUR";

                    if (dv.Count > 0)
                    {
                        for (int j = 0; j < dv.Count; j++)
                        {
                            //加上char(0)是为了将日期作为字符串赋给x轴显示
                            SeriesPoint point = new SeriesPoint(dv[j]["TIME"].ToString());
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
                chartView.Series.Add(dt.Rows[i]["WARNINGNAME"].ToString(), ViewType.Bar);
                chartView.Series[i].Tag = dt.Rows[i]["WARNINGID2"].ToString();

                BarSeriesView vw = (BarSeriesView)chartView.Series[i].View;
                vw.Transparency = ((byte)(135));
            }

            int idx = chartView.Series.Add("总报警", ViewType.Bar);
            chartView.Series[idx].Tag = "0";
            
            BarSeriesView vw2 = (BarSeriesView)chartView.Series[idx].View;
            vw2.Transparency = ((byte)(135));
            vw2.Color = Color.Gray;
            vw2.Pane = ((XYDiagram)chartView.Diagram).Panes[0];

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
            diagram.AxisX.VisibleInPanesSerializable = "0";

            diagram.AxisY.VisualRange.Auto = true;
            diagram.AxisY.VisualRange.AutoSideMargins = true;
            diagram.AxisY.WholeRange.AutoSideMargins = true;
            diagram.AxisY.VisibleInPanesSerializable = "-1;0";

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
                if ((points.Count + 1) * 100 <= chartView.ClientSize.Width)
                {
                    return;
                }

                int num = chartView.ClientSize.Width / 100 - 1;

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
