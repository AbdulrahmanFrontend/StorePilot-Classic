namespace StorePilot.WinForms.Forms
{
    partial class EditNameForm
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel rootLayoutPanel;
        private Label titleLabel;
        private Label nameLabel;
        private TextBox nameTextBox;
        private FlowLayoutPanel buttonsPanel;
        private Button saveButton;
        private Button cancelButton;

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
            rootLayoutPanel = new TableLayoutPanel();
            titleLabel = new Label();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            buttonsPanel = new FlowLayoutPanel();
            cancelButton = new Button();
            saveButton = new Button();
            rootLayoutPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootLayoutPanel
            // 
            rootLayoutPanel.ColumnCount = 1;
            rootLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayoutPanel.Controls.Add(titleLabel, 0, 0);
            rootLayoutPanel.Controls.Add(nameLabel, 0, 1);
            rootLayoutPanel.Controls.Add(nameTextBox, 0, 2);
            rootLayoutPanel.Controls.Add(buttonsPanel, 0, 3);
            rootLayoutPanel.Dock = DockStyle.Fill;
            rootLayoutPanel.Location = new Point(0, 0);
            rootLayoutPanel.Name = "rootLayoutPanel";
            rootLayoutPanel.Padding = new Padding(20);
            rootLayoutPanel.RowCount = 4;
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            rootLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayoutPanel.Size = new Size(440, 230);
            rootLayoutPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            titleLabel.Location = new Point(23, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(394, 42);
            titleLabel.TabIndex = 0;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.Location = new Point(23, 62);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(394, 28);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "الاسم:";
            nameLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // nameTextBox
            // 
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            nameTextBox.Dock = DockStyle.Fill;
            nameTextBox.Font = new Font("Segoe UI", 10F);
            nameTextBox.Location = new Point(26, 94);
            nameTextBox.Margin = new Padding(0, 4, 6, 0);
            nameTextBox.MaxLength = 100;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(394, 30);
            nameTextBox.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Location = new Point(23, 133);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(0, 12, 0, 0);
            buttonsPanel.Size = new Size(394, 74);
            buttonsPanel.TabIndex = 3;
            buttonsPanel.WrapContents = false;
            // 
            // cancelButton
            // 
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 9F);
            cancelButton.Location = new Point(3, 12);
            cancelButton.Margin = new Padding(3, 0, 3, 0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 38);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "إلغاء";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Cursor = Cursors.Hand;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            saveButton.Location = new Point(106, 12);
            saveButton.Margin = new Padding(8, 0, 0, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 38);
            saveButton.TabIndex = 1;
            saveButton.Text = "حفظ";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            // 
            // EditNameForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(440, 230);
            Controls.Add(rootLayoutPanel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditNameForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تعديل";
            Load += EditNameForm_Load;
            Shown += EditNameForm_Shown;
            rootLayoutPanel.ResumeLayout(false);
            rootLayoutPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
