namespace StorePilot.WinForms.Controls
{
    partial class ReferenceDataToolbar
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayoutPanel;
        private Label titleLabel;
        private Button addButton;

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
            components = new System.ComponentModel.Container();
            rootLayoutPanel = new TableLayoutPanel();
            searchLayoutPanel = new TableLayoutPanel();
            searchTextBox = new TextBox();
            searchLabel = new Label();
            titleLabel = new Label();
            addButton = new Button();
            searchTimer = new System.Windows.Forms.Timer(components);
            rootLayoutPanel.SuspendLayout();
            searchLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayoutPanel
            // 
            rootLayoutPanel.ColumnCount = 3;
            rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            rootLayoutPanel.Controls.Add(searchLayoutPanel, 1, 0);
            rootLayoutPanel.Controls.Add(titleLabel, 0, 0);
            rootLayoutPanel.Controls.Add(addButton, 2, 0);
            rootLayoutPanel.Dock = DockStyle.Fill;
            rootLayoutPanel.Location = new Point(0, 0);
            rootLayoutPanel.Margin = new Padding(0);
            rootLayoutPanel.Name = "rootLayoutPanel";
            rootLayoutPanel.Padding = new Padding(12, 8, 12, 8);
            rootLayoutPanel.RowCount = 1;
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayoutPanel.Size = new Size(900, 70);
            rootLayoutPanel.TabIndex = 0;
            // 
            // searchLayoutPanel
            // 
            searchLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchLayoutPanel.ColumnCount = 2;
            searchLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            searchLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayoutPanel.Controls.Add(searchTextBox, 1, 0);
            searchLayoutPanel.Controls.Add(searchLabel, 0, 0);
            searchLayoutPanel.Location = new Point(135, 11);
            searchLayoutPanel.Name = "searchLayoutPanel";
            searchLayoutPanel.RowCount = 1;
            searchLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            searchLayoutPanel.Size = new Size(294, 48);
            searchLayoutPanel.TabIndex = 3;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.BorderStyle = BorderStyle.None;
            searchTextBox.Font = new Font("Segoe UI", 9.5F);
            searchTextBox.Location = new Point(0, 13);
            searchTextBox.Margin = new Padding(0);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "ابحث بالاسم...";
            searchTextBox.Size = new Size(242, 22);
            searchTextBox.TabIndex = 0;
            searchTextBox.TextChanged += SearchTextBox_TextChanged;
            searchTextBox.KeyDown += SearchTextBox_KeyDown;
            // 
            // searchLabel
            // 
            searchLabel.Dock = DockStyle.Right;
            searchLabel.Font = new Font("Segoe UI", 9F);
            searchLabel.Location = new Point(242, 0);
            searchLabel.Margin = new Padding(0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(52, 48);
            searchLabel.TabIndex = 1;
            searchLabel.Text = "بحث:";
            searchLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            titleLabel.Location = new Point(432, 8);
            titleLabel.Margin = new Padding(0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(456, 54);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "البيانات المرجعية";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // addButton
            // 
            addButton.Cursor = Cursors.Hand;
            addButton.Dock = DockStyle.Fill;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            addButton.Location = new Point(12, 12);
            addButton.Margin = new Padding(8, 4, 0, 4);
            addButton.Name = "addButton";
            addButton.Size = new Size(112, 46);
            addButton.TabIndex = 1;
            addButton.Text = "+ إضافة";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += AddButton_Click;
            // 
            // searchTimer
            // 
            searchTimer.Interval = 350;
            searchTimer.Tick += SearchTimer_Tick;
            // 
            // ReferenceDataToolbar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(rootLayoutPanel);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(0);
            Name = "ReferenceDataToolbar";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(900, 70);
            rootLayoutPanel.ResumeLayout(false);
            searchLayoutPanel.ResumeLayout(false);
            searchLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        private TableLayoutPanel searchLayoutPanel;
        private TextBox searchTextBox;
        private Label searchLabel;
        private System.Windows.Forms.Timer searchTimer;
    }
}
