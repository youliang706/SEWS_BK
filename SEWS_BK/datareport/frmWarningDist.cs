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
            string sql = "SELECT LINEID2, LINENAME "
                        + "FROM TB_LINES "
                        + "ORDER BY LINENAME ";
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

            string sql = "SELECT p.WARNINGNAME, NVL(a.NUM,0) AS NUM "
                        + "FROM TB_WARNINGTYPE p "
                        + "LEFT JOIN ( "
                        + "    SELECT a.WARNINGTYPE, COUNT(*) AS NUM "
                        + "    FROM TB_WARNING a LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 "
                        + "    " + conStr
                        + "    GROUP BY a.WARNINGTYPE "
                        + ") a ON a.WARNINGTYPE = p.WARNINGID2 ";
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
    }
}
