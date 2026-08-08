namespace StorePilot.UI
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.SplashScreen = new DevToolkit.BaseWinForms.Controls.UserControls.ucSplashScreen();
            this.SuspendLayout();
            // 
            // SplashScreen
            // 
            this.SplashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplashScreen.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplashScreen.Footer = "تطوير م/عبدالرحمن ناصر عبدالستار";
            this.SplashScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.SplashScreen.LoadingMessage = "...جاري تحميل النظام";
            this.SplashScreen.Location = new System.Drawing.Point(0, 0);
            this.SplashScreen.Logo = global::StorePilot.UI.Properties.Resources.sink;
            this.SplashScreen.Margin = new System.Windows.Forms.Padding(0);
            this.SplashScreen.Name = "SplashScreen";
            this.SplashScreen.Size = new System.Drawing.Size(501, 453);
            this.SplashScreen.SubTitle = "رقم الإصدار 1.0 | StorePilot";
            this.SplashScreen.SubTitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplashScreen.TabIndex = 0;
            this.SplashScreen.Title = "نظام إدارة محل أدوات سباكة";
            this.SplashScreen.TitleColor = System.Drawing.SystemColors.ControlText;
            this.SplashScreen.TitleFont = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SplashScreen.SplashCompleted += new System.EventHandler(this.SplashScreen_SplashCompleted);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 453);
            this.Controls.Add(this.SplashScreen);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مرحبا";
            this.ResumeLayout(false);

        }

        #endregion

        private DevToolkit.BaseWinForms.Controls.UserControls.ucSplashScreen SplashScreen;
    }
}

