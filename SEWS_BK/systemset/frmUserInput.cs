using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Database;
using SEWS_BK.generic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Com.SubClass;

namespace SEWS_BK.systemset
{
    public partial class frmUserInput : Form
    {
        private string winid = "user";
        private string winname = "用户设置";

        //定义委托事件 
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private int editType;
        private string userCode;

        public frmUserInput()
        {
            InitializeComponent();

            editType = 1;
            InitCbo();
        }

        public frmUserInput(string usercode)
        {
            InitializeComponent();

            editType = 2;
            userCode = usercode;
            InitCbo();
            FillData();

            CFunc.SetCtrlsSta(false, txtCode);
        }

        private void InitCbo()
        {
            string sql = "SELECT ROLECODE, ROLENAME "
                        + "FROM TB_UPC_ROLE "
                        + "ORDER BY ROLENAME ";
            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count > 0)
            {
                ComboBoxItemCollection coll = cboRole.Properties.Items;
                coll.BeginUpdate();
                coll.Clear();
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        coll.Add(new ExComboBox(i, dt.Rows[i]["ROLECODE"].ToString(), dt.Rows[i]["ROLENAME"].ToString()));
                    }
                }
                finally
                {
                    coll.EndUpdate();
                }
                cboRole.SelectedIndex = -1;
            }
        }

        private void FillData()
        {
            string querySql = "SELECT a.USERCODE, a.USERNAME, a.PASSWORD, b.ROLECODE "
                            + "FROM TB_UPC_USER a INNER JOIN TB_UPC_USER_ROLE b ON b.USERCODE = a.USERCODE "
                            + "WHERE a.USERCODE = '" + userCode + "' ";
            DataTable ds = db.GetRs(querySql);

            if (ds.Rows.Count > 0)
            {
                txtCode.Text = ds.Rows[0]["USERCODE"].ToString();
                txtPwd.Text = "        ";   //伪显示
                txtPwd.Tag = ds.Rows[0]["PASSWORD"].ToString();
                txtName.Text = ds.Rows[0]["USERNAME"].ToString();

                CSubClass.FindInCbo(cboRole, ds.Rows[0]["ROLECODE"].ToString());

                txtName.Tag = txtName.Text;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckData())
            {
                return;
            }

            if (editType == 1)
            {
                SaveData();
            }
            else
            {
                UpdateData();
            }

            DataChanged(editType, userCode);
            this.Close();
        }

        private bool CheckData()
        {
            if (!CFunc.TxtCheck(txtCode, "登录名"))
            {
                return false;
            }
            if (!CFunc.TxtCheck(txtName, "姓名"))
            {
                return false;
            }
            if (!CFunc.CboCheck(cboRole, "角色类型"))
            {
                return false;
            }

            if (editType == 1)
            {
                if (CFunc.ChkExists("TB_UPC_USER", "USERCODE", txtCode.Text))
                {
                    MessageBox.Show("系统中已存在相同登录名的用户。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            //if (CFunc.ChkExists("TB_UPC_USER", "USERNAME", txtName.Text, editType == 1 ? "" : "USERCOSE <> " + usrCode))
            //{
            //    MessageBox.Show("系统中已存在相同名称的项目。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            return true;
        }

        private void SaveData()
        {
            List<string> sqls = new List<string>();
            string sql;

            userCode = txtCode.Text;

            sql = "INSERT INTO TB_UPC_USER (usercode, username, password, modifytime, ldapState, validflag, rihgtMode, createtime, userHash) "
                + "VALUES ('" + txtCode.Text + "', '" + txtName.Text + "', MD5('" + txtPwd.Text + "'), to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss'), 0, 1, 1, to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss'), MD5('" + txtCode.Text + "')) ";
            sqls.Add(sql);

            string rolecode = ((ExComboBox)cboRole.SelectedItem).Key;

            sql = "INSERT INTO TB_UPC_USER_ROLE (MAINID, USERCODE, ROLECODE) "
                + "VALUES (FN_GET_UUID(), '" + txtCode.Text + "', '" + rolecode + "') ";
            sqls.Add(sql);

            db.Execute(sqls);

            //记录日志
            CFunc.SaveLog(winid, winname, "新增角色【" + txtName.Text + "】");
        }

        private void UpdateData()
        {
            List<string> sqls = new List<string>();
            string sql;

            if (txtPwd.Tag.ToString() == "")
            {
                sql = "UPDATE TB_UPC_USER SET USERNAME = '" + txtName.Text + "', PASSWORD = MD5('" + txtPwd.Text + "'), "
                    + "    modifytime = SYSDATE "
                    + "WHERE USERCODE = '" + userCode + "' ";            
            }
            else
            {
                sql = "UPDATE TB_UPC_USER SET USERNAME = '" + txtName.Text + "', modifytime = SYSDATE "
                    + "WHERE USERCODE = '" + userCode + "' ";
            }
            sqls.Add(sql);

            string rolecode = ((ExComboBox)cboRole.SelectedItem).Key;

            sql = "UPDATE TB_UPC_USER_ROLE SET ROLECODE = '" + rolecode + "' "
                + "WHERE USERCODE = '" + userCode + "' ";
            sqls.Add(sql);

            db.Execute(sqls);

            //记录日志
            if (txtName.Tag.ToString() == txtName.Text)
            {
                CFunc.SaveLog(winid, winname, "编辑用户【" + txtName.Text + "】");
            }
            else
            {
                CFunc.SaveLog(winid, winname, "编辑用户【" + txtName.Tag.ToString() + "->" + txtName.Text + "】");
            }
        }

        private void txtPwd_EditValueChanged(object sender, EventArgs e)
        {
            txtPwd.Tag = "";
        }

        private void frmUserInput_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
            CFunc.SetMaxLength("TB_UPC_USER", txtCode, "USERCODE", txtName, "USERNAME");
        }
    }
}
