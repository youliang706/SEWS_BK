namespace SEWS_BK.systemset
{
    partial class frmUserArc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lstArc = new DevExpress.XtraTreeList.TreeList();
            this.colMenu = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lstArc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(161, 523);
            this.btnOK.LookAndFeel.SkinName = "Office 2013";
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(257, 523);
            this.btnCancel.LookAndFeel.SkinName = "Office 2013";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstArc
            // 
            this.lstArc.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.lstArc.Appearance.FocusedCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstArc.Appearance.FocusedCell.Options.UseBackColor = true;
            this.lstArc.Appearance.FocusedCell.Options.UseFont = true;
            this.lstArc.Appearance.FocusedRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstArc.Appearance.FocusedRow.Options.UseFont = true;
            this.lstArc.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstArc.Appearance.Row.Options.UseFont = true;
            this.lstArc.Appearance.SelectedRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstArc.Appearance.SelectedRow.Options.UseFont = true;
            this.lstArc.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colMenu,
            this.colCode});
            this.lstArc.Location = new System.Drawing.Point(6, 6);
            this.lstArc.Name = "lstArc";
            this.lstArc.OptionsBehavior.AllowIndeterminateCheckState = true;
            this.lstArc.OptionsBehavior.Editable = false;
            this.lstArc.OptionsView.ShowCheckBoxes = true;
            this.lstArc.OptionsView.ShowColumns = false;
            this.lstArc.OptionsView.ShowFocusedFrame = false;
            this.lstArc.OptionsView.ShowHorzLines = false;
            this.lstArc.OptionsView.ShowIndicator = false;
            this.lstArc.OptionsView.ShowVertLines = false;
            this.lstArc.Size = new System.Drawing.Size(347, 507);
            this.lstArc.TabIndex = 0;
            this.lstArc.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.lstArc_BeforeCheckNode);
            this.lstArc.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.lstArc_AfterCheckNode);
            // 
            // colMenu
            // 
            this.colMenu.Caption = "模块";
            this.colMenu.FieldName = "模块";
            this.colMenu.MinWidth = 32;
            this.colMenu.Name = "colMenu";
            this.colMenu.Visible = true;
            this.colMenu.VisibleIndex = 0;
            // 
            // colCode
            // 
            this.colCode.Caption = "编码";
            this.colCode.FieldName = "编码";
            this.colCode.Name = "colCode";
            // 
            // frmUserArc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 561);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstArc);
            this.Name = "frmUserArc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户管辖专用道设置";
            ((System.ComponentModel.ISupportInitialize)(this.lstArc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraTreeList.TreeList lstArc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
    }
}