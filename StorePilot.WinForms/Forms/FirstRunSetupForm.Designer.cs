namespace StorePilot.WinForms.Forms;

partial class FirstRunSetupForm
{
    private System.ComponentModel.IContainer components = null;

    private Panel headerPanel = null!;
    private Label titleLabel = null!;
    private Label subtitleLabel = null!;

    private TableLayoutPanel contentLayout = null!;

    private Panel formPanel = null!;
    private Label storeNameLabel = null!;
    private TextBox storeNameTextBox = null!;
    private Label userNameLabel = null!;
    private TextBox userNameTextBox = null!;
    private Label themeLabel = null!;
    private FlowLayoutPanel themeFlow = null!;
    private RadioButton lightThemeRadioButton = null!;
    private RadioButton darkThemeRadioButton = null!;

    private Panel logoPanel = null!;
    private Label logoTitleLabel = null!;
    private PictureBox logoPreview = null!;
    private Button chooseLogoButton = null!;
    private Button removeLogoButton = null!;
    private Label logoHintLabel = null!;

    private Panel previewPanel = null!;
    private Label previewTitleLabel = null!;
    private Label previewStoreLabel = null!;
    private Label previewUserLabel = null!;

    private Panel footerPanel = null!;
    private Button cancelButton = null!;
    private Button saveButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        headerPanel = new Panel();
        subtitleLabel = new Label();
        titleLabel = new Label();
        contentLayout = new TableLayoutPanel();
        formPanel = new Panel();
        themeFlow = new FlowLayoutPanel();
        lightThemeRadioButton = new RadioButton();
        darkThemeRadioButton = new RadioButton();
        themeLabel = new Label();
        userNameTextBox = new TextBox();
        userNameLabel = new Label();
        storeNameTextBox = new TextBox();
        storeNameLabel = new Label();
        logoPanel = new Panel();
        tlpLogoButtons = new TableLayoutPanel();
        chooseLogoButton = new Button();
        removeLogoButton = new Button();
        logoHintLabel = new Label();
        logoPreview = new PictureBox();
        logoTitleLabel = new Label();
        previewPanel = new Panel();
        previewUserLabel = new Label();
        previewStoreLabel = new Label();
        previewTitleLabel = new Label();
        footerPanel = new Panel();
        cancelButton = new Button();
        saveButton = new Button();
        headerPanel.SuspendLayout();
        contentLayout.SuspendLayout();
        formPanel.SuspendLayout();
        themeFlow.SuspendLayout();
        logoPanel.SuspendLayout();
        tlpLogoButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoPreview).BeginInit();
        previewPanel.SuspendLayout();
        footerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // headerPanel
        // 
        headerPanel.Controls.Add(subtitleLabel);
        headerPanel.Controls.Add(titleLabel);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Padding = new Padding(32, 24, 32, 12);
        headerPanel.Size = new Size(900, 121);
        headerPanel.TabIndex = 2;
        // 
        // subtitleLabel
        // 
        subtitleLabel.Dock = DockStyle.Top;
        subtitleLabel.Location = new Point(32, 80);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(836, 31);
        subtitleLabel.TabIndex = 0;
        subtitleLabel.Text = "أدخل بيانات المحل الأساسية واختر المظهر الذي يناسبك.";
        // 
        // titleLabel
        // 
        titleLabel.Dock = DockStyle.Top;
        titleLabel.Font = new Font("Segoe UI Semibold", 20F);
        titleLabel.Location = new Point(32, 24);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(836, 56);
        titleLabel.TabIndex = 1;
        titleLabel.Text = "إعداد النظام لأول مرة";
        // 
        // contentLayout
        // 
        contentLayout.ColumnCount = 3;
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.8947372F));
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.08134F));
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        contentLayout.Controls.Add(formPanel, 0, 0);
        contentLayout.Controls.Add(logoPanel, 1, 0);
        contentLayout.Controls.Add(previewPanel, 2, 0);
        contentLayout.Dock = DockStyle.Fill;
        contentLayout.Location = new Point(0, 121);
        contentLayout.Name = "contentLayout";
        contentLayout.Padding = new Padding(32, 8, 32, 16);
        contentLayout.RowCount = 1;
        contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        contentLayout.Size = new Size(900, 427);
        contentLayout.TabIndex = 0;
        // 
        // formPanel
        // 
        formPanel.Controls.Add(themeFlow);
        formPanel.Controls.Add(themeLabel);
        formPanel.Controls.Add(userNameTextBox);
        formPanel.Controls.Add(userNameLabel);
        formPanel.Controls.Add(storeNameTextBox);
        formPanel.Controls.Add(storeNameLabel);
        formPanel.Dock = DockStyle.Fill;
        formPanel.Location = new Point(596, 11);
        formPanel.Name = "formPanel";
        formPanel.Padding = new Padding(0, 8, 24, 8);
        formPanel.Size = new Size(269, 397);
        formPanel.TabIndex = 0;
        // 
        // themeFlow
        // 
        themeFlow.Controls.Add(lightThemeRadioButton);
        themeFlow.Controls.Add(darkThemeRadioButton);
        themeFlow.Dock = DockStyle.Top;
        themeFlow.Location = new Point(0, 186);
        themeFlow.Name = "themeFlow";
        themeFlow.Size = new Size(245, 45);
        themeFlow.TabIndex = 0;
        themeFlow.WrapContents = false;
        // 
        // lightThemeRadioButton
        // 
        lightThemeRadioButton.AutoSize = true;
        lightThemeRadioButton.Checked = true;
        lightThemeRadioButton.Location = new Point(173, 10);
        lightThemeRadioButton.Margin = new Padding(12, 10, 0, 0);
        lightThemeRadioButton.Name = "lightThemeRadioButton";
        lightThemeRadioButton.Size = new Size(60, 27);
        lightThemeRadioButton.TabIndex = 0;
        lightThemeRadioButton.TabStop = true;
        lightThemeRadioButton.Text = "فاتح";
        lightThemeRadioButton.CheckedChanged += themeRadioButton_CheckedChanged;
        // 
        // darkThemeRadioButton
        // 
        darkThemeRadioButton.AutoSize = true;
        darkThemeRadioButton.Location = new Point(97, 10);
        darkThemeRadioButton.Margin = new Padding(12, 10, 0, 0);
        darkThemeRadioButton.Name = "darkThemeRadioButton";
        darkThemeRadioButton.Size = new Size(64, 27);
        darkThemeRadioButton.TabIndex = 1;
        darkThemeRadioButton.Text = "داكن";
        darkThemeRadioButton.CheckedChanged += themeRadioButton_CheckedChanged;
        // 
        // themeLabel
        // 
        themeLabel.Dock = DockStyle.Top;
        themeLabel.Location = new Point(0, 130);
        themeLabel.Name = "themeLabel";
        themeLabel.Padding = new Padding(0, 20, 0, 0);
        themeLabel.Size = new Size(245, 56);
        themeLabel.TabIndex = 1;
        themeLabel.Text = "المظهر";
        // 
        // userNameTextBox
        // 
        userNameTextBox.Dock = DockStyle.Top;
        userNameTextBox.Location = new Point(0, 100);
        userNameTextBox.Name = "userNameTextBox";
        userNameTextBox.Size = new Size(245, 30);
        userNameTextBox.TabIndex = 2;
        userNameTextBox.TextChanged += userNameTextBox_TextChanged;
        // 
        // userNameLabel
        // 
        userNameLabel.Dock = DockStyle.Top;
        userNameLabel.Location = new Point(0, 66);
        userNameLabel.Name = "userNameLabel";
        userNameLabel.Size = new Size(245, 34);
        userNameLabel.TabIndex = 3;
        userNameLabel.Text = "اسم المستخدم";
        // 
        // storeNameTextBox
        // 
        storeNameTextBox.Dock = DockStyle.Top;
        storeNameTextBox.Location = new Point(0, 36);
        storeNameTextBox.Name = "storeNameTextBox";
        storeNameTextBox.Size = new Size(245, 30);
        storeNameTextBox.TabIndex = 4;
        storeNameTextBox.TextChanged += storeNameTextBox_TextChanged;
        // 
        // storeNameLabel
        // 
        storeNameLabel.Dock = DockStyle.Top;
        storeNameLabel.Location = new Point(0, 8);
        storeNameLabel.Name = "storeNameLabel";
        storeNameLabel.Size = new Size(245, 28);
        storeNameLabel.TabIndex = 5;
        storeNameLabel.Text = "اسم المحل";
        // 
        // logoPanel
        // 
        logoPanel.Controls.Add(tlpLogoButtons);
        logoPanel.Controls.Add(logoHintLabel);
        logoPanel.Controls.Add(logoPreview);
        logoPanel.Controls.Add(logoTitleLabel);
        logoPanel.Dock = DockStyle.Fill;
        logoPanel.Location = new Point(286, 11);
        logoPanel.Name = "logoPanel";
        logoPanel.Size = new Size(304, 397);
        logoPanel.TabIndex = 1;
        // 
        // tlpLogoButtons
        // 
        tlpLogoButtons.AutoSize = true;
        tlpLogoButtons.ColumnCount = 2;
        tlpLogoButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpLogoButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpLogoButtons.Controls.Add(chooseLogoButton, 1, 0);
        tlpLogoButtons.Controls.Add(removeLogoButton, 0, 0);
        tlpLogoButtons.Dock = DockStyle.Top;
        tlpLogoButtons.Location = new Point(0, 180);
        tlpLogoButtons.Name = "tlpLogoButtons";
        tlpLogoButtons.RowCount = 1;
        tlpLogoButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpLogoButtons.Size = new Size(304, 42);
        tlpLogoButtons.TabIndex = 5;
        // 
        // chooseLogoButton
        // 
        chooseLogoButton.Anchor = AnchorStyles.Left;
        chooseLogoButton.Location = new Point(19, 3);
        chooseLogoButton.Name = "chooseLogoButton";
        chooseLogoButton.Size = new Size(130, 36);
        chooseLogoButton.TabIndex = 2;
        chooseLogoButton.Text = "اختيار شعار";
        chooseLogoButton.Click += chooseLogoButton_Click;
        // 
        // removeLogoButton
        // 
        removeLogoButton.Anchor = AnchorStyles.Right;
        removeLogoButton.Location = new Point(155, 3);
        removeLogoButton.Name = "removeLogoButton";
        removeLogoButton.Size = new Size(110, 36);
        removeLogoButton.TabIndex = 1;
        removeLogoButton.Text = "حذف الشعار";
        removeLogoButton.Click += removeLogoButton_Click;
        // 
        // logoHintLabel
        // 
        logoHintLabel.Dock = DockStyle.Bottom;
        logoHintLabel.Location = new Point(0, 355);
        logoHintLabel.Name = "logoHintLabel";
        logoHintLabel.Size = new Size(304, 42);
        logoHintLabel.TabIndex = 0;
        logoHintLabel.Text = "PNG أو JPG أو BMP. يمكنك ترك الشعار الافتراضي.";
        // 
        // logoPreview
        // 
        logoPreview.BorderStyle = BorderStyle.FixedSingle;
        logoPreview.Dock = DockStyle.Top;
        logoPreview.Location = new Point(0, 30);
        logoPreview.Name = "logoPreview";
        logoPreview.Size = new Size(304, 150);
        logoPreview.SizeMode = PictureBoxSizeMode.Zoom;
        logoPreview.TabIndex = 3;
        logoPreview.TabStop = false;
        logoPreview.Text = "بدون شعار";
        // 
        // logoTitleLabel
        // 
        logoTitleLabel.Dock = DockStyle.Top;
        logoTitleLabel.Location = new Point(0, 0);
        logoTitleLabel.Name = "logoTitleLabel";
        logoTitleLabel.Size = new Size(304, 30);
        logoTitleLabel.TabIndex = 4;
        logoTitleLabel.Text = "شعار المحل";
        // 
        // previewPanel
        // 
        previewPanel.Controls.Add(previewUserLabel);
        previewPanel.Controls.Add(previewStoreLabel);
        previewPanel.Controls.Add(previewTitleLabel);
        previewPanel.Dock = DockStyle.Fill;
        previewPanel.Location = new Point(35, 11);
        previewPanel.Name = "previewPanel";
        previewPanel.Padding = new Padding(24);
        previewPanel.Size = new Size(245, 397);
        previewPanel.TabIndex = 2;
        // 
        // previewUserLabel
        // 
        previewUserLabel.Dock = DockStyle.Top;
        previewUserLabel.Location = new Point(24, 114);
        previewUserLabel.Name = "previewUserLabel";
        previewUserLabel.Size = new Size(197, 35);
        previewUserLabel.TabIndex = 0;
        previewUserLabel.Text = "اسم المستخدم";
        previewUserLabel.TextAlign = ContentAlignment.TopCenter;
        // 
        // previewStoreLabel
        // 
        previewStoreLabel.Dock = DockStyle.Top;
        previewStoreLabel.Font = new Font("Segoe UI Semibold", 18F);
        previewStoreLabel.Location = new Point(24, 59);
        previewStoreLabel.Name = "previewStoreLabel";
        previewStoreLabel.Size = new Size(197, 55);
        previewStoreLabel.TabIndex = 1;
        previewStoreLabel.Text = "اسم المحل";
        previewStoreLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // previewTitleLabel
        // 
        previewTitleLabel.Dock = DockStyle.Top;
        previewTitleLabel.Font = new Font("Segoe UI Semibold", 12F);
        previewTitleLabel.Location = new Point(24, 24);
        previewTitleLabel.Name = "previewTitleLabel";
        previewTitleLabel.Size = new Size(197, 35);
        previewTitleLabel.TabIndex = 2;
        previewTitleLabel.Text = "معاينة الهوية";
        previewTitleLabel.TextAlign = ContentAlignment.TopCenter;
        // 
        // footerPanel
        // 
        footerPanel.Controls.Add(cancelButton);
        footerPanel.Controls.Add(saveButton);
        footerPanel.Dock = DockStyle.Bottom;
        footerPanel.Location = new Point(0, 548);
        footerPanel.Name = "footerPanel";
        footerPanel.Padding = new Padding(32, 12, 32, 18);
        footerPanel.Size = new Size(900, 72);
        footerPanel.TabIndex = 1;
        // 
        // cancelButton
        // 
        cancelButton.Dock = DockStyle.Right;
        cancelButton.Location = new Point(628, 12);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new Size(100, 42);
        cancelButton.TabIndex = 0;
        cancelButton.Text = "إلغاء";
        cancelButton.Click += cancelButton_Click;
        // 
        // saveButton
        // 
        saveButton.Dock = DockStyle.Right;
        saveButton.Location = new Point(728, 12);
        saveButton.Margin = new Padding(0, 0, 12, 0);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(140, 42);
        saveButton.TabIndex = 1;
        saveButton.Text = "حفظ ومتابعة";
        saveButton.Click += saveButton_Click;
        // 
        // FirstRunSetupForm
        // 
        ClientSize = new Size(900, 620);
        Controls.Add(contentLayout);
        Controls.Add(footerPanel);
        Controls.Add(headerPanel);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimumSize = new Size(760, 560);
        Name = "FirstRunSetupForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "إعداد StorePilot";
        headerPanel.ResumeLayout(false);
        contentLayout.ResumeLayout(false);
        formPanel.ResumeLayout(false);
        formPanel.PerformLayout();
        themeFlow.ResumeLayout(false);
        themeFlow.PerformLayout();
        logoPanel.ResumeLayout(false);
        logoPanel.PerformLayout();
        tlpLogoButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)logoPreview).EndInit();
        previewPanel.ResumeLayout(false);
        footerPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel tlpLogoButtons;
}
