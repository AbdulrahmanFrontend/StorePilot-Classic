using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.Core.Models;
using StorePilot.UI.Global.Classes;
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

namespace StorePilot.UI.Returns
{
    public partial class frmAddEditUpdateReturnItems : frmBase
    {
        private frmMode _Mode;

        private int _ReturnId;
        private int _SaleInvoiceId;
        private int _InvoiceId;
        private InvoiceItemViewModel _InvoiceItem;
        private BindingList<InvoiceItemViewModel> _Items;

        public delegate void DataBackEventHandler(
            object sender,
            BindingList<InvoiceItemViewModel> items);
        public event DataBackEventHandler DataBack;

        public frmAddEditUpdateReturnItems(
            int saleInvoiceId,
            BindingList<InvoiceItemViewModel> items)
        {
            InitializeComponent();

            _Mode = frmMode.Update;
            _Items = items;
            _SaleInvoiceId = saleInvoiceId;
        }

        public frmAddEditUpdateReturnItems(int id, frmMode mode = frmMode.AddNew)
        {
            InitializeComponent();

            switch (mode)
            {
                case frmMode.AddNew:
                    _Mode = frmMode.AddNew;
                    _Items = new BindingList<InvoiceItemViewModel>();
                    _SaleInvoiceId = id;
                    break;

                case frmMode.Edit:
                    _Mode = frmMode.Edit;
                    _ReturnId = id;
                    break;

                default:
                    MessageBoxManager.ShowError(
                        "حالة الشاشة غير متوقعة!",
                        Language.ar);
                    this.Close();
                    break;
            }
        }

        protected override void ApplyTheme()
        {
            this.BackColor = Theme.Border;
            this.ForeColor = Theme.Text;

            btnSaveItem.BackColor = Theme.Success;
            btnSaveItem.ForeColor = Theme.Text;

            btnCancel.BackColor = Theme.Surface;
            btnCancel.ForeColor = Theme.Text;

            btnSaveList.BackColor = Theme.Success;
            btnSaveList.ForeColor = Theme.TextSecondary;

            btnExit.BackColor = Theme.Warning;
            btnExit.ForeColor = Theme.TextSecondary;

            btnResetList.BackColor = Theme.Danger;
            btnResetList.ForeColor = Theme.TextSecondary;
        }

        private void frmAddEditUpdateReturnItems_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            var SaleInvoiceResult = SaleInvoiceService.Find(_SaleInvoiceId);

            if (!SaleInvoiceResult.IsSuccess)
            {
                MessageBoxManager.ShowError(SaleInvoiceResult.Message, Language.ar);
                this.Close();
            }

            _InvoiceId = SaleInvoiceResult.Data.Model.InvoiceID;

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

            tbQuantity.Text = "0";
            tbUnitPrice.Text = "0";
            tbTotalPrice.Text = "0";

            cbProducts.SelectedIndex = -1;

            _InvoiceItem = new InvoiceItemViewModel();
        }

        private void _FillProductsComboBox()
        {
            var result = InvoiceItemService.GetInvoiceItems(_InvoiceId);

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
            var result = SaleReturnItemService.GetSalesReturnItems(_ReturnId);

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
            => int.TryParse(value, out int result) ? result : 0;

        private decimal _GetDecimalValue(string value)
            => decimal.TryParse(value, out decimal result) ? result : 0;

        private void cbProducts_Validating(object sender, CancelEventArgs e)
        {
            int ProductID = _GetIntValue(cbProducts.SelectedValue?.ToString());
            var result = InvoiceItemService.Find(_SaleInvoiceId, ProductID);

            tbQuantity.ReadOnly = !result.IsSuccess;
            btnSaveItem.Enabled = result.IsSuccess;
            btnCancel.Enabled = result.IsSuccess;

            if (result.IsSuccess)
            {
                _InvoiceItem.ProductID = ProductID;
                tbUnitPrice.Text = result.Data.Model.UnitPrice.ToString("#,##0");
                tbQuantity.Text = result.Data.Model.Quantity.ToString("#,##0");
            }
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
            var ItemResult = InvoiceItemService.Find(
                _SaleInvoiceId, 
                _InvoiceItem.ProductID);

            if (!ItemResult.IsSuccess)
                return Result.Failure(ItemResult.Message);

            if (_Items.Count(i => i.ProductID == _InvoiceItem.ProductID) > 0)
                return Result.Failure(
                    $"هذا الصنف موجود بالفعل في الفاتورة!");

            decimal Quantity = _GetDecimalValue(tbQuantity.Text?.ToString());

            if (Quantity <= 0)
                return Result.Failure(
                    $"يجب أن تكون الكمية التي تم إرجاعها أكبر من الصفر!");

            if (Quantity > ItemResult.Data.Model.Quantity)
                return Result.Failure(
                    $"هذا الصنف الكمية المطلوبة منه أكبر من المسجلة في فاتورة البيع!");

            decimal UnitPrice = _GetDecimalValue(tbUnitPrice.Text?.ToString());

            _InvoiceItem.Quantity = Quantity;
            _InvoiceItem.UnitPrice = UnitPrice;

            var ProductResult = ProductService.Find(_InvoiceItem.ProductID);

            if (!ProductResult.IsSuccess)
                return Result.Failure(ProductResult.Message);

            _InvoiceItem.ProductName = ProductResult.Data.Model.ProductName;
            _InvoiceItem.GroupName = ProductResult.Data.GroupModel.GroupName;
            _InvoiceItem.UnitName = ProductResult.Data.UnitModel.UnitName;

            return Result.Success();
        }

        private void _EnabledButtonsList()
        {
            btnSaveList.Enabled = _Items.Count > 0;
            btnResetList.Enabled = _Items.Count > 0;
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
    }
}
