namespace SEWS_BK.evaluatesys
{
    partial class frmBehaviorAnalysis
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
            DevExpress.XtraCharts.RadarDiagram radarDiagram1 = new DevExpress.XtraCharts.RadarDiagram();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem1 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem2 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("驾驶员经验", new object[] {
            ((object)(6.5D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("工作量", new object[] {
            ((object)(7.5D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("车辆运行时间", new object[] {
            ((object)(6D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("行为习惯频次", new object[] {
            ((object)(7.5D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("严重程度", new object[] {
            ((object)(7.5D))});
            DevExpress.XtraCharts.RadarAreaSeriesView radarAreaSeriesView1 = new DevExpress.XtraCharts.RadarAreaSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("驾驶员经验", new object[] {
            ((object)(5D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint("工作量", new object[] {
            ((object)(8D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint("车辆运行时间", new object[] {
            ((object)(8D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint9 = new DevExpress.XtraCharts.SeriesPoint("行为习惯频次", new object[] {
            ((object)(6D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint("严重程度", new object[] {
            ((object)(6D))});
            DevExpress.XtraCharts.RadarAreaSeriesView radarAreaSeriesView2 = new DevExpress.XtraCharts.RadarAreaSeriesView();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chartView = new DevExpress.XtraCharts.ChartControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(radarDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(radarAreaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(radarAreaSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.chartView);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(884, 561);
            this.panelControl1.TabIndex = 0;
            // 
            // chartView
            // 
            this.chartView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartView.Cursor = System.Windows.Forms.Cursors.Default;
            this.chartView.DataBindings = null;
            radarDiagram1.AxisX.Label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radarDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
            radarDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            radarDiagram1.AxisX.WholeRange.SideMarginsValue = 0D;
            radarDiagram1.AxisY.Visible = false;
            radarDiagram1.BorderColor = System.Drawing.Color.DimGray;
            radarDiagram1.DrawingStyle = DevExpress.XtraCharts.RadarDiagramDrawingStyle.Polygon;
            radarDiagram1.RotationDirection = DevExpress.XtraCharts.RadarDiagramRotationDirection.Clockwise;
            this.chartView.Diagram = radarDiagram1;
            customLegendItem1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(223)))), ((int)(((byte)(158)))));
            customLegendItem1.Name = "个人指标";
            customLegendItem2.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(175)))), ((int)(((byte)(239)))));
            customLegendItem2.Name = "平均指标";
            this.chartView.Legend.CustomItems.AddRange(new DevExpress.XtraCharts.CustomLegendItem[] {
            customLegendItem1,
            customLegendItem2});
            this.chartView.Legend.EquallySpacedItems = false;
            this.chartView.Legend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chartView.Legend.Name = "Default Legend";
            this.chartView.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartView.Location = new System.Drawing.Point(8, 7);
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
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5});
            radarAreaSeriesView1.ColorEach = true;
            radarAreaSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.View = radarAreaSeriesView1;
            series2.LegendName = "Default Legend";
            series2.Name = "Series 2";
            series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint6,
            seriesPoint7,
            seriesPoint8,
            seriesPoint9,
            seriesPoint10});
            radarAreaSeriesView2.ColorEach = true;
            radarAreaSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
            series2.View = radarAreaSeriesView2;
            this.chartView.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            areaSeriesView1.Transparency = ((byte)(0));
            this.chartView.SeriesTemplate.View = areaSeriesView1;
            this.chartView.Size = new System.Drawing.Size(868, 547);
            this.chartView.TabIndex = 2;
            chartTitle1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Text = "驾驶员评价";
            this.chartView.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraScrollableControl1.Appearance.Options.UseFont = true;
            this.xtraScrollableControl1.Controls.Add(this.panelControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(884, 561);
            this.xtraScrollableControl1.TabIndex = 3;
            // 
            // frmBehaviorAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.xtraScrollableControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBehaviorAnalysis";
            this.Text = "驾驶员行为分析";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(radarDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(radarAreaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(radarAreaSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartView)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraCharts.ChartControl chartView;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
    }
}