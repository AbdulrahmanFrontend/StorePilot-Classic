using Krypton.Toolkit;

namespace StorePilot.WinForms.Forms
{
    partial class HomePage
    {
        private KryptonPanel rootPanel;
        private KryptonLabel titleLabel;
        private KryptonLabel descriptionLabel;

        private void InitializeComponent()
        {
            this.rootPanel = new Krypton.Toolkit.KryptonPanel();
            this.titleLabel = new Krypton.Toolkit.KryptonLabel();
            this.descriptionLabel = new Krypton.Toolkit.KryptonLabel();

            ((System.ComponentModel.ISupportInitialize)(this.rootPanel)).BeginInit();
            this.rootPanel.SuspendLayout();
            this.SuspendLayout();

            this.rootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootPanel.StateCommon.Color1 = System.Drawing.Color.White;

            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(48, 48);
            this.titleLabel.StateCommon.ShortText.Font =
                new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Values.Text = "الرئيسية";

            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(52, 102);
            this.descriptionLabel.StateCommon.ShortText.Font =
                new System.Drawing.Font("Segoe UI", 10.5F);
            this.descriptionLabel.StateCommon.ShortText.Color1 =
                System.Drawing.Color.DimGray;
            this.descriptionLabel.Values.Text =
                "هذا هو الإطار الرئيسي للنظام. سنبني Dashboard الحقيقي لاحقاً.";

            this.rootPanel.Controls.Add(this.descriptionLabel);
            this.rootPanel.Controls.Add(this.titleLabel);

            this.Controls.Add(this.rootPanel);
            this.Name = "HomePage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(900, 600);

            this.rootPanel.ResumeLayout(false);
            this.rootPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rootPanel)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
