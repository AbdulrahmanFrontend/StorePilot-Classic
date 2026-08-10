namespace StorePilot.UI
{
    partial class ucDashboardScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpQuickActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.btnNewSale = new System.Windows.Forms.Button();
            this.btnNewPurchase = new System.Windows.Forms.Button();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.tlpTables = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLowStockProducts = new System.Windows.Forms.Panel();
            this.ctrlDgvLowStockProducts = new DevToolkit.BaseWinForms.Controls.CustomControls.ccDataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLowStockProducts = new System.Windows.Forms.Label();
            this.pnlRecentSales = new System.Windows.Forms.Panel();
            this.ctrlDgvRecentSales = new DevToolkit.BaseWinForms.Controls.CustomControls.ccDataGridView();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRecentSales = new System.Windows.Forms.Label();
            this.chtYearlySales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flpStatsCards = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpProductsCount = new System.Windows.Forms.TableLayoutPanel();
            this.tlpProductsCountContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblProductsCountValue = new System.Windows.Forms.Label();
            this.lblProductsCountTitle = new System.Windows.Forms.Label();
            this.picbProductsCount = new System.Windows.Forms.PictureBox();
            this.tlpCustomersCount = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCustomersCountContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomersCountValue = new System.Windows.Forms.Label();
            this.lblCustomersCountTitle = new System.Windows.Forms.Label();
            this.picbCustomersCount = new System.Windows.Forms.PictureBox();
            this.tlpSuppliersCount = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSuppliersCountContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblSuppliersCountValue = new System.Windows.Forms.Label();
            this.lblSuppliersCountTitle = new System.Windows.Forms.Label();
            this.picbSuppliersCount = new System.Windows.Forms.PictureBox();
            this.tlpInvoicesCount = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInvoicesCountContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblInvoicesTodayValue = new System.Windows.Forms.Label();
            this.lblInvoicesTodayTitle = new System.Windows.Forms.Label();
            this.picbInvoicesCount = new System.Windows.Forms.PictureBox();
            this.tlpSalesToday = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSalesTodayContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblSalesTodayValue = new System.Windows.Forms.Label();
            this.lblSalesTodayTitle = new System.Windows.Forms.Label();
            this.picbSalesToday = new System.Windows.Forms.PictureBox();
            this.tlpPurchasesToday = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPurchasesTodayContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblPurchasesTodayValue = new System.Windows.Forms.Label();
            this.lblPurchasesTodayTitle = new System.Windows.Forms.Label();
            this.picbPurchasesToday = new System.Windows.Forms.PictureBox();
            this.tlpEarningToday = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEarningsTodayContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblEarningsTodayValue = new System.Windows.Forms.Label();
            this.lblEarningsTodayTitle = new System.Windows.Forms.Label();
            this.picbEarningsToday = new System.Windows.Forms.PictureBox();
            this.tlpDebtsCount = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDebtsCountContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblDebtsCountValue = new System.Windows.Forms.Label();
            this.lblDebtsCountTitle = new System.Windows.Forms.Label();
            this.picbDebtsCount = new System.Windows.Forms.PictureBox();
            this.tlpContainer.SuspendLayout();
            this.tlpQuickActions.SuspendLayout();
            this.tlpTables.SuspendLayout();
            this.pnlLowStockProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlDgvLowStockProducts)).BeginInit();
            this.pnlRecentSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlDgvRecentSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtYearlySales)).BeginInit();
            this.flpStatsCards.SuspendLayout();
            this.tlpProductsCount.SuspendLayout();
            this.tlpProductsCountContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbProductsCount)).BeginInit();
            this.tlpCustomersCount.SuspendLayout();
            this.tlpCustomersCountContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbCustomersCount)).BeginInit();
            this.tlpSuppliersCount.SuspendLayout();
            this.tlpSuppliersCountContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbSuppliersCount)).BeginInit();
            this.tlpInvoicesCount.SuspendLayout();
            this.tlpInvoicesCountContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInvoicesCount)).BeginInit();
            this.tlpSalesToday.SuspendLayout();
            this.tlpSalesTodayContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbSalesToday)).BeginInit();
            this.tlpPurchasesToday.SuspendLayout();
            this.tlpPurchasesTodayContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPurchasesToday)).BeginInit();
            this.tlpEarningToday.SuspendLayout();
            this.tlpEarningsTodayContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbEarningsToday)).BeginInit();
            this.tlpDebtsCount.SuspendLayout();
            this.tlpDebtsCountContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbDebtsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpContainer
            // 
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContainer.Controls.Add(this.tlpQuickActions, 0, 3);
            this.tlpContainer.Controls.Add(this.tlpTables, 0, 2);
            this.tlpContainer.Controls.Add(this.chtYearlySales, 0, 1);
            this.tlpContainer.Controls.Add(this.flpStatsCards, 0, 0);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpContainer.RowCount = 4;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.Size = new System.Drawing.Size(971, 851);
            this.tlpContainer.TabIndex = 2;
            // 
            // tlpQuickActions
            // 
            this.tlpQuickActions.ColumnCount = 5;
            this.tlpQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpQuickActions.Controls.Add(this.btnNewCustomer, 1, 0);
            this.tlpQuickActions.Controls.Add(this.btnNewSupplier, 0, 0);
            this.tlpQuickActions.Controls.Add(this.btnNewSale, 4, 0);
            this.tlpQuickActions.Controls.Add(this.btnNewPurchase, 3, 0);
            this.tlpQuickActions.Controls.Add(this.btnNewProduct, 2, 0);
            this.tlpQuickActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpQuickActions.Location = new System.Drawing.Point(7, 801);
            this.tlpQuickActions.Name = "tlpQuickActions";
            this.tlpQuickActions.RowCount = 1;
            this.tlpQuickActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuickActions.Size = new System.Drawing.Size(957, 42);
            this.tlpQuickActions.TabIndex = 8;
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewCustomer.FlatAppearance.BorderSize = 0;
            this.btnNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCustomer.Image = global::StorePilot.UI.Properties.Resources.customer;
            this.btnNewCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewCustomer.Location = new System.Drawing.Point(606, 3);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewCustomer.Size = new System.Drawing.Size(130, 36);
            this.btnNewCustomer.TabIndex = 4;
            this.btnNewCustomer.Text = "عميل جديد";
            this.btnNewCustomer.UseVisualStyleBackColor = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewSupplier.FlatAppearance.BorderSize = 0;
            this.btnNewSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSupplier.Image = global::StorePilot.UI.Properties.Resources.supplier;
            this.btnNewSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSupplier.Location = new System.Drawing.Point(797, 3);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewSupplier.Size = new System.Drawing.Size(130, 36);
            this.btnNewSupplier.TabIndex = 0;
            this.btnNewSupplier.Text = "مورد جديد";
            this.btnNewSupplier.UseVisualStyleBackColor = false;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // btnNewSale
            // 
            this.btnNewSale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewSale.FlatAppearance.BorderSize = 0;
            this.btnNewSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSale.Image = global::StorePilot.UI.Properties.Resources.sales;
            this.btnNewSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSale.Location = new System.Drawing.Point(32, 3);
            this.btnNewSale.Name = "btnNewSale";
            this.btnNewSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewSale.Size = new System.Drawing.Size(130, 36);
            this.btnNewSale.TabIndex = 3;
            this.btnNewSale.Text = "بيع جديد";
            this.btnNewSale.UseVisualStyleBackColor = false;
            this.btnNewSale.Click += new System.EventHandler(this.btnNewSale_Click);
            // 
            // btnNewPurchase
            // 
            this.btnNewPurchase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPurchase.FlatAppearance.BorderSize = 0;
            this.btnNewPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPurchase.Image = global::StorePilot.UI.Properties.Resources.purchases;
            this.btnNewPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewPurchase.Location = new System.Drawing.Point(224, 3);
            this.btnNewPurchase.Name = "btnNewPurchase";
            this.btnNewPurchase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewPurchase.Size = new System.Drawing.Size(130, 36);
            this.btnNewPurchase.TabIndex = 2;
            this.btnNewPurchase.Text = "شراء جديد";
            this.btnNewPurchase.UseVisualStyleBackColor = false;
            this.btnNewPurchase.Click += new System.EventHandler(this.btnNewPurchase_Click);
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewProduct.FlatAppearance.BorderSize = 0;
            this.btnNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProduct.Image = global::StorePilot.UI.Properties.Resources.product;
            this.btnNewProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewProduct.Location = new System.Drawing.Point(415, 3);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewProduct.Size = new System.Drawing.Size(130, 36);
            this.btnNewProduct.TabIndex = 1;
            this.btnNewProduct.Text = "منتج جديد";
            this.btnNewProduct.UseVisualStyleBackColor = false;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // tlpTables
            // 
            this.tlpTables.ColumnCount = 2;
            this.tlpTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTables.Controls.Add(this.pnlLowStockProducts, 0, 0);
            this.tlpTables.Controls.Add(this.pnlRecentSales, 1, 0);
            this.tlpTables.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpTables.Location = new System.Drawing.Point(7, 402);
            this.tlpTables.Name = "tlpTables";
            this.tlpTables.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpTables.RowCount = 1;
            this.tlpTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTables.Size = new System.Drawing.Size(957, 393);
            this.tlpTables.TabIndex = 7;
            // 
            // pnlLowStockProducts
            // 
            this.pnlLowStockProducts.Controls.Add(this.ctrlDgvLowStockProducts);
            this.pnlLowStockProducts.Controls.Add(this.lblLowStockProducts);
            this.pnlLowStockProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLowStockProducts.Location = new System.Drawing.Point(482, 8);
            this.pnlLowStockProducts.Name = "pnlLowStockProducts";
            this.pnlLowStockProducts.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLowStockProducts.Size = new System.Drawing.Size(468, 377);
            this.pnlLowStockProducts.TabIndex = 6;
            // 
            // ctrlDgvLowStockProducts
            // 
            this.ctrlDgvLowStockProducts.AllowUserToAddRows = false;
            this.ctrlDgvLowStockProducts.AllowUserToDeleteRows = false;
            this.ctrlDgvLowStockProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.ctrlDgvLowStockProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.ctrlDgvLowStockProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctrlDgvLowStockProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ctrlDgvLowStockProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctrlDgvLowStockProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ctrlDgvLowStockProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ctrlDgvLowStockProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.ctrlDgvLowStockProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlDgvLowStockProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Quantity,
            this.MinQuantity});
            this.ctrlDgvLowStockProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ctrlDgvLowStockProducts.DefaultCellStyle = dataGridViewCellStyle27;
            this.ctrlDgvLowStockProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDgvLowStockProducts.EnableHeadersVisualStyles = false;
            this.ctrlDgvLowStockProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.ctrlDgvLowStockProducts.Location = new System.Drawing.Point(4, 35);
            this.ctrlDgvLowStockProducts.MultiSelect = false;
            this.ctrlDgvLowStockProducts.Name = "ctrlDgvLowStockProducts";
            this.ctrlDgvLowStockProducts.ReadOnly = true;
            this.ctrlDgvLowStockProducts.RowHeadersVisible = false;
            this.ctrlDgvLowStockProducts.RowHeadersWidth = 51;
            this.ctrlDgvLowStockProducts.RowTemplate.Height = 35;
            this.ctrlDgvLowStockProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlDgvLowStockProducts.Size = new System.Drawing.Size(460, 337);
            this.ctrlDgvLowStockProducts.TabIndex = 5;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "اسم المنتج";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "الكمية الحالية";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // MinQuantity
            // 
            this.MinQuantity.DataPropertyName = "MinQuantity";
            this.MinQuantity.HeaderText = "الحد الأدنى";
            this.MinQuantity.MinimumWidth = 6;
            this.MinQuantity.Name = "MinQuantity";
            this.MinQuantity.ReadOnly = true;
            // 
            // lblLowStockProducts
            // 
            this.lblLowStockProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLowStockProducts.Location = new System.Drawing.Point(4, 5);
            this.lblLowStockProducts.Name = "lblLowStockProducts";
            this.lblLowStockProducts.Size = new System.Drawing.Size(460, 30);
            this.lblLowStockProducts.TabIndex = 4;
            this.lblLowStockProducts.Text = "المنتجات الناقصة:";
            this.lblLowStockProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRecentSales
            // 
            this.pnlRecentSales.Controls.Add(this.ctrlDgvRecentSales);
            this.pnlRecentSales.Controls.Add(this.lblRecentSales);
            this.pnlRecentSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecentSales.Location = new System.Drawing.Point(7, 8);
            this.pnlRecentSales.Name = "pnlRecentSales";
            this.pnlRecentSales.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlRecentSales.Size = new System.Drawing.Size(469, 377);
            this.pnlRecentSales.TabIndex = 5;
            // 
            // ctrlDgvRecentSales
            // 
            this.ctrlDgvRecentSales.AllowUserToAddRows = false;
            this.ctrlDgvRecentSales.AllowUserToDeleteRows = false;
            this.ctrlDgvRecentSales.AllowUserToResizeRows = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.ctrlDgvRecentSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            this.ctrlDgvRecentSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctrlDgvRecentSales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ctrlDgvRecentSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctrlDgvRecentSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ctrlDgvRecentSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ctrlDgvRecentSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.ctrlDgvRecentSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlDgvRecentSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.SaleInvoiceID,
            this.InvoiceDate,
            this.CustomerName,
            this.NetTotal});
            this.ctrlDgvRecentSales.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ctrlDgvRecentSales.DefaultCellStyle = dataGridViewCellStyle30;
            this.ctrlDgvRecentSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDgvRecentSales.EnableHeadersVisualStyles = false;
            this.ctrlDgvRecentSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.ctrlDgvRecentSales.Location = new System.Drawing.Point(4, 35);
            this.ctrlDgvRecentSales.MultiSelect = false;
            this.ctrlDgvRecentSales.Name = "ctrlDgvRecentSales";
            this.ctrlDgvRecentSales.ReadOnly = true;
            this.ctrlDgvRecentSales.RowHeadersVisible = false;
            this.ctrlDgvRecentSales.RowHeadersWidth = 51;
            this.ctrlDgvRecentSales.RowTemplate.Height = 35;
            this.ctrlDgvRecentSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlDgvRecentSales.Size = new System.Drawing.Size(461, 337);
            this.ctrlDgvRecentSales.TabIndex = 5;
            // 
            // InvoiceID
            // 
            this.InvoiceID.DataPropertyName = "InvoiceID";
            this.InvoiceID.HeaderText = "رقم الفاتورة";
            this.InvoiceID.MinimumWidth = 6;
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            this.InvoiceID.ToolTipText = "رقم الفاتورة سواء كانت شراء أو بيع";
            // 
            // SaleInvoiceID
            // 
            this.SaleInvoiceID.DataPropertyName = "SaleInvoiceID";
            this.SaleInvoiceID.HeaderText = "رقم فاتورة البيع";
            this.SaleInvoiceID.MinimumWidth = 6;
            this.SaleInvoiceID.Name = "SaleInvoiceID";
            this.SaleInvoiceID.ReadOnly = true;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "تاريخ الفاتورة";
            this.InvoiceDate.MinimumWidth = 6;
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "اسم العميل";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // NetTotal
            // 
            this.NetTotal.DataPropertyName = "NetTotal";
            this.NetTotal.HeaderText = "الإجمالي / الصافي";
            this.NetTotal.MinimumWidth = 6;
            this.NetTotal.Name = "NetTotal";
            this.NetTotal.ReadOnly = true;
            // 
            // lblRecentSales
            // 
            this.lblRecentSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecentSales.Location = new System.Drawing.Point(4, 5);
            this.lblRecentSales.Name = "lblRecentSales";
            this.lblRecentSales.Size = new System.Drawing.Size(461, 30);
            this.lblRecentSales.TabIndex = 4;
            this.lblRecentSales.Text = "آخر فواتير البيع:";
            this.lblRecentSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chtYearlySales
            // 
            this.chtYearlySales.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea5.Name = "ChartArea1";
            this.chtYearlySales.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chtYearlySales.Legends.Add(legend5);
            this.chtYearlySales.Location = new System.Drawing.Point(127, 140);
            this.chtYearlySales.Name = "chtYearlySales";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chtYearlySales.Series.Add(series5);
            this.chtYearlySales.Size = new System.Drawing.Size(717, 255);
            this.chtYearlySales.TabIndex = 3;
            this.chtYearlySales.Text = "chart1";
            // 
            // flpStatsCards
            // 
            this.flpStatsCards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flpStatsCards.AutoSize = true;
            this.flpStatsCards.Controls.Add(this.tlpProductsCount);
            this.flpStatsCards.Controls.Add(this.tlpCustomersCount);
            this.flpStatsCards.Controls.Add(this.tlpSuppliersCount);
            this.flpStatsCards.Controls.Add(this.tlpInvoicesCount);
            this.flpStatsCards.Controls.Add(this.tlpSalesToday);
            this.flpStatsCards.Controls.Add(this.tlpPurchasesToday);
            this.flpStatsCards.Controls.Add(this.tlpEarningToday);
            this.flpStatsCards.Controls.Add(this.tlpDebtsCount);
            this.flpStatsCards.Location = new System.Drawing.Point(78, 8);
            this.flpStatsCards.Name = "flpStatsCards";
            this.flpStatsCards.Size = new System.Drawing.Size(815, 126);
            this.flpStatsCards.TabIndex = 0;
            // 
            // tlpProductsCount
            // 
            this.tlpProductsCount.ColumnCount = 2;
            this.tlpProductsCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpProductsCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpProductsCount.Controls.Add(this.tlpProductsCountContent, 1, 0);
            this.tlpProductsCount.Controls.Add(this.picbProductsCount, 0, 0);
            this.tlpProductsCount.Location = new System.Drawing.Point(662, 3);
            this.tlpProductsCount.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.tlpProductsCount.Name = "tlpProductsCount";
            this.tlpProductsCount.RowCount = 1;
            this.tlpProductsCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProductsCount.Size = new System.Drawing.Size(153, 57);
            this.tlpProductsCount.TabIndex = 3;
            // 
            // tlpProductsCountContent
            // 
            this.tlpProductsCountContent.ColumnCount = 1;
            this.tlpProductsCountContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProductsCountContent.Controls.Add(this.lblProductsCountValue, 0, 1);
            this.tlpProductsCountContent.Controls.Add(this.lblProductsCountTitle, 0, 0);
            this.tlpProductsCountContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProductsCountContent.Location = new System.Drawing.Point(3, 3);
            this.tlpProductsCountContent.Name = "tlpProductsCountContent";
            this.tlpProductsCountContent.RowCount = 2;
            this.tlpProductsCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProductsCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProductsCountContent.Size = new System.Drawing.Size(102, 51);
            this.tlpProductsCountContent.TabIndex = 0;
            // 
            // lblProductsCountValue
            // 
            this.lblProductsCountValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProductsCountValue.AutoSize = true;
            this.lblProductsCountValue.Location = new System.Drawing.Point(44, 30);
            this.lblProductsCountValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblProductsCountValue.Name = "lblProductsCountValue";
            this.lblProductsCountValue.Size = new System.Drawing.Size(15, 17);
            this.lblProductsCountValue.TabIndex = 1;
            this.lblProductsCountValue.Text = "0";
            // 
            // lblProductsCountTitle
            // 
            this.lblProductsCountTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProductsCountTitle.AutoSize = true;
            this.lblProductsCountTitle.Location = new System.Drawing.Point(10, 3);
            this.lblProductsCountTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblProductsCountTitle.Name = "lblProductsCountTitle";
            this.lblProductsCountTitle.Size = new System.Drawing.Size(83, 17);
            this.lblProductsCountTitle.TabIndex = 0;
            this.lblProductsCountTitle.Text = "عدد المنتجات:";
            // 
            // picbProductsCount
            // 
            this.picbProductsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbProductsCount.Image = global::StorePilot.UI.Properties.Resources.product_72;
            this.picbProductsCount.Location = new System.Drawing.Point(111, 3);
            this.picbProductsCount.Name = "picbProductsCount";
            this.picbProductsCount.Size = new System.Drawing.Size(39, 51);
            this.picbProductsCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbProductsCount.TabIndex = 1;
            this.picbProductsCount.TabStop = false;
            // 
            // tlpCustomersCount
            // 
            this.tlpCustomersCount.ColumnCount = 2;
            this.tlpCustomersCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCustomersCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpCustomersCount.Controls.Add(this.tlpCustomersCountContent, 1, 0);
            this.tlpCustomersCount.Controls.Add(this.picbCustomersCount, 0, 0);
            this.tlpCustomersCount.Location = new System.Drawing.Point(499, 3);
            this.tlpCustomersCount.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.tlpCustomersCount.Name = "tlpCustomersCount";
            this.tlpCustomersCount.RowCount = 1;
            this.tlpCustomersCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCustomersCount.Size = new System.Drawing.Size(153, 57);
            this.tlpCustomersCount.TabIndex = 4;
            // 
            // tlpCustomersCountContent
            // 
            this.tlpCustomersCountContent.ColumnCount = 1;
            this.tlpCustomersCountContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCustomersCountContent.Controls.Add(this.lblCustomersCountValue, 0, 1);
            this.tlpCustomersCountContent.Controls.Add(this.lblCustomersCountTitle, 0, 0);
            this.tlpCustomersCountContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCustomersCountContent.Location = new System.Drawing.Point(3, 3);
            this.tlpCustomersCountContent.Name = "tlpCustomersCountContent";
            this.tlpCustomersCountContent.RowCount = 2;
            this.tlpCustomersCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCustomersCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCustomersCountContent.Size = new System.Drawing.Size(102, 51);
            this.tlpCustomersCountContent.TabIndex = 0;
            // 
            // lblCustomersCountValue
            // 
            this.lblCustomersCountValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCustomersCountValue.AutoSize = true;
            this.lblCustomersCountValue.Location = new System.Drawing.Point(44, 30);
            this.lblCustomersCountValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblCustomersCountValue.Name = "lblCustomersCountValue";
            this.lblCustomersCountValue.Size = new System.Drawing.Size(15, 17);
            this.lblCustomersCountValue.TabIndex = 1;
            this.lblCustomersCountValue.Text = "0";
            // 
            // lblCustomersCountTitle
            // 
            this.lblCustomersCountTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCustomersCountTitle.AutoSize = true;
            this.lblCustomersCountTitle.Location = new System.Drawing.Point(14, 3);
            this.lblCustomersCountTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblCustomersCountTitle.Name = "lblCustomersCountTitle";
            this.lblCustomersCountTitle.Size = new System.Drawing.Size(75, 17);
            this.lblCustomersCountTitle.TabIndex = 0;
            this.lblCustomersCountTitle.Text = "عدد االعملاء:";
            // 
            // picbCustomersCount
            // 
            this.picbCustomersCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbCustomersCount.Image = global::StorePilot.UI.Properties.Resources.customers_72;
            this.picbCustomersCount.Location = new System.Drawing.Point(111, 3);
            this.picbCustomersCount.Name = "picbCustomersCount";
            this.picbCustomersCount.Size = new System.Drawing.Size(39, 51);
            this.picbCustomersCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbCustomersCount.TabIndex = 1;
            this.picbCustomersCount.TabStop = false;
            // 
            // tlpSuppliersCount
            // 
            this.tlpSuppliersCount.ColumnCount = 2;
            this.tlpSuppliersCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpSuppliersCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpSuppliersCount.Controls.Add(this.tlpSuppliersCountContent, 1, 0);
            this.tlpSuppliersCount.Controls.Add(this.picbSuppliersCount, 0, 0);
            this.tlpSuppliersCount.Location = new System.Drawing.Point(336, 3);
            this.tlpSuppliersCount.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.tlpSuppliersCount.Name = "tlpSuppliersCount";
            this.tlpSuppliersCount.RowCount = 1;
            this.tlpSuppliersCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSuppliersCount.Size = new System.Drawing.Size(153, 57);
            this.tlpSuppliersCount.TabIndex = 5;
            // 
            // tlpSuppliersCountContent
            // 
            this.tlpSuppliersCountContent.ColumnCount = 1;
            this.tlpSuppliersCountContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSuppliersCountContent.Controls.Add(this.lblSuppliersCountValue, 0, 1);
            this.tlpSuppliersCountContent.Controls.Add(this.lblSuppliersCountTitle, 0, 0);
            this.tlpSuppliersCountContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSuppliersCountContent.Location = new System.Drawing.Point(3, 3);
            this.tlpSuppliersCountContent.Name = "tlpSuppliersCountContent";
            this.tlpSuppliersCountContent.RowCount = 2;
            this.tlpSuppliersCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSuppliersCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSuppliersCountContent.Size = new System.Drawing.Size(102, 51);
            this.tlpSuppliersCountContent.TabIndex = 0;
            // 
            // lblSuppliersCountValue
            // 
            this.lblSuppliersCountValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSuppliersCountValue.AutoSize = true;
            this.lblSuppliersCountValue.Location = new System.Drawing.Point(44, 30);
            this.lblSuppliersCountValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblSuppliersCountValue.Name = "lblSuppliersCountValue";
            this.lblSuppliersCountValue.Size = new System.Drawing.Size(15, 17);
            this.lblSuppliersCountValue.TabIndex = 1;
            this.lblSuppliersCountValue.Text = "0";
            // 
            // lblSuppliersCountTitle
            // 
            this.lblSuppliersCountTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSuppliersCountTitle.AutoSize = true;
            this.lblSuppliersCountTitle.Location = new System.Drawing.Point(10, 3);
            this.lblSuppliersCountTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblSuppliersCountTitle.Name = "lblSuppliersCountTitle";
            this.lblSuppliersCountTitle.Size = new System.Drawing.Size(83, 17);
            this.lblSuppliersCountTitle.TabIndex = 0;
            this.lblSuppliersCountTitle.Text = "عدد الموردين:";
            // 
            // picbSuppliersCount
            // 
            this.picbSuppliersCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbSuppliersCount.Image = global::StorePilot.UI.Properties.Resources.suppliers_72;
            this.picbSuppliersCount.Location = new System.Drawing.Point(111, 3);
            this.picbSuppliersCount.Name = "picbSuppliersCount";
            this.picbSuppliersCount.Size = new System.Drawing.Size(39, 51);
            this.picbSuppliersCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbSuppliersCount.TabIndex = 1;
            this.picbSuppliersCount.TabStop = false;
            // 
            // tlpInvoicesCount
            // 
            this.tlpInvoicesCount.ColumnCount = 2;
            this.tlpInvoicesCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpInvoicesCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpInvoicesCount.Controls.Add(this.tlpInvoicesCountContent, 1, 0);
            this.tlpInvoicesCount.Controls.Add(this.picbInvoicesCount, 0, 0);
            this.tlpInvoicesCount.Location = new System.Drawing.Point(173, 3);
            this.tlpInvoicesCount.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.tlpInvoicesCount.Name = "tlpInvoicesCount";
            this.tlpInvoicesCount.RowCount = 1;
            this.tlpInvoicesCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInvoicesCount.Size = new System.Drawing.Size(153, 57);
            this.tlpInvoicesCount.TabIndex = 7;
            // 
            // tlpInvoicesCountContent
            // 
            this.tlpInvoicesCountContent.ColumnCount = 1;
            this.tlpInvoicesCountContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInvoicesCountContent.Controls.Add(this.lblInvoicesTodayValue, 0, 1);
            this.tlpInvoicesCountContent.Controls.Add(this.lblInvoicesTodayTitle, 0, 0);
            this.tlpInvoicesCountContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInvoicesCountContent.Location = new System.Drawing.Point(3, 3);
            this.tlpInvoicesCountContent.Name = "tlpInvoicesCountContent";
            this.tlpInvoicesCountContent.RowCount = 2;
            this.tlpInvoicesCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInvoicesCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInvoicesCountContent.Size = new System.Drawing.Size(102, 51);
            this.tlpInvoicesCountContent.TabIndex = 0;
            // 
            // lblInvoicesTodayValue
            // 
            this.lblInvoicesTodayValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInvoicesTodayValue.AutoSize = true;
            this.lblInvoicesTodayValue.Location = new System.Drawing.Point(44, 30);
            this.lblInvoicesTodayValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblInvoicesTodayValue.Name = "lblInvoicesTodayValue";
            this.lblInvoicesTodayValue.Size = new System.Drawing.Size(15, 17);
            this.lblInvoicesTodayValue.TabIndex = 1;
            this.lblInvoicesTodayValue.Text = "0";
            // 
            // lblInvoicesTodayTitle
            // 
            this.lblInvoicesTodayTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblInvoicesTodayTitle.AutoSize = true;
            this.lblInvoicesTodayTitle.Location = new System.Drawing.Point(3, 3);
            this.lblInvoicesTodayTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblInvoicesTodayTitle.Name = "lblInvoicesTodayTitle";
            this.lblInvoicesTodayTitle.Size = new System.Drawing.Size(97, 17);
            this.lblInvoicesTodayTitle.TabIndex = 0;
            this.lblInvoicesTodayTitle.Text = "عدد فواتير اليوم:";
            // 
            // picbInvoicesCount
            // 
            this.picbInvoicesCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbInvoicesCount.Image = global::StorePilot.UI.Properties.Resources.invoice_72;
            this.picbInvoicesCount.Location = new System.Drawing.Point(111, 3);
            this.picbInvoicesCount.Name = "picbInvoicesCount";
            this.picbInvoicesCount.Size = new System.Drawing.Size(39, 51);
            this.picbInvoicesCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbInvoicesCount.TabIndex = 1;
            this.picbInvoicesCount.TabStop = false;
            // 
            // tlpSalesToday
            // 
            this.tlpSalesToday.ColumnCount = 2;
            this.tlpSalesToday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpSalesToday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpSalesToday.Controls.Add(this.tlpSalesTodayContent, 1, 0);
            this.tlpSalesToday.Controls.Add(this.picbSalesToday, 0, 0);
            this.tlpSalesToday.Location = new System.Drawing.Point(10, 3);
            this.tlpSalesToday.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.tlpSalesToday.Name = "tlpSalesToday";
            this.tlpSalesToday.RowCount = 1;
            this.tlpSalesToday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSalesToday.Size = new System.Drawing.Size(153, 57);
            this.tlpSalesToday.TabIndex = 8;
            // 
            // tlpSalesTodayContent
            // 
            this.tlpSalesTodayContent.ColumnCount = 1;
            this.tlpSalesTodayContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSalesTodayContent.Controls.Add(this.lblSalesTodayValue, 0, 1);
            this.tlpSalesTodayContent.Controls.Add(this.lblSalesTodayTitle, 0, 0);
            this.tlpSalesTodayContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSalesTodayContent.Location = new System.Drawing.Point(3, 3);
            this.tlpSalesTodayContent.Name = "tlpSalesTodayContent";
            this.tlpSalesTodayContent.RowCount = 2;
            this.tlpSalesTodayContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSalesTodayContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSalesTodayContent.Size = new System.Drawing.Size(102, 51);
            this.tlpSalesTodayContent.TabIndex = 0;
            // 
            // lblSalesTodayValue
            // 
            this.lblSalesTodayValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSalesTodayValue.AutoSize = true;
            this.lblSalesTodayValue.Location = new System.Drawing.Point(44, 30);
            this.lblSalesTodayValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblSalesTodayValue.Name = "lblSalesTodayValue";
            this.lblSalesTodayValue.Size = new System.Drawing.Size(15, 17);
            this.lblSalesTodayValue.TabIndex = 1;
            this.lblSalesTodayValue.Text = "0";
            // 
            // lblSalesTodayTitle
            // 
            this.lblSalesTodayTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSalesTodayTitle.AutoSize = true;
            this.lblSalesTodayTitle.Location = new System.Drawing.Point(11, 3);
            this.lblSalesTodayTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblSalesTodayTitle.Name = "lblSalesTodayTitle";
            this.lblSalesTodayTitle.Size = new System.Drawing.Size(80, 17);
            this.lblSalesTodayTitle.TabIndex = 0;
            this.lblSalesTodayTitle.Text = "مبيعات اليوم:";
            // 
            // picbSalesToday
            // 
            this.picbSalesToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbSalesToday.Image = global::StorePilot.UI.Properties.Resources.sales_72;
            this.picbSalesToday.Location = new System.Drawing.Point(111, 3);
            this.picbSalesToday.Name = "picbSalesToday";
            this.picbSalesToday.Size = new System.Drawing.Size(39, 51);
            this.picbSalesToday.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbSalesToday.TabIndex = 1;
            this.picbSalesToday.TabStop = false;
            // 
            // tlpPurchasesToday
            // 
            this.tlpPurchasesToday.ColumnCount = 2;
            this.tlpPurchasesToday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPurchasesToday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpPurchasesToday.Controls.Add(this.tlpPurchasesTodayContent, 1, 0);
            this.tlpPurchasesToday.Controls.Add(this.picbPurchasesToday, 0, 0);
            this.tlpPurchasesToday.Location = new System.Drawing.Point(662, 66);
            this.tlpPurchasesToday.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.tlpPurchasesToday.Name = "tlpPurchasesToday";
            this.tlpPurchasesToday.RowCount = 1;
            this.tlpPurchasesToday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPurchasesToday.Size = new System.Drawing.Size(153, 57);
            this.tlpPurchasesToday.TabIndex = 9;
            // 
            // tlpPurchasesTodayContent
            // 
            this.tlpPurchasesTodayContent.ColumnCount = 1;
            this.tlpPurchasesTodayContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPurchasesTodayContent.Controls.Add(this.lblPurchasesTodayValue, 0, 1);
            this.tlpPurchasesTodayContent.Controls.Add(this.lblPurchasesTodayTitle, 0, 0);
            this.tlpPurchasesTodayContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPurchasesTodayContent.Location = new System.Drawing.Point(3, 3);
            this.tlpPurchasesTodayContent.Name = "tlpPurchasesTodayContent";
            this.tlpPurchasesTodayContent.RowCount = 2;
            this.tlpPurchasesTodayContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPurchasesTodayContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPurchasesTodayContent.Size = new System.Drawing.Size(102, 51);
            this.tlpPurchasesTodayContent.TabIndex = 0;
            // 
            // lblPurchasesTodayValue
            // 
            this.lblPurchasesTodayValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPurchasesTodayValue.AutoSize = true;
            this.lblPurchasesTodayValue.Location = new System.Drawing.Point(44, 30);
            this.lblPurchasesTodayValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblPurchasesTodayValue.Name = "lblPurchasesTodayValue";
            this.lblPurchasesTodayValue.Size = new System.Drawing.Size(15, 17);
            this.lblPurchasesTodayValue.TabIndex = 1;
            this.lblPurchasesTodayValue.Text = "0";
            // 
            // lblPurchasesTodayTitle
            // 
            this.lblPurchasesTodayTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPurchasesTodayTitle.AutoSize = true;
            this.lblPurchasesTodayTitle.Location = new System.Drawing.Point(7, 3);
            this.lblPurchasesTodayTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblPurchasesTodayTitle.Name = "lblPurchasesTodayTitle";
            this.lblPurchasesTodayTitle.Size = new System.Drawing.Size(89, 17);
            this.lblPurchasesTodayTitle.TabIndex = 0;
            this.lblPurchasesTodayTitle.Text = "مشتريات اليوم:";
            // 
            // picbPurchasesToday
            // 
            this.picbPurchasesToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbPurchasesToday.Image = global::StorePilot.UI.Properties.Resources.purchase_72;
            this.picbPurchasesToday.Location = new System.Drawing.Point(111, 3);
            this.picbPurchasesToday.Name = "picbPurchasesToday";
            this.picbPurchasesToday.Size = new System.Drawing.Size(39, 51);
            this.picbPurchasesToday.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbPurchasesToday.TabIndex = 1;
            this.picbPurchasesToday.TabStop = false;
            // 
            // tlpEarningToday
            // 
            this.tlpEarningToday.ColumnCount = 2;
            this.tlpEarningToday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEarningToday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpEarningToday.Controls.Add(this.tlpEarningsTodayContent, 1, 0);
            this.tlpEarningToday.Controls.Add(this.picbEarningsToday, 0, 0);
            this.tlpEarningToday.Location = new System.Drawing.Point(499, 66);
            this.tlpEarningToday.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.tlpEarningToday.Name = "tlpEarningToday";
            this.tlpEarningToday.RowCount = 1;
            this.tlpEarningToday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEarningToday.Size = new System.Drawing.Size(153, 57);
            this.tlpEarningToday.TabIndex = 10;
            this.tlpEarningToday.Visible = false;
            // 
            // tlpEarningsTodayContent
            // 
            this.tlpEarningsTodayContent.ColumnCount = 1;
            this.tlpEarningsTodayContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEarningsTodayContent.Controls.Add(this.lblEarningsTodayValue, 0, 1);
            this.tlpEarningsTodayContent.Controls.Add(this.lblEarningsTodayTitle, 0, 0);
            this.tlpEarningsTodayContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEarningsTodayContent.Location = new System.Drawing.Point(3, 3);
            this.tlpEarningsTodayContent.Name = "tlpEarningsTodayContent";
            this.tlpEarningsTodayContent.RowCount = 2;
            this.tlpEarningsTodayContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEarningsTodayContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEarningsTodayContent.Size = new System.Drawing.Size(102, 51);
            this.tlpEarningsTodayContent.TabIndex = 0;
            // 
            // lblEarningsTodayValue
            // 
            this.lblEarningsTodayValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEarningsTodayValue.AutoSize = true;
            this.lblEarningsTodayValue.Location = new System.Drawing.Point(44, 30);
            this.lblEarningsTodayValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblEarningsTodayValue.Name = "lblEarningsTodayValue";
            this.lblEarningsTodayValue.Size = new System.Drawing.Size(15, 17);
            this.lblEarningsTodayValue.TabIndex = 1;
            this.lblEarningsTodayValue.Text = "0";
            // 
            // lblEarningsTodayTitle
            // 
            this.lblEarningsTodayTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblEarningsTodayTitle.AutoSize = true;
            this.lblEarningsTodayTitle.Location = new System.Drawing.Point(19, 3);
            this.lblEarningsTodayTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblEarningsTodayTitle.Name = "lblEarningsTodayTitle";
            this.lblEarningsTodayTitle.Size = new System.Drawing.Size(64, 17);
            this.lblEarningsTodayTitle.TabIndex = 0;
            this.lblEarningsTodayTitle.Text = "أرباح اليوم:";
            // 
            // picbEarningsToday
            // 
            this.picbEarningsToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbEarningsToday.Image = global::StorePilot.UI.Properties.Resources.earnings_72;
            this.picbEarningsToday.Location = new System.Drawing.Point(111, 3);
            this.picbEarningsToday.Name = "picbEarningsToday";
            this.picbEarningsToday.Size = new System.Drawing.Size(39, 51);
            this.picbEarningsToday.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbEarningsToday.TabIndex = 1;
            this.picbEarningsToday.TabStop = false;
            // 
            // tlpDebtsCount
            // 
            this.tlpDebtsCount.ColumnCount = 2;
            this.tlpDebtsCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpDebtsCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpDebtsCount.Controls.Add(this.tlpDebtsCountContent, 1, 0);
            this.tlpDebtsCount.Controls.Add(this.picbDebtsCount, 0, 0);
            this.tlpDebtsCount.Location = new System.Drawing.Point(336, 66);
            this.tlpDebtsCount.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpDebtsCount.Name = "tlpDebtsCount";
            this.tlpDebtsCount.RowCount = 1;
            this.tlpDebtsCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDebtsCount.Size = new System.Drawing.Size(153, 57);
            this.tlpDebtsCount.TabIndex = 11;
            // 
            // tlpDebtsCountContent
            // 
            this.tlpDebtsCountContent.ColumnCount = 1;
            this.tlpDebtsCountContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDebtsCountContent.Controls.Add(this.lblDebtsCountValue, 0, 1);
            this.tlpDebtsCountContent.Controls.Add(this.lblDebtsCountTitle, 0, 0);
            this.tlpDebtsCountContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDebtsCountContent.Location = new System.Drawing.Point(3, 3);
            this.tlpDebtsCountContent.Name = "tlpDebtsCountContent";
            this.tlpDebtsCountContent.RowCount = 2;
            this.tlpDebtsCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDebtsCountContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDebtsCountContent.Size = new System.Drawing.Size(102, 51);
            this.tlpDebtsCountContent.TabIndex = 0;
            // 
            // lblDebtsCountValue
            // 
            this.lblDebtsCountValue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDebtsCountValue.AutoSize = true;
            this.lblDebtsCountValue.Location = new System.Drawing.Point(44, 30);
            this.lblDebtsCountValue.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblDebtsCountValue.Name = "lblDebtsCountValue";
            this.lblDebtsCountValue.Size = new System.Drawing.Size(15, 17);
            this.lblDebtsCountValue.TabIndex = 1;
            this.lblDebtsCountValue.Text = "0";
            // 
            // lblDebtsCountTitle
            // 
            this.lblDebtsCountTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDebtsCountTitle.AutoSize = true;
            this.lblDebtsCountTitle.Location = new System.Drawing.Point(8, 3);
            this.lblDebtsCountTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblDebtsCountTitle.Name = "lblDebtsCountTitle";
            this.lblDebtsCountTitle.Size = new System.Drawing.Size(86, 17);
            this.lblDebtsCountTitle.TabIndex = 0;
            this.lblDebtsCountTitle.Text = "إجمالي الديون:";
            // 
            // picbDebtsCount
            // 
            this.picbDebtsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbDebtsCount.Image = global::StorePilot.UI.Properties.Resources.debt_72;
            this.picbDebtsCount.Location = new System.Drawing.Point(111, 3);
            this.picbDebtsCount.Name = "picbDebtsCount";
            this.picbDebtsCount.Size = new System.Drawing.Size(39, 51);
            this.picbDebtsCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbDebtsCount.TabIndex = 1;
            this.picbDebtsCount.TabStop = false;
            // 
            // ucDashboardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucDashboardScreen";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(971, 851);
            this.Load += new System.EventHandler(this.ucDashboardScreen_Load);
            this.tlpContainer.ResumeLayout(false);
            this.tlpContainer.PerformLayout();
            this.tlpQuickActions.ResumeLayout(false);
            this.tlpTables.ResumeLayout(false);
            this.pnlLowStockProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlDgvLowStockProducts)).EndInit();
            this.pnlRecentSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlDgvRecentSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtYearlySales)).EndInit();
            this.flpStatsCards.ResumeLayout(false);
            this.tlpProductsCount.ResumeLayout(false);
            this.tlpProductsCountContent.ResumeLayout(false);
            this.tlpProductsCountContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbProductsCount)).EndInit();
            this.tlpCustomersCount.ResumeLayout(false);
            this.tlpCustomersCountContent.ResumeLayout(false);
            this.tlpCustomersCountContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbCustomersCount)).EndInit();
            this.tlpSuppliersCount.ResumeLayout(false);
            this.tlpSuppliersCountContent.ResumeLayout(false);
            this.tlpSuppliersCountContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbSuppliersCount)).EndInit();
            this.tlpInvoicesCount.ResumeLayout(false);
            this.tlpInvoicesCountContent.ResumeLayout(false);
            this.tlpInvoicesCountContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInvoicesCount)).EndInit();
            this.tlpSalesToday.ResumeLayout(false);
            this.tlpSalesTodayContent.ResumeLayout(false);
            this.tlpSalesTodayContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbSalesToday)).EndInit();
            this.tlpPurchasesToday.ResumeLayout(false);
            this.tlpPurchasesTodayContent.ResumeLayout(false);
            this.tlpPurchasesTodayContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbPurchasesToday)).EndInit();
            this.tlpEarningToday.ResumeLayout(false);
            this.tlpEarningsTodayContent.ResumeLayout(false);
            this.tlpEarningsTodayContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbEarningsToday)).EndInit();
            this.tlpDebtsCount.ResumeLayout(false);
            this.tlpDebtsCountContent.ResumeLayout(false);
            this.tlpDebtsCountContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbDebtsCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.FlowLayoutPanel flpStatsCards;
        private System.Windows.Forms.TableLayoutPanel tlpProductsCount;
        private System.Windows.Forms.TableLayoutPanel tlpProductsCountContent;
        private System.Windows.Forms.Label lblProductsCountValue;
        private System.Windows.Forms.Label lblProductsCountTitle;
        private System.Windows.Forms.PictureBox picbProductsCount;
        private System.Windows.Forms.TableLayoutPanel tlpCustomersCount;
        private System.Windows.Forms.TableLayoutPanel tlpCustomersCountContent;
        private System.Windows.Forms.Label lblCustomersCountValue;
        private System.Windows.Forms.Label lblCustomersCountTitle;
        private System.Windows.Forms.PictureBox picbCustomersCount;
        private System.Windows.Forms.TableLayoutPanel tlpSuppliersCount;
        private System.Windows.Forms.TableLayoutPanel tlpSuppliersCountContent;
        private System.Windows.Forms.Label lblSuppliersCountValue;
        private System.Windows.Forms.Label lblSuppliersCountTitle;
        private System.Windows.Forms.PictureBox picbSuppliersCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtYearlySales;
        private System.Windows.Forms.TableLayoutPanel tlpInvoicesCount;
        private System.Windows.Forms.TableLayoutPanel tlpInvoicesCountContent;
        private System.Windows.Forms.Label lblInvoicesTodayValue;
        private System.Windows.Forms.Label lblInvoicesTodayTitle;
        private System.Windows.Forms.PictureBox picbInvoicesCount;
        private System.Windows.Forms.TableLayoutPanel tlpSalesToday;
        private System.Windows.Forms.TableLayoutPanel tlpSalesTodayContent;
        private System.Windows.Forms.Label lblSalesTodayValue;
        private System.Windows.Forms.Label lblSalesTodayTitle;
        private System.Windows.Forms.PictureBox picbSalesToday;
        private System.Windows.Forms.TableLayoutPanel tlpPurchasesToday;
        private System.Windows.Forms.TableLayoutPanel tlpPurchasesTodayContent;
        private System.Windows.Forms.Label lblPurchasesTodayValue;
        private System.Windows.Forms.Label lblPurchasesTodayTitle;
        private System.Windows.Forms.PictureBox picbPurchasesToday;
        private System.Windows.Forms.TableLayoutPanel tlpEarningToday;
        private System.Windows.Forms.TableLayoutPanel tlpEarningsTodayContent;
        private System.Windows.Forms.Label lblEarningsTodayValue;
        private System.Windows.Forms.Label lblEarningsTodayTitle;
        private System.Windows.Forms.PictureBox picbEarningsToday;
        private System.Windows.Forms.TableLayoutPanel tlpDebtsCount;
        private System.Windows.Forms.TableLayoutPanel tlpDebtsCountContent;
        private System.Windows.Forms.Label lblDebtsCountValue;
        private System.Windows.Forms.Label lblDebtsCountTitle;
        private System.Windows.Forms.PictureBox picbDebtsCount;
        private System.Windows.Forms.TableLayoutPanel tlpTables;
        private System.Windows.Forms.Panel pnlLowStockProducts;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccDataGridView ctrlDgvLowStockProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinQuantity;
        private System.Windows.Forms.Label lblLowStockProducts;
        private System.Windows.Forms.Panel pnlRecentSales;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccDataGridView ctrlDgvRecentSales;
        private System.Windows.Forms.Label lblRecentSales;
        private System.Windows.Forms.TableLayoutPanel tlpQuickActions;
        private System.Windows.Forms.Button btnNewSale;
        private System.Windows.Forms.Button btnNewPurchase;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetTotal;
        private System.Windows.Forms.Button btnNewCustomer;
    }
}
