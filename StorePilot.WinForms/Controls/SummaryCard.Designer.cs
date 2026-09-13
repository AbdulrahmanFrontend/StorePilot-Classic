namespace StorePilot.WinForms.Controls;

partial class SummaryCard
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
        panel = new Krypton.Toolkit.KryptonPanel();
        valueLabel = new Krypton.Toolkit.KryptonLabel();
        captionLabel = new Krypton.Toolkit.KryptonLabel();
        ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
        panel.SuspendLayout();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(valueLabel);
        panel.Controls.Add(captionLabel);
        panel.Dock = DockStyle.Fill;
        panel.Location = new Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new Padding(16);
        panel.Size = new Size(160, 150);
        panel.TabIndex = 0;
        // 
        // valueLabel
        // 
        valueLabel.Dock = DockStyle.Fill;
        valueLabel.Location = new Point(16, 40);
        valueLabel.Name = "valueLabel";
        valueLabel.Size = new Size(128, 94);
        valueLabel.TabIndex = 0;
        valueLabel.Values.Text = "0";
        // 
        // captionLabel
        // 
        captionLabel.Dock = DockStyle.Top;
        captionLabel.Location = new Point(16, 16);
        captionLabel.Name = "captionLabel";
        captionLabel.Size = new Size(128, 24);
        captionLabel.TabIndex = 1;
        captionLabel.Values.Text = "العنوان";
        // 
        // SummaryCard
        // 
        Controls.Add(panel);
        DoubleBuffered = true;
        MinimumSize = new Size(160, 105);
        Name = "SummaryCard";
        RightToLeft = RightToLeft.Yes;
        Size = new Size(160, 150);
        ((System.ComponentModel.ISupportInitialize)panel).EndInit();
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Krypton.Toolkit.KryptonPanel panel;
    private Krypton.Toolkit.KryptonLabel captionLabel;
    private Krypton.Toolkit.KryptonLabel valueLabel;
}
