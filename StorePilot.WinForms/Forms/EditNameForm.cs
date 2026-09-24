using System.Drawing;
using System.Windows.Forms;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Forms;

public partial class EditNameForm : Form
{
    public string NameValue =>
        nameTextBox.Text.Trim();

    public EditNameForm(
        string title,
        string initialName = "")
    {
        InitializeComponent();

        Text = title;
        titleLabel.Text = title;

        nameTextBox.Text =
            initialName;
    }

    private void ApplyTheme()
    {
        BackColor =
            AppTheme.Background;

        titleLabel.ForeColor =
            AppTheme.Text;

        nameLabel.ForeColor =
            AppTheme.MutedText;

        nameTextBox.BackColor =
            AppTheme.Surface;

        nameTextBox.ForeColor =
            AppTheme.Text;

        cancelButton.BackColor =
            AppTheme.SurfaceSecondary;

        cancelButton.ForeColor =
            AppTheme.Text;

        cancelButton.FlatAppearance.BorderColor =
            AppTheme.Border;

        saveButton.BackColor =
            AppTheme.Accent;

        saveButton.ForeColor =
            Color.White;

        saveButton.FlatAppearance.BorderColor =
            AppTheme.Accent;
    }

    private void SaveButton_Click(
        object? sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameValue))
        {
            MessageBox.Show(
                "يرجى إدخال الاسم.",
                "تنبيه",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nameTextBox.Focus();

            return;
        }

        DialogResult result = MessageBox.Show(
                "هل تريد تأكيد عملية الحفظ؟",
                "تأكيد",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        DialogResult =
            DialogResult.OK;

        Close();
    }

    private void CancelButton_Click(
        object? sender,
        EventArgs e)
    {
        DialogResult =
            DialogResult.Cancel;

        Close();
    }

    private void EditNameForm_Shown(object sender, EventArgs e)
    {
        nameTextBox.Focus();
        nameTextBox.SelectAll();
    }

    private void EditNameForm_Load(object sender, EventArgs e)
        => ApplyTheme();
}