namespace StorePilot.UI.Sales
{
    partial class frmAddEditUpdateSaleItems
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUpdateSaleItems));
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpItem = new System.Windows.Forms.TableLayoutPanel();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.btnResetList = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveList = new System.Windows.Forms.Button();
            this.ctrlCmData = new DevToolkit.BaseWinForms.Controls.CustomControls.ccDataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctrlCmsData = new DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tss = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.tlpHeader.SuspendLayout();
            this.tlpItem.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCmData)).BeginInit();
            this.ctrlCmsData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 3;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpHeader.Controls.Add(this.btnCancel, 2, 0);
            this.tlpHeader.Controls.Add(this.tlpItem, 0, 0);
            this.tlpHeader.Controls.Add(this.btnSaveItem, 1, 0);
            this.tlpHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(1094, 74);
            this.tlpHeader.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(3, 29);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(41, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpItem
            // 
            this.tlpItem.ColumnCount = 4;
            this.tlpItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpItem.Controls.Add(this.cbProducts, 0, 1);
            this.tlpItem.Controls.Add(this.tbTotalPrice, 3, 1);
            this.tlpItem.Controls.Add(this.tbUnitPrice, 2, 1);
            this.tlpItem.Controls.Add(this.lblTotalPrice, 3, 0);
            this.tlpItem.Controls.Add(this.lblUnitPrice, 2, 0);
            this.tlpItem.Controls.Add(this.lblQuantity, 1, 0);
            this.tlpItem.Controls.Add(this.lblProduct, 0, 0);
            this.tlpItem.Controls.Add(this.tbQuantity, 1, 1);
            this.tlpItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlpItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpItem.Location = new System.Drawing.Point(92, 11);
            this.tlpItem.Margin = new System.Windows.Forms.Padding(0);
            this.tlpItem.Name = "tlpItem";
            this.tlpItem.RowCount = 2;
            this.tlpItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpItem.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpItem.Size = new System.Drawing.Size(1002, 63);
            this.tlpItem.TabIndex = 8;
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotalPrice.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbTotalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalPrice.Location = new System.Drawing.Point(3, 34);
            this.tbTotalPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.ReadOnly = true;
            this.tbTotalPrice.Size = new System.Drawing.Size(196, 27);
            this.tbTotalPrice.TabIndex = 7;
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnitPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUnitPrice.Location = new System.Drawing.Point(205, 34);
            this.tbUnitPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.tbUnitPrice.MaxLength = 6;
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.ReadOnly = true;
            this.tbUnitPrice.Size = new System.Drawing.Size(194, 27);
            this.tbUnitPrice.TabIndex = 2;
            this.tbUnitPrice.TextChanged += new System.EventHandler(this.QuantitAndUnitPrice_TextChanged);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Image = global::StorePilot.UI.Properties.Resources.money;
            this.lblTotalPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalPrice.Location = new System.Drawing.Point(3, 0);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(196, 28);
            this.lblTotalPrice.TabIndex = 3;
            this.lblTotalPrice.Text = "الإجمالي:";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Image = global::StorePilot.UI.Properties.Resources.money;
            this.lblUnitPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnitPrice.Location = new System.Drawing.Point(205, 0);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(194, 28);
            this.lblUnitPrice.TabIndex = 2;
            this.lblUnitPrice.Text = "سعر الوحدة:";
            this.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Image = global::StorePilot.UI.Properties.Resources.weight_pound;
            this.lblQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuantity.Location = new System.Drawing.Point(405, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(194, 28);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "الكمية:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProduct.Image = global::StorePilot.UI.Properties.Resources.product;
            this.lblProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProduct.Location = new System.Drawing.Point(605, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(394, 28);
            this.lblProduct.TabIndex = 12;
            this.lblProduct.Text = "الصنف:";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuantity.Location = new System.Drawing.Point(405, 34);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.tbQuantity.MaxLength = 6;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.ReadOnly = true;
            this.tbQuantity.Size = new System.Drawing.Size(194, 27);
            this.tbQuantity.TabIndex = 1;
            this.tbQuantity.TextChanged += new System.EventHandler(this.QuantitAndUnitPrice_TextChanged);
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveItem.AutoSize = true;
            this.btnSaveItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveItem.Enabled = false;
            this.btnSaveItem.FlatAppearance.BorderSize = 0;
            this.btnSaveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveItem.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveItem.Location = new System.Drawing.Point(47, 29);
            this.btnSaveItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(44, 27);
            this.btnSaveItem.TabIndex = 3;
            this.btnSaveItem.Text = "حفظ";
            this.btnSaveItem.UseVisualStyleBackColor = true;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // tlpFooter
            // 
            this.tlpFooter.ColumnCount = 6;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.93205F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.689318F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.689318F));
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.689318F));
            this.tlpFooter.Controls.Add(this.lblTotal, 1, 0);
            this.tlpFooter.Controls.Add(this.lblItemsCount, 0, 0);
            this.tlpFooter.Controls.Add(this.btnResetList, 3, 0);
            this.tlpFooter.Controls.Add(this.btnExit, 5, 0);
            this.tlpFooter.Controls.Add(this.btnSaveList, 4, 0);
            this.tlpFooter.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpFooter.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpFooter.Location = new System.Drawing.Point(0, 545);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlpFooter.RowCount = 1;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(1094, 45);
            this.tlpFooter.TabIndex = 16;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotal.Location = new System.Drawing.Point(845, 14);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(18, 0, 3, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(102, 17);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "إجمالي الفاتورة: 0";
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblItemsCount.AutoSize = true;
            this.lblItemsCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblItemsCount.Location = new System.Drawing.Point(968, 14);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(123, 17);
            this.lblItemsCount.TabIndex = 10;
            this.lblItemsCount.Text = "عدد عناصر الفاتورة: 0";
            // 
            // btnResetList
            // 
            this.btnResetList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetList.Enabled = false;
            this.btnResetList.FlatAppearance.BorderSize = 0;
            this.btnResetList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetList.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetList.Image = global::StorePilot.UI.Properties.Resources.discharge;
            this.btnResetList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetList.Location = new System.Drawing.Point(167, 4);
            this.btnResetList.Name = "btnResetList";
            this.btnResetList.Size = new System.Drawing.Size(75, 37);
            this.btnResetList.TabIndex = 6;
            this.btnResetList.Text = "تفريغ";
            this.btnResetList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetList.UseVisualStyleBackColor = true;
            this.btnResetList.Click += new System.EventHandler(this.btnResetList_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::StorePilot.UI.Properties.Resources.Close_32;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(77, 37);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "خروج";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnSaveList
            // 
            this.btnSaveList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveList.Enabled = false;
            this.btnSaveList.FlatAppearance.BorderSize = 0;
            this.btnSaveList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveList.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveList.Image = global::StorePilot.UI.Properties.Resources.Save_32;
            this.btnSaveList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveList.Location = new System.Drawing.Point(86, 4);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Size = new System.Drawing.Size(75, 37);
            this.btnSaveList.TabIndex = 7;
            this.btnSaveList.Text = "حفظ";
            this.btnSaveList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveList.UseVisualStyleBackColor = true;
            this.btnSaveList.Click += new System.EventHandler(this.btnSaveList_Click);
            // 
            // ctrlCmData
            // 
            this.ctrlCmData.AllowUserToAddRows = false;
            this.ctrlCmData.AllowUserToDeleteRows = false;
            this.ctrlCmData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.ctrlCmData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ctrlCmData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ctrlCmData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ctrlCmData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctrlCmData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ctrlCmData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ctrlCmData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ctrlCmData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrlCmData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.GroupName,
            this.Unit,
            this.RequiredQuantity,
            this.UnitPrice,
            this.TotalPrice});
            this.ctrlCmData.ContextMenuStrip = this.ctrlCmsData;
            this.ctrlCmData.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ctrlCmData.DefaultCellStyle = dataGridViewCellStyle6;
            this.ctrlCmData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCmData.EnableHeadersVisualStyles = false;
            this.ctrlCmData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.ctrlCmData.Location = new System.Drawing.Point(0, 74);
            this.ctrlCmData.MultiSelect = false;
            this.ctrlCmData.Name = "ctrlCmData";
            this.ctrlCmData.ReadOnly = true;
            this.ctrlCmData.RowHeadersVisible = false;
            this.ctrlCmData.RowHeadersWidth = 51;
            this.ctrlCmData.RowTemplate.Height = 35;
            this.ctrlCmData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrlCmData.Size = new System.Drawing.Size(1094, 471);
            this.ctrlCmData.TabIndex = 5;
            this.ctrlCmData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctrlCmData_CellDoubleClick);
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "رقم المنتج";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "اسم المنتج";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Group";
            this.GroupName.HeaderText = "المجموعة";
            this.GroupName.MinimumWidth = 6;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "UnitName";
            this.Unit.HeaderText = "وحدة القياس";
            this.Unit.MinimumWidth = 6;
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // RequiredQuantity
            // 
            this.RequiredQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.RequiredQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.RequiredQuantity.HeaderText = "الكمية";
            this.RequiredQuantity.MinimumWidth = 6;
            this.RequiredQuantity.Name = "RequiredQuantity";
            this.RequiredQuantity.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.UnitPrice.HeaderText = "سعر الوحدة";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.TotalPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalPrice.HeaderText = "الإجمالي";
            this.TotalPrice.MinimumWidth = 6;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            // 
            // ctrlCmsData
            // 
            this.ctrlCmsData.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ctrlCmsData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.ctrlCmsData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tss,
            this.tsmiDelete});
            this.ctrlCmsData.Name = "ctrlCmsData";
            this.ctrlCmsData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCmsData.Size = new System.Drawing.Size(128, 66);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiUpdate.Image = global::StorePilot.UI.Properties.Resources.update;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(127, 28);
            this.tsmiUpdate.Text = "تحديث";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tss
            // 
            this.tss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(124, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.tsmiDelete.Image = global::StorePilot.UI.Properties.Resources.delete;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(127, 28);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // cbProducts
            // 
            this.cbProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProducts.DropDownHeight = 100;
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.IntegralHeight = false;
            this.cbProducts.Location = new System.Drawing.Point(605, 31);
            this.cbProducts.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.Size = new System.Drawing.Size(394, 28);
            this.cbProducts.TabIndex = 0;
            // 
            // frmAddEditUpdateSaleItems
            // 
            this.AcceptButton = this.btnSaveList;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1094, 590);
            this.Controls.Add(this.ctrlCmData);
            this.Controls.Add(this.tlpFooter);
            this.Controls.Add(this.tlpHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditUpdateSaleItems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateSaleItems";
            this.Load += new System.EventHandler(this.frmAddEditUpdateSaleItems_Load);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.tlpItem.ResumeLayout(false);
            this.tlpItem.PerformLayout();
            this.tlpFooter.ResumeLayout(false);
            this.tlpFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCmData)).EndInit();
            this.ctrlCmsData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpItem;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Button btnSaveItem;
        private System.Windows.Forms.TableLayoutPanel tlpFooter;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblItemsCount;
        private System.Windows.Forms.Button btnResetList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveList;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccDataGridView ctrlCmData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccContextMenuStrip ctrlCmsData;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator tss;
        private System.Windows.Forms.ComboBox cbProducts;
    }
}