using Krypton.Toolkit;
using StorePilot.WinForms.Controls;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Pages;

public partial class DemoPage : UserControl
{
    public DemoPage(string title,string description)
    {
        InitializeComponent();
        header.Title = title;
        header.Description = description;
    }
} 
