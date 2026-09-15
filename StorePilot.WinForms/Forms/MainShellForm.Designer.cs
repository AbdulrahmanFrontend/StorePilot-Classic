namespace StorePilot.WinForms;

partial class MainShellForm
{
    private System.ComponentModel.IContainer components = null!;

    private Krypton.Toolkit.KryptonPanel sidebarPanel;
    private Krypton.Toolkit.KryptonPanel topBarPanel;
    private Krypton.Toolkit.KryptonPanel contentPanel;

    private System.Windows.Forms.FlowLayoutPanel navigationPanel;
    private System.Windows.Forms.Panel contentHost;

    private System.Windows.Forms.Button btnDashboard;
    private System.Windows.Forms.Button btnProducts;
    private System.Windows.Forms.Button btnCustomers;
    private System.Windows.Forms.Button btnSuppliers;
    private System.Windows.Forms.Button btnSales;
    private System.Windows.Forms.Button btnPurchases;
    private System.Windows.Forms.Button btnQuotations;
    private System.Windows.Forms.Button btnReturns;
    private System.Windows.Forms.Button btnPayments;
    private System.Windows.Forms.Button btnInventory;
    private System.Windows.Forms.Button btnReports;

    private System.Windows.Forms.Button btnSettings;
    private System.Windows.Forms.Button btnBackup;
    private System.Windows.Forms.Button btnTheme;
    private System.Windows.Forms.Button btnExit;

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
        this.components = new System.ComponentModel.Container();

        this.sidebarPanel = new Krypton.Toolkit.KryptonPanel();
        this.topBarPanel = new Krypton.Toolkit.KryptonPanel();
        this.contentPanel = new Krypton.Toolkit.KryptonPanel();

        this.navigationPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.contentHost = new System.Windows.Forms.Panel();

        this.btnDashboard = CreateNavigationButton("الرئيسية");
        this.btnProducts = CreateNavigationButton("الأصناف");
        this.btnCustomers = CreateNavigationButton("العملاء");
        this.btnSuppliers = CreateNavigationButton("الموردون");
        this.btnSales = CreateNavigationButton("المبيعات");
        this.btnPurchases = CreateNavigationButton("المشتريات");
        this.btnQuotations = CreateNavigationButton("التسعير");
        this.btnReturns = CreateNavigationButton("المرتجعات");
        this.btnPayments = CreateNavigationButton("الدفعات");
        this.btnInventory = CreateNavigationButton("المخزون");
        this.btnReports = CreateNavigationButton("التقارير");

        this.btnSettings = CreateTopButton("الإعدادات");
        this.btnBackup = CreateTopButton("نسخة احتياطية");
        this.btnTheme = CreateTopButton("الوضع");
        this.btnExit = CreateTopButton("خروج");

        this.SuspendLayout();

        // MainShellForm
        this.AutoScaleDimensions =
            new System.Drawing.SizeF(7F, 15F);

        this.AutoScaleMode =
            System.Windows.Forms.AutoScaleMode.Font;

        this.ClientSize =
            new System.Drawing.Size(1400, 800);

        this.Name = "MainShellForm";
        this.Text = "StorePilot";

        this.RightToLeft =
            System.Windows.Forms.RightToLeft.Yes;

        this.RightToLeftLayout = true;

        // Sidebar
        this.sidebarPanel.Dock =
            System.Windows.Forms.DockStyle.Right;

        this.sidebarPanel.Width = 230;

        this.sidebarPanel.Padding =
            new System.Windows.Forms.Padding(10);

        this.sidebarPanel.Name = "sidebarPanel";

        this.sidebarPanel.Controls.Add(this.navigationPanel);

        // Navigation
        this.navigationPanel.Dock =
            System.Windows.Forms.DockStyle.Fill;

        this.navigationPanel.FlowDirection =
            System.Windows.Forms.FlowDirection.TopDown;

        this.navigationPanel.WrapContents = false;

        this.navigationPanel.AutoScroll = true;

        this.navigationPanel.Name = "navigationPanel";

        this.navigationPanel.Controls.Add(this.btnDashboard);
        this.navigationPanel.Controls.Add(this.btnProducts);
        this.navigationPanel.Controls.Add(this.btnCustomers);
        this.navigationPanel.Controls.Add(this.btnSuppliers);
        this.navigationPanel.Controls.Add(this.btnSales);
        this.navigationPanel.Controls.Add(this.btnPurchases);
        this.navigationPanel.Controls.Add(this.btnQuotations);
        this.navigationPanel.Controls.Add(this.btnReturns);
        this.navigationPanel.Controls.Add(this.btnPayments);
        this.navigationPanel.Controls.Add(this.btnInventory);
        this.navigationPanel.Controls.Add(this.btnReports);

        // Top bar
        this.topBarPanel.Dock =
            System.Windows.Forms.DockStyle.Top;

        this.topBarPanel.Height = 55;

        this.topBarPanel.Padding =
            new System.Windows.Forms.Padding(10, 8, 10, 8);

        this.topBarPanel.Name = "topBarPanel";

        this.topBarPanel.Controls.Add(this.btnExit);
        this.topBarPanel.Controls.Add(this.btnTheme);
        this.topBarPanel.Controls.Add(this.btnBackup);
        this.topBarPanel.Controls.Add(this.btnSettings);

        // Content
        this.contentPanel.Dock =
            System.Windows.Forms.DockStyle.Fill;

        this.contentPanel.Padding =
            new System.Windows.Forms.Padding(10);

        this.contentPanel.Name = "contentPanel";

        this.contentPanel.Controls.Add(this.contentHost);

        // Content Host
        this.contentHost.Dock =
            System.Windows.Forms.DockStyle.Fill;

        this.contentHost.Name = "contentHost";

        this.contentHost.AutoScroll = true;

        // Add to form
        this.Controls.Add(this.contentPanel);
        this.Controls.Add(this.topBarPanel);
        this.Controls.Add(this.sidebarPanel);

        this.ResumeLayout(false);
    }

    private static System.Windows.Forms.Button CreateNavigationButton(
        string text)
    {
        return new System.Windows.Forms.Button
        {
            Text = text,
            Width = 205,
            Height = 42,
            Margin = new System.Windows.Forms.Padding(0, 0, 0, 5),
            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
            TextAlign = System.Drawing.ContentAlignment.MiddleRight,
            Padding = new System.Windows.Forms.Padding(12, 0, 12, 0),
            UseVisualStyleBackColor = false,
            TabStop = false
        };
    }

    private static System.Windows.Forms.Button CreateTopButton(
        string text)
    {
        return new System.Windows.Forms.Button
        {
            Text = text,
            AutoSize = true,
            Height = 35,
            Margin = new System.Windows.Forms.Padding(4, 0, 4, 0),
            FlatStyle = System.Windows.Forms.FlatStyle.Flat,
            UseVisualStyleBackColor = false,
            TabStop = false
        };
    }
}