namespace StorePilot.WinForms.Forms;

partial class FirstRunSetupForm
{
    private System.ComponentModel.IContainer components = null;
    private Krypton.Toolkit.KryptonPanel panel;
    private Label title;
    private Label desc;
    private Krypton.Toolkit.KryptonLabel l1;
    private Krypton.Toolkit.KryptonLabel l2;
    private Krypton.Toolkit.KryptonLabel l3;
    private Krypton.Toolkit.KryptonLabel l4;
    private Krypton.Toolkit.KryptonLabel logoInfo;
    private Krypton.Toolkit.KryptonTextBox shopName;
    private Krypton.Toolkit.KryptonTextBox userName;
    private Krypton.Toolkit.KryptonComboBox cmbTheme;
    private Krypton.Toolkit.KryptonButton choose;
    private Krypton.Toolkit.KryptonButton remove;
    private Krypton.Toolkit.KryptonButton save;
    private System.Windows.Forms.TableLayoutPanel layout;
    private System.Windows.Forms.FlowLayoutPanel lf;
    private System.Windows.Forms.Panel bottom;

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
        panel = new Krypton.Toolkit.KryptonPanel();
        layout = new TableLayoutPanel();
        l1 = new Krypton.Toolkit.KryptonLabel();
        shopName = new Krypton.Toolkit.KryptonTextBox();
        l2 = new Krypton.Toolkit.KryptonLabel();
        userName = new Krypton.Toolkit.KryptonTextBox();
        l3 = new Krypton.Toolkit.KryptonLabel();
        cmbTheme = new Krypton.Toolkit.KryptonComboBox();
        l4 = new Krypton.Toolkit.KryptonLabel();
        lf = new FlowLayoutPanel();
        choose = new Krypton.Toolkit.KryptonButton();
        remove = new Krypton.Toolkit.KryptonButton();
        logoInfo = new Krypton.Toolkit.KryptonLabel();
        desc = new Label();
        title = new Label();
        bottom = new Panel();
        save = new Krypton.Toolkit.KryptonButton();
        ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
        panel.SuspendLayout();
        layout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cmbTheme).BeginInit();
        lf.SuspendLayout();
        bottom.SuspendLayout();
        SuspendLayout();
        // 
        // panel
        // 
        panel.Controls.Add(layout);
        panel.Controls.Add(desc);
        panel.Controls.Add(title);
        panel.Controls.Add(bottom);
        panel.Dock = DockStyle.Fill;
        panel.Location = new Point(0, 0);
        panel.Name = "panel";
        panel.Padding = new Padding(32);
        panel.RightToLeft = RightToLeft.Yes;
        panel.Size = new Size(542, 430);
        panel.TabIndex = 0;
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(l1, 0, 0);
        layout.Controls.Add(shopName, 1, 0);
        layout.Controls.Add(l2, 0, 1);
        layout.Controls.Add(userName, 1, 1);
        layout.Controls.Add(l3, 0, 2);
        layout.Controls.Add(cmbTheme, 1, 2);
        layout.Controls.Add(l4, 0, 3);
        layout.Controls.Add(lf, 1, 3);
        layout.Controls.Add(logoInfo, 1, 4);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(32, 80);
        layout.Name = "layout";
        layout.RowCount = 5;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 119F));
        layout.Size = new Size(478, 270);
        layout.TabIndex = 0;
        // 
        // l1
        // 
        l1.Anchor = AnchorStyles.Left;
        l1.Location = new Point(393, 4);
        l1.Name = "l1";
        l1.Size = new Size(82, 24);
        l1.TabIndex = 0;
        l1.Values.Text = ":اسم المحل";
        // 
        // shopName
        // 
        shopName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        shopName.Location = new Point(3, 3);
        shopName.Name = "shopName";
        shopName.Size = new Size(354, 27);
        shopName.TabIndex = 1;
        // 
        // l2
        // 
        l2.Anchor = AnchorStyles.Left;
        l2.Location = new Point(368, 39);
        l2.Name = "l2";
        l2.Size = new Size(107, 24);
        l2.TabIndex = 2;
        l2.Values.Text = ":اسم المستخدم";
        // 
        // userName
        // 
        userName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        userName.Location = new Point(3, 37);
        userName.Name = "userName";
        userName.Size = new Size(354, 27);
        userName.TabIndex = 3;
        // 
        // l3
        // 
        l3.Anchor = AnchorStyles.Left;
        l3.Location = new Point(415, 74);
        l3.Name = "l3";
        l3.Size = new Size(60, 24);
        l3.TabIndex = 4;
        l3.Values.Text = ":المظهر";
        // 
        // cmbTheme
        // 
        cmbTheme.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTheme.Items.AddRange(new object[] { "فاتح", "داكن" });
        cmbTheme.Location = new Point(3, 73);
        cmbTheme.Name = "cmbTheme";
        cmbTheme.Size = new Size(354, 26);
        cmbTheme.TabIndex = 5;
        // 
        // l4
        // 
        l4.Anchor = AnchorStyles.Left;
        l4.Location = new Point(419, 110);
        l4.Name = "l4";
        l4.Size = new Size(56, 24);
        l4.TabIndex = 6;
        l4.Values.Text = ":الشعار";
        // 
        // lf
        // 
        lf.Anchor = AnchorStyles.None;
        lf.AutoSize = true;
        lf.Controls.Add(choose);
        lf.Controls.Add(remove);
        lf.FlowDirection = FlowDirection.RightToLeft;
        lf.Location = new Point(84, 106);
        lf.Name = "lf";
        lf.Size = new Size(192, 31);
        lf.TabIndex = 7;
        lf.WrapContents = false;
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
        // remove
        // 
        remove.Location = new Point(99, 3);
        remove.Name = "remove";
        remove.Size = new Size(90, 25);
        remove.TabIndex = 1;
        remove.Values.DropDownArrowColor = Color.Empty;
        remove.Values.Text = "حذف";
        remove.Click += remove_Click;
        // 
        // logoInfo
        // 
        logoInfo.Anchor = AnchorStyles.None;
        logoInfo.Location = new Point(122, 193);
        logoInfo.Name = "logoInfo";
        logoInfo.Size = new Size(116, 24);
        logoInfo.TabIndex = 8;
        logoInfo.Values.Text = "الشعار الافتراضي";
        // 
        // desc
        // 
        desc.Dock = DockStyle.Top;
        desc.Location = new Point(32, 56);
        desc.Name = "desc";
        desc.Size = new Size(478, 24);
        desc.TabIndex = 1;
        desc.Text = "أدخل البيانات الأساسية. يمكنك تعديلها لاحقاً من الإعدادات.";
        desc.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // title
        // 
        title.Dock = DockStyle.Top;
        title.Location = new Point(32, 32);
        title.Name = "title";
        title.Size = new Size(478, 24);
        title.TabIndex = 2;
        title.Text = "الإعداد الأول";
        title.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // bottom
        // 
        bottom.Controls.Add(save);
        bottom.Dock = DockStyle.Bottom;
        bottom.Location = new Point(32, 350);
        bottom.Name = "bottom";
        bottom.Size = new Size(478, 48);
        bottom.TabIndex = 3;
        // 
        // save
        // 
        save.Dock = DockStyle.Fill;
        save.Location = new Point(0, 0);
        save.Name = "save";
        save.Size = new Size(478, 48);
        save.TabIndex = 0;
        save.Values.DropDownArrowColor = Color.Empty;
        save.Values.Text = "حفظ وبدء الاستخدام";
        save.Click += save_Click;
        // 
        // FirstRunSetupForm
        // 
        AcceptButton = save;
        ClientSize = new Size(542, 430);
        Controls.Add(panel);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Far;
        MaximizeBox = false;
        MinimumSize = new Size(560, 390);
        Name = "FirstRunSetupForm";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "الإعداد الأول";
        ((System.ComponentModel.ISupportInitialize)panel).EndInit();
        panel.ResumeLayout(false);
        layout.ResumeLayout(false);
        layout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)cmbTheme).EndInit();
        lf.ResumeLayout(false);
        bottom.ResumeLayout(false);
        ResumeLayout(false);
    }
}