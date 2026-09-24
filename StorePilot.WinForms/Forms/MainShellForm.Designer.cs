namespace StorePilot.WinForms.Forms;

partial class MainShellForm
{
    private System.ComponentModel.IContainer components = null;

    private TableLayoutPanel rootLayoutPanel = null!;
    private Panel sidebarPanel = null!;
    private Panel mainPanel = null!;
    private Panel topBarPanel = null!;
    private Panel contentPanel = null!;
    private Panel footerPanel = null!;

    private Panel brandPanel = null!;
    private PictureBox logoPictureBox = null!;
    private Label logoMarkLabel = null!;

    private Button dashboardButton = null!;

    private Label topBarStoreNameLabel = null!;
    private Panel userPanel = null!;
    private Panel userAvatarPanel = null!;
    private Label userInitialLabel = null!;

    private Panel contentHostPanel = null!;
    private Label footerLabel = null!;
    private Button unitsButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        rootLayoutPanel = new TableLayoutPanel();
        sidebarPanel = new Panel();
        navigationPanel = new Panel();
        settingsButton = new Button();
        reportsButton = new Button();
        inventoryButton = new Button();
        paymentsButton = new Button();
        returnsButton = new Button();
        quotationsButton = new Button();
        purchasesButton = new Button();
        salesButton = new Button();
        suppliersButton = new Button();
        customersButton = new Button();
        productsButton = new Button();
        unitsButton = new Button();
        groupsButton = new Button();
        dashboardButton = new Button();
        brandPanel = new Panel();
        storeSubtitleLabel = new Label();
        storeNameLabel = new Label();
        logoMarkLabel = new Label();
        logoPictureBox = new PictureBox();
        mainPanel = new Panel();
        contentPanel = new Panel();
        contentHostPanel = new Panel();
        footerPanel = new Panel();
        footerLabel = new Label();
        topBarPanel = new Panel();
        userPanel = new Panel();
        userNameLabel = new Label();
        welcomeUserLabel = new Label();
        userAvatarPanel = new Panel();
        userInitialLabel = new Label();
        topBarStoreNameLabel = new Label();
        rootLayoutPanel.SuspendLayout();
        sidebarPanel.SuspendLayout();
        navigationPanel.SuspendLayout();
        brandPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
        mainPanel.SuspendLayout();
        contentPanel.SuspendLayout();
        footerPanel.SuspendLayout();
        topBarPanel.SuspendLayout();
        userPanel.SuspendLayout();
        userAvatarPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayoutPanel
        // 
        rootLayoutPanel.ColumnCount = 2;
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 348F));
        rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayoutPanel.Controls.Add(sidebarPanel, 0, 0);
        rootLayoutPanel.Controls.Add(mainPanel, 1, 0);
        rootLayoutPanel.Dock = DockStyle.Fill;
        rootLayoutPanel.Location = new Point(0, 0);
        rootLayoutPanel.Margin = new Padding(0);
        rootLayoutPanel.Name = "rootLayoutPanel";
        rootLayoutPanel.RowCount = 1;
        rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayoutPanel.Size = new Size(1463, 960);
        rootLayoutPanel.TabIndex = 0;
        // 
        // sidebarPanel
        // 
        sidebarPanel.BackColor = Color.FromArgb(20, 24, 32);
        sidebarPanel.Controls.Add(navigationPanel);
        sidebarPanel.Controls.Add(brandPanel);
        sidebarPanel.Dock = DockStyle.Fill;
        sidebarPanel.Location = new Point(1115, 0);
        sidebarPanel.Margin = new Padding(0);
        sidebarPanel.Name = "sidebarPanel";
        sidebarPanel.Padding = new Padding(14, 16, 14, 16);
        sidebarPanel.Size = new Size(348, 960);
        sidebarPanel.TabIndex = 0;
        // 
        // navigationPanel
        // 
        navigationPanel.Controls.Add(settingsButton);
        navigationPanel.Controls.Add(reportsButton);
        navigationPanel.Controls.Add(inventoryButton);
        navigationPanel.Controls.Add(paymentsButton);
        navigationPanel.Controls.Add(returnsButton);
        navigationPanel.Controls.Add(quotationsButton);
        navigationPanel.Controls.Add(purchasesButton);
        navigationPanel.Controls.Add(salesButton);
        navigationPanel.Controls.Add(suppliersButton);
        navigationPanel.Controls.Add(customersButton);
        navigationPanel.Controls.Add(productsButton);
        navigationPanel.Controls.Add(unitsButton);
        navigationPanel.Controls.Add(groupsButton);
        navigationPanel.Controls.Add(dashboardButton);
        navigationPanel.Dock = DockStyle.Fill;
        navigationPanel.Location = new Point(14, 85);
        navigationPanel.Name = "navigationPanel";
        navigationPanel.Padding = new Padding(5);
        navigationPanel.Size = new Size(320, 859);
        navigationPanel.TabIndex = 2;
        // 
        // settingsButton
        // 
        settingsButton.BackColor = Color.FromArgb(20, 24, 32);
        settingsButton.Cursor = Cursors.Hand;
        settingsButton.Dock = DockStyle.Top;
        settingsButton.FlatAppearance.BorderSize = 0;
        settingsButton.FlatStyle = FlatStyle.Flat;
        settingsButton.ForeColor = Color.FromArgb(220, 225, 235);
        settingsButton.Location = new Point(5, 733);
        settingsButton.Margin = new Padding(0, 0, 0, 8);
        settingsButton.Name = "settingsButton";
        settingsButton.Size = new Size(310, 56);
        settingsButton.TabIndex = 13;
        settingsButton.Tag = "11";
        settingsButton.Text = "⚙  الإعدادات";
        settingsButton.TextAlign = ContentAlignment.MiddleLeft;
        settingsButton.UseVisualStyleBackColor = false;
        settingsButton.Click += NavigationButton_Click;
        // 
        // reportsButton
        // 
        reportsButton.BackColor = Color.FromArgb(20, 24, 32);
        reportsButton.Cursor = Cursors.Hand;
        reportsButton.Dock = DockStyle.Top;
        reportsButton.FlatAppearance.BorderSize = 0;
        reportsButton.FlatStyle = FlatStyle.Flat;
        reportsButton.ForeColor = Color.FromArgb(220, 225, 235);
        reportsButton.Location = new Point(5, 677);
        reportsButton.Margin = new Padding(0, 0, 0, 8);
        reportsButton.Name = "reportsButton";
        reportsButton.Size = new Size(310, 56);
        reportsButton.TabIndex = 12;
        reportsButton.Tag = "10";
        reportsButton.Text = "▤    التقارير ";
        reportsButton.TextAlign = ContentAlignment.MiddleLeft;
        reportsButton.UseVisualStyleBackColor = false;
        reportsButton.Click += NavigationButton_Click;
        // 
        // inventoryButton
        // 
        inventoryButton.BackColor = Color.FromArgb(20, 24, 32);
        inventoryButton.Cursor = Cursors.Hand;
        inventoryButton.Dock = DockStyle.Top;
        inventoryButton.FlatAppearance.BorderSize = 0;
        inventoryButton.FlatStyle = FlatStyle.Flat;
        inventoryButton.ForeColor = Color.FromArgb(220, 225, 235);
        inventoryButton.Location = new Point(5, 621);
        inventoryButton.Margin = new Padding(0, 0, 0, 8);
        inventoryButton.Name = "inventoryButton";
        inventoryButton.Size = new Size(310, 56);
        inventoryButton.TabIndex = 11;
        inventoryButton.Tag = "9";
        inventoryButton.Text = "▥    المخزون";
        inventoryButton.TextAlign = ContentAlignment.MiddleLeft;
        inventoryButton.UseVisualStyleBackColor = false;
        inventoryButton.Click += NavigationButton_Click;
        // 
        // paymentsButton
        // 
        paymentsButton.BackColor = Color.FromArgb(20, 24, 32);
        paymentsButton.Cursor = Cursors.Hand;
        paymentsButton.Dock = DockStyle.Top;
        paymentsButton.FlatAppearance.BorderSize = 0;
        paymentsButton.FlatStyle = FlatStyle.Flat;
        paymentsButton.ForeColor = Color.FromArgb(220, 225, 235);
        paymentsButton.Location = new Point(5, 565);
        paymentsButton.Margin = new Padding(0, 0, 0, 8);
        paymentsButton.Name = "paymentsButton";
        paymentsButton.Size = new Size(310, 56);
        paymentsButton.TabIndex = 10;
        paymentsButton.Tag = "8";
        paymentsButton.Text = "◫    المدفوعات";
        paymentsButton.TextAlign = ContentAlignment.MiddleLeft;
        paymentsButton.UseVisualStyleBackColor = false;
        paymentsButton.Click += NavigationButton_Click;
        // 
        // returnsButton
        // 
        returnsButton.BackColor = Color.FromArgb(20, 24, 32);
        returnsButton.Cursor = Cursors.Hand;
        returnsButton.Dock = DockStyle.Top;
        returnsButton.FlatAppearance.BorderSize = 0;
        returnsButton.FlatStyle = FlatStyle.Flat;
        returnsButton.ForeColor = Color.FromArgb(220, 225, 235);
        returnsButton.Location = new Point(5, 509);
        returnsButton.Margin = new Padding(0, 0, 0, 8);
        returnsButton.Name = "returnsButton";
        returnsButton.Size = new Size(310, 56);
        returnsButton.TabIndex = 9;
        returnsButton.Tag = "7";
        returnsButton.Text = "↩    المرتجعات";
        returnsButton.TextAlign = ContentAlignment.MiddleLeft;
        returnsButton.UseVisualStyleBackColor = false;
        returnsButton.Click += NavigationButton_Click;
        // 
        // quotationsButton
        // 
        quotationsButton.BackColor = Color.FromArgb(20, 24, 32);
        quotationsButton.Cursor = Cursors.Hand;
        quotationsButton.Dock = DockStyle.Top;
        quotationsButton.FlatAppearance.BorderSize = 0;
        quotationsButton.FlatStyle = FlatStyle.Flat;
        quotationsButton.ForeColor = Color.FromArgb(220, 225, 235);
        quotationsButton.Location = new Point(5, 453);
        quotationsButton.Margin = new Padding(0, 0, 0, 8);
        quotationsButton.Name = "quotationsButton";
        quotationsButton.Size = new Size(310, 56);
        quotationsButton.TabIndex = 8;
        quotationsButton.Tag = "6";
        quotationsButton.Text = "▧    عروض الأسعار";
        quotationsButton.TextAlign = ContentAlignment.MiddleLeft;
        quotationsButton.UseVisualStyleBackColor = false;
        quotationsButton.Click += NavigationButton_Click;
        // 
        // purchasesButton
        // 
        purchasesButton.BackColor = Color.FromArgb(20, 24, 32);
        purchasesButton.Cursor = Cursors.Hand;
        purchasesButton.Dock = DockStyle.Top;
        purchasesButton.FlatAppearance.BorderSize = 0;
        purchasesButton.FlatStyle = FlatStyle.Flat;
        purchasesButton.ForeColor = Color.FromArgb(220, 225, 235);
        purchasesButton.Location = new Point(5, 397);
        purchasesButton.Margin = new Padding(0, 0, 0, 8);
        purchasesButton.Name = "purchasesButton";
        purchasesButton.Size = new Size(310, 56);
        purchasesButton.TabIndex = 7;
        purchasesButton.Tag = "5";
        purchasesButton.Text = "▤    المشتريات";
        purchasesButton.TextAlign = ContentAlignment.MiddleLeft;
        purchasesButton.UseVisualStyleBackColor = false;
        purchasesButton.Click += NavigationButton_Click;
        // 
        // salesButton
        // 
        salesButton.BackColor = Color.FromArgb(20, 24, 32);
        salesButton.Cursor = Cursors.Hand;
        salesButton.Dock = DockStyle.Top;
        salesButton.FlatAppearance.BorderSize = 0;
        salesButton.FlatStyle = FlatStyle.Flat;
        salesButton.ForeColor = Color.FromArgb(220, 225, 235);
        salesButton.Location = new Point(5, 341);
        salesButton.Margin = new Padding(0, 0, 0, 8);
        salesButton.Name = "salesButton";
        salesButton.Size = new Size(310, 56);
        salesButton.TabIndex = 6;
        salesButton.Tag = "4";
        salesButton.Text = "▰    المبيعات";
        salesButton.TextAlign = ContentAlignment.MiddleLeft;
        salesButton.UseVisualStyleBackColor = false;
        salesButton.Click += NavigationButton_Click;
        // 
        // suppliersButton
        // 
        suppliersButton.BackColor = Color.FromArgb(20, 24, 32);
        suppliersButton.Cursor = Cursors.Hand;
        suppliersButton.Dock = DockStyle.Top;
        suppliersButton.FlatAppearance.BorderSize = 0;
        suppliersButton.FlatStyle = FlatStyle.Flat;
        suppliersButton.ForeColor = Color.FromArgb(220, 225, 235);
        suppliersButton.Location = new Point(5, 285);
        suppliersButton.Margin = new Padding(0, 0, 0, 8);
        suppliersButton.Name = "suppliersButton";
        suppliersButton.Size = new Size(310, 56);
        suppliersButton.TabIndex = 5;
        suppliersButton.Tag = "3";
        suppliersButton.Text = "▤    الموردون";
        suppliersButton.TextAlign = ContentAlignment.MiddleLeft;
        suppliersButton.UseVisualStyleBackColor = false;
        suppliersButton.Click += NavigationButton_Click;
        // 
        // customersButton
        // 
        customersButton.BackColor = Color.FromArgb(20, 24, 32);
        customersButton.Cursor = Cursors.Hand;
        customersButton.Dock = DockStyle.Top;
        customersButton.FlatAppearance.BorderSize = 0;
        customersButton.FlatStyle = FlatStyle.Flat;
        customersButton.ForeColor = Color.FromArgb(220, 225, 235);
        customersButton.Location = new Point(5, 229);
        customersButton.Margin = new Padding(0, 0, 0, 8);
        customersButton.Name = "customersButton";
        customersButton.Size = new Size(310, 56);
        customersButton.TabIndex = 4;
        customersButton.Tag = "2";
        customersButton.Text = "◉    العملاء";
        customersButton.TextAlign = ContentAlignment.MiddleLeft;
        customersButton.UseVisualStyleBackColor = false;
        customersButton.Click += NavigationButton_Click;
        // 
        // productsButton
        // 
        productsButton.BackColor = Color.FromArgb(20, 24, 32);
        productsButton.Cursor = Cursors.Hand;
        productsButton.Dock = DockStyle.Top;
        productsButton.FlatAppearance.BorderSize = 0;
        productsButton.FlatStyle = FlatStyle.Flat;
        productsButton.ForeColor = Color.FromArgb(220, 225, 235);
        productsButton.Location = new Point(5, 173);
        productsButton.Margin = new Padding(0, 0, 0, 8);
        productsButton.Name = "productsButton";
        productsButton.Size = new Size(310, 56);
        productsButton.TabIndex = 3;
        productsButton.Tag = "1";
        productsButton.Text = "▣    الأصناف";
        productsButton.TextAlign = ContentAlignment.MiddleLeft;
        productsButton.UseVisualStyleBackColor = false;
        productsButton.Click += NavigationButton_Click;
        // 
        // unitsButton
        // 
        unitsButton.BackColor = Color.FromArgb(20, 24, 32);
        unitsButton.Cursor = Cursors.Hand;
        unitsButton.Dock = DockStyle.Top;
        unitsButton.FlatAppearance.BorderSize = 0;
        unitsButton.FlatStyle = FlatStyle.Flat;
        unitsButton.ForeColor = Color.FromArgb(220, 225, 235);
        unitsButton.Location = new Point(5, 117);
        unitsButton.Margin = new Padding(0, 0, 0, 8);
        unitsButton.Name = "unitsButton";
        unitsButton.Size = new Size(310, 56);
        unitsButton.TabIndex = 2;
        unitsButton.Tag = "11";
        unitsButton.Text = "⚙  وحدات القياس";
        unitsButton.TextAlign = ContentAlignment.MiddleLeft;
        unitsButton.UseVisualStyleBackColor = false;
        unitsButton.Click += NavigationButton_Click;
        // 
        // groupsButton
        // 
        groupsButton.BackColor = Color.FromArgb(20, 24, 32);
        groupsButton.Cursor = Cursors.Hand;
        groupsButton.Dock = DockStyle.Top;
        groupsButton.FlatAppearance.BorderSize = 0;
        groupsButton.FlatStyle = FlatStyle.Flat;
        groupsButton.ForeColor = Color.FromArgb(220, 225, 235);
        groupsButton.Location = new Point(5, 61);
        groupsButton.Margin = new Padding(0, 0, 0, 8);
        groupsButton.Name = "groupsButton";
        groupsButton.Size = new Size(310, 56);
        groupsButton.TabIndex = 1;
        groupsButton.Tag = "11";
        groupsButton.Text = "⚙  المجموعات";
        groupsButton.TextAlign = ContentAlignment.MiddleLeft;
        groupsButton.UseVisualStyleBackColor = false;
        groupsButton.Click += NavigationButton_Click;
        // 
        // dashboardButton
        // 
        dashboardButton.BackColor = Color.FromArgb(42, 112, 222);
        dashboardButton.Cursor = Cursors.Hand;
        dashboardButton.Dock = DockStyle.Top;
        dashboardButton.FlatAppearance.BorderSize = 0;
        dashboardButton.FlatStyle = FlatStyle.Flat;
        dashboardButton.ForeColor = Color.White;
        dashboardButton.Location = new Point(5, 5);
        dashboardButton.Margin = new Padding(0, 0, 0, 8);
        dashboardButton.Name = "dashboardButton";
        dashboardButton.Size = new Size(310, 56);
        dashboardButton.TabIndex = 0;
        dashboardButton.Tag = "0";
        dashboardButton.Text = "⌂    الرئيسية";
        dashboardButton.TextAlign = ContentAlignment.MiddleLeft;
        dashboardButton.UseVisualStyleBackColor = false;
        dashboardButton.Click += NavigationButton_Click;
        // 
        // brandPanel
        // 
        brandPanel.BackColor = Color.FromArgb(20, 24, 32);
        brandPanel.Controls.Add(storeSubtitleLabel);
        brandPanel.Controls.Add(storeNameLabel);
        brandPanel.Controls.Add(logoMarkLabel);
        brandPanel.Controls.Add(logoPictureBox);
        brandPanel.Dock = DockStyle.Top;
        brandPanel.Location = new Point(14, 16);
        brandPanel.Margin = new Padding(0);
        brandPanel.Name = "brandPanel";
        brandPanel.Size = new Size(320, 69);
        brandPanel.TabIndex = 0;
        // 
        // storeSubtitleLabel
        // 
        storeSubtitleLabel.AutoEllipsis = true;
        storeSubtitleLabel.Dock = DockStyle.Bottom;
        storeSubtitleLabel.Font = new Font("Segoe UI", 8F);
        storeSubtitleLabel.ForeColor = Color.FromArgb(160, 170, 185);
        storeSubtitleLabel.Location = new Point(0, 37);
        storeSubtitleLabel.Name = "storeSubtitleLabel";
        storeSubtitleLabel.Size = new Size(196, 32);
        storeSubtitleLabel.TabIndex = 7;
        storeSubtitleLabel.Text = "نظام إدارة المبيعات والمخزون";
        storeSubtitleLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // storeNameLabel
        // 
        storeNameLabel.AutoEllipsis = true;
        storeNameLabel.Dock = DockStyle.Top;
        storeNameLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        storeNameLabel.ForeColor = Color.White;
        storeNameLabel.Location = new Point(0, 0);
        storeNameLabel.Name = "storeNameLabel";
        storeNameLabel.Size = new Size(196, 37);
        storeNameLabel.TabIndex = 6;
        storeNameLabel.Text = "StorePilot";
        storeNameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // logoMarkLabel
        // 
        logoMarkLabel.BackColor = Color.FromArgb(42, 112, 222);
        logoMarkLabel.Dock = DockStyle.Right;
        logoMarkLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        logoMarkLabel.ForeColor = Color.White;
        logoMarkLabel.ImageAlign = ContentAlignment.MiddleLeft;
        logoMarkLabel.Location = new Point(196, 0);
        logoMarkLabel.Name = "logoMarkLabel";
        logoMarkLabel.Size = new Size(62, 69);
        logoMarkLabel.TabIndex = 1;
        logoMarkLabel.Text = "SP";
        logoMarkLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // logoPictureBox
        // 
        logoPictureBox.BackColor = Color.Transparent;
        logoPictureBox.Dock = DockStyle.Right;
        logoPictureBox.Location = new Point(258, 0);
        logoPictureBox.Margin = new Padding(3, 4, 3, 4);
        logoPictureBox.Name = "logoPictureBox";
        logoPictureBox.Size = new Size(62, 69);
        logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        logoPictureBox.TabIndex = 0;
        logoPictureBox.TabStop = false;
        logoPictureBox.Visible = false;
        // 
        // mainPanel
        // 
        mainPanel.BackColor = Color.FromArgb(247, 249, 252);
        mainPanel.Controls.Add(contentPanel);
        mainPanel.Controls.Add(footerPanel);
        mainPanel.Controls.Add(topBarPanel);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 0);
        mainPanel.Margin = new Padding(0);
        mainPanel.Name = "mainPanel";
        mainPanel.Size = new Size(1115, 960);
        mainPanel.TabIndex = 1;
        // 
        // contentPanel
        // 
        contentPanel.BackColor = Color.FromArgb(247, 249, 252);
        contentPanel.Controls.Add(contentHostPanel);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(0, 85);
        contentPanel.Margin = new Padding(3, 4, 3, 4);
        contentPanel.Name = "contentPanel";
        contentPanel.Padding = new Padding(27, 32, 27, 32);
        contentPanel.Size = new Size(1115, 838);
        contentPanel.TabIndex = 1;
        // 
        // contentHostPanel
        // 
        contentHostPanel.BackColor = Color.White;
        contentHostPanel.Dock = DockStyle.Fill;
        contentHostPanel.Location = new Point(27, 32);
        contentHostPanel.Margin = new Padding(3, 4, 3, 4);
        contentHostPanel.Name = "contentHostPanel";
        contentHostPanel.Size = new Size(1061, 774);
        contentHostPanel.TabIndex = 0;
        // 
        // footerPanel
        // 
        footerPanel.BackColor = Color.White;
        footerPanel.Controls.Add(footerLabel);
        footerPanel.Dock = DockStyle.Bottom;
        footerPanel.Location = new Point(0, 923);
        footerPanel.Margin = new Padding(3, 4, 3, 4);
        footerPanel.Name = "footerPanel";
        footerPanel.Padding = new Padding(27, 0, 27, 0);
        footerPanel.Size = new Size(1115, 37);
        footerPanel.TabIndex = 2;
        // 
        // footerLabel
        // 
        footerLabel.Dock = DockStyle.Fill;
        footerLabel.Font = new Font("Segoe UI", 8F);
        footerLabel.ForeColor = Color.FromArgb(107, 114, 128);
        footerLabel.Location = new Point(27, 0);
        footerLabel.Name = "footerLabel";
        footerLabel.Size = new Size(1061, 37);
        footerLabel.TabIndex = 0;
        footerLabel.Text = "StorePilot • نظام إدارة المبيعات والمشتريات والمخزون";
        footerLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // topBarPanel
        // 
        topBarPanel.BackColor = Color.White;
        topBarPanel.Controls.Add(userPanel);
        topBarPanel.Controls.Add(topBarStoreNameLabel);
        topBarPanel.Dock = DockStyle.Top;
        topBarPanel.Location = new Point(0, 0);
        topBarPanel.Margin = new Padding(3, 4, 3, 4);
        topBarPanel.Name = "topBarPanel";
        topBarPanel.Padding = new Padding(27, 16, 27, 16);
        topBarPanel.Size = new Size(1115, 85);
        topBarPanel.TabIndex = 0;
        // 
        // userPanel
        // 
        userPanel.BackColor = Color.White;
        userPanel.Controls.Add(userNameLabel);
        userPanel.Controls.Add(welcomeUserLabel);
        userPanel.Controls.Add(userAvatarPanel);
        userPanel.Dock = DockStyle.Right;
        userPanel.Location = new Point(852, 16);
        userPanel.Margin = new Padding(3, 4, 3, 4);
        userPanel.Name = "userPanel";
        userPanel.Size = new Size(236, 53);
        userPanel.TabIndex = 1;
        // 
        // userNameLabel
        // 
        userNameLabel.AutoEllipsis = true;
        userNameLabel.Dock = DockStyle.Bottom;
        userNameLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        userNameLabel.ForeColor = Color.FromArgb(31, 41, 55);
        userNameLabel.Location = new Point(0, 21);
        userNameLabel.Name = "userNameLabel";
        userNameLabel.Size = new Size(172, 32);
        userNameLabel.TabIndex = 4;
        userNameLabel.Text = "المستخدم";
        userNameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // welcomeUserLabel
        // 
        welcomeUserLabel.AutoEllipsis = true;
        welcomeUserLabel.Dock = DockStyle.Top;
        welcomeUserLabel.Font = new Font("Segoe UI", 8F);
        welcomeUserLabel.ForeColor = Color.FromArgb(107, 114, 128);
        welcomeUserLabel.Location = new Point(0, 0);
        welcomeUserLabel.Name = "welcomeUserLabel";
        welcomeUserLabel.Size = new Size(172, 27);
        welcomeUserLabel.TabIndex = 3;
        welcomeUserLabel.Text = "مرحباً";
        // 
        // userAvatarPanel
        // 
        userAvatarPanel.BackColor = Color.FromArgb(42, 112, 222);
        userAvatarPanel.Controls.Add(userInitialLabel);
        userAvatarPanel.Dock = DockStyle.Right;
        userAvatarPanel.Location = new Point(172, 0);
        userAvatarPanel.Margin = new Padding(0);
        userAvatarPanel.Name = "userAvatarPanel";
        userAvatarPanel.Size = new Size(64, 53);
        userAvatarPanel.TabIndex = 2;
        // 
        // userInitialLabel
        // 
        userInitialLabel.Dock = DockStyle.Fill;
        userInitialLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        userInitialLabel.ForeColor = Color.White;
        userInitialLabel.Location = new Point(0, 0);
        userInitialLabel.Name = "userInitialLabel";
        userInitialLabel.Padding = new Padding(0, 0, 0, 10);
        userInitialLabel.Size = new Size(64, 53);
        userInitialLabel.TabIndex = 0;
        userInitialLabel.Text = "م";
        userInitialLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // topBarStoreNameLabel
        // 
        topBarStoreNameLabel.Anchor = AnchorStyles.Left;
        topBarStoreNameLabel.AutoEllipsis = true;
        topBarStoreNameLabel.AutoSize = true;
        topBarStoreNameLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        topBarStoreNameLabel.ForeColor = Color.FromArgb(31, 41, 55);
        topBarStoreNameLabel.Location = new Point(27, 27);
        topBarStoreNameLabel.Name = "topBarStoreNameLabel";
        topBarStoreNameLabel.Size = new Size(111, 30);
        topBarStoreNameLabel.TabIndex = 0;
        topBarStoreNameLabel.Text = "StorePilot";
        topBarStoreNameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // MainShellForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 249, 252);
        ClientSize = new Size(1463, 960);
        Controls.Add(rootLayoutPanel);
        Font = new Font("Segoe UI", 9F);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(1140, 784);
        Name = "MainShellForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "StorePilot";
        WindowState = FormWindowState.Maximized;
        Load += MainShellForm_Load;
        rootLayoutPanel.ResumeLayout(false);
        sidebarPanel.ResumeLayout(false);
        navigationPanel.ResumeLayout(false);
        brandPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
        mainPanel.ResumeLayout(false);
        contentPanel.ResumeLayout(false);
        footerPanel.ResumeLayout(false);
        topBarPanel.ResumeLayout(false);
        topBarPanel.PerformLayout();
        userPanel.ResumeLayout(false);
        userAvatarPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
    private Label userNameLabel;
    private Label welcomeUserLabel;
    private Label storeSubtitleLabel;
    private Label storeNameLabel;
    private Panel navigationPanel;
    private Button suppliersButton;
    private Button customersButton;
    private Button productsButton;
    //private Button button2;
    private Button groupsButton;
    private Button settingsButton;
    private Button reportsButton;
    private Button inventoryButton;
    private Button paymentsButton;
    private Button returnsButton;
    private Button quotationsButton;
    private Button purchasesButton;
    private Button salesButton;
    //private Button unitsButton;
}
