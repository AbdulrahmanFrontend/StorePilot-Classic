namespace StorePilot.WinForms.Pages;

partial class ReferenceDataGrid
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dataGridView;
    private DataGridViewTextBoxColumn idColumn;
    private DataGridViewTextBoxColumn nameColumn;

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
        dataGridView = new DataGridView();
        idColumn = new DataGridViewTextBoxColumn();
        nameColumn = new DataGridViewTextBoxColumn();

        ((System.ComponentModel.ISupportInitialize)
            dataGridView).BeginInit();

        SuspendLayout();

        // 
        // dataGridView
        // 
        dataGridView.AllowUserToAddRows =
            false;

        dataGridView.AllowUserToDeleteRows =
            false;

        dataGridView.AllowUserToResizeRows =
            false;

        dataGridView.AutoGenerateColumns =
            false;

        dataGridView.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dataGridView.BackgroundColor =
            Color.White;

        dataGridView.BorderStyle =
            BorderStyle.None;

        dataGridView.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        dataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;

        dataGridView.ColumnHeadersHeight =
            42;

        dataGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        dataGridView.ColumnHeadersDefaultCellStyle =
            new DataGridViewCellStyle
            {
                Alignment =
                    DataGridViewContentAlignment.MiddleCenter,

                Font =
                    new Font(
                        "Segoe UI Semibold",
                        9F,
                        FontStyle.Bold),

                Padding =
                    new Padding(4)
            };

        dataGridView.DefaultCellStyle =
            new DataGridViewCellStyle
            {
                Alignment =
                    DataGridViewContentAlignment.MiddleCenter,

                Font =
                    new Font(
                        "Segoe UI",
                        9F),

                Padding =
                    new Padding(4),

                SelectionBackColor =
                    Color.FromArgb(42, 112, 222),

                SelectionForeColor =
                    Color.White
            };

        dataGridView.Dock =
            DockStyle.Fill;

        dataGridView.EnableHeadersVisualStyles =
            false;

        dataGridView.MultiSelect =
            false;

        dataGridView.Name =
            "dataGridView";

        dataGridView.ReadOnly =
            true;

        dataGridView.RowHeadersVisible =
            false;

        dataGridView.RowTemplate.Height =
            38;

        dataGridView.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dataGridView.TabIndex =
            0;

        dataGridView.Columns.AddRange(
            new DataGridViewColumn[]
            {
                idColumn,
                nameColumn
            });

        // 
        // idColumn
        // 
        idColumn.DataPropertyName =
            "Id";

        idColumn.FillWeight =
            20F;

        idColumn.HeaderText =
            "الرقم";

        idColumn.Name =
            "idColumn";

        idColumn.ReadOnly =
            true;

        // 
        // nameColumn
        // 
        nameColumn.DataPropertyName =
            "Name";

        nameColumn.FillWeight =
            80F;

        nameColumn.HeaderText =
            "الاسم";

        nameColumn.Name =
            "nameColumn";

        nameColumn.ReadOnly =
            true;

        // 
        // ReferenceDataGrid
        // 
        AutoScaleDimensions =
            new SizeF(8F, 20F);

        AutoScaleMode =
            AutoScaleMode.Font;

        BackColor =
            Color.White;

        Controls.Add(
            dataGridView);

        Font =
            new Font(
                "Segoe UI",
                9F);

        Name =
            "ReferenceDataGrid";

        RightToLeft =
            RightToLeft.Yes;

        Size =
            new Size(700, 400);

        ((System.ComponentModel.ISupportInitialize)
            dataGridView).EndInit();

        ResumeLayout(false);
    }
}
