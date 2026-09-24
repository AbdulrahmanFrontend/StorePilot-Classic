using StorePilot.WinForms.Controls;
using System.Net.Sockets;

namespace StorePilot.WinForms.Pages;

partial class UnitsPage
{
    private System.ComponentModel.IContainer components = null;

    private TableLayoutPanel rootLayoutPanel;
    private ReferenceDataToolbar toolbar;
    private ReferenceDataGrid unitsGrid;
    private PaginationControl pagination;
    private Label totalLabel;

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
        rootLayoutPanel = new TableLayoutPanel();
        toolbar = new ReferenceDataToolbar();
        unitsGrid = new ReferenceDataGrid();
        footerLayoutPanel = new TableLayoutPanel();
        pagination = new PaginationControl();
        totalLabel = new Label();
        rootLayoutPanel.SuspendLayout();
        footerLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayoutPanel
        // 
        rootLayoutPanel.ColumnCount = 1;
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayoutPanel.Controls.Add(toolbar, 0, 0);
        rootLayoutPanel.Controls.Add(unitsGrid, 0, 1);
        rootLayoutPanel.Controls.Add(footerLayoutPanel, 0, 2);
        rootLayoutPanel.Dock = DockStyle.Fill;
        rootLayoutPanel.Location = new Point(0, 0);
        rootLayoutPanel.Margin = new Padding(0);
        rootLayoutPanel.Name = "rootLayoutPanel";
        rootLayoutPanel.Padding = new Padding(16);
        rootLayoutPanel.RowCount = 3;
        rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
        rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        rootLayoutPanel.Size = new Size(1000, 650);
        rootLayoutPanel.TabIndex = 0;
        // 
        // toolbar
        // 
        toolbar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        toolbar.BackColor = Color.White;
        toolbar.Font = new Font("Segoe UI", 9F);
        toolbar.Location = new Point(16, 16);
        toolbar.Margin = new Padding(0);
        toolbar.Name = "toolbar";
        toolbar.RightToLeft = RightToLeft.Yes;
        toolbar.Size = new Size(968, 68);
        toolbar.TabIndex = 0;
        toolbar.AddClicked += Toolbar_AddClicked;
        toolbar.SearchRequested += Toolbar_SearchRequested;
        // 
        // unitsGrid
        // 
        unitsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        unitsGrid.BackColor = Color.White;
        unitsGrid.Font = new Font("Segoe UI", 9F);
        unitsGrid.Location = new Point(19, 87);
        unitsGrid.Name = "unitsGrid";
        unitsGrid.RightToLeft = RightToLeft.Yes;
        unitsGrid.Size = new Size(962, 492);
        unitsGrid.TabIndex = 1;
        unitsGrid.TabStop = false;
        unitsGrid.CellDoubleClicked += UnitsGrid_CellDoubleClicked;
        // 
        // footerLayoutPanel
        // 
        footerLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        footerLayoutPanel.ColumnCount = 2;
        footerLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        footerLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 569F));
        footerLayoutPanel.Controls.Add(pagination, 1, 0);
        footerLayoutPanel.Controls.Add(totalLabel, 0, 0);
        footerLayoutPanel.Location = new Point(19, 585);
        footerLayoutPanel.Name = "footerLayoutPanel";
        footerLayoutPanel.RowCount = 1;
        footerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        footerLayoutPanel.Size = new Size(962, 46);
        footerLayoutPanel.TabIndex = 2;
        // 
        // pagination
        // 
        pagination.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        pagination.BackColor = Color.Transparent;
        pagination.Font = new Font("Segoe UI", 9F);
        pagination.Location = new Point(3, 3);
        pagination.Name = "pagination";
        pagination.RightToLeft = RightToLeft.Yes;
        pagination.Size = new Size(563, 39);
        pagination.TabIndex = 1;
        pagination.PageChanged += Pagination_PageChanged;
        pagination.PageSizeChanged += Pagination_PageSizeChanged;
        // 
        // totalLabel
        // 
        totalLabel.Anchor = AnchorStyles.Left;
        totalLabel.AutoSize = true;
        totalLabel.Location = new Point(835, 13);
        totalLabel.Name = "totalLabel";
        totalLabel.Size = new Size(124, 20);
        totalLabel.TabIndex = 0;
        totalLabel.Text = "إجمالي الوحدات: 0";
        totalLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // UnitsPage
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(rootLayoutPanel);
        Font = new Font("Segoe UI", 9F);
        Name = "UnitsPage";
        RightToLeft = RightToLeft.Yes;
        Size = new Size(1000, 650);
        Load += UnitsPage_Load;
        rootLayoutPanel.ResumeLayout(false);
        footerLayoutPanel.ResumeLayout(false);
        footerLayoutPanel.PerformLayout();
        ResumeLayout(false);
    }

    private TableLayoutPanel footerLayoutPanel;
}
