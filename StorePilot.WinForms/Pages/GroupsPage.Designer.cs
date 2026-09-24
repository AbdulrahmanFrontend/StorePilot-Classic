using StorePilot.WinForms.Controls;

namespace StorePilot.WinForms.Pages
{
    partial class GroupsPage
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayoutPanel;
        private ReferenceDataToolbar toolbar;
        private ReferenceDataGrid groupsGrid;
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
            groupsGrid = new ReferenceDataGrid();
            tableLayoutPanel1 = new TableLayoutPanel();
            pagination = new PaginationControl();
            totalLabel = new Label();
            rootLayoutPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayoutPanel
            // 
            rootLayoutPanel.ColumnCount = 1;
            rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayoutPanel.Controls.Add(toolbar, 0, 0);
            rootLayoutPanel.Controls.Add(groupsGrid, 0, 1);
            rootLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 2);
            rootLayoutPanel.Dock = DockStyle.Fill;
            rootLayoutPanel.Location = new Point(0, 0);
            rootLayoutPanel.Margin = new Padding(0);
            rootLayoutPanel.Name = "rootLayoutPanel";
            rootLayoutPanel.Padding = new Padding(16);
            rootLayoutPanel.RowCount = 3;
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            rootLayoutPanel.Size = new Size(1000, 650);
            rootLayoutPanel.TabIndex = 0;
            // 
            // toolbar
            // 
            toolbar.BackColor = Color.White;
            toolbar.Dock = DockStyle.Fill;
            toolbar.Font = new Font("Segoe UI", 9F);
            toolbar.Location = new Point(16, 16);
            toolbar.Margin = new Padding(0);
            toolbar.Name = "toolbar";
            toolbar.RightToLeft = RightToLeft.Yes;
            toolbar.Size = new Size(968, 65);
            toolbar.TabIndex = 0;
            toolbar.AddClicked += Toolbar_AddClicked;
            toolbar.SearchRequested += Toolbar_SearchRequested;
            // 
            // groupsGrid
            // 
            groupsGrid.BackColor = Color.White;
            groupsGrid.Dock = DockStyle.Fill;
            groupsGrid.Font = new Font("Segoe UI", 9F);
            groupsGrid.Location = new Point(16, 89);
            groupsGrid.Margin = new Padding(0, 8, 0, 0);
            groupsGrid.Name = "groupsGrid";
            groupsGrid.RightToLeft = RightToLeft.Yes;
            groupsGrid.Size = new Size(968, 498);
            groupsGrid.TabIndex = 1;
            groupsGrid.TabStop = false;
            groupsGrid.CellDoubleClicked += GroupsGrid_CellDoubleClicked;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 567F));
            tableLayoutPanel1.Controls.Add(pagination, 1, 0);
            tableLayoutPanel1.Controls.Add(totalLabel, 0, 0);
            tableLayoutPanel1.Location = new Point(19, 590);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(962, 41);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // pagination
            // 
            pagination.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pagination.BackColor = Color.Transparent;
            pagination.Font = new Font("Segoe UI", 9F);
            pagination.Location = new Point(3, 3);
            pagination.Name = "pagination";
            pagination.RightToLeft = RightToLeft.Yes;
            pagination.Size = new Size(561, 35);
            pagination.TabIndex = 2;
            pagination.PageChanged += Pagination_PageChanged;
            pagination.PageSizeChanged += Pagination_PageSizeChanged;
            // 
            // totalLabel
            // 
            totalLabel.Anchor = AnchorStyles.Left;
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(816, 10);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(143, 20);
            totalLabel.TabIndex = 2;
            totalLabel.Text = "إجمالي المجموعات: 0";
            totalLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // GroupsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(rootLayoutPanel);
            Font = new Font("Segoe UI", 9F);
            Name = "GroupsPage";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1000, 650);
            Load += GroupsPage_Load;
            rootLayoutPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private TableLayoutPanel tableLayoutPanel1;
    }
}
