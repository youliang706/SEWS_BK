using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Database;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Com.SubClass;
using SEWS_BK.generic;

namespace SEWS_BK.datareport
{
    public partial class frmWarningDetail : Form
    {
        private DevExpress.XtraGrid.Columns.GridColumn colBusNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colSpeed;

        private CDatabase db = Program.db;

        public frmWarningDetail()
        {
            InitializeComponent();

            InitCbo();
            InitGrid();

            CSubClass.SetXtraDtpStyle(dtpBeg, DtType.LongDate);
            CSubClass.SetXtraDtpStyle(dtpEnd, DtType.LongDate);

            //dtpBeg.EditValue = DateTime.Now;
            //dtpEnd.EditValue = DateTime.Now;
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

            ComboBoxItemCollection coll2 = cboType.Properties.Items;
            coll2.BeginUpdate();
            coll2.Clear();
            try
            {
                coll2.Add(new ExComboBox(0, "1", "超速"));
                coll2.Add(new ExComboBox(0, "2", "偏离车道"));
                coll2.Add(new ExComboBox(0, "3", "碰撞"));
            }
            finally
            {
                coll2.EndUpdate();
            }
            cboType.SelectedIndex = -1;
        }

        private void InitGrid()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);

            colBusNumber = CSubClass.CreateColumn("PLATENUMBER", "车牌号", 1, 100);
            colLine = CSubClass.CreateColumn("LINENAME", "车队", 2, 100);
            colType = CSubClass.CreateColumn("WARNINGNAME", "报警类型", 3, 100);
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

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
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
            if (cboType.SelectedItem != null)
            {
                string typeid = ((ExComboBox)cboLine.SelectedItem).Key;
                sqlCon.Add("a.WARNINGTYPE = " + typeid + " ");
            }

            string sql = "SELECT b.PLATENUMBER, d.ALIAS AS LINENAME, f.WARNINGNAME, a.ITIME, e.STATIONNAME AS PLACE, a.SPEED " + Environment.NewLine
                        + "FROM TB_WARNING a " + Environment.NewLine
                        + "LEFT JOIN TB_BUSES b ON b.BUSID2 = a.BUSID2 " + Environment.NewLine
                        + "LEFT JOIN TB_LINES c ON c.LINEID2 = a.LINEID2 " + Environment.NewLine
                        + "INNER JOIN TB_TMPLINES d ON d.LINEID2 = c.LINEID2 " + Environment.NewLine
                        + "LEFT JOIN TB_STATIONS e ON e.STATIONID2 = a.STATIONID2 " + Environment.NewLine
                        + "LEFT JOIN TB_WARNINGTYPE f ON f.WARNINGID2 = a.WARNINGTYPE ";

            if (sqlCon.Count > 0)
            {
                conStr = "WHERE (" + string.Join("AND ", sqlCon) + ") ";
            }

            sql += "ORDER BY a.ITIME ";
            DataTable dt = db.GetRs(sql);

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

        private void frmWarningDatail_SizeChanged(object sender, EventArgs e)
        {
            if (this.ClientSize.Width > 640)
            {
                panelControl1.Width = this.ClientSize.Width;
            }
            else
            {
                panelControl1.Width = 640;
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void dgvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dgvDetail_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            CSubClass.SetEmptyForeground(this.dgvDetail, e);
        }

        private void frmWarningDatail_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CSubClass.ExpToExcel(gridList);
        }
    }
}
