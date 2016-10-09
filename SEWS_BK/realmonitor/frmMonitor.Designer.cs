namespace SEWS_BK.realmonitor
{
    partial class frmMonitor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitor));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ttMsg = new System.Windows.Forms.ToolTip(this.components);
            this.tipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.pnlCase = new System.Windows.Forms.Panel();
            this.pnlWarning = new DevExpress.XtraEditors.PanelControl();
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlList = new DevExpress.XtraEditors.PanelControl();
            this.lstTree = new DevExpress.XtraTreeList.TreeList();
            this.colTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pnlSearch = new DevExpress.XtraEditors.PanelControl();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.lblSearch = new DevExpress.XtraEditors.LabelControl();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.mnuBusInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemSendAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSpBus = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRemoveBus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAll = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemShowAllUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHideAllUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemShowAllDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHideAllDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLineInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemShowUpLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHideUpLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemShowDownLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHideDownLine = new System.Windows.Forms.ToolStripMenuItem();
            this.xtraScrollableControl1.SuspendLayout();
            this.pnlCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWarning)).BeginInit();
            this.pnlWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlList)).BeginInit();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.mnuBusInfo.SuspendLayout();
            this.mnuAll.SuspendLayout();
            this.mnuLineInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "项目2.ico");
            this.imageList1.Images.SetKeyName(1, "Bus.png");
            this.imageList1.Images.SetKeyName(2, "Bus1.png");
            this.imageList1.Images.SetKeyName(3, "Bus2.png");
            this.imageList1.Images.SetKeyName(4, "Bus3.png");
            this.imageList1.Images.SetKeyName(5, "透明.png");
            // 
            // tmrDelay
            // 
            this.tmrDelay.Interval = 5000;
            this.tmrDelay.Tick += new System.EventHandler(this.tmrDelay_Tick);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xtraScrollableControl1.Appearance.Options.UseBorderColor = true;
            this.xtraScrollableControl1.Controls.Add(this.pnlCase);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(945, 476);
            this.xtraScrollableControl1.TabIndex = 3;
            // 
            // pnlCase
            // 
            this.pnlCase.Controls.Add(this.pnlWarning);
            this.pnlCase.Controls.Add(this.pnlList);
            this.pnlCase.Controls.Add(this.pnlSearch);
            this.pnlCase.Controls.Add(this.gmap);
            this.pnlCase.Location = new System.Drawing.Point(0, 0);
            this.pnlCase.Name = "pnlCase";
            this.pnlCase.Size = new System.Drawing.Size(900, 450);
            this.pnlCase.TabIndex = 14;
            // 
            // pnlWarning
            // 
            this.pnlWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWarning.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlWarning.Appearance.Options.UseBackColor = true;
            this.pnlWarning.Controls.Add(this.gridList);
            this.pnlWarning.Location = new System.Drawing.Point(8, 354);
            this.pnlWarning.LookAndFeel.SkinName = "Office 2013";
            this.pnlWarning.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(695, 88);
            this.pnlWarning.TabIndex = 16;
            // 
            // gridList
            // 
            this.gridList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridList.Location = new System.Drawing.Point(2, 2);
            this.gridList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridList.MainView = this.dgvDetail;
            this.gridList.Name = "gridList";
            this.gridList.ShowOnlyPredefinedDetails = true;
            this.gridList.Size = new System.Drawing.Size(691, 84);
            this.gridList.TabIndex = 22;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dgvDetail.GridControl = this.gridList;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.OptionsView.ShowGroupPanel = false;
            this.dgvDetail.OptionsView.ShowIndicator = false;
            // 
            // pnlList
            // 
            this.pnlList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlList.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlList.Appearance.Options.UseBackColor = true;
            this.pnlList.Controls.Add(this.lstTree);
            this.pnlList.Location = new System.Drawing.Point(712, 8);
            this.pnlList.LookAndFeel.SkinName = "Office 2013";
            this.pnlList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(180, 339);
            this.pnlList.TabIndex = 15;
            // 
            // lstTree
            // 
            this.lstTree.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.lstTree.Appearance.FocusedCell.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.lstTree.Appearance.FocusedCell.Options.UseFont = true;
            this.lstTree.Appearance.FocusedRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTree.Appearance.FocusedRow.Options.UseFont = true;
            this.lstTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.lstTree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.lstTree.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTree.Appearance.Row.Options.UseFont = true;
            this.lstTree.Appearance.SelectedRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTree.Appearance.SelectedRow.Options.UseFont = true;
            this.lstTree.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lstTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTree,
            this.colKey,
            this.colLevel});
            this.lstTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstTree.Location = new System.Drawing.Point(2, 2);
            this.lstTree.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lstTree.Name = "lstTree";
            this.lstTree.OptionsBehavior.Editable = false;
            this.lstTree.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.lstTree.OptionsView.ShowCheckBoxes = true;
            this.lstTree.OptionsView.ShowHorzLines = false;
            this.lstTree.OptionsView.ShowIndicator = false;
            this.lstTree.OptionsView.ShowVertLines = false;
            this.lstTree.Size = new System.Drawing.Size(176, 335);
            this.lstTree.StateImageList = this.imageList1;
            this.lstTree.TabIndex = 14;
            this.lstTree.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.lstTree_BeforeCheckNode);
            this.lstTree.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.lstTree_AfterCheckNode);
            this.lstTree.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.lstTree_CustomDrawNodeCell);
            this.lstTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTree_MouseDoubleClick);
            this.lstTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTree_MouseDown);
            // 
            // colTree
            // 
            this.colTree.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTree.AppearanceHeader.Options.UseFont = true;
            this.colTree.Caption = "车辆";
            this.colTree.FieldName = "BUSNUMBER";
            this.colTree.MinWidth = 52;
            this.colTree.Name = "colTree";
            this.colTree.Visible = true;
            this.colTree.VisibleIndex = 0;
            // 
            // colKey
            // 
            this.colKey.Caption = "ID";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            // 
            // colLevel
            // 
            this.colLevel.Caption = "Level";
            this.colLevel.FieldName = "Level";
            this.colLevel.Name = "colLevel";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Appearance.Options.UseBackColor = true;
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(8, 8);
            this.pnlSearch.LookAndFeel.SkinName = "Office 2013";
            this.pnlSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(300, 60);
            this.pnlSearch.TabIndex = 14;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(82, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txtSearch.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtSearch.Properties.LookAndFeel.SkinName = "VS2010";
            this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSearch.Size = new System.Drawing.Size(200, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(16, 24);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(60, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "快速定位：";
            // 
            // gmap
            // 
            this.gmap.BackColor = System.Drawing.Color.SteelBlue;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 6;
            this.gmap.MinZoom = 6;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.Empty;
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(900, 450);
            this.gmap.TabIndex = 2;
            this.gmap.Zoom = 0D;
            this.gmap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gmap_OnMapZoomChanged);
            // 
            // mnuBusInfo
            // 
            this.mnuBusInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSendAudio,
            this.toolStripSpBus,
            this.mnuItemRemoveBus});
            this.mnuBusInfo.Name = "contextMenuStripBusInfo";
            this.mnuBusInfo.Size = new System.Drawing.Size(185, 54);
            // 
            // mnuItemSendAudio
            // 
            this.mnuItemSendAudio.Name = "mnuItemSendAudio";
            this.mnuItemSendAudio.Size = new System.Drawing.Size(184, 22);
            this.mnuItemSendAudio.Text = "语音下发（单辆车）";
            // 
            // toolStripSpBus
            // 
            this.toolStripSpBus.Name = "toolStripSpBus";
            this.toolStripSpBus.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuItemRemoveBus
            // 
            this.mnuItemRemoveBus.Name = "mnuItemRemoveBus";
            this.mnuItemRemoveBus.Size = new System.Drawing.Size(184, 22);
            this.mnuItemRemoveBus.Text = "移除车辆";
            // 
            // mnuAll
            // 
            this.mnuAll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemShowAllUp,
            this.mnuItemHideAllUp,
            this.mnuItemShowAllDown,
            this.mnuItemHideAllDown});
            this.mnuAll.Name = "contextMenuStripAll";
            this.mnuAll.Size = new System.Drawing.Size(173, 92);
            // 
            // mnuItemShowAllUp
            // 
            this.mnuItemShowAllUp.Name = "mnuItemShowAllUp";
            this.mnuItemShowAllUp.Size = new System.Drawing.Size(172, 22);
            this.mnuItemShowAllUp.Text = "显示所有上行线路";
            this.mnuItemShowAllUp.Click += new System.EventHandler(this.mnuItemShowAllUp_Click);
            // 
            // mnuItemHideAllUp
            // 
            this.mnuItemHideAllUp.Name = "mnuItemHideAllUp";
            this.mnuItemHideAllUp.Size = new System.Drawing.Size(172, 22);
            this.mnuItemHideAllUp.Text = "隐藏所有上行线路";
            this.mnuItemHideAllUp.Click += new System.EventHandler(this.mnuItemHideAllUp_Click);
            // 
            // mnuItemShowAllDown
            // 
            this.mnuItemShowAllDown.Name = "mnuItemShowAllDown";
            this.mnuItemShowAllDown.Size = new System.Drawing.Size(172, 22);
            this.mnuItemShowAllDown.Text = "显示所有下行线路";
            this.mnuItemShowAllDown.Click += new System.EventHandler(this.mnuItemShowAllDown_Click);
            // 
            // mnuItemHideAllDown
            // 
            this.mnuItemHideAllDown.Name = "mnuItemHideAllDown";
            this.mnuItemHideAllDown.Size = new System.Drawing.Size(172, 22);
            this.mnuItemHideAllDown.Text = "隐藏所有下行线路";
            this.mnuItemHideAllDown.Click += new System.EventHandler(this.mnuItemHideAllDown_Click);
            // 
            // mnuLineInfo
            // 
            this.mnuLineInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemShowUpLine,
            this.mnuItemHideUpLine,
            this.mnuItemShowDownLine,
            this.mnuItemHideDownLine});
            this.mnuLineInfo.Name = "contextMenuStripLineInfo";
            this.mnuLineInfo.Size = new System.Drawing.Size(149, 92);
            // 
            // mnuItemShowUpLine
            // 
            this.mnuItemShowUpLine.Name = "mnuItemShowUpLine";
            this.mnuItemShowUpLine.Size = new System.Drawing.Size(148, 22);
            this.mnuItemShowUpLine.Text = "显示上行线路";
            this.mnuItemShowUpLine.Click += new System.EventHandler(this.mnuItemShowUpLine_Click);
            // 
            // mnuItemHideUpLine
            // 
            this.mnuItemHideUpLine.Name = "mnuItemHideUpLine";
            this.mnuItemHideUpLine.Size = new System.Drawing.Size(148, 22);
            this.mnuItemHideUpLine.Text = "隐藏上行线路";
            this.mnuItemHideUpLine.Click += new System.EventHandler(this.mnuItemHideUpLine_Click);
            // 
            // mnuItemShowDownLine
            // 
            this.mnuItemShowDownLine.Name = "mnuItemShowDownLine";
            this.mnuItemShowDownLine.Size = new System.Drawing.Size(148, 22);
            this.mnuItemShowDownLine.Text = "显示下行线路";
            this.mnuItemShowDownLine.Click += new System.EventHandler(this.mnuItemShowDownLine_Click);
            // 
            // mnuItemHideDownLine
            // 
            this.mnuItemHideDownLine.Name = "mnuItemHideDownLine";
            this.mnuItemHideDownLine.Size = new System.Drawing.Size(148, 22);
            this.mnuItemHideDownLine.Text = "隐藏下行线路";
            this.mnuItemHideDownLine.Click += new System.EventHandler(this.mnuItemHideDownLine_Click);
            // 
            // frmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(945, 476);
            this.Controls.Add(this.xtraScrollableControl1);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "frmMonitor";
            this.Text = "地图监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMonitor_FormClosing);
            this.SizeChanged += new System.EventHandler(this.frmMonitor_SizeChanged);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.pnlCase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlWarning)).EndInit();
            this.pnlWarning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlList)).EndInit();
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.mnuBusInfo.ResumeLayout(false);
            this.mnuAll.ResumeLayout(false);
            this.mnuLineInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip ttMsg;
        private System.Windows.Forms.ToolTip tipInfo;
        private System.Windows.Forms.Timer tmrDelay;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.ContextMenuStrip mnuBusInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSendAudio;
        private System.Windows.Forms.ToolStripSeparator toolStripSpBus;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRemoveBus;
        private System.Windows.Forms.ContextMenuStrip mnuAll;
        private System.Windows.Forms.ToolStripMenuItem mnuItemShowAllUp;
        private System.Windows.Forms.ToolStripMenuItem mnuItemShowAllDown;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHideAllUp;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHideAllDown;
        private System.Windows.Forms.ContextMenuStrip mnuLineInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuItemShowUpLine;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHideUpLine;
        private System.Windows.Forms.ToolStripMenuItem mnuItemShowDownLine;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHideDownLine;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Panel pnlCase;
        private DevExpress.XtraEditors.PanelControl pnlSearch;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraEditors.LabelControl lblSearch;
        private DevExpress.XtraEditors.PanelControl pnlList;
        private DevExpress.XtraTreeList.TreeList lstTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKey;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLevel;
        private DevExpress.XtraEditors.PanelControl pnlWarning;
        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
    }
}

