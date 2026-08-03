using DevToolkit.BaseWinForms.Controls.CustomControls;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Global.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            _SetCardsData();

            _SetCardsStyles();

            _SetQuickActions();

            _ConfigureTablesSection();
        }

        private void _SetCardsData()
        {
            //_SetLabelText(lblProductsCountValue, ProductService.GetCount());

            //_SetLabelText(
            //    lblCustomersCountValue,
            //    CustomerService.GetCount());

            //_SetLabelText(
            //    lblSuppliersCountValue,
            //    SupplierService.GetCount());

            //_SetLabelText(lblDebtsCountValue, CreditPaymentService.GetDebtsSum());
        }

        private void _SetLabelText(Label lbl, Result<int> result)
        {
            if (result.IsSuccess)
                lbl.Text = result.Data.ToString();
        }

        private void _SetCardsStyles()
        {
            
        }

        private void _SetQuickActions()
        {
            //foreach (var btn in tlpQuickActions.Controls.OfType<Button>())
            //{
            //    btn.Size = new Size(130, 40);
            //    btn.Padding = new Padding(0);
            //    btn.Margin = new Padding(0);
            //}
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
