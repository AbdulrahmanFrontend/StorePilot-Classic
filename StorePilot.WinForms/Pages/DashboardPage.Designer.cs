using System.Drawing;
using System.Windows.Forms;

namespace StorePilot.WinForms.Pages
{
    partial class DashboardPage
    {
        private TableLayoutPanel rootLayout;
        private Panel headerPanel;
        private Label storeNameLabel;
        private Label welcomeUserLabel;

        private TableLayoutPanel statisticsLayout;

        private Panel todaySalesCard;
        private Panel todayPurchasesCard;
        private Panel totalDebtsCard;
        private Panel productsCard;
        private Panel lowStockCard;

        private Label todaySalesTitleLabel;
        private Label todaySalesValueLabel;
        private Label todaySalesDescriptionLabel;

        private Label todayPurchasesTitleLabel;
        private Label todayPurchasesValueLabel;
        private Label todayPurchasesDescriptionLabel;

        private Label totalDebtsTitleLabel;
        private Label totalDebtsValueLabel;
        private Label totalDebtsDescriptionLabel;

        private Label productsTitleLabel;
        private Label productsValueLabel;
        private Label productsDescriptionLabel;

        private Label lowStockTitleLabel;
        private Label lowStockValueLabel;
        private Label lowStockDescriptionLabel;

        private TableLayoutPanel bottomLayout;
        private Panel recentSalesPanel;
        private Panel lowStockPanel;

        private Label recentSalesTitleLabel;
        //private Label lowStockTitleLabel;

        private DataGridView recentSalesGrid;
        private DataGridView lowStockGrid;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            rootLayout = new TableLayoutPanel();
            headerPanel = new Panel();
            pageTitleLabel = new Label();
            pageSubtitleLabel = new Label();
            panel1 = new Panel();
            refreshButton = new Button();
            storeNameLabel = new Label();
            welcomeUserLabel = new Label();
            statisticsLayout = new TableLayoutPanel();
            todaySalesCard = new Panel();
            todaySalesDescriptionLabel = new Label();
            todaySalesValueLabel = new Label();
            todaySalesTitleLabel = new Label();
            todayPurchasesCard = new Panel();
            todayPurchasesDescriptionLabel = new Label();
            todayPurchasesValueLabel = new Label();
            todayPurchasesTitleLabel = new Label();
            totalDebtsCard = new Panel();
            totalDebtsDescriptionLabel = new Label();
            totalDebtsValueLabel = new Label();
            totalDebtsTitleLabel = new Label();
            productsCard = new Panel();
            productsDescriptionLabel = new Label();
            productsValueLabel = new Label();
            productsTitleLabel = new Label();
            lowStockCard = new Panel();
            lowStockDescriptionLabel = new Label();
            lowStockValueLabel = new Label();
            bottomLayout = new TableLayoutPanel();
            recentSalesPanel = new Panel();
            recentSalesGrid = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            recentSalesTitleLabel = new Label();
            lowStockPanel = new Panel();
            lowStockGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            lowStockTitleLabel = new Label();
            rootLayout.SuspendLayout();
            headerPanel.SuspendLayout();
            panel1.SuspendLayout();
            statisticsLayout.SuspendLayout();
            todaySalesCard.SuspendLayout();
            todayPurchasesCard.SuspendLayout();
            totalDebtsCard.SuspendLayout();
            productsCard.SuspendLayout();
            lowStockCard.SuspendLayout();
            bottomLayout.SuspendLayout();
            recentSalesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)recentSalesGrid).BeginInit();
            lowStockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lowStockGrid).BeginInit();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(headerPanel, 0, 0);
            rootLayout.Controls.Add(statisticsLayout, 0, 1);
            rootLayout.Controls.Add(bottomLayout, 0, 2);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(23, 27);
            rootLayout.Margin = new Padding(3, 4, 3, 4);
            rootLayout.Name = "rootLayout";
            rootLayout.RowCount = 3;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 176F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.Size = new Size(1251, 521);
            rootLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.AutoSize = true;
            headerPanel.Controls.Add(pageTitleLabel);
            headerPanel.Controls.Add(pageSubtitleLabel);
            headerPanel.Controls.Add(panel1);
            headerPanel.Controls.Add(storeNameLabel);
            headerPanel.Controls.Add(welcomeUserLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(0, 0, 0, 20);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1251, 78);
            headerPanel.TabIndex = 0;
            // 
            // pageTitleLabel
            // 
            pageTitleLabel.Dock = DockStyle.Top;
            pageTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            pageTitleLabel.Location = new Point(105, 0);
            pageTitleLabel.Name = "pageTitleLabel";
            pageTitleLabel.Size = new Size(1146, 43);
            pageTitleLabel.TabIndex = 9;
            pageTitleLabel.Text = "لوحة التحكم";
            // 
            // pageSubtitleLabel
            // 
            pageSubtitleLabel.Dock = DockStyle.Bottom;
            pageSubtitleLabel.Font = new Font("Segoe UI", 9.5F);
            pageSubtitleLabel.Location = new Point(105, 43);
            pageSubtitleLabel.Name = "pageSubtitleLabel";
            pageSubtitleLabel.Size = new Size(1146, 35);
            pageSubtitleLabel.TabIndex = 8;
            pageSubtitleLabel.Text = "ملخص سريع لحالة المبيعات والمشتريات والمخزون.";
            pageSubtitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(refreshButton);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(105, 78);
            panel1.TabIndex = 2;
            // 
            // refreshButton
            // 
            refreshButton.AutoSize = true;
            refreshButton.Cursor = Cursors.Hand;
            refreshButton.Dock = DockStyle.Fill;
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.Font = new Font("Segoe UI", 9F);
            refreshButton.Location = new Point(20, 20);
            refreshButton.Margin = new Padding(3, 4, 3, 4);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(65, 38);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "تحديث";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += RefreshButton_Click;
            // 
            // storeNameLabel
            // 
            storeNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            storeNameLabel.AutoSize = true;
            storeNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            storeNameLabel.Location = new Point(1993, 5);
            storeNameLabel.Name = "storeNameLabel";
            storeNameLabel.Size = new Size(90, 23);
            storeNameLabel.TabIndex = 0;
            storeNameLabel.Text = "StorePilot";
            // 
            // welcomeUserLabel
            // 
            welcomeUserLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            welcomeUserLabel.AutoSize = true;
            welcomeUserLabel.Font = new Font("Segoe UI", 9F);
            welcomeUserLabel.Location = new Point(1993, 51);
            welcomeUserLabel.Name = "welcomeUserLabel";
            welcomeUserLabel.Size = new Size(64, 20);
            welcomeUserLabel.TabIndex = 1;
            welcomeUserLabel.Text = "مرحباً بك";
            // 
            // statisticsLayout
            // 
            statisticsLayout.ColumnCount = 5;
            statisticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statisticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statisticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statisticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statisticsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            statisticsLayout.Controls.Add(todaySalesCard, 0, 0);
            statisticsLayout.Controls.Add(todayPurchasesCard, 1, 0);
            statisticsLayout.Controls.Add(totalDebtsCard, 2, 0);
            statisticsLayout.Controls.Add(productsCard, 3, 0);
            statisticsLayout.Controls.Add(lowStockCard, 4, 0);
            statisticsLayout.Dock = DockStyle.Fill;
            statisticsLayout.Location = new Point(0, 98);
            statisticsLayout.Margin = new Padding(0, 0, 0, 20);
            statisticsLayout.Name = "statisticsLayout";
            statisticsLayout.RowCount = 1;
            statisticsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            statisticsLayout.Size = new Size(1251, 156);
            statisticsLayout.TabIndex = 1;
            // 
            // todaySalesCard
            // 
            todaySalesCard.Controls.Add(todaySalesDescriptionLabel);
            todaySalesCard.Controls.Add(todaySalesValueLabel);
            todaySalesCard.Controls.Add(todaySalesTitleLabel);
            todaySalesCard.Dock = DockStyle.Fill;
            todaySalesCard.Location = new Point(1010, 0);
            todaySalesCard.Margin = new Padding(0, 0, 9, 0);
            todaySalesCard.Name = "todaySalesCard";
            todaySalesCard.Padding = new Padding(17, 20, 17, 20);
            todaySalesCard.Size = new Size(241, 156);
            todaySalesCard.TabIndex = 0;
            // 
            // todaySalesDescriptionLabel
            // 
            todaySalesDescriptionLabel.Dock = DockStyle.Fill;
            todaySalesDescriptionLabel.Font = new Font("Segoe UI", 8F);
            todaySalesDescriptionLabel.Location = new Point(17, 109);
            todaySalesDescriptionLabel.Name = "todaySalesDescriptionLabel";
            todaySalesDescriptionLabel.Size = new Size(207, 27);
            todaySalesDescriptionLabel.TabIndex = 0;
            todaySalesDescriptionLabel.Text = "إجمالي الفواتير المدفوعة";
            todaySalesDescriptionLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // todaySalesValueLabel
            // 
            todaySalesValueLabel.Dock = DockStyle.Top;
            todaySalesValueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            todaySalesValueLabel.Location = new Point(17, 53);
            todaySalesValueLabel.Name = "todaySalesValueLabel";
            todaySalesValueLabel.Size = new Size(207, 56);
            todaySalesValueLabel.TabIndex = 1;
            todaySalesValueLabel.Text = "0.00";
            todaySalesValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // todaySalesTitleLabel
            // 
            todaySalesTitleLabel.Dock = DockStyle.Top;
            todaySalesTitleLabel.Font = new Font("Segoe UI", 9F);
            todaySalesTitleLabel.Location = new Point(17, 20);
            todaySalesTitleLabel.Name = "todaySalesTitleLabel";
            todaySalesTitleLabel.Size = new Size(207, 33);
            todaySalesTitleLabel.TabIndex = 2;
            todaySalesTitleLabel.Text = "مبيعات اليوم";
            todaySalesTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // todayPurchasesCard
            // 
            todayPurchasesCard.Controls.Add(todayPurchasesDescriptionLabel);
            todayPurchasesCard.Controls.Add(todayPurchasesValueLabel);
            todayPurchasesCard.Controls.Add(todayPurchasesTitleLabel);
            todayPurchasesCard.Dock = DockStyle.Fill;
            todayPurchasesCard.Location = new Point(760, 0);
            todayPurchasesCard.Margin = new Padding(0, 0, 9, 0);
            todayPurchasesCard.Name = "todayPurchasesCard";
            todayPurchasesCard.Padding = new Padding(17, 20, 17, 20);
            todayPurchasesCard.Size = new Size(241, 156);
            todayPurchasesCard.TabIndex = 1;
            // 
            // todayPurchasesDescriptionLabel
            // 
            todayPurchasesDescriptionLabel.Dock = DockStyle.Fill;
            todayPurchasesDescriptionLabel.Font = new Font("Segoe UI", 8F);
            todayPurchasesDescriptionLabel.Location = new Point(17, 109);
            todayPurchasesDescriptionLabel.Name = "todayPurchasesDescriptionLabel";
            todayPurchasesDescriptionLabel.Size = new Size(207, 27);
            todayPurchasesDescriptionLabel.TabIndex = 0;
            todayPurchasesDescriptionLabel.Text = "إجمالي فواتير الشراء";
            todayPurchasesDescriptionLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // todayPurchasesValueLabel
            // 
            todayPurchasesValueLabel.Dock = DockStyle.Top;
            todayPurchasesValueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            todayPurchasesValueLabel.Location = new Point(17, 53);
            todayPurchasesValueLabel.Name = "todayPurchasesValueLabel";
            todayPurchasesValueLabel.Size = new Size(207, 56);
            todayPurchasesValueLabel.TabIndex = 1;
            todayPurchasesValueLabel.Text = "0.00";
            todayPurchasesValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // todayPurchasesTitleLabel
            // 
            todayPurchasesTitleLabel.Dock = DockStyle.Top;
            todayPurchasesTitleLabel.Font = new Font("Segoe UI", 9F);
            todayPurchasesTitleLabel.Location = new Point(17, 20);
            todayPurchasesTitleLabel.Name = "todayPurchasesTitleLabel";
            todayPurchasesTitleLabel.Size = new Size(207, 33);
            todayPurchasesTitleLabel.TabIndex = 2;
            todayPurchasesTitleLabel.Text = "مشتريات اليوم";
            todayPurchasesTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // totalDebtsCard
            // 
            totalDebtsCard.Controls.Add(totalDebtsDescriptionLabel);
            totalDebtsCard.Controls.Add(totalDebtsValueLabel);
            totalDebtsCard.Controls.Add(totalDebtsTitleLabel);
            totalDebtsCard.Dock = DockStyle.Fill;
            totalDebtsCard.Location = new Point(510, 0);
            totalDebtsCard.Margin = new Padding(0, 0, 9, 0);
            totalDebtsCard.Name = "totalDebtsCard";
            totalDebtsCard.Padding = new Padding(17, 20, 17, 20);
            totalDebtsCard.Size = new Size(241, 156);
            totalDebtsCard.TabIndex = 2;
            // 
            // totalDebtsDescriptionLabel
            // 
            totalDebtsDescriptionLabel.Dock = DockStyle.Fill;
            totalDebtsDescriptionLabel.Font = new Font("Segoe UI", 8F);
            totalDebtsDescriptionLabel.Location = new Point(17, 109);
            totalDebtsDescriptionLabel.Name = "totalDebtsDescriptionLabel";
            totalDebtsDescriptionLabel.Size = new Size(207, 27);
            totalDebtsDescriptionLabel.TabIndex = 0;
            totalDebtsDescriptionLabel.Text = "مبالغ مستحقة على العملاء";
            totalDebtsDescriptionLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // totalDebtsValueLabel
            // 
            totalDebtsValueLabel.Dock = DockStyle.Top;
            totalDebtsValueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            totalDebtsValueLabel.Location = new Point(17, 53);
            totalDebtsValueLabel.Name = "totalDebtsValueLabel";
            totalDebtsValueLabel.Size = new Size(207, 56);
            totalDebtsValueLabel.TabIndex = 1;
            totalDebtsValueLabel.Text = "0.00";
            totalDebtsValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // totalDebtsTitleLabel
            // 
            totalDebtsTitleLabel.Dock = DockStyle.Top;
            totalDebtsTitleLabel.Font = new Font("Segoe UI", 9F);
            totalDebtsTitleLabel.Location = new Point(17, 20);
            totalDebtsTitleLabel.Name = "totalDebtsTitleLabel";
            totalDebtsTitleLabel.Size = new Size(207, 33);
            totalDebtsTitleLabel.TabIndex = 2;
            totalDebtsTitleLabel.Text = "إجمالي الديون";
            totalDebtsTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productsCard
            // 
            productsCard.Controls.Add(productsDescriptionLabel);
            productsCard.Controls.Add(productsValueLabel);
            productsCard.Controls.Add(productsTitleLabel);
            productsCard.Dock = DockStyle.Fill;
            productsCard.Location = new Point(260, 0);
            productsCard.Margin = new Padding(0, 0, 9, 0);
            productsCard.Name = "productsCard";
            productsCard.Padding = new Padding(17, 20, 17, 20);
            productsCard.Size = new Size(241, 156);
            productsCard.TabIndex = 3;
            // 
            // productsDescriptionLabel
            // 
            productsDescriptionLabel.Dock = DockStyle.Fill;
            productsDescriptionLabel.Font = new Font("Segoe UI", 8F);
            productsDescriptionLabel.Location = new Point(17, 109);
            productsDescriptionLabel.Name = "productsDescriptionLabel";
            productsDescriptionLabel.Size = new Size(207, 27);
            productsDescriptionLabel.TabIndex = 0;
            productsDescriptionLabel.Text = "المنتجات النشطة";
            productsDescriptionLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // productsValueLabel
            // 
            productsValueLabel.Dock = DockStyle.Top;
            productsValueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            productsValueLabel.Location = new Point(17, 53);
            productsValueLabel.Name = "productsValueLabel";
            productsValueLabel.Size = new Size(207, 56);
            productsValueLabel.TabIndex = 1;
            productsValueLabel.Text = "0";
            productsValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productsTitleLabel
            // 
            productsTitleLabel.Dock = DockStyle.Top;
            productsTitleLabel.Font = new Font("Segoe UI", 9F);
            productsTitleLabel.Location = new Point(17, 20);
            productsTitleLabel.Name = "productsTitleLabel";
            productsTitleLabel.Size = new Size(207, 33);
            productsTitleLabel.TabIndex = 2;
            productsTitleLabel.Text = "عدد المنتجات";
            productsTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lowStockCard
            // 
            lowStockCard.Controls.Add(lowStockDescriptionLabel);
            lowStockCard.Controls.Add(lowStockValueLabel);
            lowStockCard.Dock = DockStyle.Fill;
            lowStockCard.Location = new Point(0, 0);
            lowStockCard.Margin = new Padding(0);
            lowStockCard.Name = "lowStockCard";
            lowStockCard.Padding = new Padding(17, 20, 17, 20);
            lowStockCard.Size = new Size(251, 156);
            lowStockCard.TabIndex = 4;
            // 
            // lowStockDescriptionLabel
            // 
            lowStockDescriptionLabel.Dock = DockStyle.Fill;
            lowStockDescriptionLabel.Font = new Font("Segoe UI", 8F);
            lowStockDescriptionLabel.Location = new Point(17, 76);
            lowStockDescriptionLabel.Name = "lowStockDescriptionLabel";
            lowStockDescriptionLabel.Size = new Size(217, 60);
            lowStockDescriptionLabel.TabIndex = 0;
            lowStockDescriptionLabel.Text = "منتجات أقل من الحد الأدنى";
            lowStockDescriptionLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lowStockValueLabel
            // 
            lowStockValueLabel.Dock = DockStyle.Top;
            lowStockValueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lowStockValueLabel.Location = new Point(17, 20);
            lowStockValueLabel.Name = "lowStockValueLabel";
            lowStockValueLabel.Size = new Size(217, 56);
            lowStockValueLabel.TabIndex = 1;
            lowStockValueLabel.Text = "0";
            lowStockValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bottomLayout
            // 
            bottomLayout.ColumnCount = 2;
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            bottomLayout.Controls.Add(recentSalesPanel, 0, 0);
            bottomLayout.Controls.Add(lowStockPanel, 1, 0);
            bottomLayout.Dock = DockStyle.Fill;
            bottomLayout.Location = new Point(3, 278);
            bottomLayout.Margin = new Padding(3, 4, 3, 4);
            bottomLayout.Name = "bottomLayout";
            bottomLayout.RowCount = 1;
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomLayout.Size = new Size(1245, 239);
            bottomLayout.TabIndex = 2;
            // 
            // recentSalesPanel
            // 
            recentSalesPanel.Controls.Add(recentSalesGrid);
            recentSalesPanel.Controls.Add(recentSalesTitleLabel);
            recentSalesPanel.Dock = DockStyle.Fill;
            recentSalesPanel.Location = new Point(507, 0);
            recentSalesPanel.Margin = new Padding(0, 0, 9, 0);
            recentSalesPanel.Name = "recentSalesPanel";
            recentSalesPanel.Padding = new Padding(17, 20, 17, 20);
            recentSalesPanel.Size = new Size(738, 239);
            recentSalesPanel.TabIndex = 0;
            // 
            // recentSalesGrid
            // 
            recentSalesGrid.AllowUserToAddRows = false;
            recentSalesGrid.AllowUserToDeleteRows = false;
            recentSalesGrid.AllowUserToResizeRows = false;
            recentSalesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            recentSalesGrid.BackgroundColor = Color.White;
            recentSalesGrid.BorderStyle = BorderStyle.None;
            recentSalesGrid.ColumnHeadersHeight = 35;
            recentSalesGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            recentSalesGrid.Dock = DockStyle.Fill;
            recentSalesGrid.Location = new Point(17, 67);
            recentSalesGrid.Margin = new Padding(3, 4, 3, 4);
            recentSalesGrid.MultiSelect = false;
            recentSalesGrid.Name = "recentSalesGrid";
            recentSalesGrid.ReadOnly = true;
            recentSalesGrid.RowHeadersVisible = false;
            recentSalesGrid.RowHeadersWidth = 51;
            recentSalesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            recentSalesGrid.Size = new Size(704, 152);
            recentSalesGrid.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "رقم الفاتورة";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "اسم العميل";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "إجمالي الفاتورة";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "حالة الدفع";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "وقت البيع";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // recentSalesTitleLabel
            // 
            recentSalesTitleLabel.Dock = DockStyle.Top;
            recentSalesTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            recentSalesTitleLabel.Location = new Point(17, 20);
            recentSalesTitleLabel.Name = "recentSalesTitleLabel";
            recentSalesTitleLabel.Size = new Size(704, 47);
            recentSalesTitleLabel.TabIndex = 1;
            recentSalesTitleLabel.Text = "آخر المبيعات";
            recentSalesTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lowStockPanel
            // 
            lowStockPanel.Controls.Add(lowStockGrid);
            lowStockPanel.Controls.Add(lowStockTitleLabel);
            lowStockPanel.Dock = DockStyle.Fill;
            lowStockPanel.Location = new Point(0, 0);
            lowStockPanel.Margin = new Padding(9, 0, 0, 0);
            lowStockPanel.Name = "lowStockPanel";
            lowStockPanel.Padding = new Padding(17, 20, 17, 20);
            lowStockPanel.Size = new Size(489, 239);
            lowStockPanel.TabIndex = 1;
            // 
            // lowStockGrid
            // 
            lowStockGrid.AllowUserToAddRows = false;
            lowStockGrid.AllowUserToDeleteRows = false;
            lowStockGrid.AllowUserToResizeRows = false;
            lowStockGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lowStockGrid.BackgroundColor = Color.White;
            lowStockGrid.BorderStyle = BorderStyle.None;
            lowStockGrid.ColumnHeadersHeight = 35;
            lowStockGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            lowStockGrid.Dock = DockStyle.Fill;
            lowStockGrid.Location = new Point(17, 67);
            lowStockGrid.Margin = new Padding(3, 4, 3, 4);
            lowStockGrid.MultiSelect = false;
            lowStockGrid.Name = "lowStockGrid";
            lowStockGrid.ReadOnly = true;
            lowStockGrid.RowHeadersVisible = false;
            lowStockGrid.RowHeadersWidth = 51;
            lowStockGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            lowStockGrid.Size = new Size(455, 152);
            lowStockGrid.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "اسم المنتج";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "الكمية الحالية";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "الحد الأدنى";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // lowStockTitleLabel
            // 
            lowStockTitleLabel.Dock = DockStyle.Top;
            lowStockTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lowStockTitleLabel.Location = new Point(17, 20);
            lowStockTitleLabel.Name = "lowStockTitleLabel";
            lowStockTitleLabel.Size = new Size(455, 47);
            lowStockTitleLabel.TabIndex = 2;
            lowStockTitleLabel.Text = "تنبيهات المخزون";
            lowStockTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DashboardPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(rootLayout);
            Margin = new Padding(0);
            Name = "DashboardPage";
            Padding = new Padding(23, 27, 23, 27);
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1297, 575);
            rootLayout.ResumeLayout(false);
            rootLayout.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statisticsLayout.ResumeLayout(false);
            todaySalesCard.ResumeLayout(false);
            todayPurchasesCard.ResumeLayout(false);
            totalDebtsCard.ResumeLayout(false);
            productsCard.ResumeLayout(false);
            lowStockCard.ResumeLayout(false);
            bottomLayout.ResumeLayout(false);
            recentSalesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)recentSalesGrid).EndInit();
            lowStockPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lowStockGrid).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Panel panel1;
        private Button refreshButton;
        private Label pageTitleLabel;
        private Label pageSubtitleLabel;
    }
}