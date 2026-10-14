using System.ComponentModel;
using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Controls;

public partial class ReferenceDataGrid : UserControl
{
    public event EventHandler<DataGridViewCellEventArgs>? CellDoubleClicked;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataGridView Grid => dataGridView;

    public ReferenceDataGrid()
    {
        InitializeComponent();
    }

    public void Configure(
        string nameHeader,
        string createdAtHeader)
    {
        nameColumn.HeaderText = nameHeader;
        createdAtColumn.HeaderText = createdAtHeader;
    }

    public void ApplyTheme()
    {
        BackColor = AppTheme.Surface;

        dataGridView.BackgroundColor = AppTheme.Surface;

        dataGridView.GridColor = AppTheme.Border;

        dataGridView.ForeColor = AppTheme.Text;

        dataGridView.DefaultCellStyle.BackColor = AppTheme.Surface;

        dataGridView.DefaultCellStyle.ForeColor = AppTheme.Text;

        dataGridView.DefaultCellStyle.SelectionBackColor = AppTheme.Accent;

        dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = 
            AppTheme.SurfaceSecondary;

        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.Text;

        dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = 
            AppTheme.SurfaceSecondary;

        dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = 
            AppTheme.Text;
    }

    private void DataGridView_CellDoubleClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        CellDoubleClicked?.Invoke(this, e);
    }

    private void ReferenceDataGrid_Load(object sender, EventArgs e)
        => ApplyTheme();
}
