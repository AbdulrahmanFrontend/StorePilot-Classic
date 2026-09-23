using System.ComponentModel;

namespace StorePilot.WinForms.Controls;

public partial class PaginationControl : UserControl
{
    private int _currentPage = 1;
    private int _totalPages;
    private int _pageSize = 10;

    public event EventHandler? PageChanged;

    public event EventHandler? PageSizeChanged;

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public int CurrentPage
    {
        get => _currentPage;
        private set
        {
            _currentPage = value;
            UpdateState();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public int TotalPages
    {
        get => _totalPages;
        private set
        {
            _totalPages = Math.Max(0, value);
            UpdateState();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Hidden)]
    public int PageSize
    {
        get => _pageSize;
        private set
        {
            _pageSize = value;
            UpdateState();
        }
    }

    public PaginationControl()
    {
        InitializeComponent();

        pageSizeComboBox.Items.AddRange(
        [
            10,
            20,
            50
        ]);

        pageSizeComboBox.SelectedItem = 10;

        pageNumberComboBox.SelectedIndexChanged +=
            PageNumberComboBox_SelectedIndexChanged;

        pageSizeComboBox.SelectedIndexChanged +=
            PageSizeComboBox_SelectedIndexChanged;

        firstButton.Click += FirstButton_Click;
        previousButton.Click += PreviousButton_Click;
        nextButton.Click += NextButton_Click;
        lastButton.Click += LastButton_Click;

        UpdateState();
    }

    public void SetPageState(
        int currentPage,
        int totalPages,
        int pageSize)
    {
        _currentPage = Math.Max(
            1,
            currentPage);

        _totalPages = Math.Max(
            0,
            totalPages);

        _pageSize = pageSize > 0
            ? pageSize
            : 10;

        RebuildPageNumbers();
        UpdateState();
    }

    private void RebuildPageNumbers()
    {
        pageNumberComboBox.BeginUpdate();

        try
        {
            pageNumberComboBox.Items.Clear();

            for (var i = 1; i <= TotalPages; i++)
                pageNumberComboBox.Items.Add(i);

            if (TotalPages > 0)
            {
                pageNumberComboBox.SelectedItem =
                    Math.Min(
                        CurrentPage,
                        TotalPages);
            }
            else
            {
                pageNumberComboBox.SelectedIndex = -1;
            }
        }
        finally
        {
            pageNumberComboBox.EndUpdate();
        }
    }

    private void UpdateState()
    {
        var hasPages = TotalPages > 0;

        pageNumberComboBox.Enabled = hasPages;

        firstButton.Enabled =
            hasPages && CurrentPage > 1;

        previousButton.Enabled =
            hasPages && CurrentPage > 1;

        nextButton.Enabled =
            hasPages && CurrentPage < TotalPages;

        lastButton.Enabled =
            hasPages && CurrentPage < TotalPages;

        pageInfoLabel.Text = hasPages
            ? $"صفحة {CurrentPage} من {TotalPages}"
            : "لا توجد صفحات";
    }

    private void FirstButton_Click(
        object? sender,
        EventArgs e)
    {
        GoToPage(1);
    }

    private void PreviousButton_Click(
        object? sender,
        EventArgs e)
    {
        GoToPage(CurrentPage - 1);
    }

    private void NextButton_Click(
        object? sender,
        EventArgs e)
    {
        GoToPage(CurrentPage + 1);
    }

    private void LastButton_Click(
        object? sender,
        EventArgs e)
    {
        GoToPage(TotalPages);
    }

    private void PageNumberComboBox_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {
        if (pageNumberComboBox.SelectedItem is int page)
            GoToPage(page);
    }

    private void PageSizeComboBox_SelectedIndexChanged(
        object? sender,
        EventArgs e)
    {
        if (pageSizeComboBox.SelectedItem is not int pageSize)
            return;

        if (PageSize == pageSize)
            return;

        _pageSize = pageSize;
        _currentPage = 1;

        PageSizeChanged?.Invoke(
            this,
            EventArgs.Empty);

        PageChanged?.Invoke(
            this,
            EventArgs.Empty);
    }

    private void GoToPage(int page)
    {
        if (TotalPages <= 0)
            return;

        page = Math.Clamp(
            page,
            1,
            TotalPages);

        if (CurrentPage == page)
            return;

        _currentPage = page;

        pageNumberComboBox.SelectedItem = page;

        UpdateState();

        PageChanged?.Invoke(
            this,
            EventArgs.Empty);
    }
}
