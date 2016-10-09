using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraNavBar;
using Com.Register;
using Com.Database;
using SEWS_BK.generic;
using SEWS_BK.systemset;
using SEWS_BK.realmonitor;
using SEWS_BK.datareport;
using SEWS_BK.evaluatesys;
using System.Configuration;

namespace SEWS_BK
{
    public partial class frmMain : Form
    {
        //注册表操作
        private CReg reg = Program.reg;
        //数据库操作
        private CDatabase db = Program.db;

        public frmMain()
        {
            InitializeComponent();

            LogOut();
        }

        private void LogOut()
        {
            foreach (Form f in MdiChildren)
            {
                f.Close();
            }

            pnlCase.Visible = true;
            pnlMenu.Visible = false;

            lblUser.Text = "";
            picPwd.Visible = false;
            picLogout.Visible = false;
        }

        private void LogIn()
        {
            pnlCase.Visible = false;
            pnlMenu.Visible = true;

            lblUser.Text = "当前登录：" + CVar.UserName;
            picPwd.Visible = true;
            picLogout.Visible = true;

            InitList();

            CFunc.ShowLoading("正在登录，请稍候...");
            OpenDefLink();
            CFunc.CloseLoading();
        }

        private void InitList() 
        {
            navBar.Groups.Clear();

            string querySql = "";

            querySql = "SELECT '' AS MENUCODE, '' AS MENUNAME, '' AS MENUPARENTCODE, 0 AS MENULEVEL, 0 AS SEQ, 0 AS ISSHOW FROM DUAL WHERE ROWNUM = 0 " + Environment.NewLine 
                    + "UNION ALL SELECT 'monitoring', '实时监控', '' , 0, 1, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'busmonitor', '车辆监控', 'monitoring' , 1, 1, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'statistics', '数据统计', '' , 0, 2, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'warningdetail', '报警数据明细', 'statistics' , 1, 1, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'warningstat', '报警数据统计', 'statistics' , 1, 2, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'warningdist', '报警类型分布', 'statistics' , 1, 3, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'warningperiodstat', '时段报警统计', 'statistics' , 1, 4, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'warningtrend', '报警趋势图', 'statistics' , 1, 5, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'evaluation', '数据分析', '' , 0, 3, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'rsnanalysis', '风险系数分析', 'evaluation' , 1, 1, 1 FROM DUAL " + Environment.NewLine
                    + "UNION ALL SELECT 'busmonitor', '驾驶行为分析', 'evaluation' , 1, 2, 1 FROM DUAL ";
            
            DataTable ds = db.GetRs(querySql);

            //绘制UI
            navBar.BeginUpdate();

            //构造菜单
            DataView dv = ds.DefaultView;
            dv.RowFilter = "MENULEVEL = 0";
            dv.Sort = "SEQ";

            foreach (DataRowView dr in dv)
            {
                NavBarGroup grp = new NavBarGroup(dr["MENUNAME"].ToString());

                DataView di = new DataView(ds, "MENUPARENTCODE = '" + dr["MENUCODE"].ToString() + "'", "SEQ", DataViewRowState.Unchanged);
                foreach (DataRowView drv in di)
                {
                    NavBarItem itemChart = new NavBarItem(drv["MENUNAME"].ToString());
                    itemChart.Tag = drv["MENUCODE"].ToString();
                    SetItemStyle(itemChart, 2);
                    if (drv["ISSHOW"].ToString() == "0")
                    {
                        itemChart.Appearance.ForeColor = Color.RoyalBlue;
                    }
                    grp.ItemLinks.Add(itemChart);
                }

                navBar.Groups.Add(grp);
            }

            //处理显示样式
            foreach (NavBarGroup grp in navBar.Groups)
            {
                grp.GroupStyle = NavBarGroupStyle.SmallIconsList;
                grp.Appearance.Font = new Font("微软雅黑", 9);
                grp.Appearance.ForeColor = Color.White;

                grp.Expanded = true;
            }

            navBar.ActiveGroup = navBar.Groups[0];
            //navBar.ActiveGroup.Expanded = true;

            navBar.LinkClicked += new NavBarLinkEventHandler(navBar_LinkClicked);

            navBar.LinkSelectionMode = LinkSelectionModeType.None;
            navBar.EndUpdate();
        }

        private void SetItemStyle(NavBarItem item, int imgIndex)
        {
            item.Appearance.Font = new Font("微软雅黑", 9);
            item.Appearance.ForeColor = Color.White;
            item.AppearanceDisabled.Font = new Font("微软雅黑", 9);
            item.AppearanceHotTracked.Font = new Font("微软雅黑", 9);
            item.AppearancePressed.Font = new Font("微软雅黑", 9);

            item.SmallImage = navbarImageCollection.Images[imgIndex];
        }

        /// <summary>   
        /// 判断MDI中是否已存在当前窗体   
        /// </summary>   
        /// <param name="ChildTypeString">窗体类型名称</param>   
        /// <returns></returns>   
        private bool ContainMDIChild(string ChildTypeString)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType().ToString().Substring(f.GetType().ToString().LastIndexOf(".") + 1) == ChildTypeString)
                {
                    f.Select();
                    return true;
                }
            }
            return false;
        }  

        void navBar_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            CFunc.ShowLoading();

            switch (e.Link.Item.Tag.ToString())
            {
                //系统管理
                case "role":
                    if (!ContainMDIChild("frmRole"))
                    {
                        frmRole frm = new frmRole();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "user":
                    if (!ContainMDIChild("frmUser"))
                    {
                        frmUser frm = new frmUser();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "log":
                    if (!ContainMDIChild("frmSysLog"))
                    {
                        frmSysLog frm = new frmSysLog();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;


                //实时监控
                case "busmonitor":
                    if (!ContainMDIChild("frmMonitor"))
                    {
                        bool bln = true;
                        if (CLineList.ManagedLines.Count == 0)
                        {
                            frmLoading LoadingForm = new frmLoading();
                            bln = LoadingForm.ShowMe(CVar.LoginID);
                        }
                        if (bln)
                        {
                            frmMonitor frm = new frmMonitor();
                            frm.MdiParent = this;
                            frm.Show();
                        }
                    }
                    break;

                //数据统计
                case "warningdetail":
                    if (!ContainMDIChild("frmWarningDetail"))
                    {
                        frmWarningDetail frm = new frmWarningDetail();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "warningstat":
                    if (!ContainMDIChild("frmWarningStat"))
                    {
                        frmWarningStat frm = new frmWarningStat();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "warningdist":
                    if (!ContainMDIChild("frmWarningDist"))
                    {
                        frmWarningDist frm = new frmWarningDist();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "warningperiodstat":
                    if (!ContainMDIChild("frmWarningPeriodStat"))
                    {
                        frmWarningPeriodStat frm = new frmWarningPeriodStat();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "warningtrend":
                    if (!ContainMDIChild("frmWarningTrend"))
                    {
                        frmWarningTrend frm = new frmWarningTrend();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                case "rsnanalysis":
                    if (!ContainMDIChild("frmRSNAanalysis"))
                    {
                        frmRSNAanalysis frm = new frmRSNAanalysis();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    break;

                default:
                    MessageBox.Show(e.Link.Item.Tag.ToString());
                    break;
            }

            CFunc.CloseLoading();
        }

        private void OpenDefLink()
        {
            if (!ContainMDIChild("frmHomepage"))
            {
                frmHomepage frm = new frmHomepage();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtLoginID.Text = reg.GetSettings(Application.ProductName, "system", "loginid");
            txtPwd.Text = reg.GetSettings(Application.ProductName, "system", "loginpwd");

            if (txtPwd.Text != "")
            { chkSavPwd.Checked = true; }
        }

        private void picBtn_Click(object sender, EventArgs e)
        {
            bool bln = ChkLogin(txtLoginID.Text, txtPwd.Text);

            if (bln)
            {
                reg.SaveSettings(Application.ProductName, "system", "loginid", txtLoginID.Text);
                if (chkSavPwd.Checked)
                { reg.SaveSettings(Application.ProductName, "system", "loginpwd", txtPwd.Text); }
                else
                { reg.SaveSettings(Application.ProductName, "system", "loginpwd", ""); }

                LogIn();
            }
        }

        private bool ChkLogin(string sUser, string sPwd)
        {
            string sql = string.Format("SELECT username, password FROM TB_UPC_USER WHERE UPPER(usercode) = UPPER('{0}')", sUser);
            DataTable ds = db.GetRs(sql);

            if (ds.Rows.Count == 0)
            {
                MessageBox.Show("用户名不存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (ds.Rows[0]["password"].ToString().ToLower() != CFunc.Md5Hash(sPwd))
                {
                    MessageBox.Show("密码不正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    CVar.LoginID = sUser;
                    CVar.LoginPwd = ds.Rows[0]["password"].ToString().ToLower();
                    CVar.UserName = ds.Rows[0]["username"].ToString();

                    return true;
                }
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            //pnlCase.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            pnlLogin.Location = new Point((pnlCase.ClientSize.Width - pnlLogin.Width) / 2, (pnlCase.ClientSize.Height - pnlLogin.Height) / 2);
        }

        private void picBtn_MouseEnter(object sender, EventArgs e)
        {
            picBtn.Image = SEWS_BK.Properties.Resources.login_btn2;
        }

        private void picBtn_MouseLeave(object sender, EventArgs e)
        {
            picBtn.Image = SEWS_BK.Properties.Resources.login_btn;
        }

        private void picBtn_MouseDown(object sender, MouseEventArgs e)
        {
            picBtn.Image = SEWS_BK.Properties.Resources.login_btn3;
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定注销登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                LogOut();
            }
        }

        private void picPwd_Click(object sender, EventArgs e)
        {
            frmPwd frm = new frmPwd();
            frm.ShowDialog();
        }

        private void lblMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //调用系统默认的浏览器  
            System.Diagnostics.Process.Start("http://skcl.cn");   
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出系统？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            CFunc.CloseLoading();
        }
    }
}
