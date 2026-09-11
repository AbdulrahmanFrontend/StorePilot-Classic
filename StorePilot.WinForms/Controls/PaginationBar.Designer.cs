namespace StorePilot.WinForms.Controls;

partial class PaginationBar
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
        btnFirst = new Krypton.Toolkit.KryptonButton();
        btnPrev = new Krypton.Toolkit.KryptonButton();
        flow = new FlowLayoutPanel();
        cmbPageNumber = new Krypton.Toolkit.KryptonComboBox();
        btnNext = new Krypton.Toolkit.KryptonButton();
        btnLast = new Krypton.Toolkit.KryptonButton();
        cmbPageSize = new Krypton.Toolkit.KryptonComboBox();
        lblInfo = new Krypton.Toolkit.KryptonLabel();
        flow.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)cmbPageNumber).BeginInit();
        ((System.ComponentModel.ISupportInitialize)cmbPageSize).BeginInit();
        SuspendLayout();
        // 
        // btnFirst
        // 
        btnFirst.Cursor = Cursors.Hand;
        btnFirst.Location = new Point(7, 7);
        btnFirst.Name = "btnFirst";
        btnFirst.Size = new Size(90, 25);
        btnFirst.TabIndex = 0;
        btnFirst.Values.DropDownArrowColor = Color.Empty;
        btnFirst.Values.Text = "الأولى";
        btnFirst.Click += btnFirst_Click;
        // 
        // btnPrev
        // 
        btnPrev.Cursor = Cursors.Hand;
        btnPrev.Location = new Point(103, 7);
        btnPrev.Name = "btnPrev";
        btnPrev.Size = new Size(90, 25);
        btnPrev.TabIndex = 1;
        btnPrev.Values.DropDownArrowColor = Color.Empty;
        btnPrev.Values.Text = "السابق";
        btnPrev.Click += btnPrev_Click;
        // 
        // flow
        // 
        flow.Controls.Add(btnFirst);
        flow.Controls.Add(btnPrev);
        flow.Controls.Add(cmbPageNumber);
        flow.Controls.Add(btnNext);
        flow.Controls.Add(btnLast);
        flow.Controls.Add(cmbPageSize);
        flow.Controls.Add(lblInfo);
        flow.Dock = DockStyle.Fill;
        flow.FlowDirection = FlowDirection.RightToLeft;
        flow.Location = new Point(0, 0);
        flow.Name = "flow";
        flow.Padding = new Padding(4);
        flow.Size = new Size(811, 42);
        flow.TabIndex = 7;
        flow.WrapContents = false;
        // 
        // cmbPageNumber
        // 
        cmbPageNumber.Cursor = Cursors.Hand;
        cmbPageNumber.DropDownHeight = 100;
        cmbPageNumber.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPageNumber.IntegralHeight = false;
        cmbPageNumber.Location = new Point(199, 7);
        cmbPageNumber.Name = "cmbPageNumber";
        cmbPageNumber.Size = new Size(90, 26);
        cmbPageNumber.Sorted = true;
        cmbPageNumber.TabIndex = 2;
        cmbPageNumber.SelectedIndexChanged += cmbPageNumber_SelectedIndexChanged;
        // 
        // btnNext
        // 
        btnNext.Cursor = Cursors.Hand;
        btnNext.Location = new Point(295, 7);
        btnNext.Name = "btnNext";
        btnNext.Size = new Size(90, 25);
        btnNext.TabIndex = 3;
        btnNext.Values.DropDownArrowColor = Color.Empty;
        btnNext.Values.Text = "التالي";
        btnNext.Click += btnNext_Click;
        // 
        // btnLast
        // 
        btnLast.Cursor = Cursors.Hand;
        btnLast.Location = new Point(391, 7);
        btnLast.Name = "btnLast";
        btnLast.Size = new Size(90, 25);
        btnLast.TabIndex = 4;
        btnLast.Values.DropDownArrowColor = Color.Empty;
        btnLast.Values.Text = "الأخيرة";
        btnLast.Click += btnLast_Click;
        // 
        // cmbPageSize
        // 
        cmbPageSize.Cursor = Cursors.Hand;
        cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPageSize.Items.AddRange(new object[] { "50", "100", "150", "200" });
        cmbPageSize.Location = new Point(487, 7);
        cmbPageSize.Name = "cmbPageSize";
        cmbPageSize.Size = new Size(90, 26);
        cmbPageSize.TabIndex = 5;
        cmbPageSize.SelectedIndexChanged += cmbPageSize_SelectedIndexChanged;
        // 
        // lblInfo
        // 
        lblInfo.Location = new Point(580, 12);
        lblInfo.Margin = new Padding(10, 8, 0, 0);
        lblInfo.Name = "lblInfo";
        lblInfo.Size = new Size(48, 24);
        lblInfo.TabIndex = 24;
        // 
        // PaginationBar
        // 
        Controls.Add(flow);
        Name = "PaginationBar";
        RightToLeft = RightToLeft.Yes;
        Size = new Size(811, 42);
        flow.ResumeLayout(false);
        flow.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)cmbPageNumber).EndInit();
        ((System.ComponentModel.ISupportInitialize)cmbPageSize).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Krypton.Toolkit.KryptonButton btnFirst;
    private Krypton.Toolkit.KryptonButton btnPrev;
    private FlowLayoutPanel flow;
    private Krypton.Toolkit.KryptonComboBox cmbPageNumber;
    private Krypton.Toolkit.KryptonButton btnNext;
    private Krypton.Toolkit.KryptonButton btnLast;
    private Krypton.Toolkit.KryptonComboBox cmbPageSize;
    private Krypton.Toolkit.KryptonLabel lblInfo;
}
