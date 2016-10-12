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
    public partial class frmWarningStat : Form
    {
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colBusNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOverSpeed;
        private DevExpress.XtraGrid.Columns.GridColumn colOffset;
        private DevExpress.XtraGrid.Columns.GridColumn colCollision;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTimes;

        private CDatabase db = Program.db;

        public frmWarningStat()
        {
            InitializeComponent();

            InitGrid();

            CSubClass.SetXtraDtpStyle(dtpBeg, DtType.LongDate);
            CSubClass.SetXtraDtpStyle(dtpEnd, DtType.LongDate);

            //dtpBeg.EditValue = DateTime.Now;
            //dtpEnd.EditValue = DateTime.Now;
        }

        private void InitGrid()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);

            colLine = CSubClass.CreateColumn("LINENAME", "车队", 1, 100);
            colBusNumber = CSubClass.CreateColumn("PLATENUMBER", "车牌号", 2, 100);
            colOverSpeed = CSubClass.CreateColumn("OVERSPEED", "超速报警次数", 3, 100);
            colOffset = CSubClass.CreateColumn("OFFSET", "偏离报警次数", 4, 100);
            colCollision = CSubClass.CreateColumn("COLLISION", "碰撞报警次数", 5, 100);
            colTotalTimes = CSubClass.CreateColumn("TOTALTIMES", "合计报警次数", 6, 100);

            dgvDetail.GroupRowHeight = 26;
            colLine.GroupIndex = 0;     //分组
            //dgvDetail.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "超速报警次数", colOverSpeed);
            //dgvDetail.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "偏离报警次数", colOffset);
            //dgvDetail.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "碰撞报警次数", colCollision);
            //dgvDetail.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "合计报警次数", colTotalTimes);

            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colLine, colBusNumber, colOverSpeed, colOffset, colCollision, colTotalTimes
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

            if (dtpBeg.EditValue != null)
            {
                sqlCon.Add("d.ITIME >= to_date('" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (dtpEnd.EditValue != null)
            {
                sqlCon.Add("d.ITIME <= to_date('" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (sqlCon.Count > 0)
            {
                conStr = "WHERE (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT b.PLATENUMBER, d.ALIAS AS LINENAME, NVL(e.OVERSPEED,0) AS OVERSPEED, NVL(e.OFFSET,0) AS OFFSET, NVL(e.COLLISION,0) AS COLLISION, NVL(e.TOTALTIMES,0) AS TOTALTIMES " + Environment.NewLine
                        + "     " + Environment.NewLine
                        + "FROM TB_LINE_BUSES a " + Environment.NewLine
                        + "INNER JOIN TB_BUSES b ON b.BUSID = a.BUSID " + Environment.NewLine
                        + "INNER JOIN TB_LINES c ON c.LINEID = a.LINEID " + Environment.NewLine
                        + "INNER JOIN TB_TMPLINES d ON d.LINEID2 = a.LINEID2 " + Environment.NewLine
                        + "INNER JOIN ( " + Environment.NewLine
                        + "    SELECT BUSID2, SUM(CASE WARNINGTYPE WHEN 1 THEN 1 ELSE 0 END) AS OVERSPEED, SUM(CASE WARNINGTYPE WHEN 2 THEN 1 ELSE 0 END) AS OFFSET, " + Environment.NewLine
                        + "        SUM(CASE WARNINGTYPE WHEN 3 THEN 1 ELSE 0 END) AS COLLISION, COUNT(*) AS TOTALTIMES " + Environment.NewLine
                        + "    FROM TB_WARNING " + conStr + Environment.NewLine
                        + "    GROUP BY BUSID2 " + Environment.NewLine 
                        + ") e ON e.BUSID2 = b.BUSID2 ";
            
            sql += "ORDER BY c.LINENAME, b.BUSNUMBER ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                gridList.DataSource = dt;
                gridList.RefreshDataSource();
                //dgvDetail.ExpandAllGroups();
            }
            else
            {
                CSubClass.ClearRows(dgvDetail);
            }
        }

        private void frmWarningStat_SizeChanged(object sender, EventArgs e)
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

        private void frmWarningStat_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CSubClass.ExpToExcel(gridList);
        }

        private void dgvDetail_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo GridGroupRowInfo = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
            GridGroupRowInfo.GroupText = GridGroupRowInfo.EditValue.ToString();
        }

    }
}
