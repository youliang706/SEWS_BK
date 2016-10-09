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
using SEWS_BK.generic;

namespace SEWS_BK
{
    public partial class frmPwd : Form
    {
        private CDatabase db = Program.db;

        public frmPwd()
        {
            InitializeComponent();

            this.Text = "修改\"" + CVar.UserName + "\"登录密码";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CFunc.Md5Hash(txtOriginalPwd.Text) != CVar.LoginPwd)
            {
                MessageBox.Show("原密码不正确，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtOriginalPwd.Text = "";
                txtOriginalPwd.Focus();
                return;
            }

            if (txtNewPwd.Text != txtRepeatPwd.Text)
            {
                MessageBox.Show("确认密码和新密码不一致，请重新输入。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRepeatPwd.Text = "";
                txtRepeatPwd.Focus();
                return;
            }

            string sql = "UPDATE TB_UPC_USER SET PASSWORD = MD5('" + txtNewPwd.Text + "'), "
                    + "    modifytime = SYSDATE "
                    + "WHERE USERCODE = '" + CVar.LoginID + "' ";
            db.Execute(sql);
    
            //记录日志
            CFunc.SaveLog("user", "用户信息", "修改密码【" + CVar.UserName + "】");
        }
    }
}
