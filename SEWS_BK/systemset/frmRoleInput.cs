using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using Com.Database;
using Com.SubClass;
using SEWS_BK.generic;

namespace SEWS_BK.systemset
{
    public partial class frmRoleInput : Form
    {
        private string winid = "role";
        private string winname = "角色设置";

        //定义委托事件 
        public event DataChangedEvevt DataChanged;

        private CDatabase db = Program.db;

        private int editType;
        private string roleCode;

        public frmRoleInput()
        {
            InitializeComponent();

            editType = 1;
            InitList();
        }

        public frmRoleInput(string rolecode)
        {
            InitializeComponent();

            editType = 2;
            roleCode = rolecode;
            FillData();
            FillList();

            CFunc.SetCtrlsSta(false, txtCode);
        }

        /// <summary>
        /// 初始化模块表
        /// </summary>
        private void InitList()
        {
            string querySql = "SELECT MENUCODE, MENUNAME, MENUPARENTCODE, CASE WHEN MENUPARENTCODE IS NULL THEN 0 ELSE 1 END AS MENULEVEL, SEQ "
                            + "FROM TB_UPC_MENU WHERE ISSHOW = 1 ";
            DataTable ds = db.GetRs(querySql);

            DataView dv = ds.DefaultView;
            dv.RowFilter = "MENULEVEL = 0";
            dv.Sort = "SEQ";

            foreach (DataRowView dr in dv)
            {
                TreeListNode ParentNode = lstRight.AppendNode(null, null);
                ParentNode.SetValue(lstRight.Columns[0], dr["MENUNAME"].ToString());
                ParentNode.SetValue(lstRight.Columns[1], dr["MENUCODE"].ToString());

                DataView di = new DataView(ds, "MENUPARENTCODE = '" + dr["MENUCODE"].ToString() + "'", "SEQ", DataViewRowState.Unchanged);
                foreach (DataRowView drv in di)
                {
                    lstRight.AppendNode(new object[] { drv["MENUNAME"].ToString(), drv["MENUCODE"].ToString() }, ParentNode.Id);
                }
            }

            lstRight.ExpandAll();
        }

        /// <summary>
        /// 初始化模块表（含权限）
        /// </summary>
        private void FillList()
        {
            string querySql = "SELECT a.MENUCODE, a.MENUNAME, a.MENUPARENTCODE, CASE WHEN a.MENUPARENTCODE IS NULL THEN 0 ELSE 1 END AS MENULEVEL, a.SEQ, "
                            + "    CASE WHEN b.MAINID IS NULL THEN 0 ELSE 1 END AS SEL "
                            + "FROM TB_UPC_MENU a "
                            + "LEFT JOIN TB_UPC_MENURIGHT b ON b.CODE = '" + roleCode + "' AND b.MENUCODE = a.MENUCODE "
                            + "WHERE a.ISSHOW = 1 ";
            DataTable ds = db.GetRs(querySql);

            DataView dv = ds.DefaultView;
            dv.RowFilter = "MENULEVEL = 0";
            dv.Sort = "SEQ";

            foreach (DataRowView dr in dv)
            {
                TreeListNode ParentNode = lstRight.AppendNode(null, null);
                ParentNode.SetValue(lstRight.Columns[0], dr["MENUNAME"].ToString());
                ParentNode.SetValue(lstRight.Columns[1], dr["MENUCODE"].ToString());
                if (dr["SEL"].ToString() == "1")
                {
                    ParentNode.CheckState = CheckState.Checked;
                }

                DataView di = new DataView(ds, "MENUPARENTCODE = '" + dr["MENUCODE"].ToString() + "'", "SEQ", DataViewRowState.Unchanged);
                foreach (DataRowView drv in di)
                {
                    lstRight.AppendNode(new object[] { drv["MENUNAME"].ToString(), drv["MENUCODE"].ToString() }, ParentNode.Id, (drv["SEL"].ToString() == "1" ? CheckState.Checked : CheckState.Unchecked));
                }
            }

            lstRight.ExpandAll();
        }

        private void FillData()
        {
            string querySql = "SELECT ROLECODE, ROLENAME FROM TB_UPC_ROLE "
                            + "WHERE ROLECODE = '" + roleCode + "' ";
            DataTable ds = db.GetRs(querySql);

            if (ds.Rows.Count > 0)
            {
                txtCode.Text = ds.Rows[0]["ROLECODE"].ToString();
                txtName.Text = ds.Rows[0]["ROLENAME"].ToString();
                txtName.Tag = txtName.Text;
            }
        }

        private void lstRight_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void lstRight_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        /// <summary>
        /// 设置子节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 设置父节点的状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Checked : check;
                SetCheckedParentNodes(node.ParentNode, check);
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

            DataChanged(editType, roleCode);
            this.Close();
        }

        private bool CheckData()
        {
            if (!CFunc.TxtCheck(txtCode, "编码"))
            {
                return false;
            }
            if (!CFunc.TxtCheck(txtName, "名称"))
            {
                return false;
            }

            if (editType == 1)
            {
                if (CFunc.ChkExists("TB_UPC_ROLE", "ROLECODE", txtCode.Text))
                {
                    MessageBox.Show("系统中已存在相同编码的项目。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (CFunc.ChkExists("TB_UPC_ROLE", "ROLENAME", txtName.Text, editType == 1 ? "" : "ROLECODE <> '" + roleCode + "'"))
            {
                MessageBox.Show("系统中已存在相同名称的项目。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            List<string> sqls = new List<string>();
            string sql;

            roleCode = txtCode.Text;

            sql = "INSERT INTO TB_UPC_ROLE(ROLECODE, ROLENAME, ISDEFAULT, ISDELETE, CREATETIME) "
                + "VALUES ('" + txtCode.Text + "', '" + txtName.Text + "', 0, 1, to_char(SYSDATE, 'yyyy-mm-dd hh24:mi:ss')) ";
            sqls.Add(sql);

            for (int i = 0; i < lstRight.Nodes.Count; i++)
            {
                if (lstRight.Nodes[i].CheckState != CheckState.Unchecked)
                {
                    sql = "INSERT INTO TB_UPC_MENURIGHT(MAINID, MENUCODE, CODE, CATEGORY, RIGHTVALUE) "
                        + "VALUES (FN_GET_UUID(), '" + lstRight.Nodes[i].GetValue(1) + "', '" + txtCode.Text + "', 'R', 'Y') ";
                    sqls.Add(sql);

                    for (int j = 0; j < lstRight.Nodes[i].Nodes.Count; j++ )
                    {
                        if (lstRight.Nodes[i].Nodes[j].CheckState != CheckState.Unchecked)
                        {
                            sql = "INSERT INTO TB_UPC_MENURIGHT(MAINID, MENUCODE, CODE, CATEGORY, RIGHTVALUE) "
                                + "VALUES (FN_GET_UUID(), '" + lstRight.Nodes[i].Nodes[j].GetValue(1) + "', '" + txtCode.Text + "', 'R', 'Y') ";
                            sqls.Add(sql);
                        }
                    }
                }
            }

            db.Execute(sqls);

            //记录日志
            CFunc.SaveLog(winid, winname, "新增角色【" + txtName.Text + "】");
        }

        private void UpdateData()
        {
            List<string> sqls = new List<string>();
            string sql;

            sql = "UPDATE TB_UPC_ROLE SET ROLENAME = '" + txtName.Text + "' "
                + "WHERE ROLECODE = '" + roleCode + "' ";
            sqls.Add(sql);

            sql = "DELETE FROM TB_UPC_MENURIGHT WHERE CODE = '" + roleCode + "' ";
            sqls.Add(sql);

            for (int i = 0; i < lstRight.Nodes.Count; i++)
            {
                if (lstRight.Nodes[i].CheckState != CheckState.Unchecked)
                {
                    sql = "INSERT INTO TB_UPC_MENURIGHT(MAINID, MENUCODE, CODE, CATEGORY, RIGHTVALUE) "
                        + "VALUES (FN_GET_UUID(), '" + lstRight.Nodes[i].GetValue(1) + "', '" + txtCode.Text + "', 'R', 'Y') ";
                    sqls.Add(sql);

                    for (int j = 0; j < lstRight.Nodes[i].Nodes.Count; j++)
                    {
                        if (lstRight.Nodes[i].Nodes[j].CheckState != CheckState.Unchecked)
                        {
                            sql = "INSERT INTO TB_UPC_MENURIGHT(MAINID, MENUCODE, CODE, CATEGORY, RIGHTVALUE) "
                                + "VALUES (FN_GET_UUID(), '" + lstRight.Nodes[i].Nodes[j].GetValue(1) + "', '" + txtCode.Text + "', 'R', 'Y') ";
                            sqls.Add(sql);
                        }
                    }
                }
            }

            db.Execute(sqls);

            //记录日志
            if (txtName.Tag.ToString() == txtName.Text)
            {
                CFunc.SaveLog(winid, winname, "编辑角色【" + txtName.Text + "】");
            }
            else
            {
                CFunc.SaveLog(winid, winname, "编辑角色【" + txtName.Tag.ToString() + "->" + txtName.Text + "】");
            }
        }

        private void frmRoleInput_Load(object sender, EventArgs e)
        {
            CSubClass.SetXtraTxtMask(this);
            CFunc.SetMaxLength("TB_UPC_ROLE", txtCode, "ROLECODE", txtName, "ROLENAME");
        }
    }
}
