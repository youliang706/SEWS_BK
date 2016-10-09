using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using Com.Database;
using SEWS_BK.generic;

namespace SEWS_BK.systemset
{
    //定义委托
    public delegate void ArcEditEvent(string usercode);

    public partial class frmUserArc : Form
    {
        private string winid = "user";
        private string winname = "用户设置";

        //定义委托事件 
        public event ArcEditEvent ArcEdit;

        private CDatabase db = Program.db;

        private string userCode;

        public frmUserArc(string usercode)
        {
            InitializeComponent();

            userCode = usercode;
            FillList();
        }

        /// <summary>
        /// 初始化专用道表
        /// </summary>
        private void FillList()
        {
            string querySql = "SELECT ROADNAME AS ID, ROADNAME AS NAME, '' AS PARENTID, 0 AS LEVEL2, 0 AS SEL FROM TB_ARCINFO GROUP BY ROADNAME "
                            + "UNION ALL "
                            + "SELECT a.ARCID, a.FNODE || ' -> ' || a.TNODE, a.ROADNAME, 1, CASE WHEN b.USERCODE IS NULL THEN  (CASE WHEN c.USERCODE IS NULL THEN 0 ELSE 2 END) ELSE 1 END AS SEL "
                            + "FROM TB_ARCINFO a "
                            + "LEFT JOIN TB_USER_ARC b ON b.USERCODE = '" + userCode + "' AND b.ARCID = a.ARCID "
                            + "LEFT JOIN TB_USER_ARC c ON c.ARCID = a.ARCID ";
            DataTable ds = db.GetRs(querySql);

            DataView dv = ds.DefaultView;
            dv.RowFilter = "LEVEL2 = 0";
            dv.Sort = "NAME";

            foreach (DataRowView dr in dv)
            {
                TreeListNode ParentNode = lstArc.AppendNode(null, null);
                ParentNode.SetValue(lstArc.Columns[0], dr["NAME"].ToString());
                ParentNode.SetValue(lstArc.Columns[1], dr["ID"].ToString());

                DataView di = new DataView(ds, "PARENTID = '" + dr["ID"].ToString() + "'", "ID", DataViewRowState.Unchanged);
                foreach (DataRowView drv in di)
                {
                    switch (drv["SEL"].ToString())
                    {
                        case "0":
                            lstArc.AppendNode(new object[] { drv["NAME"].ToString(), drv["ID"].ToString() }, ParentNode.Id, CheckState.Unchecked);
                            break;
                        case "1":
                            lstArc.AppendNode(new object[] { drv["NAME"].ToString(), drv["ID"].ToString() }, ParentNode.Id, CheckState.Checked);
                            break;
                        case "2":
                            lstArc.AppendNode(new object[] { drv["NAME"].ToString(), drv["ID"].ToString() }, ParentNode.Id, CheckState.Indeterminate);
                            break;
                    }
                }
            }

            //处理父节点选中
            for (int i = 0; i < lstArc.Nodes.Count; i++)
            {
                int k = 0;

                for (int j = 0; j < lstArc.Nodes[i].Nodes.Count; j++)
                {
                    if (lstArc.Nodes[i].Nodes[j].Checked)
                    {
                        k++;
                    }
                }

                if (k==0)
                {
                    lstArc.Nodes[i].CheckState = CheckState.Unchecked;
                }
                else if (k == lstArc.Nodes[i].Nodes.Count)
                {
                    lstArc.Nodes[i].CheckState = CheckState.Checked;
                }
                else
                {
                    lstArc.Nodes[i].CheckState = CheckState.Indeterminate;
                }
            }

            lstArc.ExpandAll();
        }

        private void lstArc_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                if (e.PrevState == CheckState.Indeterminate)
                {
                    return;
                }
            }

            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void lstArc_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                if (e.Node.CheckState == CheckState.Indeterminate)
                {
                    return;
                }
            }

            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
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
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
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

            UpdateData();

            ArcEdit(userCode);
            this.Close();
        }

        private bool CheckData()
        {
            return true;
        }

        private void UpdateData()
        {
            List<string> sqls = new List<string>();
            string sql;

            sql = "DELETE FROM TB_USER_ARC WHERE USERCODE = '" + userCode + "' ";
            sqls.Add(sql);

            for (int i = 0; i < lstArc.Nodes.Count; i++)
            {
                if (lstArc.Nodes[i].CheckState != CheckState.Unchecked)
                {
                    for (int j = 0; j < lstArc.Nodes[i].Nodes.Count; j++)
                    {
                        if (lstArc.Nodes[i].Nodes[j].Checked)
                        {
                            sql = "INSERT INTO TB_USER_ARC(USERCODE, ARCID) "
                                + "VALUES ('" + userCode + "', '" + lstArc.Nodes[i].Nodes[j].GetValue(1) + "') ";
                            sqls.Add(sql);
                        }
                    }
                }
            }

            db.Execute(sqls);

            //记录日志
            string lineName = CFunc.IDValue("TB_LINES", "LINEID", "LINENAME", userCode);
            CFunc.SaveLog(winid, winname, "编辑线路专用道【" + lineName + "】");
        }
    }
}
