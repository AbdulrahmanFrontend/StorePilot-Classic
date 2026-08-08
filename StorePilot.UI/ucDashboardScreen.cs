using DevToolkit.BaseWinForms.Controls.CustomControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Global.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StorePilot.UI
{
    public partial class ucDashboardScreen : UserControl
    {
        public ucDashboardScreen()
        {
            InitializeComponent();
        }

        private async void ucDashboardScreen_Load(object sender, EventArgs e)
        {
            Result<DataSet> result = await DashboardService.GetDashboardData();

            _ConfigureAppearance();

            _LoadData(result);
        }

        private void _LoadData(Result<DataSet> result)
        {
            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                return;
            }

            // Load summary data

            DataTable SummaryTable = result.Data.Tables["Summary"];

            lblProductsCountValue.Text = 
                SummaryTable.Rows[0]["ProductsCount"].ToString();
            lblCustomersCountValue.Text = 
                SummaryTable.Rows[0]["CustomersCount"].ToString();
            lblSuppliersCountValue.Text =
                SummaryTable.Rows[0]["SuppliersCount"].ToString();
            lblInvoicesTodayValue.Text =
                SummaryTable.Rows[0]["TodayInvoices"].ToString();
            lblSalesTodayValue.Text =
                SummaryTable.Rows[0]["TodaySales"].ToString();
            lblPurchasesTodayValue.Text =
                SummaryTable.Rows[0]["TodayPurchases"].ToString();
            lblDebtsCountValue.Text =
                SummaryTable.Rows[0]["TotalDebts"].ToString();

            // Load chart data

            chtYearlySales.DataSource = result.Data.Tables["ChartData"].DefaultView;
            chtYearlySales.DataBind();

            // Load tables data

            ctrlDgvLowStockProducts.DataSource = 
                result.Data.Tables["LowStockProducts"].DefaultView;
            ctrlDgvRecentSales.DataSource =
                result.Data.Tables["RecentSales"].DefaultView;
        }

        private void _ConfigureAppearance()
        {
            _SetCardsStyles();
            _SetQuickActions();
            _ConfigureTablesAppearance();
            _ConfigureChartAppearance();
            _ConfigureTablesAppearance();
        }

        private void _SetCardsStyles()
        {
            
        }

        private void _SetQuickActions()
        {
            
        }

        private void _ConfigureTablesAppearance()
        {
            
        }

        private void _ConfigureChartAppearance()
        {
            chtYearlySales.Series.Clear();
            chtYearlySales.ChartAreas.Clear();
            chtYearlySales.Legends.Clear();

            var area = new ChartArea("MainArea");
            area.AxisX.Title = "الفترة";
            area.AxisY.Title = "إجمالي المبيعات";
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.IsStaggered = true;
            area.AxisX.Interval = 1;
            chtYearlySales.ChartAreas.Add(area);

            var legend = new Legend("MainLegend") { Docking = Docking.Bottom };
            chtYearlySales.Legends.Add(legend);

            var series = new Series("إجمالي المبيعات")
            {
                ChartArea = "MainArea",
                Legend = "MainLegend",
                ChartType = SeriesChartType.Column,
                XValueMember = "Period",
                YValueMembers = "TotalSales",
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                LabelForeColor = Color.DarkBlue,
                Color = Color.FromArgb(46, 117, 182),
            };
            series["PointWidth"] = "0.6";
            chtYearlySales.Series.Add(series);
        }

        private void ctrlDgvRecentSales_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (ctrlDgvRecentSales.Columns[e.ColumnIndex].Name == "InvoiceDate")
            {
                if (DateTime.TryParse(e.Value?.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy hh:mm tt");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
