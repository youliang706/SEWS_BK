namespace SEWS_BK.realmonitor
{
    partial class frmPlayback
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
            this.pnlCtrl = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlVedio = new DevExpress.XtraEditors.PanelControl();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trackBarProgress = new DevExpress.XtraEditors.TrackBarControl();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBarSpeed = new DevExpress.XtraEditors.TrackBarControl();
            this.tsWarningPause = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsTrackingLine = new DevExpress.XtraEditors.ToggleSwitch();
            this.btnPlayback = new DevExpress.XtraEditors.SimpleButton();
            this.btnRePlayback = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.dtpEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.dtpStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblDistence = new System.Windows.Forms.Label();
            this.lstBus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnExp = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.cboBusSelected = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSp = new System.Windows.Forms.Label();
            this.mnuMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideList = new System.Windows.Forms.ToolStripMenuItem();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.gridList = new DevExpress.XtraGrid.GridControl();
            this.dgvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.pnlParam = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSetting = new DevExpress.XtraEditors.PanelControl();
            this.lblMile = new System.Windows.Forms.Label();
            this.lblSel = new System.Windows.Forms.Label();
            this.lblBus = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVedio)).BeginInit();
            this.pnlVedio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsWarningPause.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsTrackingLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusSelected.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).BeginInit();
            this.mnuMap.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.pnlParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSetting)).BeginInit();
            this.pnlSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCtrl
            // 
            this.pnlCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCtrl.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlCtrl.Controls.Add(this.label4);
            this.pnlCtrl.Controls.Add(this.pnlVedio);
            this.pnlCtrl.Location = new System.Drawing.Point(697, 351);
            this.pnlCtrl.Name = "pnlCtrl";
            this.pnlCtrl.Size = new System.Drawing.Size(256, 242);
            this.pnlCtrl.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "播放控制";
            // 
            // pnlVedio
            // 
            this.pnlVedio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVedio.Controls.Add(this.lblProgress);
            this.pnlVedio.Controls.Add(this.lblSpeed);
            this.pnlVedio.Controls.Add(this.trackBarProgress);
            this.pnlVedio.Controls.Add(this.label9);
            this.pnlVedio.Controls.Add(this.label8);
            this.pnlVedio.Controls.Add(this.trackBarSpeed);
            this.pnlVedio.Controls.Add(this.tsWarningPause);
            this.pnlVedio.Controls.Add(this.tsTrackingLine);
            this.pnlVedio.Controls.Add(this.btnPlayback);
            this.pnlVedio.Controls.Add(this.btnRePlayback);
            this.pnlVedio.Controls.Add(this.label11);
            this.pnlVedio.Controls.Add(this.label12);
            this.pnlVedio.Location = new System.Drawing.Point(0, 32);
            this.pnlVedio.LookAndFeel.SkinName = "Office 2013";
            this.pnlVedio.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlVedio.Name = "pnlVedio";
            this.pnlVedio.Size = new System.Drawing.Size(256, 210);
            this.pnlVedio.TabIndex = 23;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblProgress.Location = new System.Drawing.Point(207, 60);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(26, 17);
            this.lblProgress.TabIndex = 23;
            this.lblProgress.Text = "0%";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblSpeed.Location = new System.Drawing.Point(207, 15);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(37, 17);
            this.lblSpeed.TabIndex = 22;
            this.lblSpeed.Text = "0.1秒";
            // 
            // trackBarProgress
            // 
            this.trackBarProgress.EditValue = null;
            this.trackBarProgress.Location = new System.Drawing.Point(46, 55);
            this.trackBarProgress.Name = "trackBarProgress";
            this.trackBarProgress.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.trackBarProgress.Properties.Maximum = 100;
            this.trackBarProgress.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarProgress.Size = new System.Drawing.Size(155, 45);
            this.trackBarProgress.TabIndex = 14;
            this.trackBarProgress.EditValueChanged += new System.EventHandler(this.trackBarProgress_EditValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "报警自动暂停";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "显示行驶轨迹";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.EditValue = 10;
            this.trackBarSpeed.Location = new System.Drawing.Point(46, 10);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.trackBarSpeed.Properties.Minimum = 1;
            this.trackBarSpeed.Size = new System.Drawing.Size(155, 45);
            this.trackBarSpeed.TabIndex = 9;
            this.trackBarSpeed.Value = 10;
            this.trackBarSpeed.EditValueChanged += new System.EventHandler(this.trackBarSpeed_EditValueChanged);
            // 
            // tsWarningPause
            // 
            this.tsWarningPause.Location = new System.Drawing.Point(120, 133);
            this.tsWarningPause.Name = "tsWarningPause";
            this.tsWarningPause.Properties.AutoWidth = true;
            this.tsWarningPause.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tsWarningPause.Properties.OffText = "off";
            this.tsWarningPause.Properties.OnText = "on";
            this.tsWarningPause.Size = new System.Drawing.Size(93, 25);
            this.tsWarningPause.TabIndex = 7;
            this.tsWarningPause.Toggled += new System.EventHandler(this.tsWarningPause_Toggled);
            // 
            // tsTrackingLine
            // 
            this.tsTrackingLine.Location = new System.Drawing.Point(120, 101);
            this.tsTrackingLine.Name = "tsTrackingLine";
            this.tsTrackingLine.Properties.AutoWidth = true;
            this.tsTrackingLine.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tsTrackingLine.Properties.OffText = "off";
            this.tsTrackingLine.Properties.OnText = "on";
            this.tsTrackingLine.Size = new System.Drawing.Size(93, 25);
            this.tsTrackingLine.TabIndex = 6;
            this.tsTrackingLine.Toggled += new System.EventHandler(this.tsTrackingLine_Toggled);
            // 
            // btnPlayback
            // 
            this.btnPlayback.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayback.Appearance.Options.UseFont = true;
            this.btnPlayback.Location = new System.Drawing.Point(104, 175);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(85, 24);
            this.btnPlayback.TabIndex = 3;
            this.btnPlayback.Text = "播放";
            this.btnPlayback.Click += new System.EventHandler(this.btnPlayback_Click);
            // 
            // btnRePlayback
            // 
            this.btnRePlayback.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRePlayback.Appearance.Options.UseFont = true;
            this.btnRePlayback.Location = new System.Drawing.Point(11, 175);
            this.btnRePlayback.Name = "btnRePlayback";
            this.btnRePlayback.Size = new System.Drawing.Size(85, 24);
            this.btnRePlayback.TabIndex = 2;
            this.btnRePlayback.Text = "重放";
            this.btnRePlayback.Click += new System.EventHandler(this.btnRePlayback_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "进度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "速率";
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = new System.DateTime(2016, 6, 23, 14, 18, 57, 0);
            this.dtpDate.Location = new System.Drawing.Point(46, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.Appearance.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpDate.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpDate.Size = new System.Drawing.Size(100, 24);
            this.dtpDate.TabIndex = 25;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpEndTime.Location = new System.Drawing.Point(159, 44);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Properties.Appearance.Options.UseFont = true;
            this.dtpEndTime.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpEndTime.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEndTime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.dtpEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpEndTime.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.dtpEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpEndTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpEndTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpEndTime.Properties.Mask.EditMask = "HH:mm:ss";
            this.dtpEndTime.Size = new System.Drawing.Size(85, 24);
            this.dtpEndTime.TabIndex = 24;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.EditValue = new System.DateTime(2016, 6, 28, 0, 0, 0, 0);
            this.dtpStartTime.Location = new System.Drawing.Point(46, 44);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Properties.Appearance.Options.UseFont = true;
            this.dtpStartTime.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtpStartTime.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtpStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStartTime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.dtpStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpStartTime.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.dtpStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpStartTime.Properties.LookAndFeel.SkinName = "Office 2013";
            this.dtpStartTime.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpStartTime.Properties.Mask.EditMask = "HH:mm:ss";
            this.dtpStartTime.Size = new System.Drawing.Size(85, 24);
            this.dtpStartTime.TabIndex = 23;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblRecords.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblRecords.Location = new System.Drawing.Point(112, 275);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(44, 17);
            this.lblRecords.TabIndex = 22;
            this.lblRecords.Text = "无记录";
            // 
            // lblDistence
            // 
            this.lblDistence.AutoSize = true;
            this.lblDistence.BackColor = System.Drawing.Color.Transparent;
            this.lblDistence.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistence.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblDistence.Location = new System.Drawing.Point(193, 170);
            this.lblDistence.Name = "lblDistence";
            this.lblDistence.Size = new System.Drawing.Size(34, 17);
            this.lblDistence.TabIndex = 21;
            this.lblDistence.Text = "0Km";
            // 
            // lstBus
            // 
            this.lstBus.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBus.Appearance.Options.UseFont = true;
            this.lstBus.CheckOnClick = true;
            this.lstBus.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstBus.Location = new System.Drawing.Point(47, 108);
            this.lstBus.Name = "lstBus";
            this.lstBus.Size = new System.Drawing.Size(100, 154);
            this.lstBus.TabIndex = 18;
            // 
            // btnExp
            // 
            this.btnExp.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExp.Appearance.Options.UseFont = true;
            this.btnExp.Location = new System.Drawing.Point(160, 238);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(85, 24);
            this.btnExp.TabIndex = 17;
            this.btnExp.Text = "导出Excel";
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Appearance.Options.UseFont = true;
            this.btnQuery.Location = new System.Drawing.Point(11, 271);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(85, 24);
            this.btnQuery.TabIndex = 16;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboBusSelected
            // 
            this.cboBusSelected.EditValue = "";
            this.cboBusSelected.Location = new System.Drawing.Point(160, 131);
            this.cboBusSelected.Name = "cboBusSelected";
            this.cboBusSelected.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusSelected.Properties.Appearance.Options.UseFont = true;
            this.cboBusSelected.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusSelected.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboBusSelected.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusSelected.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBusSelected.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusSelected.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboBusSelected.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusSelected.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboBusSelected.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBusSelected.Properties.LookAndFeel.SkinName = "Office 2013";
            this.cboBusSelected.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cboBusSelected.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBusSelected.Size = new System.Drawing.Size(85, 24);
            this.cboBusSelected.TabIndex = 15;
            this.cboBusSelected.SelectedIndexChanged += new System.EventHandler(this.cboBusSelected_SelectedIndexChanged);
            // 
            // cboLine
            // 
            this.cboLine.Location = new System.Drawing.Point(47, 76);
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
            this.cboLine.TabIndex = 13;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // lblSp
            // 
            this.lblSp.AutoSize = true;
            this.lblSp.BackColor = System.Drawing.Color.Transparent;
            this.lblSp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSp.Location = new System.Drawing.Point(136, 47);
            this.lblSp.Name = "lblSp";
            this.lblSp.Size = new System.Drawing.Size(20, 17);
            this.lblSp.TabIndex = 12;
            this.lblSp.Text = "至";
            // 
            // mnuMap
            // 
            this.mnuMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowList,
            this.mnuHideList});
            this.mnuMap.Name = "mnuMap";
            this.mnuMap.Size = new System.Drawing.Size(149, 48);
            // 
            // mnuShowList
            // 
            this.mnuShowList.Name = "mnuShowList";
            this.mnuShowList.Size = new System.Drawing.Size(148, 22);
            this.mnuShowList.Text = "显示轨迹列表";
            this.mnuShowList.Click += new System.EventHandler(this.mnuShowList_Click);
            // 
            // mnuHideList
            // 
            this.mnuHideList.Name = "mnuHideList";
            this.mnuHideList.Size = new System.Drawing.Size(148, 22);
            this.mnuHideList.Text = "隐藏轨迹列表";
            this.mnuHideList.Visible = false;
            this.mnuHideList.Click += new System.EventHandler(this.mnuHideList_Click);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.panelMain);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(985, 665);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.pnlDgv);
            this.panelMain.Controls.Add(this.gmap);
            this.panelMain.Controls.Add(this.pnlParam);
            this.panelMain.Controls.Add(this.pnlCtrl);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(960, 600);
            this.panelMain.TabIndex = 2;
            // 
            // pnlDgv
            // 
            this.pnlDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDgv.Controls.Add(this.gridList);
            this.pnlDgv.Location = new System.Drawing.Point(7, 407);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(684, 186);
            this.pnlDgv.TabIndex = 25;
            // 
            // gridList
            // 
            this.gridList.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.Location = new System.Drawing.Point(0, 0);
            this.gridList.MainView = this.dgvDetail;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(684, 186);
            this.gridList.TabIndex = 25;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetail});
            // 
            // dgvDetail
            // 
            this.dgvDetail.GridControl = this.gridList;
            this.dgvDetail.IndicatorWidth = 32;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.OptionsCustomization.AllowSort = false;
            this.dgvDetail.OptionsMenu.EnableColumnMenu = false;
            this.dgvDetail.OptionsView.ShowGroupPanel = false;
            this.dgvDetail.OptionsView.ShowIndicator = false;
            this.dgvDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvDetail_FocusedRowChanged);
            // 
            // gmap
            // 
            this.gmap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gmap.Bearing = 0F;
            this.gmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gmap.CanDragMap = true;
            this.gmap.ContextMenuStrip = this.mnuMap;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(7, 7);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(684, 394);
            this.gmap.TabIndex = 10;
            this.gmap.Zoom = 0D;
            this.gmap.OnPositionChanged += new GMap.NET.PositionChanged(this.gmap_OnPositionChanged);
            this.gmap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.gmap_OnMapZoomChanged);
            this.gmap.SizeChanged += new System.EventHandler(this.gmap_SizeChanged);
            // 
            // pnlParam
            // 
            this.pnlParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParam.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlParam.Controls.Add(this.label1);
            this.pnlParam.Controls.Add(this.pnlSetting);
            this.pnlParam.Location = new System.Drawing.Point(697, 7);
            this.pnlParam.Name = "pnlParam";
            this.pnlParam.Size = new System.Drawing.Size(256, 338);
            this.pnlParam.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "回放参数设置";
            // 
            // pnlSetting
            // 
            this.pnlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSetting.Controls.Add(this.dtpDate);
            this.pnlSetting.Controls.Add(this.dtpEndTime);
            this.pnlSetting.Controls.Add(this.dtpStartTime);
            this.pnlSetting.Controls.Add(this.lblRecords);
            this.pnlSetting.Controls.Add(this.lblDistence);
            this.pnlSetting.Controls.Add(this.lstBus);
            this.pnlSetting.Controls.Add(this.btnExp);
            this.pnlSetting.Controls.Add(this.btnQuery);
            this.pnlSetting.Controls.Add(this.cboBusSelected);
            this.pnlSetting.Controls.Add(this.cboLine);
            this.pnlSetting.Controls.Add(this.lblSp);
            this.pnlSetting.Controls.Add(this.lblMile);
            this.pnlSetting.Controls.Add(this.lblSel);
            this.pnlSetting.Controls.Add(this.lblBus);
            this.pnlSetting.Controls.Add(this.lblLine);
            this.pnlSetting.Controls.Add(this.lblTime);
            this.pnlSetting.Controls.Add(this.lblDate);
            this.pnlSetting.Location = new System.Drawing.Point(0, 32);
            this.pnlSetting.LookAndFeel.SkinName = "Office 2013";
            this.pnlSetting.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(256, 306);
            this.pnlSetting.TabIndex = 21;
            // 
            // lblMile
            // 
            this.lblMile.AutoSize = true;
            this.lblMile.BackColor = System.Drawing.Color.Transparent;
            this.lblMile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMile.Location = new System.Drawing.Point(157, 170);
            this.lblMile.Name = "lblMile";
            this.lblMile.Size = new System.Drawing.Size(44, 17);
            this.lblMile.TabIndex = 10;
            this.lblMile.Text = "里程：";
            // 
            // lblSel
            // 
            this.lblSel.AutoSize = true;
            this.lblSel.BackColor = System.Drawing.Color.Transparent;
            this.lblSel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSel.Location = new System.Drawing.Point(157, 111);
            this.lblSel.Name = "lblSel";
            this.lblSel.Size = new System.Drawing.Size(32, 17);
            this.lblSel.TabIndex = 8;
            this.lblSel.Text = "选中";
            // 
            // lblBus
            // 
            this.lblBus.AutoSize = true;
            this.lblBus.BackColor = System.Drawing.Color.Transparent;
            this.lblBus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBus.Location = new System.Drawing.Point(8, 111);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(32, 17);
            this.lblBus.TabIndex = 6;
            this.lblBus.Text = "车辆";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.BackColor = System.Drawing.Color.Transparent;
            this.lblLine.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(8, 79);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(32, 17);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "车队";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(8, 47);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(32, 17);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "时间";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(8, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(32, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "日期";
            // 
            // frmPlayback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 665);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Name = "frmPlayback";
            this.Text = "轨迹回放";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayback_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayback_Load);
            this.SizeChanged += new System.EventHandler(this.frmPlayback_SizeChanged);
            this.pnlCtrl.ResumeLayout(false);
            this.pnlCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVedio)).EndInit();
            this.pnlVedio.ResumeLayout(false);
            this.pnlVedio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsWarningPause.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsTrackingLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusSelected.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLine.Properties)).EndInit();
            this.mnuMap.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.pnlParam.ResumeLayout(false);
            this.pnlParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSetting)).EndInit();
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.PanelControl pnlVedio;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblSpeed;
        private DevExpress.XtraEditors.TrackBarControl trackBarProgress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TrackBarControl trackBarSpeed;
        private DevExpress.XtraEditors.ToggleSwitch tsWarningPause;
        private DevExpress.XtraEditors.ToggleSwitch tsTrackingLine;
        private DevExpress.XtraEditors.SimpleButton btnPlayback;
        private DevExpress.XtraEditors.SimpleButton btnRePlayback;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private DevExpress.XtraEditors.TimeEdit dtpEndTime;
        private DevExpress.XtraEditors.TimeEdit dtpStartTime;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblDistence;
        private DevExpress.XtraEditors.CheckedListBoxControl lstBus;
        private DevExpress.XtraEditors.SimpleButton btnExp;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.ComboBoxEdit cboBusSelected;
        private DevExpress.XtraEditors.ComboBoxEdit cboLine;
        private System.Windows.Forms.Label lblSp;
        private System.Windows.Forms.ContextMenuStrip mnuMap;
        private System.Windows.Forms.ToolStripMenuItem mnuShowList;
        private System.Windows.Forms.ToolStripMenuItem mnuHideList;
        private System.Windows.Forms.ToolTip ttInfo;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel pnlDgv;
        private DevExpress.XtraGrid.GridControl gridList;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetail;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Panel pnlParam;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl pnlSetting;
        private System.Windows.Forms.Label lblMile;
        private System.Windows.Forms.Label lblSel;
        private System.Windows.Forms.Label lblBus;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
    }
}