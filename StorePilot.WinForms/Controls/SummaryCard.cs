using StorePilot.WinForms.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StorePilot.WinForms.Controls;

public partial class SummaryCard : UserControl
{
    public SummaryCard()
    { 
        InitializeComponent(); 
        ApplyTheme(); 
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Caption
    {
        get => captionLabel.Text;
        set => captionLabel.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Value 
    { 
        get => valueLabel.Text;
        set => valueLabel.Text = value; 
    }

    public void ApplyTheme() 
    { 
        BackColor = AppTheme.Surface;
        panel.StateCommon.Color1 = AppTheme.Surface;
        captionLabel.StateCommon.ShortText.Color1 = AppTheme.SecondaryText; 
        valueLabel.StateCommon.ShortText.Color1 = AppTheme.Text;
    }
}
