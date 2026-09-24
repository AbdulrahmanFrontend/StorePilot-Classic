namespace StorePilot.WinForms.Controls;

partial class PaginationControl
{
    private System.ComponentModel.IContainer components = null;

    private TableLayoutPanel rootLayoutPanel;
    private Button firstButton;
    private Button previousButton;
    private ComboBox pageNumberComboBox;
    private Label pageInfoLabel;
    private Button nextButton;
    private Button lastButton;
    private Label pageSizeLabel;
    private ComboBox pageSizeComboBox;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        rootLayoutPanel = new TableLayoutPanel();
        firstButton = new Button();
        previousButton = new Button();
        pageNumberComboBox = new ComboBox();
        pageInfoLabel = new Label();
        nextButton = new Button();
        lastButton = new Button();
        pageSizeLabel = new Label();
        pageSizeComboBox = new ComboBox();
        rootLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayoutPanel
        // 
        rootLayoutPanel.ColumnCount = 8;
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 147F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 59F));
        rootLayoutPanel.Controls.Add(firstButton, 0, 0);
        rootLayoutPanel.Controls.Add(previousButton, 1, 0);
        rootLayoutPanel.Controls.Add(pageNumberComboBox, 2, 0);
        rootLayoutPanel.Controls.Add(pageInfoLabel, 3, 0);
        rootLayoutPanel.Controls.Add(nextButton, 4, 0);
        rootLayoutPanel.Controls.Add(lastButton, 5, 0);
        rootLayoutPanel.Controls.Add(pageSizeLabel, 6, 0);
        rootLayoutPanel.Controls.Add(pageSizeComboBox, 7, 0);
        rootLayoutPanel.Dock = DockStyle.Fill;
        rootLayoutPanel.Location = new Point(0, 0);
        rootLayoutPanel.Margin = new Padding(0);
        rootLayoutPanel.Name = "rootLayoutPanel";
        rootLayoutPanel.RowCount = 1;
        rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayoutPanel.Size = new Size(570, 42);
        rootLayoutPanel.TabIndex = 0;
        // 
        // firstButton
        // 
        firstButton.Anchor = AnchorStyles.None;
        firstButton.Cursor = Cursors.Hand;
        firstButton.FlatAppearance.BorderSize = 0;
        firstButton.FlatStyle = FlatStyle.Flat;
        firstButton.Location = new Point(526, 2);
        firstButton.Margin = new Padding(2);
        firstButton.Name = "firstButton";
        firstButton.Size = new Size(42, 38);
        firstButton.TabIndex = 0;
        firstButton.Text = "|<";
        firstButton.UseVisualStyleBackColor = true;
        firstButton.Click += FirstButton_Click;
        // 
        // previousButton
        // 
        previousButton.Anchor = AnchorStyles.None;
        previousButton.Cursor = Cursors.Hand;
        previousButton.FlatAppearance.BorderSize = 0;
        previousButton.FlatStyle = FlatStyle.Flat;
        previousButton.Location = new Point(480, 2);
        previousButton.Margin = new Padding(2);
        previousButton.Name = "previousButton";
        previousButton.Size = new Size(42, 38);
        previousButton.TabIndex = 1;
        previousButton.Text = "<";
        previousButton.UseVisualStyleBackColor = true;
        previousButton.Click += PreviousButton_Click;
        // 
        // pageNumberComboBox
        // 
        pageNumberComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        pageNumberComboBox.Cursor = Cursors.Hand;
        pageNumberComboBox.DropDownHeight = 100;
        pageNumberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        pageNumberComboBox.FormattingEnabled = true;
        pageNumberComboBox.IntegralHeight = false;
        pageNumberComboBox.Location = new Point(413, 7);
        pageNumberComboBox.Name = "pageNumberComboBox";
        pageNumberComboBox.Size = new Size(62, 28);
        pageNumberComboBox.TabIndex = 2;
        pageNumberComboBox.SelectedIndexChanged += PageNumberComboBox_SelectedIndexChanged;
        // 
        // pageInfoLabel
        // 
        pageInfoLabel.Dock = DockStyle.Fill;
        pageInfoLabel.Location = new Point(266, 0);
        pageInfoLabel.Name = "pageInfoLabel";
        pageInfoLabel.Size = new Size(141, 42);
        pageInfoLabel.TabIndex = 3;
        pageInfoLabel.Text = "لا توجد صفحات";
        pageInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // nextButton
        // 
        nextButton.Anchor = AnchorStyles.None;
        nextButton.Cursor = Cursors.Hand;
        nextButton.FlatAppearance.BorderSize = 0;
        nextButton.FlatStyle = FlatStyle.Flat;
        nextButton.Location = new Point(219, 2);
        nextButton.Margin = new Padding(2);
        nextButton.Name = "nextButton";
        nextButton.Size = new Size(42, 38);
        nextButton.TabIndex = 3;
        nextButton.Text = ">";
        nextButton.UseVisualStyleBackColor = true;
        nextButton.Click += NextButton_Click;
        // 
        // lastButton
        // 
        lastButton.Anchor = AnchorStyles.None;
        lastButton.Cursor = Cursors.Hand;
        lastButton.FlatAppearance.BorderSize = 0;
        lastButton.FlatStyle = FlatStyle.Flat;
        lastButton.Location = new Point(173, 2);
        lastButton.Margin = new Padding(2);
        lastButton.Name = "lastButton";
        lastButton.Size = new Size(42, 38);
        lastButton.TabIndex = 4;
        lastButton.Text = ">|";
        lastButton.UseVisualStyleBackColor = true;
        lastButton.Click += LastButton_Click;
        // 
        // pageSizeLabel
        // 
        pageSizeLabel.Dock = DockStyle.Fill;
        pageSizeLabel.Location = new Point(83, 0);
        pageSizeLabel.Name = "pageSizeLabel";
        pageSizeLabel.Size = new Size(85, 42);
        pageSizeLabel.TabIndex = 6;
        pageSizeLabel.Text = "الحجم:";
        pageSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pageSizeComboBox
        // 
        pageSizeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        pageSizeComboBox.Cursor = Cursors.Hand;
        pageSizeComboBox.DropDownHeight = 100;
        pageSizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        pageSizeComboBox.FormattingEnabled = true;
        pageSizeComboBox.IntegralHeight = false;
        pageSizeComboBox.Location = new Point(3, 7);
        pageSizeComboBox.Name = "pageSizeComboBox";
        pageSizeComboBox.Size = new Size(74, 28);
        pageSizeComboBox.TabIndex = 5;
        pageSizeComboBox.SelectedIndexChanged += PageSizeComboBox_SelectedIndexChanged;
        // 
        // PaginationControl
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Transparent;
        Controls.Add(rootLayoutPanel);
        Font = new Font("Segoe UI", 9F);
        Name = "PaginationControl";
        RightToLeft = RightToLeft.Yes;
        Size = new Size(570, 42);
        Load += PaginationControl_Load;
        rootLayoutPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}
