namespace SEWS_BK
{
    partial class frmPwd
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
            this.txtOriginalPwd = new DevExpress.XtraEditors.TextEdit();
            this.lblOriginalPwd = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblNewPwd = new DevExpress.XtraEditors.LabelControl();
            this.lblRepeatPwd = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtRepeatPwd = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeatPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOriginalPwd
            // 
            this.txtOriginalPwd.Location = new System.Drawing.Point(90, 25);
            this.txtOriginalPwd.Name = "txtOriginalPwd";
            this.txtOriginalPwd.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalPwd.Properties.Appearance.Options.UseFont = true;
            this.txtOriginalPwd.Properties.PasswordChar = '●';
            this.txtOriginalPwd.Size = new System.Drawing.Size(150, 24);
            this.txtOriginalPwd.TabIndex = 1;
            // 
            // lblOriginalPwd
            // 
            this.lblOriginalPwd.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalPwd.Location = new System.Drawing.Point(24, 28);
            this.lblOriginalPwd.Name = "lblOriginalPwd";
            this.lblOriginalPwd.Size = new System.Drawing.Size(48, 17);
            this.lblOriginalPwd.TabIndex = 0;
            this.lblOriginalPwd.Text = "原密码：";
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(292, 23);
            this.btnOK.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.btnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(292, 60);
            this.btnCancel.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPwd.Location = new System.Drawing.Point(24, 69);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(48, 17);
            this.lblNewPwd.TabIndex = 2;
            this.lblNewPwd.Text = "新密码：";
            // 
            // lblRepeatPwd
            // 
            this.lblRepeatPwd.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatPwd.Location = new System.Drawing.Point(24, 108);
            this.lblRepeatPwd.Name = "lblRepeatPwd";
            this.lblRepeatPwd.Size = new System.Drawing.Size(60, 17);
            this.lblRepeatPwd.TabIndex = 4;
            this.lblRepeatPwd.Text = "确认密码：";
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(90, 65);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPwd.Properties.Appearance.Options.UseFont = true;
            this.txtNewPwd.Properties.PasswordChar = '●';
            this.txtNewPwd.Size = new System.Drawing.Size(150, 24);
            this.txtNewPwd.TabIndex = 3;
            // 
            // txtRepeatPwd
            // 
            this.txtRepeatPwd.Location = new System.Drawing.Point(90, 105);
            this.txtRepeatPwd.Name = "txtRepeatPwd";
            this.txtRepeatPwd.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeatPwd.Properties.Appearance.Options.UseFont = true;
            this.txtRepeatPwd.Properties.PasswordChar = '●';
            this.txtRepeatPwd.Size = new System.Drawing.Size(150, 24);
            this.txtRepeatPwd.TabIndex = 5;
            // 
            // frmPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 153);
            this.Controls.Add(this.txtRepeatPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.lblRepeatPwd);
            this.Controls.Add(this.lblNewPwd);
            this.Controls.Add(this.txtOriginalPwd);
            this.Controls.Add(this.lblOriginalPwd);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改登录密码";
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepeatPwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtOriginalPwd;
        private DevExpress.XtraEditors.LabelControl lblOriginalPwd;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblNewPwd;
        private DevExpress.XtraEditors.LabelControl lblRepeatPwd;
        private DevExpress.XtraEditors.TextEdit txtNewPwd;
        private DevExpress.XtraEditors.TextEdit txtRepeatPwd;
    }
}