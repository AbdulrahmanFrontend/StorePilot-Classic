using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StorePilot.WinForms.Controls;

public partial class PaginationBar : UserControl
{
    public event EventHandler? PageChanged;
    private int page = 1, size = 50, total;

    public PaginationBar()
    {
        InitializeComponent();
    }

    public int CurrentPage => page;
    public int PageSize => size;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int TotalItems
    {
        get => total;
        set
        {
            total = Math.Max(0, value);
            page = Math.Min(page, Math.Max(1, TotalPages));
            Reset();
        }
    }

    private void FillPageNumberComboBox()
    {
        cmbPageNumber.Items.Clear();

        int i = 0;
        do
        {
            i++;
            cmbPageNumber.Items.Add(i.ToString());
        } while (i < TotalPages);

        cmbPageNumber.SelectedIndex = 0;
    }

    public int TotalPages => 
        total == 0 ? 
        0 : 
        (int)Math.Ceiling(total / (double)size);

    public void Reset()
        => cmbPageSize.SelectedIndex = 0;

    void ChangePage()
    {
        UpdateState();
        PageChanged?.Invoke(this, EventArgs.Empty);
    }

    void UpdateState()
    {
        lblInfo.Text = TotalPages == 0 ?
            "لا توجد بيانات" :
            $"صفحة {page} من {TotalPages} — إجمالي {total}";
        btnFirst.Enabled = btnPrev.Enabled = page > 1;
        btnNext.Enabled = btnLast.Enabled = TotalPages > 0 && page < TotalPages;
    }

    void btnFirst_Click(object? s, EventArgs e)
    {
        if (cmbPageNumber.Items.Count > 1)
            cmbPageNumber.SelectedIndex = 0;
    }

    void btnPrev_Click(object? s, EventArgs e)
    {
        if (page > 1)
            cmbPageNumber.SelectedIndex--;
    }

    void btnNext_Click(object? s, EventArgs e)
    {
        if (page < TotalPages)
            cmbPageNumber.SelectedIndex++;
    }

    void btnLast_Click(object? s, EventArgs e)
    {
        if (TotalPages > 0 && page < TotalPages)
            cmbPageNumber.SelectedIndex = TotalPages - 1;
    }

    void cmbPageSize_SelectedIndexChanged(object? s, EventArgs e)
    {
        if (cmbPageSize.SelectedItem is null)
            return;

        size = int.Parse(cmbPageSize.SelectedItem?.ToString()!);
        FillPageNumberComboBox();
    }

    private void cmbPageNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbPageNumber.SelectedItem is null)
            return;

        page = int.Parse(cmbPageNumber.SelectedItem?.ToString()!);
        ChangePage();
    }
}
