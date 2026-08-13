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

namespace StorePilot.UI.Purchases
{
    public partial class frmAddEditUpdatePurchaseItems : frmBase
    {
        private frmMode _Mode;

        private int _InvoiceID;
        private InvoiceItemViewModel _InvoiceItem;
        private BindingList<InvoiceItemViewModel> _Items;

        public delegate void DataBackEventHandler(
            object sender,
            BindingList<InvoiceItemViewModel> items);
        public event DataBackEventHandler DataBack;

        public frmAddEditUpdatePurchaseItems()
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
            _Items = new BindingList<InvoiceItemViewModel>();
        }

        public frmAddEditUpdatePurchaseItems(BindingList<InvoiceItemViewModel> items)
        {
            InitializeComponent();

            _Mode = frmMode.Update;
            _Items = items;
        }

        public frmAddEditUpdatePurchaseItems(int invoiceId)
        {
            InitializeComponent();

            _Mode = frmMode.Edit;
            _InvoiceID = invoiceId;
        }

        protected override void ApplyTheme()
        {
            this.BackColor = Theme.Border;
            this.ForeColor = Theme.Text;

            this.btnAddNew.BackColor = Theme.TextSecondary;
            this.btnAddNew.ForeColor = Theme.Text;

            this.btnSaveItem.BackColor = Theme.Success;
            this.btnSaveItem.ForeColor = Theme.Text;

            this.btnCancel.BackColor = Theme.Surface;
            this.btnCancel.ForeColor = Theme.Text;

            this.btnSaveList.BackColor = Theme.Success;
            this.btnSaveList.ForeColor = Theme.TextSecondary;

            this.btnExit.BackColor = Theme.Warning;
            this.btnExit.ForeColor = Theme.TextSecondary;

            this.btnResetList.BackColor = Theme.Danger;
            this.btnResetList.ForeColor = Theme.TextSecondary;
        }

        private void frmAddEditUpdatePurchaseItems_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            switch (_Mode)
            {
                case frmMode.AddNew:
                    _FillProductsComboBox();
                    break;

                case frmMode.Update:
                    _FillProductsComboBox();
                    break;

                case frmMode.Edit:
                    tlpHeader.Visible = false;
                    btnSaveList.Visible = false;
                    btnResetList.Visible = false;
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
                $"{_Items.Sum(i => i.UnitPrice).ToString("#,##0")}";
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
            => int.TryParse(value, out int result) ? result : 0;

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
                tbUnitPrice.Text = result.Data.Model.PurchasePrice.ToString("#,##0");
            }

            tbQuantity.Text = "0";
            tbTotalPrice.Text = "0";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditUpdateProduct())
            {
                frm.DataBack += Frm_DataBack;
                frm.ShowDialog();
            }
        }

        private void Frm_DataBack(object sender) => _FillProductsComboBox();

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
                    $"الصنف {result.Data.Model.ProductName} غير مفعل في النظام!");

            if (_Items.Count(i => i.ProductID == _InvoiceItem.ProductID) > 1)
                return Result.Failure(
                    $"الصنف {result.Data.Model.ProductName} مكرر في الفاتورة!");

            decimal Quantity = _GetDecimalValue(tbQuantity.Text?.ToString());

            if (Quantity <= 0)
                return Result.Failure(
                    $"الصنف {result.Data.Model.ProductName} " +
                    $"الكمية المطلوبة منه أصغر من الصفر!");

            decimal UnitPrice = _GetDecimalValue(tbUnitPrice.Text?.ToString());

            if (UnitPrice <= 0)
                return Result.Failure(
                    $"الصنف {result.Data.Model.ProductName} سعر الوحدة له أصغر من " +
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
            btnExit.Enabled = _Items.Count > 0;
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
            InvoiceItemViewModel Item = _RemoveItemFromList();

            btnSaveItem.Enabled = true;
            btnCancel.Enabled = true;
            tbQuantity.ReadOnly = false;
            tbUnitPrice.ReadOnly = false;

            cbProducts.SelectedValue = Item.ProductID;
            tbQuantity.Text = Item.Quantity.ToString("#,##0");
            tbUnitPrice.Text = Item.UnitPrice.ToString("#,##0");
            tbTotalPrice.Text = Item.TotalPrice.ToString("#,##0");
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
                _GetSelectedDecimalCellValue(tbQuantity.Text?.ToString());
            decimal UnitPrice =
                _GetSelectedDecimalCellValue(tbUnitPrice.Text?.ToString());

            tbTotalPrice.Text = (Quantity * UnitPrice).ToString("#,##0");
        }

        private void ctrlCmData_CellDoubleClick(
            object sender, 
            DataGridViewCellEventArgs e)
            => _Update();
    }
}
