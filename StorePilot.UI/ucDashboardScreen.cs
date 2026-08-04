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
        public event EventHandler<DashboardActionEventArgs> ButtonClicked;

        public class DashboardActionEventArgs : EventArgs
        {
            public DashboardAction Action { get; }
            public DashboardActionEventArgs(DashboardAction action)
            {
                Action = action;
            }
        }

        public ucDashboardScreen()
        {
            InitializeComponent();
        }

        //private void _RaiseAction(DashboardAction action)
        //    => ActionRequested?.Invoke(
        //        this,
        //        new DashboardActionEventArgs(action));

        private void ucDashboardScreen_Load(object sender, EventArgs e)
        {
            Result<DataSet> result = DashboardService.GetDashboardData();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                return;
            }

            _SetCardsData(result.Data.Tables["Summary"]);

            _SetCardsStyles();

            _SetQuickActions();

            _ConfigureTablesSection();

            _ConfigureChartAppearance();

            _LoadChartData();
        }

        private void _SetCardsData(DataTable summaryTable)
        {
            lblProductsCountValue.Text = 
                summaryTable.Rows[0]["ProductsCount"].ToString();

            lblCustomersCountValue.Text =
                summaryTable.Rows[0]["CustomersCount"].ToString();

            lblSuppliersCountValue.Text =
                summaryTable.Rows[0]["SuppliersCount"].ToString();

            lblInvoicesTodayValue.Text =
                summaryTable.Rows[0]["TodayInvoices"].ToString();

            lblSalesTodayValue.Text =
                summaryTable.Rows[0]["TodaySales"].ToString();

            lblPurchasesTodayValue.Text =
                summaryTable.Rows[0]["TodayPurchases"].ToString();

            lblDebtsCountValue.Text =
                summaryTable.Rows[0]["TotalDebts"].ToString();
        }

        private void _SetCardsStyles()
        {
            
        }

        private void _SetQuickActions()
        {
            foreach (var btn in tlpQuickActions.Controls.OfType<Button>())
            {
                btn.Size = new Size(130, 40);
                btn.Padding = new Padding(0);
                btn.Margin = new Padding(0);
            }
        }

        private void _ConfigureTablesSection()
        {
            //tlpTables.BackColor = AutoPartsColors.Border;

            //pnlLowStockProducts.BackColor = AutoPartsColors.Surface;
            //pnlRecentSales.BackColor = AutoPartsColors.Surface;

            //_FillTable(
            //    ProductService.GetLowStockProducts(),
            //    ctrlDgvLowStockProducts);

            //_FillTable(
            //    SalesInvoiceService.GetRecentSales(),
            //    ctrlDgvRecentSales);
        }

        private void _FillTable(Result<DataTable> result, ccDataGridView dgv)
        {
            if (result.IsSuccess)
                dgv.DataSource = result.Data;
        }

        private void _ConfigureChartAppearance()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            var area = new ChartArea("MainArea");
            area.AxisX.Title = "الأقسام";
            area.AxisY.Title = "المنتجات";
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.IsStaggered = true;
            area.AxisX.Interval = 1;
            chart1.ChartAreas.Add(area);

            var legend = new Legend("MainLegend") { Docking = Docking.Bottom };
            chart1.Legends.Add(legend);

            var series = new Series("إجمالي المبيعات")
            {
                ChartArea = "MainArea",
                Legend = "MainLegend",
                ChartType = SeriesChartType.Column,
                XValueMember = "ProductName",
                YValueMembers = "Quantity",
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                LabelForeColor = Color.DarkBlue,
                Color = Color.FromArgb(46, 117, 182),
            };
            series["PointWidth"] = "0.6";
            chart1.Series.Add(series);
        }

        private void _LoadChartData()
        {
            var result = ProductService.GetLowStockProducts();
            if (!result.IsSuccess)
            {
                MessageBox.Show("فشل في جلب البيانات: " + result.Message);
                return;
            }

            chart1.DataSource = result.Data;
            chart1.DataBind();
        }

        //private void btnNewSale_Click(object sender, EventArgs e)
        //    => _RaiseAction(DashboardAction.NewSale);

        //private void btnNewPurchase_Click(object sender, EventArgs e)
        //    => _RaiseAction(DashboardAction.NewPurchase);

        //private void btnAddNewProduct_Click(object sender, EventArgs e)
        //    => _RaiseAction(DashboardAction.NewProduct);

        //private void btnRecordNewPayment_Click(object sender, EventArgs e)
        //    => _RaiseAction(DashboardAction.NewPayment);

        private void ctrlDgvRecentSales_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            //if (ctrlDgvRecentSales.Columns[e.ColumnIndex].Name == "InvoiceDate")
            //{
            //    if (DateTime.TryParse(
            //        e.Value?.ToString(),
            //        out DateTime date))
            //    {
            //        e.Value = date.ToString("tt   hh:mm   dd/MM/yyyy");
            //        e.FormattingApplied = true;
            //    }
            //}
        }
    }
}
