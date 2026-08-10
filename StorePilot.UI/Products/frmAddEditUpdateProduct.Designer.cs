namespace StorePilot.UI.Products
{
    partial class frmAddEditUpdateProduct
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUpdateProduct));
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnSave = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.btnActivate = new DevToolkit.BaseWinForms.Controls.CustomControls.ccButton();
            this.tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this.tlpNotes = new System.Windows.Forms.TableLayoutPanel();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.tlpUp = new System.Windows.Forms.TableLayoutPanel();
            this.tlpQuantity = new System.Windows.Forms.TableLayoutPanel();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tlpSalePrice = new System.Windows.Forms.TableLayoutPanel();
            this.tbSalePrice = new System.Windows.Forms.TextBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.tlpPurchasePrice = new System.Windows.Forms.TableLayoutPanel();
            this.tbPurchasePrice = new System.Windows.Forms.TextBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.tlpMinQuantity = new System.Windows.Forms.TableLayoutPanel();
            this.tbMinQuantity = new System.Windows.Forms.TextBox();
            this.lblMinQuantity = new System.Windows.Forms.Label();
            this.tlpGroups = new System.Windows.Forms.TableLayoutPanel();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.tlpBarCode = new System.Windows.Forms.TableLayoutPanel();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.tlpProductName = new System.Windows.Forms.TableLayoutPanel();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.tlpUnits = new System.Windows.Forms.TableLayoutPanel();
            this.cbUnits = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.epProductData = new System.Windows.Forms.ErrorProvider(this.components);
            this.flpFooter.SuspendLayout();
            this.tlpBody.SuspendLayout();
            this.tlpNotes.SuspendLayout();
            this.tlpUp.SuspendLayout();
            this.tlpQuantity.SuspendLayout();
            this.tlpSalePrice.SuspendLayout();
            this.tlpPurchasePrice.SuspendLayout();
            this.tlpMinQuantity.SuspendLayout();
            this.tlpGroups.SuspendLayout();
            this.tlpBarCode.SuspendLayout();
            this.tlpProductName.SuspendLayout();
            this.tlpUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epProductData)).BeginInit();
            this.SuspendLayout();
            // 
            // flpFooter
            // 
            this.flpFooter.AutoSize = true;
            this.flpFooter.Controls.Add(this.btnClose);
            this.flpFooter.Controls.Add(this.btnSave);
            this.flpFooter.Controls.Add(this.btnActivate);
            this.flpFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpFooter.Location = new System.Drawing.Point(0, 388);
            this.flpFooter.Name = "flpFooter";
            this.flpFooter.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flpFooter.Size = new System.Drawing.Size(601, 40);
            this.flpFooter.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnClose.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Primary;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::StorePilot.UI.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnClose.Size = new System.Drawing.Size(92, 28);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "إغلاق";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnSave.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Success;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(101)))), ((int)(((byte)(47)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(74)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::StorePilot.UI.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(104, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSave.Size = new System.Drawing.Size(92, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnActivate.ButtonStyle = DevToolkit.BaseWinForms.Theming.ButtonStyle.Danger;
            this.btnActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnActivate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnActivate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivate.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Image = global::StorePilot.UI.Properties.Resources.activate_profile;
            this.btnActivate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivate.Location = new System.Drawing.Point(202, 6);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnActivate.Size = new System.Drawing.Size(92, 28);
            this.btnActivate.TabIndex = 8;
            this.btnActivate.Text = "تفعيل";
            this.btnActivate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // tlpBody
            // 
            this.tlpBody.ColumnCount = 1;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBody.Controls.Add(this.tlpNotes, 0, 1);
            this.tlpBody.Controls.Add(this.tlpUp, 0, 0);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(0, 46);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 2;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.48351F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.51648F));
            this.tlpBody.Size = new System.Drawing.Size(601, 342);
            this.tlpBody.TabIndex = 12;
            // 
            // tlpNotes
            // 
            this.tlpNotes.ColumnCount = 1;
            this.tlpNotes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNotes.Controls.Add(this.tbNotes, 0, 1);
            this.tlpNotes.Controls.Add(this.lblNotes, 0, 0);
            this.tlpNotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpNotes.Location = new System.Drawing.Point(0, 227);
            this.tlpNotes.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNotes.Name = "tlpNotes";
            this.tlpNotes.RowCount = 2;
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNotes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpNotes.Size = new System.Drawing.Size(601, 115);
            this.tlpNotes.TabIndex = 4;
            // 
            // tbNotes
            // 
            this.tbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNotes.Location = new System.Drawing.Point(20, 18);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbNotes.MaxLength = 500;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(578, 94);
            this.tbNotes.TabIndex = 7;
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotes.Image = global::StorePilot.UI.Properties.Resources.Notes_32;
            this.lblNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNotes.Location = new System.Drawing.Point(3, 0);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(593, 15);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "ملاحظات:";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpUp
            // 
            this.tlpUp.ColumnCount = 2;
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUp.Controls.Add(this.tlpQuantity, 1, 3);
            this.tlpUp.Controls.Add(this.tlpSalePrice, 0, 3);
            this.tlpUp.Controls.Add(this.tlpPurchasePrice, 1, 2);
            this.tlpUp.Controls.Add(this.tlpMinQuantity, 0, 2);
            this.tlpUp.Controls.Add(this.tlpGroups, 0, 1);
            this.tlpUp.Controls.Add(this.tlpBarCode, 1, 0);
            this.tlpUp.Controls.Add(this.tlpProductName, 0, 0);
            this.tlpUp.Controls.Add(this.tlpUnits, 1, 1);
            this.tlpUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUp.Location = new System.Drawing.Point(3, 3);
            this.tlpUp.Name = "tlpUp";
            this.tlpUp.RowCount = 4;
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpUp.Size = new System.Drawing.Size(595, 221);
            this.tlpUp.TabIndex = 3;
            // 
            // tlpQuantity
            // 
            this.tlpQuantity.ColumnCount = 1;
            this.tlpQuantity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuantity.Controls.Add(this.tbQuantity, 0, 1);
            this.tlpQuantity.Controls.Add(this.lblQuantity, 0, 0);
            this.tlpQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuantity.Location = new System.Drawing.Point(0, 165);
            this.tlpQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQuantity.Name = "tlpQuantity";
            this.tlpQuantity.RowCount = 2;
            this.tlpQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQuantity.Size = new System.Drawing.Size(298, 56);
            this.tlpQuantity.TabIndex = 17;
            this.tlpQuantity.Visible = false;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuantity.Location = new System.Drawing.Point(20, 28);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbQuantity.MaxLength = 50;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.ReadOnly = true;
            this.tbQuantity.Size = new System.Drawing.Size(275, 25);
            this.tbQuantity.TabIndex = 0;
            this.tbQuantity.Text = "0";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuantity.Image = global::StorePilot.UI.Properties.Resources.weight_pound;
            this.lblQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuantity.Location = new System.Drawing.Point(5, 0);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(288, 25);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "الكمية الحالية:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpSalePrice
            // 
            this.tlpSalePrice.ColumnCount = 1;
            this.tlpSalePrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSalePrice.Controls.Add(this.tbSalePrice, 0, 1);
            this.tlpSalePrice.Controls.Add(this.lblSalePrice, 0, 0);
            this.tlpSalePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSalePrice.Location = new System.Drawing.Point(298, 165);
            this.tlpSalePrice.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSalePrice.Name = "tlpSalePrice";
            this.tlpSalePrice.RowCount = 2;
            this.tlpSalePrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSalePrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSalePrice.Size = new System.Drawing.Size(297, 56);
            this.tlpSalePrice.TabIndex = 16;
            // 
            // tbSalePrice
            // 
            this.tbSalePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSalePrice.Location = new System.Drawing.Point(20, 28);
            this.tbSalePrice.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbSalePrice.MaxLength = 6;
            this.tbSalePrice.Name = "tbSalePrice";
            this.tbSalePrice.Size = new System.Drawing.Size(274, 25);
            this.tbSalePrice.TabIndex = 6;
            this.tbSalePrice.Text = "0";
            this.tbSalePrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbSalePrice_Validating);
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSalePrice.Image = global::StorePilot.UI.Properties.Resources.money;
            this.lblSalePrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSalePrice.Location = new System.Drawing.Point(5, 0);
            this.lblSalePrice.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(287, 25);
            this.lblSalePrice.TabIndex = 1;
            this.lblSalePrice.Text = "سعر البيع:";
            this.lblSalePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpPurchasePrice
            // 
            this.tlpPurchasePrice.ColumnCount = 1;
            this.tlpPurchasePrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPurchasePrice.Controls.Add(this.tbPurchasePrice, 0, 1);
            this.tlpPurchasePrice.Controls.Add(this.lblPurchasePrice, 0, 0);
            this.tlpPurchasePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPurchasePrice.Location = new System.Drawing.Point(0, 110);
            this.tlpPurchasePrice.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPurchasePrice.Name = "tlpPurchasePrice";
            this.tlpPurchasePrice.RowCount = 2;
            this.tlpPurchasePrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPurchasePrice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPurchasePrice.Size = new System.Drawing.Size(298, 55);
            this.tlpPurchasePrice.TabIndex = 15;
            // 
            // tbPurchasePrice
            // 
            this.tbPurchasePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPurchasePrice.Location = new System.Drawing.Point(20, 27);
            this.tbPurchasePrice.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbPurchasePrice.MaxLength = 6;
            this.tbPurchasePrice.Name = "tbPurchasePrice";
            this.tbPurchasePrice.Size = new System.Drawing.Size(275, 25);
            this.tbPurchasePrice.TabIndex = 5;
            this.tbPurchasePrice.Text = "0";
            this.tbPurchasePrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbPurchasePrice_Validating);
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPurchasePrice.Image = global::StorePilot.UI.Properties.Resources.money;
            this.lblPurchasePrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPurchasePrice.Location = new System.Drawing.Point(5, 0);
            this.lblPurchasePrice.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(288, 24);
            this.lblPurchasePrice.TabIndex = 1;
            this.lblPurchasePrice.Text = "سعر الشراء:";
            this.lblPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMinQuantity
            // 
            this.tlpMinQuantity.ColumnCount = 1;
            this.tlpMinQuantity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMinQuantity.Controls.Add(this.tbMinQuantity, 0, 1);
            this.tlpMinQuantity.Controls.Add(this.lblMinQuantity, 0, 0);
            this.tlpMinQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMinQuantity.Location = new System.Drawing.Point(298, 110);
            this.tlpMinQuantity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMinQuantity.Name = "tlpMinQuantity";
            this.tlpMinQuantity.RowCount = 2;
            this.tlpMinQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMinQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMinQuantity.Size = new System.Drawing.Size(297, 55);
            this.tlpMinQuantity.TabIndex = 14;
            // 
            // tbMinQuantity
            // 
            this.tbMinQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMinQuantity.Location = new System.Drawing.Point(20, 27);
            this.tbMinQuantity.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbMinQuantity.MaxLength = 6;
            this.tbMinQuantity.Name = "tbMinQuantity";
            this.tbMinQuantity.Size = new System.Drawing.Size(274, 25);
            this.tbMinQuantity.TabIndex = 4;
            this.tbMinQuantity.Text = "0";
            this.tbMinQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.tbMinQuantity_Validating);
            // 
            // lblMinQuantity
            // 
            this.lblMinQuantity.AutoSize = true;
            this.lblMinQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinQuantity.Image = global::StorePilot.UI.Properties.Resources.border_bottom;
            this.lblMinQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMinQuantity.Location = new System.Drawing.Point(5, 0);
            this.lblMinQuantity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMinQuantity.Name = "lblMinQuantity";
            this.lblMinQuantity.Size = new System.Drawing.Size(287, 24);
            this.lblMinQuantity.TabIndex = 1;
            this.lblMinQuantity.Text = "الحد الأدنى:";
            this.lblMinQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpGroups
            // 
            this.tlpGroups.ColumnCount = 1;
            this.tlpGroups.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGroups.Controls.Add(this.cbGroups, 0, 1);
            this.tlpGroups.Controls.Add(this.lblGroup, 0, 0);
            this.tlpGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGroups.Location = new System.Drawing.Point(298, 55);
            this.tlpGroups.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGroups.Name = "tlpGroups";
            this.tlpGroups.RowCount = 2;
            this.tlpGroups.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGroups.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpGroups.Size = new System.Drawing.Size(297, 55);
            this.tlpGroups.TabIndex = 13;
            // 
            // cbGroups
            // 
            this.cbGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbGroups.DropDownHeight = 100;
            this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroups.FormattingEnabled = true;
            this.cbGroups.IntegralHeight = false;
            this.cbGroups.Location = new System.Drawing.Point(20, 27);
            this.cbGroups.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(274, 25);
            this.cbGroups.TabIndex = 2;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroup.Image = global::StorePilot.UI.Properties.Resources.groups;
            this.lblGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGroup.Location = new System.Drawing.Point(5, 0);
            this.lblGroup.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(287, 24);
            this.lblGroup.TabIndex = 1;
            this.lblGroup.Text = "المجموعة: ";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpBarCode
            // 
            this.tlpBarCode.ColumnCount = 1;
            this.tlpBarCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBarCode.Controls.Add(this.tbBarCode, 0, 1);
            this.tlpBarCode.Controls.Add(this.lblBarCode, 0, 0);
            this.tlpBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBarCode.Location = new System.Drawing.Point(0, 0);
            this.tlpBarCode.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBarCode.Name = "tlpBarCode";
            this.tlpBarCode.RowCount = 2;
            this.tlpBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBarCode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBarCode.Size = new System.Drawing.Size(298, 55);
            this.tlpBarCode.TabIndex = 5;
            // 
            // tbBarCode
            // 
            this.tbBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBarCode.Location = new System.Drawing.Point(20, 27);
            this.tbBarCode.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbBarCode.MaxLength = 20;
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(275, 25);
            this.tbBarCode.TabIndex = 1;
            this.tbBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.tbBarCode_Validating);
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBarCode.Image = global::StorePilot.UI.Properties.Resources.barcode;
            this.lblBarCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBarCode.Location = new System.Drawing.Point(5, 0);
            this.lblBarCode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(288, 24);
            this.lblBarCode.TabIndex = 1;
            this.lblBarCode.Text = "الباركود:";
            this.lblBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpProductName
            // 
            this.tlpProductName.ColumnCount = 1;
            this.tlpProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProductName.Controls.Add(this.tbProductName, 0, 1);
            this.tlpProductName.Controls.Add(this.lblProductName, 0, 0);
            this.tlpProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProductName.Location = new System.Drawing.Point(298, 0);
            this.tlpProductName.Margin = new System.Windows.Forms.Padding(0);
            this.tlpProductName.Name = "tlpProductName";
            this.tlpProductName.RowCount = 2;
            this.tlpProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProductName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProductName.Size = new System.Drawing.Size(297, 55);
            this.tlpProductName.TabIndex = 4;
            // 
            // tbProductName
            // 
            this.tbProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbProductName.Location = new System.Drawing.Point(20, 27);
            this.tbProductName.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.tbProductName.MaxLength = 100;
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(274, 25);
            this.tbProductName.TabIndex = 0;
            this.tbProductName.Validating += new System.ComponentModel.CancelEventHandler(this.tbProductName_Validating);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Image = global::StorePilot.UI.Properties.Resources.product;
            this.lblProductName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProductName.Location = new System.Drawing.Point(5, 0);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(287, 24);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "الإسم:";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpUnits
            // 
            this.tlpUnits.ColumnCount = 1;
            this.tlpUnits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUnits.Controls.Add(this.cbUnits, 0, 1);
            this.tlpUnits.Controls.Add(this.lblUnit, 0, 0);
            this.tlpUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUnits.Location = new System.Drawing.Point(0, 55);
            this.tlpUnits.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUnits.Name = "tlpUnits";
            this.tlpUnits.RowCount = 2;
            this.tlpUnits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUnits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUnits.Size = new System.Drawing.Size(298, 55);
            this.tlpUnits.TabIndex = 6;
            // 
            // cbUnits
            // 
            this.cbUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUnits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUnits.DropDownHeight = 100;
            this.cbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnits.FormattingEnabled = true;
            this.cbUnits.IntegralHeight = false;
            this.cbUnits.Items.AddRange(new object[] {
            ""});
            this.cbUnits.Location = new System.Drawing.Point(20, 27);
            this.cbUnits.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cbUnits.Name = "cbUnits";
            this.cbUnits.Size = new System.Drawing.Size(275, 25);
            this.cbUnits.TabIndex = 3;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnit.Image = global::StorePilot.UI.Properties.Resources.weight_pound;
            this.lblUnit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit.Location = new System.Drawing.Point(5, 0);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(288, 24);
            this.lblUnit.TabIndex = 1;
            this.lblUnit.Text = "وحدة القياس: ";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Image = global::StorePilot.UI.Properties.Resources.product;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(601, 46);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // epProductData
            // 
            this.epProductData.ContainerControl = this;
            this.epProductData.RightToLeft = true;
            // 
            // frmAddEditUpdateProduct
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(601, 428);
            this.Controls.Add(this.tlpBody);
            this.Controls.Add(this.flpFooter);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditUpdateProduct";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditUpdateProduct";
            this.Load += new System.EventHandler(this.frmAddEditUpdateProduct_Load);
            this.flpFooter.ResumeLayout(false);
            this.tlpBody.ResumeLayout(false);
            this.tlpNotes.ResumeLayout(false);
            this.tlpNotes.PerformLayout();
            this.tlpUp.ResumeLayout(false);
            this.tlpQuantity.ResumeLayout(false);
            this.tlpQuantity.PerformLayout();
            this.tlpSalePrice.ResumeLayout(false);
            this.tlpSalePrice.PerformLayout();
            this.tlpPurchasePrice.ResumeLayout(false);
            this.tlpPurchasePrice.PerformLayout();
            this.tlpMinQuantity.ResumeLayout(false);
            this.tlpMinQuantity.PerformLayout();
            this.tlpGroups.ResumeLayout(false);
            this.tlpGroups.PerformLayout();
            this.tlpBarCode.ResumeLayout(false);
            this.tlpBarCode.PerformLayout();
            this.tlpProductName.ResumeLayout(false);
            this.tlpProductName.PerformLayout();
            this.tlpUnits.ResumeLayout(false);
            this.tlpUnits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epProductData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpFooter;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnClose;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnSave;
        private DevToolkit.BaseWinForms.Controls.CustomControls.ccButton btnActivate;
        private System.Windows.Forms.TableLayoutPanel tlpBody;
        private System.Windows.Forms.TableLayoutPanel tlpUp;
        private System.Windows.Forms.TableLayoutPanel tlpQuantity;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TableLayoutPanel tlpSalePrice;
        private System.Windows.Forms.TextBox tbSalePrice;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.TableLayoutPanel tlpPurchasePrice;
        private System.Windows.Forms.TextBox tbPurchasePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.TableLayoutPanel tlpMinQuantity;
        private System.Windows.Forms.TextBox tbMinQuantity;
        private System.Windows.Forms.Label lblMinQuantity;
        private System.Windows.Forms.TableLayoutPanel tlpGroups;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TableLayoutPanel tlpBarCode;
        private System.Windows.Forms.TextBox tbBarCode;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.TableLayoutPanel tlpProductName;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TableLayoutPanel tlpUnits;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cbGroups;
        private System.Windows.Forms.ComboBox cbUnits;
        private System.Windows.Forms.TableLayoutPanel tlpNotes;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.ErrorProvider epProductData;
    }
}