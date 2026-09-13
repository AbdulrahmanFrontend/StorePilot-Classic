namespace StorePilot.WinForms.Pages;
partial class SuppliersPage
{
    private System.ComponentModel.IContainer components=null!;
    private StorePilot.WinForms.Controls.PageHeader header=null!;
    private Krypton.Toolkit.KryptonPanel surface=null!;
    private Krypton.Toolkit.KryptonTextBox search=null!;
    private StorePilot.WinForms.Controls.PaginationBar pagination=null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        header = new StorePilot.WinForms.Controls.PageHeader();
        surface = new Krypton.Toolkit.KryptonPanel();
        search = new Krypton.Toolkit.KryptonTextBox();
        pagination = new StorePilot.WinForms.Controls.PaginationBar();
        grid = new Krypton.Toolkit.KryptonDataGridView();
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
        header.Size = new Size(1184, 68);
        header.TabIndex = 1;
        header.Title = "الموردون";
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
        surface.Size = new Size(1184, 560);
        surface.TabIndex = 0;
        // 
        // search
        // 
        search.Dock = DockStyle.Top;
        search.Location = new Point(14, 14);
        search.Name = "search";
        search.Size = new Size(1156, 27);
        search.TabIndex = 1;
        // 
        // pagination
        // 
        pagination.Dock = DockStyle.Bottom;
        pagination.Location = new Point(14, 504);
        pagination.Name = "pagination";
        pagination.RightToLeft = RightToLeft.Yes;
        pagination.Size = new Size(1156, 42);
        pagination.TabIndex = 2;
        pagination.TotalItems = 0;
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
        grid.Size = new Size(1156, 463);
        grid.TabIndex = 3;
        // 
        // SuppliersPage
        // 
        Controls.Add(surface);
        Controls.Add(header);
        Name = "SuppliersPage";
        Padding = new Padding(18);
        RightToLeft = RightToLeft.Yes;
        Size = new Size(1220, 664);
        ((System.ComponentModel.ISupportInitialize)surface).EndInit();
        surface.ResumeLayout(false);
        surface.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ResumeLayout(false);
    }

    private Krypton.Toolkit.KryptonDataGridView grid;
}
