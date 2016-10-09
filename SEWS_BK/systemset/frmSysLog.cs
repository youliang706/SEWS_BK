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

namespace SEWS_BK.systemset
{
    public partial class frmSysLog : Form
    {
        //private string winid = "syslog";
        //private string winname = "系统日志";

        private DevExpress.XtraGrid.Columns.GridColumn colMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn colContect;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;

        private CDatabase db = Program.db;

        public frmSysLog()
        {
            InitializeComponent();

            CSubClass.SetXtraGridStyle(dgvDetail);
            InitGrid();

            InitObject();

            CSubClass.SetXtraDtpStyle(dtpBeg, DtType.LongDate);
            CSubClass.SetXtraDtpStyle(dtpEnd, DtType.LongDate);
            dtpBeg.EditValue = DateTime.Now.Date;
            dtpEnd.EditValue = DateTime.Now.Date;
        }

        private void InitObject()
        {
            string sql = "SELECT a.MENUCODE, CASE WHEN a.MENUPARENTCODE IS NULL THEN '' ELSE '--' END || a.MENUNAME AS MENUNAME, "
                        + "    CASE WHEN a.MENUPARENTCODE IS NULL THEN 0 ELSE 1 END AS MENULEVEL "
                        + "FROM TB_UPC_MENU a LEFT JOIN TB_UPC_MENU b ON b.MENUCODE = a.MENUPARENTCODE "
                        + "WHERE a.ISSHOW = 1 "
                        + "ORDER BY nvl(b.SEQ, a.SEQ), CASE WHEN b.SEQ IS NULL THEN 0 ELSE a.SEQ END ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                ComboBoxItemCollection coll = cboObject.Properties.Items;
                coll.BeginUpdate();
                coll.Clear();
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        coll.Add(new ExComboBox(i, dt.Rows[i]["MENUCODE"].ToString(), dt.Rows[i]["MENUNAME"].ToString(), dt.Rows[i]["MENULEVEL"].ToString()));
                    }
                }
                finally
                {
                    coll.EndUpdate();
                }
                cboObject.SelectedIndex = -1;
            }
        }

        private void InitGrid()
        {
            this.colMenu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();

            this.colMenu.Caption = "模块";
            this.colMenu.FieldName = "MENUNAME";
            this.colMenu.Name = "MENUNAME";
            this.colMenu.VisibleIndex = 1;
            this.colMenu.Width = 100;
            this.colMenu.OptionsColumn.AllowEdit = false;

            this.colUser.Caption = "用户";
            this.colUser.FieldName = "USERNAME";
            this.colUser.Name = "USERNAME";
            this.colUser.VisibleIndex = 2;
            this.colUser.Width = 100;
            this.colUser.OptionsColumn.AllowEdit = false;

            this.colIP.Caption = "IP地址";
            this.colIP.FieldName = "OPERATEIP";
            this.colIP.Name = "OPERATEIP";
            this.colIP.VisibleIndex = 3;
            this.colIP.Width = 150;
            this.colIP.OptionsColumn.AllowEdit = false;

            this.colContect.Caption = "操作";
            this.colContect.FieldName = "OPERATECONTENT";
            this.colContect.Name = "OPERATECONTENT";
            this.colContect.VisibleIndex = 4;
            this.colContect.Width = 400;
            this.colContect.OptionsColumn.AllowEdit = false;

            this.colTime.Caption = "时间";
            this.colTime.FieldName = "OPERATETIME";
            this.colTime.Name = "OPERATETIME";
            this.colTime.VisibleIndex = 5;
            this.colTime.Width = 150;
            this.colTime.OptionsColumn.AllowEdit = false;

            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMenu, this.colUser, this.colIP, this.colContect, this.colTime
            });
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
            string sql = "SELECT c.MENUNAME, b.USERNAME, a.OPERATEIP, a.OPERATECONTENT, a.OPERATETIME "
                        + "FROM TB_SYSTEM_LOG a INNER JOIN TB_UPC_USER b ON b.USERCODE = a.OPERATEUSERCODE "
                        + "INNER JOIN TB_UPC_MENU c ON c.MENUCODE = a.OPERATEOBJECTID AND c.ISSHOW = 1 "
                        + "WHERE a.OPERATETIME >= '" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd 00:00:00") + "' "
                        + "AND a.OPERATETIME <= '" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd 23:59:59") + "' ";

            if (cboObject.SelectedItem != null)
            {
                string menucode = ((ExComboBox)cboObject.SelectedItem).Key;
                string menulevel = ((ExComboBox)cboObject.SelectedItem).Tag;

                if (menulevel == "1")
                {
                    sql += "AND c.MENUCODE = '" + menucode + "' ";
                }
                else
                {
                    sql += "AND c.MENUPARENTCODE = '" + menucode + "' ";
                }
            }

            sql += "ORDER BY a.OPERATETIME ";
        
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

        /// <summary>
        /// 查询记录
        /// </summary>
        private void DataChanged(int editType, object id)
        {
            FillData();

            dgvDetail.FocusedRowHandle = dgvDetail.LocateByValue(0, dgvDetail.Columns["ROLECODE"], id.ToString());            
        }

        private void frmSysLog_SizeChanged(object sender, EventArgs e)
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

        private void frmSysLog_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }
    }
}
