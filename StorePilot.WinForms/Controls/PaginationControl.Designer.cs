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
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
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
        firstButton.Dock = DockStyle.Fill;
        firstButton.Location = new Point(526, 2);
        firstButton.Margin = new Padding(2);
        firstButton.Name = "firstButton";
        firstButton.Size = new Size(42, 38);
        firstButton.TabIndex = 0;
        firstButton.Text = "|<";
        firstButton.UseVisualStyleBackColor = true;
        // 
        // previousButton
        // 
        previousButton.Dock = DockStyle.Fill;
        previousButton.Location = new Point(480, 2);
        previousButton.Margin = new Padding(2);
        previousButton.Name = "previousButton";
        previousButton.Size = new Size(42, 38);
        previousButton.TabIndex = 1;
        previousButton.Text = "<";
        previousButton.UseVisualStyleBackColor = true;
        // 
        // pageNumberComboBox
        // 
        pageNumberComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        pageNumberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        pageNumberComboBox.FormattingEnabled = true;
        pageNumberComboBox.Location = new Point(396, 7);
        pageNumberComboBox.Name = "pageNumberComboBox";
        pageNumberComboBox.Size = new Size(79, 28);
        pageNumberComboBox.TabIndex = 2;
        // 
        // pageInfoLabel
        // 
        pageInfoLabel.Dock = DockStyle.Fill;
        pageInfoLabel.Location = new Point(266, 0);
        pageInfoLabel.Name = "pageInfoLabel";
        pageInfoLabel.Size = new Size(124, 42);
        pageInfoLabel.TabIndex = 3;
        pageInfoLabel.Text = "لا توجد صفحات";
        pageInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // nextButton
        // 
        nextButton.Dock = DockStyle.Fill;
        nextButton.Location = new Point(219, 2);
        nextButton.Margin = new Padding(2);
        nextButton.Name = "nextButton";
        nextButton.Size = new Size(42, 38);
        nextButton.TabIndex = 4;
        nextButton.Text = ">";
        nextButton.UseVisualStyleBackColor = true;
        // 
        // lastButton
        // 
        lastButton.Dock = DockStyle.Fill;
        lastButton.Location = new Point(173, 2);
        lastButton.Margin = new Padding(2);
        lastButton.Name = "lastButton";
        lastButton.Size = new Size(42, 38);
        lastButton.TabIndex = 5;
        lastButton.Text = ">|";
        lastButton.UseVisualStyleBackColor = true;
        // 
        // pageSizeLabel
        // 
        pageSizeLabel.Dock = DockStyle.Fill;
        pageSizeLabel.Location = new Point(104, 0);
        pageSizeLabel.Name = "pageSizeLabel";
        pageSizeLabel.Size = new Size(64, 42);
        pageSizeLabel.TabIndex = 6;
        pageSizeLabel.Text = "الحجم:";
        pageSizeLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pageSizeComboBox
        // 
        pageSizeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        pageSizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        pageSizeComboBox.FormattingEnabled = true;
        pageSizeComboBox.Location = new Point(3, 7);
        pageSizeComboBox.Name = "pageSizeComboBox";
        pageSizeComboBox.Size = new Size(95, 28);
        pageSizeComboBox.TabIndex = 7;
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
        rootLayoutPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}
