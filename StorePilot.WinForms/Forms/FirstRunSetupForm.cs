using Krypton.Toolkit;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StorePilot.WinForms.Forms;

public partial class FirstRunSetupForm : KryptonForm
{
    readonly AppBrandSettingsStore store; 
    string? selectedLogo;
    
    public FirstRunSetupForm(AppBrandSettingsStore store)
    { 
        InitializeComponent(); 
        this.store = store; 
        AppTheme.Apply(this);
        cmbTheme.SelectedIndex = 0;
    }

    void choose_Click(object? s, EventArgs e) 
    { 
        using var d = new OpenFileDialog
        { 
            Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp" 
        }; 

        if (d.ShowDialog(this) == DialogResult.OK)
        { 
            selectedLogo = d.FileName;
            logoInfo.Text = Path.GetFileName(selectedLogo);
        }
    }

    void remove_Click(object? s, EventArgs e)
    { 
        selectedLogo = null;
        logoInfo.Text = "الشعار الافتراضي";
    }

    void save_Click(object? s, EventArgs e) 
    { 
        if (string.IsNullOrWhiteSpace(shopName.Text) 
            || string.IsNullOrWhiteSpace(userName.Text))
        {
            KryptonMessageBox.Show(
                "أدخل اسم المحل واسم المستخدم.",
                "بيانات ناقصة",
                KryptonMessageBoxButtons.OK,
                KryptonMessageBoxIcon.Warning);
            return;
        }

        var x = new AppBrandSettings 
        { 
            ShopName = shopName.Text.Trim(),
            UserDisplayName = userName.Text.Trim(), 
            Theme = 
                cmbTheme.SelectedIndex == 1 ? 
                ThemeMode.Dark : 
                ThemeMode.Light 
        };
        
        if (selectedLogo != null)
            x.LogoPath = store.CopyLogo(selectedLogo) ?? ""; 

        store.Save(x); 
        AppTheme.Set(x.Theme); 
        DialogResult = DialogResult.OK; 
        Close(); 
    }
}
