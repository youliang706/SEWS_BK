namespace SEWS_BK.evaluatesys
{
    partial class frmDBAanalysis
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
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.lblSp = new DevExpress.XtraEditors.LabelControl();
            this.dtpEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtpBeg = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.cboLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Location = new System.Drawing.Point(448, 36);
            this.btnFind.LookAndFeel.SkinName = "Office 2013";
            this.btnFind.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(70, 24);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "查询";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblLine
            // 
            this.lblLine.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(13, 39);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(36, 17);
            this.lblLine.TabIndex = 0;
            this.lblLine.Text = "车队：";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.lblSp);
            this.groupControl1.Controls.Add(this.dtpEnd);
            this.groupControl1.Controls.Add(this.dtpBeg);
            this.groupControl1.Controls.Add(this.lblDate);
            this.groupControl1.Controls.Add(this.cboLine);
            this.groupControl1.Controls.Add(this.btnFind);
            this.groupControl1.Controls.Add(this.lblLine);
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(784, 72);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询条件";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Location = new System.Drawing.Point(524, 36);
            this.btnExport.LookAndFeel.SkinName = "Office 2013";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 24);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblSp
            // 
            this.lblSp.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSp.Location = new System.Drawing.Point(315, 39);
            this.lblSp.Name = "lblSp";
            this.lblSp.Size = new System.Drawing.Size(12, 17);
            this.lblSp.TabIndex = 4;
            this.lblSp.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.EditValue = null;
            this.dtpEnd.Location = new System.Drawing.Point(333, 36);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.Appearance.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpEnd.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.dtpEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpEnd.Size = new System.Drawing.Size(90, 24);
            this.dtpEnd.TabIndex = 5;
            // 
            // dtpBeg
            // 
            this.dtpBeg.EditValue = null;
            this.dtpBeg.Location = new System.Drawing.Point(219, 36);
            this.dtpBeg.Name = "dtpBeg";
            this.dtpBeg.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.Appearance.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpBeg.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBeg.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpBeg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBeg.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpBeg.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpBeg.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpBeg.Size = new System.Drawing.Size(90, 24);
            this.dtpBeg.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(177, 39);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 17);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "时间：";
            // 
            // cboLine
            // 
            this.cboLine.Location = new System.Drawing.Point(55, 36);
            this.cboLine.Name = "cboLine";
            this.cboLine.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.Appearance.Options.UseFont = true;
            this.cboLine.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboLine.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLine.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboLine.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLine.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLine.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboLine.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboLine.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboLine.Size = new System.Drawing.Size(100, 24);
            this.cboLine.TabIndex = 1;
            // 
            // gridList
            // 
            this.gridList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridList.Location = new System.Drawing.Point(8, 86);
            this.gridList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridList.MainView = this.dgvDetail;
            this.gridList.Name = "gridList";
            this.gridList.ShowOnlyPredefinedDetails = true;
            this.gridList.Size = new System.Drawing.Size(784, 319);
            this.gridList.TabIndex = 1;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.GridControl = this.gridList;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvDetail_CustomDrawRowIndicator);
            this.dgvDetail.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.dgvDetail_CustomDrawEmptyForeground);
            this.dgvDetail.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvDetail_CustomUnboundColumnData);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gridList);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 413);
            this.panelControl1.TabIndex = 0;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraScrollableControl1.Appearance.Options.UseFont = true;
            this.xtraScrollableControl1.Controls.Add(this.panelControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(800, 441);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // frmDBAanalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 441);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "frmDBAanalysis";
            this.Text = "驾驶行为分析";
            this.Load += new System.EventHandler(this.frmWarningDatail_Load);
            this.SizeChanged += new System.EventHandler(this.frmWarningDatail_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboLine;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl lblSp;
        private DevExpress.XtraEditors.DateEdit dtpEnd;
        private DevExpress.XtraEditors.DateEdit dtpBeg;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
    }
}