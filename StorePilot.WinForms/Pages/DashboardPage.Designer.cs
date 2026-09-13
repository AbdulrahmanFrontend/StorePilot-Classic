namespace StorePilot.WinForms.Pages;

partial class DashboardPage
{
    private System.ComponentModel.IContainer components = null;

    private StorePilot.WinForms.Controls.PageHeader header;

    private System.Windows.Forms.TableLayoutPanel cards;
    private System.Windows.Forms.TableLayoutPanel tables;

    private StorePilot.WinForms.Controls.SummaryCard sales;
    private StorePilot.WinForms.Controls.SummaryCard customers;
    private StorePilot.WinForms.Controls.SummaryCard suppliers;
    private StorePilot.WinForms.Controls.SummaryCard low;

    private Krypton.Toolkit.KryptonPanel recent;
    private Krypton.Toolkit.KryptonPanel alerts;

    private Krypton.Toolkit.KryptonLabel recentTitle;
    private Krypton.Toolkit.KryptonLabel alertsTitle;

    private Krypton.Toolkit.KryptonDataGridView salesGrid;
    private Krypton.Toolkit.KryptonDataGridView lowGrid;

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
        // 1. تهيئة الكروت والكونترولز
        header = new StorePilot.WinForms.Controls.PageHeader();
        cards = new System.Windows.Forms.TableLayoutPanel();
        sales = new StorePilot.WinForms.Controls.SummaryCard();
        customers = new StorePilot.WinForms.Controls.SummaryCard();
        suppliers = new StorePilot.WinForms.Controls.SummaryCard();
        low = new StorePilot.WinForms.Controls.SummaryCard();

        tables = new System.Windows.Forms.TableLayoutPanel();
        recent = new Krypton.Toolkit.KryptonPanel();
        salesGrid = new Krypton.Toolkit.KryptonDataGridView();
        recentTitle = new Krypton.Toolkit.KryptonLabel();
        alerts = new Krypton.Toolkit.KryptonPanel();
        lowGrid = new Krypton.Toolkit.KryptonDataGridView();
        alertsTitle = new Krypton.Toolkit.KryptonLabel();

        cards.SuspendLayout();
        tables.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)recent).BeginInit();
        recent.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)salesGrid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)alerts).BeginInit();
        alerts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)lowGrid).BeginInit();
        SuspendLayout();

        // 
        // header
        // 
        header.Dock = System.Windows.Forms.DockStyle.Top;
        header.Height = 60;
        header.Name = "header";
        header.Title = "لوحة التحكم";
        header.Description = "ملخص سريع للمبيعات والذمم وتنبيهات النواقص.";

        // 
        // cards (شبكة الكروت 4 أعمدة)
        // 
        cards.ColumnCount = 4;
        cards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        cards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        cards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        cards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

        // إضافة الكروت إلى شبكة الـ cards
        cards.Controls.Add(sales, 0, 0);
        cards.Controls.Add(customers, 1, 0);
        cards.Controls.Add(suppliers, 2, 0);
        cards.Controls.Add(low, 3, 0);

        cards.Dock = System.Windows.Forms.DockStyle.Top;
        cards.Height = 125;
        cards.Name = "cards";
        cards.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);

        // 
        // sales
        // 
        sales.Dock = System.Windows.Forms.DockStyle.Fill;
        sales.Name = "sales";
        //sales.Title = "مبيعات اليوم";

        // 
        // customers
        // 
        customers.Dock = System.Windows.Forms.DockStyle.Fill;
        customers.Name = "customers";
        //customers.Title = "أرصدة العملاء";

        // 
        // suppliers
        // 
        suppliers.Dock = System.Windows.Forms.DockStyle.Fill;
        suppliers.Name = "suppliers";
        //suppliers.Title = "أرصدة الموردين";

        // 
        // low
        // 
        low.Dock = System.Windows.Forms.DockStyle.Fill;
        low.Name = "low";
        //low.Title = "نواقص المخزون";

        // 
        // tables
        // 
        tables.ColumnCount = 2;
        tables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
        tables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
        tables.Controls.Add(recent, 0, 0);
        tables.Controls.Add(alerts, 1, 0);
        tables.Dock = System.Windows.Forms.DockStyle.Fill;
        tables.Name = "tables";

        // 
        // recent
        // 
        recent.Controls.Add(salesGrid);
        recent.Controls.Add(recentTitle);
        recent.Dock = System.Windows.Forms.DockStyle.Fill;
        recent.Name = "recent";
        recent.Padding = new System.Windows.Forms.Padding(12);

        // 
        // salesGrid
        // 
        salesGrid.AllowUserToAddRows = false;
        salesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        salesGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        salesGrid.ColumnHeadersHeight = 36;
        salesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        salesGrid.Name = "salesGrid";
        salesGrid.ReadOnly = true;
        salesGrid.RowHeadersVisible = false;

        // 
        // recentTitle
        // 
        recentTitle.Dock = System.Windows.Forms.DockStyle.Top;
        recentTitle.Name = "recentTitle";
        recentTitle.Values.Text = "آخر فواتير البيع";

        // 
        // alerts
        // 
        alerts.Controls.Add(lowGrid);
        alerts.Controls.Add(alertsTitle);
        alerts.Dock = System.Windows.Forms.DockStyle.Fill;
        alerts.Name = "alerts";
        alerts.Padding = new System.Windows.Forms.Padding(12);

        // 
        // lowGrid
        // 
        lowGrid.AllowUserToAddRows = false;
        lowGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        lowGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        lowGrid.ColumnHeadersHeight = 36;
        lowGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        lowGrid.Name = "lowGrid";
        lowGrid.ReadOnly = true;
        lowGrid.RowHeadersVisible = false;

        // 
        // alertsTitle
        // 
        alertsTitle.Dock = System.Windows.Forms.DockStyle.Top;
        alertsTitle.Name = "alertsTitle";
        alertsTitle.Values.Text = "تنبيهات المخزون";

        // 
        // DashboardPage
        // 
        Controls.Add(tables);
        Controls.Add(cards);
        Controls.Add(header);
        Name = "DashboardPage";
        Padding = new System.Windows.Forms.Padding(18);
        RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        Size = new System.Drawing.Size(1286, 533);

        cards.ResumeLayout(false);
        tables.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)recent).EndInit();
        recent.ResumeLayout(false);
        recent.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)salesGrid).EndInit();
        ((System.ComponentModel.ISupportInitialize)alerts).EndInit();
        alerts.ResumeLayout(false);
        alerts.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)lowGrid).EndInit();
        ResumeLayout(false);
    }
}