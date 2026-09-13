using Krypton.Toolkit;
using StorePilot.WinForms.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace StorePilot.WinForms.Forms;

public partial class SplashForm : KryptonForm
{
    private readonly System.Windows.Forms.Timer timer = new()
    { 
        Interval = 40
    }; 

    private int elapsed;

    public SplashForm() 
    { 
        InitializeComponent();
        AppTheme.Apply(this); 
        Opacity = 0;
        timer.Tick += Tick;
        Shown += (_, _) => timer.Start();
    }

    void Tick(object? s, EventArgs e)
    { 
        elapsed += timer.Interval; 

        if (elapsed <= 300) 
        { 
            Opacity = Math.Min(1, elapsed / 300.0); 
            return; 
        } 

        if (elapsed >= 1000) 
        { 
            timer.Stop(); 
            Close(); 
        }
    }
}
