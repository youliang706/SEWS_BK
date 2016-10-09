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
    public partial class frmRole : Form
    {
        private string winid = "role";
        private string winname = "角色设置";

        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOpr;

        private CDatabase db = Program.db;

        public frmRole()
        {
            InitializeComponent();

            CSubClass.SetXtraGridStyle(dgvDetail);
            InitGrid();
        }

        private void InitGrid()
        {
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpr = new DevExpress.XtraGrid.Columns.GridColumn();

            this.colID.Caption = "ID";
            this.colID.FieldName = "ROLECODE";
            this.colID.Name = "ROLECODE";
            this.colID.VisibleIndex = 0;

            this.colName.Caption = "名称";
            this.colName.FieldName = "ROLENAME";
            this.colName.Name = "ROLENAME";
            this.colName.VisibleIndex = 2;
            this.colName.Width = 200;

            CreateButtonColumn();

            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colID, this.colName, this.colOpr
            });

            this.colID.Visible = false;

            dgvDetail.OptionsBehavior.Editable = true;
            foreach (GridColumn c in dgvDetail.Columns)
            {
                c.OptionsColumn.AllowEdit = c.ColumnEdit is RepositoryItemButtonEdit;
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void CreateButtonColumn()
        {
            RepositoryItemButtonEdit riButtonEdit = CSubClass.CreateDefOprColumn(false);
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit_ButtonClick);

            this.colOpr.Caption = "操作";
            this.colOpr.FieldName = "operate";
            this.colOpr.Width = 200;
            this.colOpr.Visible = true;
            this.colOpr.Fixed = FixedStyle.Right;
            this.colOpr.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOpr.ColumnEdit = riButtonEdit;
            gridList.RepositoryItems.Add(riButtonEdit);
        }

        private void riButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //获取当前行的index
            int RowIndex = dgvDetail.FocusedRowHandle;
            DataRow row = dgvDetail.GetDataRow(RowIndex);//获取当前行   

            if (e.Button.Tag.ToString() == "edit")
            {
                DataEdit(row["ROLECODE"].ToString());
            }
            else
            {
                DataDelete(row["ROLECODE"].ToString());
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
            string sql = "SELECT ROLECODE, ROLENAME FROM TB_UPC_ROLE "
                        + "WHERE ROLENAME LIKE '%" + txtName.Text + "%' "
                        + "ORDER BY CREATETIME ";
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

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="id"></param>
        private void DataEdit(string rolecode)
        {
            if (CFunc.IDValue("TB_UPC_ROLE", "ROLECODE", "ISDELETE", rolecode) == "0")
            {
                MessageBox.Show("系统固化项目，禁止编辑。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmRoleInput frm = new frmRoleInput(rolecode);
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="rolecode"></param>
        private void DataDelete(string rolecode)
        {
            if (CFunc.IDValue("TB_UPC_ROLE", "ROLECODE", "ISDELETE", rolecode) == "0")
            {
                MessageBox.Show("系统固化项目，禁止删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("删除的项目不能恢复，确定删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            if (CFunc.ChkExists("TB_UPC_USER_ROLE", "ROLECODE", rolecode))
            {
                MessageBox.Show("选择的项目已被其它项目使用，禁止删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string sql1 = "DELETE FROM TB_UPC_ROLE WHERE ROLECODE = '" + rolecode + "' ";
            string sql2 = "DELETE FROM TB_UPC_MENURIGHT WHERE CODE = '" + rolecode + "' ";

            db.Execute(sql1, sql2);

            //记录日志
            int RowIndex = dgvDetail.FocusedRowHandle;
            DataRow row = dgvDetail.GetDataRow(RowIndex);//获取当前行   

            CFunc.SaveLog(winid, winname, "删除角色【" + row["ROLENAME"].ToString() + "】");

            dgvDetail.DeleteSelectedRows();
        }

        private void frmRole_SizeChanged(object sender, EventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmRoleInput frm = new frmRoleInput();
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        private void dgvDetail_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            CSubClass.SetEmptyForeground(this.dgvDetail, e);
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }
    }
}
