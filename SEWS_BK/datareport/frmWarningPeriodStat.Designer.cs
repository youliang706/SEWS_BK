namespace SEWS_BK.datareport
{
    partial class frmWarningPeriodStat
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.XYDiagramPane xyDiagramPane1 = new DevExpress.XtraCharts.XYDiagramPane();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView2 = new DevExpress.XtraCharts.AreaSeriesView();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView3 = new DevExpress.XtraCharts.AreaSeriesView();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblSp = new DevExpress.XtraEditors.LabelControl();
            this.dtpEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtpBeg = new DevExpress.XtraEditors.DateEdit();
            this.cboLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.mnuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuArea = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chartView = new DevExpress.XtraCharts.ChartControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).BeginInit();
            this.mnuChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagramPane1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView3)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.Location = new System.Drawing.Point(520, 36);
            this.btnPreview.LookAndFeel.SkinName = "Office 2013";
            this.btnPreview.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(70, 24);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Location = new System.Drawing.Point(444, 36);
            this.btnFind.LookAndFeel.SkinName = "Office 2013";
            this.btnFind.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(70, 24);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "查询";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnPreview);
            this.groupControl1.Controls.Add(this.btnFind);
            this.groupControl1.Controls.Add(this.lblSp);
            this.groupControl1.Controls.Add(this.dtpEnd);
            this.groupControl1.Controls.Add(this.dtpBeg);
            this.groupControl1.Controls.Add(this.cboLine);
            this.groupControl1.Controls.Add(this.lblTime);
            this.groupControl1.Controls.Add(this.lblLine);
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(784, 72);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询条件";
            // 
            // lblSp
            // 
            this.lblSp.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSp.Location = new System.Drawing.Point(318, 39);
            this.lblSp.Name = "lblSp";
            this.lblSp.Size = new System.Drawing.Size(12, 17);
            this.lblSp.TabIndex = 4;
            this.lblSp.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.EditValue = null;
            this.dtpEnd.Location = new System.Drawing.Point(336, 36);
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
            this.dtpEnd.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpEnd.Size = new System.Drawing.Size(90, 24);
            this.dtpEnd.TabIndex = 5;
            // 
            // dtpBeg
            // 
            this.dtpBeg.EditValue = null;
            this.dtpBeg.Location = new System.Drawing.Point(222, 36);
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
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // lblTime
            // 
            this.lblTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(180, 39);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(36, 17);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "时间：";
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
            // mnuBar
            // 
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(112, 22);
            this.mnuBar.Text = "柱形图";
            // 
            // mnuLine
            // 
            this.mnuLine.Name = "mnuLine";
            this.mnuLine.Size = new System.Drawing.Size(112, 22);
            this.mnuLine.Text = "折线图";
            // 
            // mnuChart
            // 
            this.mnuChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLine,
            this.mnuBar,
            this.mnuArea});
            this.mnuChart.Name = "mnuChart";
            this.mnuChart.Size = new System.Drawing.Size(113, 70);
            this.mnuChart.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuChart_ItemClicked);
            // 
            // mnuArea
            // 
            this.mnuArea.Name = "mnuArea";
            this.mnuArea.Size = new System.Drawing.Size(112, 22);
            this.mnuArea.Text = "面积图";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.chartView);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 413);
            this.panelControl1.TabIndex = 0;
            // 
            // chartView
            // 
            this.chartView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartView.ContextMenuStrip = this.mnuChart;
            this.chartView.Cursor = System.Windows.Forms.Cursors.Default;
            this.chartView.DataBindings = null;
            xyDiagram1.AxisX.Tickmarks.MinorVisible = false;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "0";
            xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisX.WholeRange.SideMarginsValue = 0D;
            xyDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1;0";
            xyDiagramPane1.Name = "Pane 1";
            xyDiagramPane1.PaneID = 0;
            xyDiagram1.Panes.AddRange(new DevExpress.XtraCharts.XYDiagramPane[] {
            xyDiagramPane1});
            this.chartView.Diagram = xyDiagram1;
            this.chartView.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartView.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartView.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartView.Legend.EquallySpacedItems = false;
            this.chartView.Legend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chartView.Legend.Name = "Default Legend";
            this.chartView.Location = new System.Drawing.Point(8, 86);
            this.chartView.Name = "chartView";
            this.chartView.PaletteName = "Palette 1";
            this.chartView.PaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(85)))), ((int)(((byte)(222)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(188)))), ((int)(((byte)(48))))), System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(188)))), ((int)(((byte)(48)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Purple, System.Drawing.Color.Purple),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(57)))), ((int)(((byte)(35))))), System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(57)))), ((int)(((byte)(35)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(142)))), ((int)(((byte)(0))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(142)))), ((int)(((byte)(0)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(167))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(167)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(0)))), ((int)(((byte)(32))))), System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(0)))), ((int)(((byte)(32))))))}));
            series1.Name = "Series 1";
            series1.View = areaSeriesView1;
            series2.Name = "Series 2";
            areaSeriesView2.PaneName = "Pane 1";
            series2.View = areaSeriesView2;
            this.chartView.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            areaSeriesView3.Transparency = ((byte)(0));
            this.chartView.SeriesTemplate.View = areaSeriesView3;
            this.chartView.Size = new System.Drawing.Size(784, 319);
            this.chartView.TabIndex = 2;
            this.chartView.SizeChanged += new System.EventHandler(this.chartView_SizeChanged);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraScrollableControl1.Appearance.Options.UseFont = true;
            this.xtraScrollableControl1.Controls.Add(this.panelControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(813, 443);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // frmWarningPeriodStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 443);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "frmWarningPeriodStat";
            this.Text = "时段报警统计";
            this.Load += new System.EventHandler(this.frmPeccancyTrend_Load);
            this.SizeChanged += new System.EventHandler(this.frmPeccancyTrend_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).EndInit();
            this.mnuChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagramPane1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblSp;
        private DevExpress.XtraEditors.DateEdit dtpEnd;
        private DevExpress.XtraEditors.DateEdit dtpBeg;
        private DevExpress.XtraEditors.ComboBoxEdit cboLine;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private System.Windows.Forms.ToolStripMenuItem mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuLine;
        private System.Windows.Forms.ContextMenuStrip mnuChart;
        private System.Windows.Forms.ToolStripMenuItem mnuArea;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraCharts.ChartControl chartView;
    }
}