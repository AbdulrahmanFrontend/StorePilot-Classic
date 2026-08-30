using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Guards;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.Core.Models;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Printing;
using StorePilot.UI.Printing.PrintDocumentModels;
using StorePilot.UI.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI.Sales
{
    public partial class frmAddEditUpdateSaleItems : frmBase
    {
        private frmMode _Mode;

        private int _InvoiceID;
        private InvoiceItemViewModel _InvoiceItem;
        private BindingList<InvoiceItemViewModel> _Items;

        public delegate void DataBackEventHandler(
            object sender,
            BindingList<InvoiceItemViewModel> items);
        public event DataBackEventHandler DataBack;

        public frmAddEditUpdateSaleItems()
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
            _Items = new BindingList<InvoiceItemViewModel>();
        }

        public frmAddEditUpdateSaleItems(BindingList<InvoiceItemViewModel> items)
        {
            InitializeComponent();

            _Mode = frmMode.Update;
            _Items = items;
        }

        public frmAddEditUpdateSaleItems(int invoiceId)
        {
            InitializeComponent();
            
            _Mode = frmMode.Edit;
            _InvoiceID = invoiceId;
        }

        protected override void ApplyTheme()
        {
            this.BackColor = Theme.Border;
            this.ForeColor = Theme.Text;

            btnSaveItem.BackColor = Theme.Success;
            btnSaveItem.ForeColor = Theme.Text;

            btnCancel.BackColor = Theme.Surface;
            btnCancel.ForeColor = Theme.Text;

            btnPrint.BackColor = Theme.Success;
            btnPrint.ForeColor = Theme.Text;

            btnSaveList.BackColor = Theme.Success;
            btnSaveList.ForeColor = Theme.TextSecondary;

            btnExit.BackColor = Theme.Warning;
            btnExit.ForeColor = Theme.TextSecondary;

            btnResetList.BackColor = Theme.Danger;
            btnResetList.ForeColor = Theme.TextSecondary;
        }

        private void frmAddEditUpdateSaleItems_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            switch (_Mode)
            {
                case frmMode.AddNew:
                    this.Text = "إضافة عناصر الفاتورة";
                    _FillProductsComboBox();
                    break;

                case frmMode.Update:
                    this.Text = "تحديث بيانات عناصر الفاتورة";
                    _FillProductsComboBox();
                    break;

                case frmMode.Edit:
                    this.Text = "بيانات عناصر الفاتورة";
                    tlpHeader.Visible = false;
                    btnSaveList.Visible = false;
                    btnResetList.Visible = false;
                    btnPrint.Visible = false;
                    ctrlCmData.ContextMenuStrip = null;
                    _LoadItems();
                    break;
            }

            ctrlCmData.DataSource = _Items;
            _Calculations();
        }

        private void _SetDefaultValues()
        {
            btnSaveItem.Enabled = false;
            btnCancel.Enabled = false;

            tbQuantity.ReadOnly = true;
            tbUnitPrice.ReadOnly = true;

            tbQuantity.Text = "0";
            tbUnitPrice.Text = "0";
            tbTotalPrice.Text = "0";

            cbProducts.SelectedIndex = -1;

            _InvoiceItem = new InvoiceItemViewModel();
        }

        private void _FillProductsComboBox()
        {
            var result = ProductService.GetForSelection();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            cbProducts.DisplayMember = "ProductName";
            cbProducts.ValueMember = "ProductID";
            cbProducts.DataSource = result.Data;

            cbProducts.SelectedIndex = -1;
        }

        private void _Calculations()
        {
            lblItemsCount.Text = $"عدد عناصر الفاتورة: {_Items.Count}";
            lblTotal.Text = $"إجمالي الفاتورة: " +
                $"{_Items.Sum(i => i.TotalPrice).ToString("#,##0")}";
        }

        private void _LoadItems()
        {
            var result = InvoiceItemService.GetInvoiceItems(_InvoiceID);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            _Items = new BindingList<InvoiceItemViewModel>();

            foreach (DataRow item in result.Data.Rows)
            {
                _Items.Add(new InvoiceItemViewModel
                {
                    ProductID = _GetIntValue(item["ProductID"]?.ToString()),
                    ProductName = item["ProductName"]?.ToString(),
                    GroupName = item["GroupName"]?.ToString(),
                    UnitName = item["UnitName"]?.ToString(),
                    Quantity = _GetDecimalValue(item["Quantity"]?.ToString()),
                    UnitPrice = _GetDecimalValue(item["UnitPrice"]?.ToString()),
                });
            }
        }

        private int _GetIntValue(string value) 
            => int.TryParse(value,out int  result) ? result : 0;

        private decimal _GetDecimalValue(string value)
            => decimal.TryParse(value, out decimal result) ? result : 0;

        private void cbProducts_Validating(object sender, CancelEventArgs e)
        {
            int ProductID = _GetIntValue(cbProducts.SelectedValue?.ToString());
            var result = ProductService.Find(ProductID);

            tbQuantity.ReadOnly = !result.IsSuccess;
            tbUnitPrice.ReadOnly = !result.IsSuccess;
            btnSaveItem.Enabled = result.IsSuccess;
            btnCancel.Enabled = result.IsSuccess;

            if (result.IsSuccess)
            {
                _InvoiceItem.ProductID = ProductID;
                tbUnitPrice.Text = result.Data.Model.SalePrice.ToString("#,##0");
            }

            tbQuantity.Text = "0";
            tbTotalPrice.Text = "0";
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            Result result = IsValid();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                return;
            }

            _Items.Add(_InvoiceItem);

            _SetDefaultValues();

            _EnabledButtonsList();

            _Calculations();
        }

        private Result IsValid()
        {
            var result = ProductService.Find(_InvoiceItem.ProductID);

            if (!result.IsSuccess)
                return Result.Failure(result.Message);

            if (!result.Data.Model.Active)
                return Result.Failure(
                    $"الصنف '{result.Data.Model.ProductName}' غير مفعل في النظام!");

            if (_Items.Count(i => i.ProductID == _InvoiceItem.ProductID) > 0)
                return Result.Failure(
                    $"هذا الصنف موجود بالفعل في الفاتورة!");

            decimal Quantity = _GetDecimalValue(tbQuantity.Text?.ToString());

            if (Quantity <= 0)
                return Result.Failure(
                    $"الصنف '{result.Data.Model.ProductName}' " +
                    $"الكمية المطلوبة منه أصغر من الصفر!");

            if (Quantity > result.Data.Model.Quantity)
                return Result.Failure(
                    $"الصنف '{result.Data.Model.ProductName}' " +
                    $"الكمية المطلوبة منه أكبر من المخزون!");

            decimal UnitPrice = _GetDecimalValue(tbUnitPrice.Text?.ToString());

            if (UnitPrice <= 0)
                return Result.Failure(
                    $"الصنف '{result.Data.Model.ProductName}' سعر الوحدة له أصغر من " +
                    $"أو يساوي الصفر!");

            _InvoiceItem.ProductName = result.Data.Model.ProductName;
            _InvoiceItem.GroupName = result.Data.GroupModel.GroupName;
            _InvoiceItem.UnitName = result.Data.UnitModel.UnitName;
            _InvoiceItem.Quantity = Quantity;
            _InvoiceItem.UnitPrice = UnitPrice;

            return Result.Success();
        }

        private void _EnabledButtonsList()
        {
            btnSaveList.Enabled = _Items.Count > 0;
            btnResetList.Enabled = _Items.Count > 0;
            btnPrint.Enabled = _Items.Count > 0;
        }

        private void btnCancel_Click(object sender, EventArgs e) => _SetDefaultValues();

        private void btnResetList_Click(object sender, EventArgs e)
        {
            _Items.Clear();
            _SetDefaultValues();
            _Calculations();
            _EnabledButtonsList();
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _Items);
            this.Close();
        }

        private void tsmiUpdate_Click(object sender, EventArgs e) => _Update();

        private void _Update()
        {
            if (_Mode == frmMode.Edit)
                return;

            _InvoiceItem = _RemoveItemFromList();

            btnSaveItem.Enabled = true;
            btnCancel.Enabled = true;
            tbQuantity.ReadOnly = false;
            tbUnitPrice.ReadOnly = false;

            cbProducts.SelectedValue = _InvoiceItem.ProductID;
            tbQuantity.Text = _InvoiceItem.Quantity.ToString("#,##0");
            tbUnitPrice.Text = _InvoiceItem.UnitPrice.ToString("#,##0");
            tbTotalPrice.Text = _InvoiceItem.TotalPrice.ToString("#,##0");
        }

        private InvoiceItemViewModel _RemoveItemFromList()
        {
            int Index = ctrlCmData.CurrentRow.Cells["ProductID"].RowIndex;

            InvoiceItemViewModel InvoiceItem = new InvoiceItemViewModel
            {
                ProductID = _GetSelectedIntCellValue("ProductID"),
                ProductName = ctrlCmData.GetSelectedRow("ProductName")?.ToString(),
                GroupName = ctrlCmData.GetSelectedRow("GroupName")?.ToString(),
                UnitName = ctrlCmData.GetSelectedRow("UnitName")?.ToString(),
                Quantity = _GetSelectedDecimalCellValue("Quantity"),
                UnitPrice = _GetSelectedDecimalCellValue("UnitPrice"),
            };

            _Items.RemoveAt(Index);

            _Calculations();

            _EnabledButtonsList();

            return InvoiceItem;
        }

        private decimal _GetSelectedDecimalCellValue(string columnName)
            => _GetDecimalValue(ctrlCmData.GetSelectedRow(columnName)?.ToString());

        private int _GetSelectedIntCellValue(string columnName)
            => _GetIntValue(ctrlCmData.GetSelectedRow(columnName)?.ToString());

        private void tsmiDelete_Click(object sender, EventArgs e)
            => _RemoveItemFromList();

        private void QuantitAndUnitPrice_TextChanged(object sender, EventArgs e)
        {
            decimal Quantity =
                _GetDecimalValue(tbQuantity.Text?.ToString());
            decimal UnitPrice =
                _GetDecimalValue(tbUnitPrice.Text?.ToString());

            tbTotalPrice.Text = (Quantity * UnitPrice).ToString("#,##0");
        }

        private void ctrlCmData_CellDoubleClick(
            object sender, 
            DataGridViewCellEventArgs e)
            => _Update();

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (_Items.Count > 0)
                this.DataBack?.Invoke(this, _Items);
        }

        // -----------------------------------------------------------------
        // Printing — "فاتورة تسعير" (price quote)
        //
        // This is a quick, unofficial pricing print of whatever items are
        // currently in the grid, before the sale is actually saved — so it
        // has no InvoiceID/SaleInvoiceID reference number yet, and the date
        // shown is "now" rather than a stored invoice date.
        // Reuses the shared DevToolkit.Printing engine already used for the
        // real sales/purchase invoices, so the look & item columns match.
        // -----------------------------------------------------------------

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_Items.Count == 0)
            {
                MessageBoxManager.ShowError("لا توجد عناصر لطباعتها!", Language.ar);
                return;
            }

            TablePrintDocument document = _BuildPriceQuoteDocument();
            PrintPreviewHelper.Show(document, "معاينة فاتورة تسعير");
        }

        private TablePrintDocument _BuildPriceQuoteDocument()
        {
            var model = new PrintDocumentModel
            {
                ShopName = "نظام إدارة محل أدوات السباكة", // TODO: point this at wherever the shop name is actually configured
                DocumentTitle = "فاتورة تسعير",

                HeaderInfoLines = new List<(string, string)>
                {
                    ("التاريخ", DateTime.Now.ToString("yyyy/MM/dd  hh:mm tt")),
                },

                Columns = new List<PrintColumn>
                {
                    new PrintColumn { Header = "المجموعة",   WidthPercent = 16, ValueSelector = o => ((InvoiceItemViewModel)o).GroupName },
                    new PrintColumn { Header = "الوحدة",     WidthPercent = 10, ValueSelector = o => ((InvoiceItemViewModel)o).UnitName },
                    new PrintColumn { Header = "الصنف",      WidthPercent = 30, ValueSelector = o => ((InvoiceItemViewModel)o).ProductName },
                    new PrintColumn { Header = "الكمية",     WidthPercent = 12, ValueSelector = o => ((InvoiceItemViewModel)o).Quantity.ToString("0.##") },
                    new PrintColumn { Header = "سعر الوحدة", WidthPercent = 16, ValueSelector = o => ((InvoiceItemViewModel)o).UnitPrice.ToString("N2") },
                    new PrintColumn { Header = "الإجمالي",   WidthPercent = 16, ValueSelector = o => ((InvoiceItemViewModel)o).TotalPrice.ToString("N2") },
                },
                Rows = _Items.Cast<object>().ToList(),

                SummaryLines = new List<(string, string)>
                {
                    ("إجمالي التسعير", _Items.Sum(i => i.TotalPrice).ToString("N2"))
                },

                FooterNote = "هذا العرض غير مُلزم وقابل للتغيير عند تحويله لفاتورة رسمية"
            };

            return new TablePrintDocument(model);
        }
    }
}
