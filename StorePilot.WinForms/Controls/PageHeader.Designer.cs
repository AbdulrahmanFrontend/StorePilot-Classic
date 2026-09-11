namespace StorePilot.WinForms.Controls;

partial class PageHeader
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        titleLabel = new Krypton.Toolkit.KryptonLabel();
        descriptionLabel = new Krypton.Toolkit.KryptonLabel();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.Dock = DockStyle.Top;
        titleLabel.Location = new Point(0, 0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(437, 24);
        titleLabel.TabIndex = 1;
        titleLabel.Values.Text = "العنوان";
        // 
        // descriptionLabel
        // 
        descriptionLabel.Dock = DockStyle.Top;
        descriptionLabel.Location = new Point(0, 24);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new Size(437, 24);
        descriptionLabel.TabIndex = 0;
        descriptionLabel.Values.Text = "الوصف";
        // 
        // PageHeader
        // 
        Controls.Add(descriptionLabel);
        Controls.Add(titleLabel);
        Name = "PageHeader";
        RightToLeft = RightToLeft.Yes;
        Height = 68;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Krypton.Toolkit.KryptonLabel titleLabel;
    private Krypton.Toolkit.KryptonLabel descriptionLabel;
}
