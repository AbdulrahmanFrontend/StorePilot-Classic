namespace StorePilot.WinForms.Pages;

partial class SettingsPage
{
    private System.ComponentModel.IContainer components=null!;

    private StorePilot.WinForms.Controls.PageHeader header=null!;

    private Krypton.Toolkit.KryptonPanel surface=null!;

    private System.Windows.Forms.TableLayoutPanel layout=null!;

    private Krypton.Toolkit.KryptonLabel l1=null!,
        l2=null!,
        l3=null!,
        l4=null!,
        logoInfo=null!;

    private Krypton.Toolkit.KryptonTextBox shop=null!,
        user=null!;

    private Krypton.Toolkit.KryptonComboBox theme=null!;

    private Krypton.Toolkit.KryptonButton choose=null!,
        delete=null!,
        save=null!;

    private System.Windows.Forms.FlowLayoutPanel f = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        surface = new Krypton.Toolkit.KryptonPanel();
        save = new Krypton.Toolkit.KryptonButton();
        layout = new TableLayoutPanel();
        l1 = new Krypton.Toolkit.KryptonLabel();
        shop = new Krypton.Toolkit.KryptonTextBox();
        l2 = new Krypton.Toolkit.KryptonLabel();
        user = new Krypton.Toolkit.KryptonTextBox();
        l3 = new Krypton.Toolkit.KryptonLabel();
        theme = new Krypton.Toolkit.KryptonComboBox();
        l4 = new Krypton.Toolkit.KryptonLabel();
        f = new FlowLayoutPanel();
        choose = new Krypton.Toolkit.KryptonButton();
        delete = new Krypton.Toolkit.KryptonButton();
        logoInfo = new Krypton.Toolkit.KryptonLabel();
        ((System.ComponentModel.ISupportInitialize)surface).BeginInit();
        surface.SuspendLayout();
        layout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)theme).BeginInit();
        f.SuspendLayout();
        SuspendLayout();
        // 
        // surface
        // 
        surface.Controls.Add(save);
        surface.Controls.Add(layout);
        surface.Dock = DockStyle.Fill;
        surface.Location = new Point(18, 18);
        surface.Name = "surface";
        surface.Padding = new Padding(22);
        surface.Size = new Size(1184, 628);
        surface.TabIndex = 0;
        // 
        // save
        // 
        save.Dock = DockStyle.Top;
        save.Location = new Point(22, 272);
        save.Name = "save";
        save.Size = new Size(1140, 44);
        save.TabIndex = 0;
        save.Values.DropDownArrowColor = Color.Empty;
        save.Values.Text = "حفظ";
        save.Click += save_Click;
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(l1, 0, 0);
        layout.Controls.Add(shop, 1, 0);
        layout.Controls.Add(l2, 0, 1);
        layout.Controls.Add(user, 1, 1);
        layout.Controls.Add(l3, 0, 2);
        layout.Controls.Add(theme, 1, 2);
        layout.Controls.Add(l4, 0, 3);
        layout.Controls.Add(f, 1, 3);
        layout.Controls.Add(logoInfo, 1, 4);
        layout.Dock = DockStyle.Top;
        layout.Location = new Point(22, 22);
        layout.Name = "layout";
        layout.RowCount = 5;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        layout.Size = new Size(1140, 250);
        layout.TabIndex = 1;
        // 
        // l1
        // 
        l1.Anchor = AnchorStyles.Left;
        l1.Location = new Point(1055, 13);
        l1.Name = "l1";
        l1.Size = new Size(82, 24);
        l1.TabIndex = 0;
        l1.Values.Text = ":اسم المحل";
        // 
        // shop
        // 
        shop.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        shop.Location = new Point(3, 11);
        shop.Name = "shop";
        shop.Size = new Size(1014, 27);
        shop.TabIndex = 1;
        // 
        // l2
        // 
        l2.Anchor = AnchorStyles.Left;
        l2.Location = new Point(1030, 63);
        l2.Name = "l2";
        l2.Size = new Size(107, 24);
        l2.TabIndex = 2;
        l2.Values.Text = ":اسم المستخدم";
        // 
        // user
        // 
        user.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        user.Location = new Point(3, 61);
        user.Name = "user";
        user.Size = new Size(1014, 27);
        user.TabIndex = 3;
        // 
        // l3
        // 
        l3.Anchor = AnchorStyles.Left;
        l3.Location = new Point(1077, 113);
        l3.Name = "l3";
        l3.Size = new Size(60, 24);
        l3.TabIndex = 4;
        l3.Values.Text = ":المظهر";
        // 
        // theme
        // 
        theme.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        theme.DropDownStyle = ComboBoxStyle.DropDownList;
        theme.Items.AddRange(new object[] { "فاتح", "داكن" });
        theme.Location = new Point(3, 112);
        theme.Name = "theme";
        theme.Size = new Size(1014, 26);
        theme.TabIndex = 5;
        // 
        // l4
        // 
        l4.Anchor = AnchorStyles.Left;
        l4.Location = new Point(1081, 163);
        l4.Name = "l4";
        l4.Size = new Size(56, 24);
        l4.TabIndex = 6;
        l4.Values.Text = ":الشعار";
        // 
        // f
        // 
        f.Anchor = AnchorStyles.None;
        f.AutoSize = true;
        f.Controls.Add(choose);
        f.Controls.Add(delete);
        f.FlowDirection = FlowDirection.RightToLeft;
        f.Location = new Point(414, 159);
        f.Name = "f";
        f.Size = new Size(192, 31);
        f.TabIndex = 7;
        f.WrapContents = false;
        // 
        // choose
        // 
        choose.Location = new Point(3, 3);
        choose.Name = "choose";
        choose.Size = new Size(90, 25);
        choose.TabIndex = 0;
        choose.Values.DropDownArrowColor = Color.Empty;
        choose.Values.Text = "اختيار";
        choose.Click += choose_Click;
        // 
        // delete
        // 
        delete.Location = new Point(99, 3);
        delete.Name = "delete";
        delete.Size = new Size(90, 25);
        delete.TabIndex = 1;
        delete.Values.DropDownArrowColor = Color.Empty;
        delete.Values.Text = "حذف";
        delete.Click += delete_Click;
        // 
        // logoInfo
        // 
        logoInfo.Anchor = AnchorStyles.None;
        logoInfo.Location = new Point(452, 213);
        logoInfo.Name = "logoInfo";
        logoInfo.Size = new Size(116, 24);
        logoInfo.TabIndex = 8;
        logoInfo.Values.Text = "الشعار الافتراضي";
        // 
        // SettingsPage
        // 
        Controls.Add(surface);
        Name = "SettingsPage";
        Padding = new Padding(18);
        RightToLeft = RightToLeft.Yes;
        Size = new Size(1220, 664);
        ((System.ComponentModel.ISupportInitialize)surface).EndInit();
        surface.ResumeLayout(false);
        layout.ResumeLayout(false);
        layout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)theme).EndInit();
        f.ResumeLayout(false);
        ResumeLayout(false);
    }
}
