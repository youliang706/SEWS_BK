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
    public partial class frmUser : Form
    {
        private string winid = "user";
        private string winname = "用户设置";

        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraGrid.Columns.GridColumn colOpr;
        private DevExpress.XtraGrid.Columns.GridColumn colOpr2;

        private CDatabase db = Program.db;

        public frmUser()
        {
            InitializeComponent();

            CSubClass.SetXtraGridStyle(dgvDetail);
            InitGrid();
        }

        private void InitGrid()
        {
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpr2 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.colID.Caption = "登录名";
            this.colID.FieldName = "USERCODE";
            this.colID.Name = "USERCODE";
            this.colID.VisibleIndex = 1;
            this.colName.Width = 150;

            this.colName.Caption = "姓名";
            this.colName.FieldName = "USERNAME";
            this.colName.Name = "USERNAME";
            this.colName.VisibleIndex = 2;
            this.colName.Width = 100;

            this.colRole.Caption = "角色";
            this.colRole.FieldName = "ROLENAME";
            this.colRole.Name = "ROLENAME";
            this.colRole.VisibleIndex = 3;
            this.colRole.Width = 150;

            CreateButtonColumn();
            CreateButtonColumn2();

            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colID, this.colName, this.colRole, this.colOpr, this.colOpr2
            });

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

        private void CreateButtonColumn2()
        {
            RepositoryItemButtonEdit riButtonEdit = CSubClass.CreateOprColumn(new ExColumn[] { new ExColumn("set", "专用道", Properties.Resources.ico_set) });
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit_ButtonClick);

            this.colOpr2.Caption = "设置";
            this.colOpr2.FieldName = "operate";
            this.colOpr2.Width = 100;
            this.colOpr2.Visible = true;
            this.colOpr2.Fixed = FixedStyle.Right;
            this.colOpr2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colOpr2.ColumnEdit = riButtonEdit;
            gridList.RepositoryItems.Add(riButtonEdit);
        }

        private void riButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //获取当前行的index
            int RowIndex = dgvDetail.FocusedRowHandle;
            DataRow row = dgvDetail.GetDataRow(RowIndex);//获取当前行   

            if (e.Button.Tag.ToString() == "edit")
            {
                DataEdit(row["USERCODE"].ToString());
            }
            else if (e.Button.Tag.ToString() == "delete")
            {
                DataDelete(row["USERCODE"].ToString());
            }
            else if (e.Button.Tag.ToString() == "set")
            {
                SetArc(row["USERCODE"].ToString());
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void FillData()
        {
            string sql = "SELECT a.USERCODE, a.USERNAME, c.ROLENAME " 
                        + "FROM TB_UPC_USER a INNER JOIN TB_UPC_USER_ROLE b ON b.USERCODE = a.USERCODE "
                        + "LEFT JOIN TB_UPC_ROLE c ON c.ROLECODE = b.ROLECODE "
                        + "WHERE a.VALIDFLAG = '1' AND (a.USERCODE LIKE '%" + txtName.Text + "%' OR a.USERNAME LIKE '%" + txtName.Text + "%') "
                        + "ORDER BY a.CREATETIME ";
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

            dgvDetail.FocusedRowHandle = dgvDetail.LocateByValue(0, dgvDetail.Columns["USERCODE"], id.ToString());            
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="usercode"></param>
        private void DataEdit(string usercode)
        {
            if (usercode.ToLower() == "admin" || usercode.ToLower() == "administrator")
            {
                MessageBox.Show("系统固化项目，禁止编辑。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmUserInput frm = new frmUserInput(usercode);
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="usercode"></param>
        private void DataDelete(string usercode)
        {
            if (usercode.ToLower() == "admin" || usercode.ToLower() == "administrator")
            {
                MessageBox.Show("系统固化项目，禁止删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("删除的项目不能恢复，确定删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            string sql1 = "UPADTE TB_UPC_USER SET VALIDFLAG = 0 WHERE USERCODE = '" + usercode + "' ";
            //string sql2 = "DELETE FROM TB_UPC_USER_ROLE WHERE USERCODE = '" + usercode + "' ";

            db.Execute(sql1);

            //记录日志
            int RowIndex = dgvDetail.FocusedRowHandle;
            DataRow row = dgvDetail.GetDataRow(RowIndex);//获取当前行   

            CFunc.SaveLog(winid, winname, "删除用户【" + row["USERNAME"].ToString() + "】");

            dgvDetail.DeleteSelectedRows();
        }

        /// <summary>
        /// 设置用户管辖专用道
        /// </summary>
        /// <param name="usercode"></param>
        private void SetArc(string usercode)
        {
            frmUserArc frm = new frmUserArc(usercode);
            frm.ArcEdit += new ArcEditEvent(ArcEdit);
            frm.ShowDialog();
        }

        private void ArcEdit(string usercode)
        {

        }

        private void frmUser_SizeChanged(object sender, EventArgs e)
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
            frmUserInput frm = new frmUserInput();
            frm.DataChanged += new DataChangedEvevt(DataChanged);
            frm.ShowDialog();
        }

        private void dgvDetail_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            CSubClass.SetEmptyForeground(this.dgvDetail, e);
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
        }
    }
}
