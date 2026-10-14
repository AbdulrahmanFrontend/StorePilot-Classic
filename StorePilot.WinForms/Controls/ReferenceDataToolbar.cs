using StorePilot.WinForms.Theme;
using System.ComponentModel;

namespace StorePilot.WinForms.Controls;

public partial class ReferenceDataToolbar : UserControl
{
    public event EventHandler? AddClicked;

    public event EventHandler? SearchRequested;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Title
    {
        get => titleLabel.Text;
        set => titleLabel.Text = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string SearchText => searchTextBox.Text.Trim();

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Button AddButton => addButton;

    public ReferenceDataToolbar()
    {
        InitializeComponent();
    }

    public void SetSearchText(string? value)
        => searchTextBox.Text = value ?? string.Empty;

    public void FocusSearch()
    {
        searchTextBox.Focus();
        searchTextBox.SelectAll();
    }

    public void ApplyTheme()
    {
        BackColor = AppTheme.Surface;

        titleLabel.ForeColor = AppTheme.Text;
        searchLabel.ForeColor = AppTheme.MutedText;

        searchTextBox.BackColor = AppTheme.SurfaceSecondary;
        searchTextBox.ForeColor = AppTheme.Text;

        searchLayoutPanel.BackColor = AppTheme.SurfaceSecondary;

        addButton.BackColor = AppTheme.Accent;
        addButton.ForeColor = Color.White;
        addButton.FlatAppearance.BorderColor = AppTheme.Accent;
    }

    private void SearchTextBox_TextChanged(object? sender, EventArgs e)
    {
        searchTimer.Stop();
        searchTimer.Start();
    }

    private void SearchTextBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
            return;

        e.SuppressKeyPress = true;

        searchTimer.Stop();

        SearchRequested?.Invoke(this, EventArgs.Empty);
    }

    private void SearchTimer_Tick(object? sender, EventArgs e)
    {
        searchTimer.Stop();

        SearchRequested?.Invoke(this, EventArgs.Empty);
    }

    private void AddButton_Click(object? sender, EventArgs e)
        => AddClicked?.Invoke(this, EventArgs.Empty);

    private void ReferenceDataToolbar_Load(object sender, EventArgs e)
        => ApplyTheme();
}
