using StorePilot.WinForms.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StorePilot.WinForms.Controls;

public partial class PageHeader : UserControl
{
    public PageHeader()
    {
        InitializeComponent();
        ApplyTheme();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Title 
    { 
        get => titleLabel.Text; 
        set => titleLabel.Text = value; 
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Description
    { 
        get => descriptionLabel.Text; 
        set => descriptionLabel.Text = value;
    }

    public void ApplyTheme() 
    { 
        BackColor = AppTheme.Background;
        titleLabel.StateCommon.ShortText.Color1 = AppTheme.Text;
        descriptionLabel.StateCommon.ShortText.Color1 = AppTheme.SecondaryText;
    }
}
