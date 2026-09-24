using System.Drawing;
using System.Windows.Forms;

namespace StorePilot.WinForms.Pages
{
    partial class SettingsPage
    {
        private TableLayoutPanel rootLayout;
        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;

        private TableLayoutPanel contentLayout;

        private GroupBox generalSettingsGroup;
        private TableLayoutPanel generalLayout;

        private Label storeNameLabel;
        private TextBox storeNameTextBox;

        private Label userNameLabel;
        private TextBox userNameTextBox;

        private Label themeLabel;
        private ComboBox themeComboBox;

        private Button saveSettingsButton;

        private GroupBox logoGroup;
        private TableLayoutPanel logoLayout;
        private PictureBox logoPictureBox;
        private Label logoFileNameLabel;

        private GroupBox backupGroup;
        private TableLayoutPanel backupLayout;
        private Label backupDescriptionLabel;
        private Label backupDirectoryLabel;
        private Button backupButton;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rootLayout = new TableLayoutPanel();
            headerPanel = new Panel();
            subtitleLabel = new Label();
            titleLabel = new Label();
            contentLayout = new TableLayoutPanel();
            generalSettingsGroup = new GroupBox();
            generalLayout = new TableLayoutPanel();
            storeNameLabel = new Label();
            storeNameTextBox = new TextBox();
            userNameLabel = new Label();
            userNameTextBox = new TextBox();
            themeLabel = new Label();
            themeComboBox = new ComboBox();
            saveSettingsButton = new Button();
            logoGroup = new GroupBox();
            logoLayout = new TableLayoutPanel();
            logoPictureBox = new PictureBox();
            logoFileNameLabel = new Label();
            tlpLogoButtons = new TableLayoutPanel();
            saveLogoButton = new Button();
            removeLogoButton = new Button();
            chooseLogoButton = new Button();
            backupGroup = new GroupBox();
            backupLayout = new TableLayoutPanel();
            backupDescriptionLabel = new Label();
            backupDirectoryLabel = new Label();
            backupButton = new Button();
            rootLayout.SuspendLayout();
            headerPanel.SuspendLayout();
            contentLayout.SuspendLayout();
            generalSettingsGroup.SuspendLayout();
            generalLayout.SuspendLayout();
            logoGroup.SuspendLayout();
            logoLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            tlpLogoButtons.SuspendLayout();
            backupGroup.SuspendLayout();
            backupLayout.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Controls.Add(headerPanel, 0, 0);
            rootLayout.Controls.Add(contentLayout, 0, 1);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(23, 27);
            rootLayout.Margin = new Padding(3, 4, 3, 4);
            rootLayout.Name = "rootLayout";
            rootLayout.RowCount = 2;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.Size = new Size(1251, 734);
            rootLayout.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(subtitleLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Fill;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(0, 0, 0, 20);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1251, 80);
            headerPanel.TabIndex = 0;
            // 
            // subtitleLabel
            // 
            subtitleLabel.Dock = DockStyle.Bottom;
            subtitleLabel.Font = new Font("Segoe UI", 9.5F);
            subtitleLabel.Location = new Point(0, 40);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(1251, 40);
            subtitleLabel.TabIndex = 0;
            subtitleLabel.Text = "إدارة بيانات المحل والشعار والنسخ الاحتياطية.";
            subtitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1251, 41);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "الإعدادات";
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            contentLayout.Controls.Add(generalSettingsGroup, 0, 0);
            contentLayout.Controls.Add(logoGroup, 1, 0);
            contentLayout.Controls.Add(backupGroup, 0, 1);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(3, 104);
            contentLayout.Margin = new Padding(3, 4, 3, 4);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 2;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            contentLayout.Size = new Size(1245, 626);
            contentLayout.TabIndex = 1;
            // 
            // generalSettingsGroup
            // 
            generalSettingsGroup.Controls.Add(generalLayout);
            generalSettingsGroup.Dock = DockStyle.Fill;
            generalSettingsGroup.Location = new Point(509, 0);
            generalSettingsGroup.Margin = new Padding(0, 0, 11, 13);
            generalSettingsGroup.Name = "generalSettingsGroup";
            generalSettingsGroup.Padding = new Padding(17, 20, 17, 20);
            generalSettingsGroup.Size = new Size(736, 331);
            generalSettingsGroup.TabIndex = 0;
            generalSettingsGroup.TabStop = false;
            generalSettingsGroup.Text = "البيانات العامة:";
            // 
            // generalLayout
            // 
            generalLayout.ColumnCount = 2;
            generalLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.0968666F));
            generalLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.90314F));
            generalLayout.Controls.Add(storeNameLabel, 0, 0);
            generalLayout.Controls.Add(storeNameTextBox, 1, 0);
            generalLayout.Controls.Add(userNameLabel, 0, 1);
            generalLayout.Controls.Add(userNameTextBox, 1, 1);
            generalLayout.Controls.Add(themeLabel, 0, 2);
            generalLayout.Controls.Add(themeComboBox, 1, 2);
            generalLayout.Controls.Add(saveSettingsButton, 1, 3);
            generalLayout.Dock = DockStyle.Fill;
            generalLayout.Location = new Point(17, 40);
            generalLayout.Margin = new Padding(3, 4, 3, 4);
            generalLayout.Name = "generalLayout";
            generalLayout.RowCount = 4;
            generalLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            generalLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            generalLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            generalLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            generalLayout.Size = new Size(702, 271);
            generalLayout.TabIndex = 0;
            // 
            // storeNameLabel
            // 
            storeNameLabel.Dock = DockStyle.Fill;
            storeNameLabel.Location = new Point(592, 0);
            storeNameLabel.Name = "storeNameLabel";
            storeNameLabel.Size = new Size(107, 67);
            storeNameLabel.TabIndex = 0;
            storeNameLabel.Text = "اسم المحل:";
            storeNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // storeNameTextBox
            // 
            storeNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            storeNameTextBox.Location = new Point(6, 20);
            storeNameTextBox.Margin = new Padding(6, 11, 6, 11);
            storeNameTextBox.MaxLength = 50;
            storeNameTextBox.Name = "storeNameTextBox";
            storeNameTextBox.RightToLeft = RightToLeft.Yes;
            storeNameTextBox.Size = new Size(577, 27);
            storeNameTextBox.TabIndex = 0;
            // 
            // userNameLabel
            // 
            userNameLabel.Dock = DockStyle.Fill;
            userNameLabel.Location = new Point(592, 67);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(107, 67);
            userNameLabel.TabIndex = 2;
            userNameLabel.Text = "اسم المستخدم:";
            userNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userNameTextBox.Location = new Point(6, 87);
            userNameTextBox.Margin = new Padding(6, 11, 6, 11);
            userNameTextBox.MaxLength = 20;
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.RightToLeft = RightToLeft.Yes;
            userNameTextBox.Size = new Size(577, 27);
            userNameTextBox.TabIndex = 1;
            // 
            // themeLabel
            // 
            themeLabel.Dock = DockStyle.Fill;
            themeLabel.Location = new Point(592, 134);
            themeLabel.Name = "themeLabel";
            themeLabel.Size = new Size(107, 67);
            themeLabel.TabIndex = 4;
            themeLabel.Text = "المظهر:";
            themeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // themeComboBox
            // 
            themeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            themeComboBox.Cursor = Cursors.Hand;
            themeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            themeComboBox.FormattingEnabled = true;
            themeComboBox.Items.AddRange(new object[] { "فاتح", "داكن" });
            themeComboBox.Location = new Point(6, 153);
            themeComboBox.Margin = new Padding(6, 11, 6, 11);
            themeComboBox.Name = "themeComboBox";
            themeComboBox.Size = new Size(577, 28);
            themeComboBox.TabIndex = 2;
            // 
            // saveSettingsButton
            // 
            saveSettingsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveSettingsButton.AutoSize = true;
            saveSettingsButton.Cursor = Cursors.Hand;
            saveSettingsButton.FlatStyle = FlatStyle.Flat;
            saveSettingsButton.Location = new Point(6, 214);
            saveSettingsButton.Margin = new Padding(6, 13, 6, 7);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Padding = new Padding(17, 7, 17, 7);
            saveSettingsButton.Size = new Size(149, 46);
            saveSettingsButton.TabIndex = 3;
            saveSettingsButton.Text = "حفظ الإعدادات";
            saveSettingsButton.UseVisualStyleBackColor = false;
            saveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // logoGroup
            // 
            logoGroup.Controls.Add(logoLayout);
            logoGroup.Dock = DockStyle.Fill;
            logoGroup.Location = new Point(0, 0);
            logoGroup.Margin = new Padding(11, 0, 0, 13);
            logoGroup.Name = "logoGroup";
            logoGroup.Padding = new Padding(17, 20, 17, 20);
            logoGroup.Size = new Size(487, 331);
            logoGroup.TabIndex = 1;
            logoGroup.TabStop = false;
            logoGroup.Text = "شعار المحل:";
            // 
            // logoLayout
            // 
            logoLayout.ColumnCount = 1;
            logoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            logoLayout.Controls.Add(logoPictureBox, 0, 0);
            logoLayout.Controls.Add(logoFileNameLabel, 0, 1);
            logoLayout.Controls.Add(tlpLogoButtons, 0, 2);
            logoLayout.Dock = DockStyle.Fill;
            logoLayout.Location = new Point(17, 40);
            logoLayout.Margin = new Padding(3, 4, 3, 4);
            logoLayout.Name = "logoLayout";
            logoLayout.RowCount = 3;
            logoLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            logoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            logoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            logoLayout.Size = new Size(453, 271);
            logoLayout.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackColor = Color.White;
            logoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Location = new Point(6, 7);
            logoPictureBox.Margin = new Padding(6, 7, 6, 7);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(441, 157);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // logoFileNameLabel
            // 
            logoFileNameLabel.AutoEllipsis = true;
            logoFileNameLabel.Dock = DockStyle.Fill;
            logoFileNameLabel.Location = new Point(3, 171);
            logoFileNameLabel.Name = "logoFileNameLabel";
            logoFileNameLabel.Size = new Size(447, 50);
            logoFileNameLabel.TabIndex = 1;
            logoFileNameLabel.Text = "لم يتم اختيار شعار.";
            logoFileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpLogoButtons
            // 
            tlpLogoButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpLogoButtons.ColumnCount = 3;
            tlpLogoButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpLogoButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpLogoButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpLogoButtons.Controls.Add(saveLogoButton, 2, 0);
            tlpLogoButtons.Controls.Add(removeLogoButton, 1, 0);
            tlpLogoButtons.Controls.Add(chooseLogoButton, 0, 0);
            tlpLogoButtons.Location = new Point(3, 224);
            tlpLogoButtons.Name = "tlpLogoButtons";
            tlpLogoButtons.RowCount = 1;
            tlpLogoButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpLogoButtons.Size = new Size(447, 44);
            tlpLogoButtons.TabIndex = 6;
            // 
            // saveLogoButton
            // 
            saveLogoButton.Cursor = Cursors.Hand;
            saveLogoButton.Dock = DockStyle.Fill;
            saveLogoButton.FlatStyle = FlatStyle.Flat;
            saveLogoButton.Location = new Point(6, 7);
            saveLogoButton.Margin = new Padding(6, 7, 6, 7);
            saveLogoButton.Name = "saveLogoButton";
            saveLogoButton.Size = new Size(137, 30);
            saveLogoButton.TabIndex = 6;
            saveLogoButton.Text = "حفظ";
            saveLogoButton.UseVisualStyleBackColor = false;
            saveLogoButton.Click += saveLogoButton_Click;
            // 
            // removeLogoButton
            // 
            removeLogoButton.Cursor = Cursors.Hand;
            removeLogoButton.Dock = DockStyle.Fill;
            removeLogoButton.FlatStyle = FlatStyle.Flat;
            removeLogoButton.Location = new Point(155, 7);
            removeLogoButton.Margin = new Padding(6, 7, 6, 7);
            removeLogoButton.Name = "removeLogoButton";
            removeLogoButton.Size = new Size(137, 30);
            removeLogoButton.TabIndex = 5;
            removeLogoButton.Text = "إزالة";
            removeLogoButton.UseVisualStyleBackColor = false;
            removeLogoButton.Click += removeLogoButton_Click;
            // 
            // chooseLogoButton
            // 
            chooseLogoButton.Cursor = Cursors.Hand;
            chooseLogoButton.Dock = DockStyle.Fill;
            chooseLogoButton.FlatStyle = FlatStyle.Flat;
            chooseLogoButton.Location = new Point(304, 7);
            chooseLogoButton.Margin = new Padding(6, 7, 6, 7);
            chooseLogoButton.Name = "chooseLogoButton";
            chooseLogoButton.Size = new Size(137, 30);
            chooseLogoButton.TabIndex = 4;
            chooseLogoButton.Text = "اختيار";
            chooseLogoButton.UseVisualStyleBackColor = false;
            chooseLogoButton.Click += ChooseLogoButton_Click;
            // 
            // backupGroup
            // 
            backupGroup.Controls.Add(backupLayout);
            backupGroup.Dock = DockStyle.Fill;
            backupGroup.Location = new Point(509, 357);
            backupGroup.Margin = new Padding(0, 13, 11, 0);
            backupGroup.Name = "backupGroup";
            backupGroup.Padding = new Padding(17, 20, 17, 20);
            backupGroup.Size = new Size(736, 269);
            backupGroup.TabIndex = 2;
            backupGroup.TabStop = false;
            backupGroup.Text = "النسخ الاحتياطي:";
            // 
            // backupLayout
            // 
            backupLayout.ColumnCount = 1;
            backupLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            backupLayout.Controls.Add(backupDescriptionLabel, 0, 0);
            backupLayout.Controls.Add(backupDirectoryLabel, 0, 1);
            backupLayout.Controls.Add(backupButton, 0, 2);
            backupLayout.Dock = DockStyle.Fill;
            backupLayout.Location = new Point(17, 40);
            backupLayout.Margin = new Padding(3, 4, 3, 4);
            backupLayout.Name = "backupLayout";
            backupLayout.RowCount = 3;
            backupLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            backupLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            backupLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            backupLayout.Size = new Size(702, 209);
            backupLayout.TabIndex = 0;
            // 
            // backupDescriptionLabel
            // 
            backupDescriptionLabel.Dock = DockStyle.Fill;
            backupDescriptionLabel.Location = new Point(3, 0);
            backupDescriptionLabel.Name = "backupDescriptionLabel";
            backupDescriptionLabel.Size = new Size(696, 60);
            backupDescriptionLabel.TabIndex = 0;
            backupDescriptionLabel.Text = "يتم نسخ ملف قاعدة البيانات الحالي إلى المكان الذي تختاره.";
            backupDescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // backupDirectoryLabel
            // 
            backupDirectoryLabel.AutoEllipsis = true;
            backupDirectoryLabel.Dock = DockStyle.Fill;
            backupDirectoryLabel.Location = new Point(3, 60);
            backupDirectoryLabel.Name = "backupDirectoryLabel";
            backupDirectoryLabel.Size = new Size(696, 82);
            backupDirectoryLabel.TabIndex = 1;
            backupDirectoryLabel.Text = "سيتم استخدام مجلد النسخ الاحتياطية الافتراضي.";
            backupDirectoryLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // backupButton
            // 
            backupButton.Anchor = AnchorStyles.Left;
            backupButton.AutoSize = true;
            backupButton.Cursor = Cursors.Hand;
            backupButton.FlatStyle = FlatStyle.Flat;
            backupButton.Location = new Point(516, 147);
            backupButton.Margin = new Padding(3, 4, 3, 4);
            backupButton.Name = "backupButton";
            backupButton.Padding = new Padding(17, 7, 17, 7);
            backupButton.Size = new Size(183, 56);
            backupButton.TabIndex = 7;
            backupButton.Text = "إنشاء نسخة احتياطية";
            backupButton.UseVisualStyleBackColor = false;
            backupButton.Click += BackupButton_Click;
            // 
            // SettingsPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(rootLayout);
            Margin = new Padding(0);
            Name = "SettingsPage";
            Padding = new Padding(23, 27, 23, 27);
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1297, 788);
            Load += SettingsPage_Load;
            rootLayout.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            generalSettingsGroup.ResumeLayout(false);
            generalLayout.ResumeLayout(false);
            generalLayout.PerformLayout();
            logoGroup.ResumeLayout(false);
            logoLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            tlpLogoButtons.ResumeLayout(false);
            backupGroup.ResumeLayout(false);
            backupLayout.ResumeLayout(false);
            backupLayout.PerformLayout();
            ResumeLayout(false);
        }

        private TableLayoutPanel tlpLogoButtons;
        private Button saveLogoButton;
        private Button removeLogoButton;
        private Button chooseLogoButton;
    }
}