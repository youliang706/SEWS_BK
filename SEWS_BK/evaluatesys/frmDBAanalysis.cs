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

namespace SEWS_BK.evaluatesys
{
    public partial class frmDBAanalysis : Form
    {
        private DevExpress.XtraGrid.Columns.GridColumn colBusNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colLine;
        private DevExpress.XtraGrid.Columns.GridColumn colScore;
        private DevExpress.XtraGrid.Columns.GridColumn colGrade;
        private DevExpress.XtraGrid.Columns.GridColumn colOpr;

        private CDatabase db = Program.db;

        public frmDBAanalysis()
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
        }

        private void InitGrid()
        {
            CSubClass.SetXtraGridStyle(dgvDetail);

            colBusNumber = CSubClass.CreateColumn("PLATENUMBER", "车牌号", 1, 100);
            colLine = CSubClass.CreateColumn("LINENAME", "车队", 2, 100);
            colScore = CSubClass.CreateColumn("SCORE", "得分", 3, 100);

            colGrade = CSubClass.CreateColumn("GRADE", "等级", 4, 150);
            colGrade.Fixed = FixedStyle.Right;
            colGrade.OptionsColumn.AllowSize = false;
            colGrade.OptionsColumn.FixedWidth = true;
            colGrade.MaxWidth = 150;
            colGrade.MinWidth = 150;
            colGrade.ColumnEdit = new RepositoryItemPictureEdit();
            colGrade.UnboundType = DevExpress.Data.UnboundColumnType.Object;

            CreateButtonColumn();

            this.dgvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colBusNumber, colLine, colScore, colGrade, colOpr
            });

            foreach (DevExpress.XtraGrid.Columns.GridColumn c in dgvDetail.Columns)
            {
                c.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void CreateButtonColumn()
        {
            colOpr = new GridColumn();

            RepositoryItemButtonEdit riButtonEdit = CSubClass.CreateOprColumn(new ExColumn[] {
                    new ExColumn("find","查看", SEWS_BK.Properties.Resources.ico_find)});
            riButtonEdit.ButtonClick += new ButtonPressedEventHandler(riButtonEdit_ButtonClick);

            this.colOpr.Caption = "操作";
            this.colOpr.FieldName = "operate";
            this.colOpr.Width = 100;
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

            if (e.Button.Tag.ToString() == "find")
            {
                //DataEdit(row["ROLECODE"].ToString());
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
                sqlCon.Add("LINEID2 = " + lineid + " ");
            }
            if (dtpBeg.EditValue != null)
            {
                sqlCon.Add("ITIME >= to_date('" + ((DateTime)dtpBeg.EditValue).ToString("yyyy-MM-dd 00:00:00") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (dtpEnd.EditValue != null)
            {
                sqlCon.Add("ITIME <= to_date('" + ((DateTime)dtpEnd.EditValue).ToString("yyyy-MM-dd 23:59:59") + "', 'yyyy-mm-dd hh24:mi:ss') ");
            }
            if (sqlCon.Count > 0)
            {
                conStr = "WHERE (" + string.Join("AND ", sqlCon) + ") ";
            }

            string sql = "SELECT b.PLATENUMBER, d.ALIAS AS LINENAME, 100 - NVL(e.NUM,0) AS SCORE " + Environment.NewLine
                        + "FROM TB_LINE_BUSES a " + Environment.NewLine
                        + "INNER JOIN TB_BUSES b ON b.BUSID = a.BUSID " + Environment.NewLine
                        + "INNER JOIN TB_LINES c ON c.LINEID = a.LINEID " + Environment.NewLine
                        + "INNER JOIN TB_TMPLINES d ON d.LINEID2 = c.LINEID2 " + Environment.NewLine
                        + "LEFT JOIN (" + Environment.NewLine
                        + "    SELECT BUSID2, SUM(WARNINGTYPE) AS NUM FROM (" + Environment.NewLine
                        + "        SELECT BUSID2, WARNINGTYPE, to_char(ITIME, 'yyyy-mm-dd') " + Environment.NewLine
                        + "        FROM TB_WARNING " + Environment.NewLine
                        + "        " + conStr + Environment.NewLine
                        + "        GROUP BY BUSID2, WARNINGTYPE, to_char(ITIME, 'yyyy-mm-dd') " + Environment.NewLine
                        + "    ) t " + Environment.NewLine
                        + "    GROUP BY t.BUSID2 " + Environment.NewLine
                        + ") e ON e.BUSID2 = b.BUSID2 " + Environment.NewLine
                        + "ORDER BY c.LINEID2, b.BUSNUMBER ";
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

        private void dgvDetail_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "GRADE")
            {
                if (e.Row != null)
                {
                    int score = int.Parse(((DataRowView)e.Row)["SCORE"].ToString());

                    if (score == 100)
                    {
                        e.Value = Properties.Resources._5_stars;
                    }
                    else if (score >= 90)
                    {
                        e.Value = Properties.Resources._4_5_stars;
                    }
                    else if (score >= 80)
                    {
                        e.Value = Properties.Resources._4_stars;
                    }
                    else if (score >= 70)
                    {
                        e.Value = Properties.Resources._3_5_stars;
                    }
                    else if (score >= 60)
                    {
                        e.Value = Properties.Resources._3_stars;
                    }
                    else if (score >= 50)
                    {
                        e.Value = Properties.Resources._2_5_stars;
                    }
                    else if (score >= 40)
                    {
                        e.Value = Properties.Resources._2_stars;
                    }
                    else if (score >= 30)
                    {
                        e.Value = Properties.Resources._1_5_stars;
                    }
                    else if (score >= 20)
                    {
                        e.Value = Properties.Resources._1_star;
                    }
                    else if (score >= 10)
                    {
                        e.Value = Properties.Resources._0_5_star;
                    }
                    else
                    {
                        e.Value = Properties.Resources._0_star;
                    }
                }
            }
        }
    }
}
