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
        captionLabel = new Krypton.Toolkit.KryptonLabel();
        valueLabel = new Krypton.Toolkit.KryptonLabel();
        ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(valueLabel);
        panel.Controls.Add(captionLabel);
        panel.Dock = DockStyle.Fill;
        panel.Padding = new Padding(16);
        //panel.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.All;
        //panel.StateCommon.Border.Rounding = 10;
        // 
        // captionLabel
        // 
        captionLabel.Dock = DockStyle.Top;
        captionLabel.Height = 28; 
        captionLabel.Values.Text = "العنوان";
        // 
        // valueLabel
        // 
        valueLabel.Dock = DockStyle.Fill; 
        valueLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
        valueLabel.Values.Text = "0";
        // 
        // SummaryCard
        // 
        Controls.Add(panel);
        MinimumSize = new Size(160, 105); 
        RightToLeft = RightToLeft.Yes;
        Name = "SummaryCard";
        ((System.ComponentModel.ISupportInitialize)panel).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Krypton.Toolkit.KryptonPanel panel;
    private Krypton.Toolkit.KryptonLabel captionLabel;
    private Krypton.Toolkit.KryptonLabel valueLabel;
}
