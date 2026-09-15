using Krypton.Toolkit;
using StorePilot.WinForms.Theme;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StorePilot.WinForms.Dashboard;

public sealed class DashboardPage : UserControl
{
    private readonly DashboardViewModel _viewModel;

    private TableLayoutPanel _mainLayout = null!;

    private Label _salesValue = null!;
    private Label _purchasesValue = null!;
    private Label _customerDebtsValue = null!;
    private Label _supplierDebtsValue = null!;

    private Label _productsValue = null!;
    private Label _customersValue = null!;
    private Label _suppliersValue = null!;

    private Panel _chartPanel = null!;
    private Panel _activitiesPanel = null!;

    public DashboardPage()
    {
        _viewModel = CreateDemoData();

        InitializeComponent();

        BuildPage();
        LoadViewModel();

        AppTheme.Apply(this);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // DashboardPage
        // 
        AutoScroll = true;
        BackColor = Color.FromArgb(246, 247, 249);
        Name = "DashboardPage";
        Padding = new Padding(20);
        Size = new Size(1015, 602);
        ResumeLayout(false);
    }

    private void BuildPage()
    {
        _mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 2,
            RowCount = 4,
            Padding = new Padding(0),
            Margin = new Padding(0)
        };

        _mainLayout.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 50F));

        _mainLayout.ColumnStyles.Add(
            new ColumnStyle(SizeType.Percent, 50F));

        Controls.Add(_mainLayout);

        var header = CreateHeader();

        _mainLayout.Controls.Add(header, 0, 0);
        _mainLayout.SetColumnSpan(header, 2);

        var statistics = CreateStatisticsCards();

        _mainLayout.Controls.Add(statistics, 0, 1);
        _mainLayout.SetColumnSpan(statistics, 2);

        _chartPanel = (Panel)CreateChartPanel();
        _activitiesPanel = (Panel)CreateActivitiesPanel();

        _mainLayout.Controls.Add(_chartPanel, 0, 2);
        _mainLayout.Controls.Add(_activitiesPanel, 1, 2);

        var inventorySummary = CreateInventorySummary();

        _mainLayout.Controls.Add(inventorySummary, 0, 3);
        _mainLayout.SetColumnSpan(inventorySummary, 2);
    }

    private Control CreateHeader()
    {
        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            Height = 70,
            Margin = new Padding(0, 0, 0, 20)
        };

        var title = new Label
        {
            Text = "لوحة التحكم",
            AutoSize = true,
            Font = new Font("Segoe UI", 20F, FontStyle.Bold),
            Location = new Point(0, 5)
        };

        var subtitle = new Label
        {
            Text = "نظرة عامة على أداء المحل",
            AutoSize = true,
            Font = new Font("Segoe UI", 10F),
            Location = new Point(3, 42)
        };

        panel.Controls.Add(title);
        panel.Controls.Add(subtitle);

        return panel;
    }

    private Control CreateStatisticsCards()
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Height = 145,
            ColumnCount = 4,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 20)
        };

        for (int i = 0; i < 4; i++)
        {
            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 25F));
        }

        var salesCard = CreateStatisticCard(
            "مبيعات اليوم",
            "0 ج.م",
            out _salesValue);

        var purchasesCard = CreateStatisticCard(
            "مشتريات اليوم",
            "0 ج.م",
            out _purchasesValue);

        var customerDebtsCard = CreateStatisticCard(
            "ديون العملاء",
            "0 ج.م",
            out _customerDebtsValue);

        var supplierDebtsCard = CreateStatisticCard(
            "ديون الموردين",
            "0 ج.م",
            out _supplierDebtsValue);

        layout.Controls.Add(salesCard, 0, 0);
        layout.Controls.Add(purchasesCard, 1, 0);
        layout.Controls.Add(customerDebtsCard, 2, 0);
        layout.Controls.Add(supplierDebtsCard, 3, 0);

        return layout;
    }

    private Control CreateStatisticCard(
        string title,
        string value,
        out Label valueLabel)
    {
        var card = new KryptonPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(5),
            Padding = new Padding(18)
        };

        card.StateCommon.Color1 = AppTheme.Surface;
        card.StateCommon.Color2 = AppTheme.Surface;

        var titleLabel = new Label
        {
            Text = title,
            AutoSize = true,
            Dock = DockStyle.Top,
            Font = new Font("Segoe UI", 10F)
        };

        valueLabel = new Label
        {
            Text = value,
            AutoSize = true,
            Dock = DockStyle.Bottom,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold),
            Padding = new Padding(0, 20, 0, 0)
        };

        card.Controls.Add(valueLabel);
        card.Controls.Add(titleLabel);

        return card;
    }

    private Control CreateChartPanel()
    {
        var card = CreateSectionCard("المبيعات خلال الأسبوع");

        var chart = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10),
            BackColor = AppTheme.Surface
        };

        chart.Paint += Chart_Paint;

        card.Controls.Add(chart);

        return card;
    }

    private Control CreateActivitiesPanel()
    {
        var card = CreateSectionCard("آخر الأنشطة");

        var list = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            Padding = new Padding(10)
        };

        foreach (var activity in _viewModel.RecentActivities)
        {
            var item = new Panel
            {
                Width = 420,
                Height = 58,
                Margin = new Padding(0, 0, 0, 8),
                BackColor = AppTheme.Surface
            };

            var title = new Label
            {
                Text = activity.Title,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(0, 2)
            };

            var description = new Label
            {
                Text = activity.Description,
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(0, 25)
            };

            var time = new Label
            {
                Text = activity.Time,
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(340, 4)
            };

            item.Controls.Add(title);
            item.Controls.Add(description);
            item.Controls.Add(time);

            list.Controls.Add(item);
        }

        card.Controls.Add(list);

        return card;
    }

    private Control CreateInventorySummary()
    {
        var card = CreateSectionCard("ملخص البيانات");

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 1,
            Padding = new Padding(15)
        };

        for (int i = 0; i < 3; i++)
        {
            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 33.33F));
        }

        _productsValue = CreateSummaryValue("الأصناف النشطة");
        _customersValue = CreateSummaryValue("العملاء النشطون");
        _suppliersValue = CreateSummaryValue("الموردون النشطون");

        layout.Controls.Add(CreateSummaryItem(
            "الأصناف النشطة",
            _productsValue), 0, 0);

        layout.Controls.Add(CreateSummaryItem(
            "العملاء النشطون",
            _customersValue), 1, 0);

        layout.Controls.Add(CreateSummaryItem(
            "الموردون النشطون",
            _suppliersValue), 2, 0);

        card.Controls.Add(layout);

        return card;
    }

    private Label CreateSummaryValue(string text)
    {
        return new Label
        {
            Text = text,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold)
        };
    }

    private Control CreateSummaryItem(string title, Label value)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10)
        };

        var titleLabel = new Label
        {
            Text = title,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10F)
        };

        panel.Controls.Add(value);
        panel.Controls.Add(titleLabel);

        return panel;
    }

    private KryptonPanel CreateSectionCard(string title)
    {
        var card = new KryptonPanel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(5),
            Padding = new Padding(15),
            Height = 320
        };

        card.StateCommon.Color1 = AppTheme.Surface;
        card.StateCommon.Color2 = AppTheme.Surface;

        var titleLabel = new Label
        {
            Text = title,
            Dock = DockStyle.Top,
            Height = 35,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold)
        };

        card.Controls.Add(titleLabel);

        return card;
    }

    private void Chart_Paint(object? sender, PaintEventArgs e)
    {
        if (sender is not Panel panel)
            return;

        var graphics = e.Graphics;

        graphics.Clear(AppTheme.Surface);

        var points = _viewModel.SalesChart;

        if (points.Count == 0)
            return;

        var maxValue = points.Max(x => x.Value);

        if (maxValue <= 0)
            return;

        int left = 45;
        int bottom = panel.Height - 35;
        int top = 20;
        int right = panel.Width - 20;

        int chartWidth = right - left;
        int chartHeight = bottom - top;

        using var axisPen = new Pen(AppTheme.Border);

        graphics.DrawLine(
            axisPen,
            left,
            bottom,
            right,
            bottom);

        graphics.DrawLine(
            axisPen,
            left,
            top,
            left,
            bottom);

        int count = points.Count;

        for (int i = 0; i < count; i++)
        {
            var point = points[i];

            float x = left + (chartWidth / (float)(count - 1)) * i;

            float y = bottom -
                      (float)(point.Value / maxValue) * chartHeight;

            using var pointBrush = new SolidBrush(AppTheme.Accent);

            graphics.FillEllipse(
                pointBrush,
                x - 4,
                y - 4,
                8,
                8);

            using var labelBrush = new SolidBrush(AppTheme.MutedText);

            graphics.DrawString(
                point.Label,
                Font,
                labelBrush,
                x - 12,
                bottom + 8);
        }
    }

    private void LoadViewModel()
    {
        _salesValue.Text =
            $"{_viewModel.TodaySales:N0} ج.م";

        _purchasesValue.Text =
            $"{_viewModel.TodayPurchases:N0} ج.م";

        _customerDebtsValue.Text =
            $"{_viewModel.CustomerDebts:N0} ج.م";

        _supplierDebtsValue.Text =
            $"{_viewModel.SupplierDebts:N0} ج.م";

        _productsValue.Text =
            _viewModel.ActiveProducts.ToString("N0");

        _customersValue.Text =
            _viewModel.ActiveCustomers.ToString("N0");

        _suppliersValue.Text =
            _viewModel.ActiveSuppliers.ToString("N0");
    }

    private static DashboardViewModel CreateDemoData()
    {
        return new DashboardViewModel
        {
            TodaySales = 12500,
            TodayPurchases = 8200,
            CustomerDebts = 24500,
            SupplierDebts = 10800,

            ActiveProducts = 324,
            ActiveCustomers = 86,
            ActiveSuppliers = 24,

            SalesChart =
            {
                new SalesPoint { Label = "السبت", Value = 8500 },
                new SalesPoint { Label = "الأحد", Value = 11200 },
                new SalesPoint { Label = "الاثنين", Value = 9800 },
                new SalesPoint { Label = "الثلاثاء", Value = 12500 },
                new SalesPoint { Label = "الأربعاء", Value = 10700 },
                new SalesPoint { Label = "الخميس", Value = 14200 },
                new SalesPoint { Label = "الجمعة", Value = 11800 }
            },

            RecentActivities =
            {
                new RecentActivityItem
                {
                    Title = "فاتورة بيع جديدة",
                    Description = "تم تسجيل فاتورة بيع رقم #10025",
                    Time = "منذ 10 دقائق"
                },

                new RecentActivityItem
                {
                    Title = "إضافة صنف جديد",
                    Description = "تمت إضافة صنف إلى المخزن",
                    Time = "منذ 30 دقيقة"
                },

                new RecentActivityItem
                {
                    Title = "دفعة من عميل",
                    Description = "تم تسجيل دفعة مالية جديدة",
                    Time = "منذ ساعة"
                }
            }
        };
    }
}