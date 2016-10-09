
namespace SEWS_BK.generic
{
    partial class WaitForm
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
            this.loadingCircle = new CircleLoading.CircleLoading();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadingCircle
            // 
            this.loadingCircle.AutoSize = true;
            this.loadingCircle.BackColor = System.Drawing.Color.Transparent;
            this.loadingCircle.InnerCircleRadius = 10;
            this.loadingCircle.LineWidth = 3;
            this.loadingCircle.Location = new System.Drawing.Point(12, 10);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.OutnerCircleRadius = 15;
            this.loadingCircle.Size = new System.Drawing.Size(48, 48);
            this.loadingCircle.Speed = 100;
            this.loadingCircle.SpokesMember = 12;
            this.loadingCircle.TabIndex = 0;
            this.loadingCircle.ThemeColor = System.Drawing.Color.Lime;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(65, 26);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(142, 20);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "正在载入，请稍候 . . .";
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(240, 66);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.loadingCircle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitForm";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircleLoading.CircleLoading loadingCircle;
        private System.Windows.Forms.Label lblText;
    }
}