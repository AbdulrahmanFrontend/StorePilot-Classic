namespace StorePilot.WinForms.Pages;

partial class CustomersPage
{
    private System.ComponentModel.IContainer components = null;
    private StorePilot.WinForms.Controls.PageHeader header;
    private Krypton.Toolkit.KryptonPanel surface;
    private Krypton.Toolkit.KryptonTextBox search;
    private Krypton.Toolkit.KryptonDataGridView grid;
    private StorePilot.WinForms.Controls.PaginationBar pagination;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        header = new StorePilot.WinForms.Controls.PageHeader();
        surface = new Krypton.Toolkit.KryptonPanel();
        grid = new Krypton.Toolkit.KryptonDataGridView();
        search = new Krypton.Toolkit.KryptonTextBox();
        pagination = new StorePilot.WinForms.Controls.PaginationBar();
        ((System.ComponentModel.ISupportInitialize)surface).BeginInit();
        surface.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
        SuspendLayout();
        // 
        // header
        // 
        header.BackColor = Color.FromArgb(246, 247, 249);
        header.Description = "بحث وتصفح البيانات مع Pagination.";
        header.Dock = DockStyle.Top;
        header.Location = new Point(18, 18);
        header.Name = "header";
        header.RightToLeft = RightToLeft.Yes;
        header.Size = new Size(1150, 68);
        header.TabIndex = 1;
        header.Title = "العملاء";
        // 
        // surface
        // 
        surface.Controls.Add(grid);
        surface.Controls.Add(search);
        surface.Controls.Add(pagination);
        surface.Dock = DockStyle.Fill;
        surface.Location = new Point(18, 86);
        surface.Name = "surface";
        surface.Padding = new Padding(14);
        surface.Size = new Size(1150, 413);
        surface.TabIndex = 0;
        // 
        // grid
        // 
        grid.AllowUserToAddRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.BorderStyle = BorderStyle.None;
        grid.ColumnHeadersHeight = 36;
        grid.Dock = DockStyle.Fill;
        grid.Location = new Point(14, 41);
        grid.Name = "grid";
        grid.ReadOnly = true;
        grid.RowHeadersVisible = false;
        grid.RowHeadersWidth = 51;
        grid.Size = new Size(1122, 316);
        grid.TabIndex = 0;
        // 
        // search
        // 
        search.Dock = DockStyle.Top;
        search.Location = new Point(14, 14);
        search.Name = "search";
        search.Size = new Size(1122, 27);
        search.TabIndex = 1;
        // 
        // pagination
        // 
        pagination.Dock = DockStyle.Bottom;
        pagination.Location = new Point(14, 357);
        pagination.Name = "pagination";
        pagination.RightToLeft = RightToLeft.Yes;
        pagination.Size = new Size(1122, 42);
        pagination.TabIndex = 2;
        pagination.TotalItems = 0;
        // 
        // CustomersPage
        // 
        Controls.Add(surface);
        Controls.Add(header);
        Name = "CustomersPage";
        Padding = new Padding(18);
        RightToLeft = RightToLeft.Yes;
        Size = new Size(1186, 517);
        Load += CustomersPage_Load;
        ((System.ComponentModel.ISupportInitialize)surface).EndInit();
        surface.ResumeLayout(false);
        surface.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ResumeLayout(false);
    }
}