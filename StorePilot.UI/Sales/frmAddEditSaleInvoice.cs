using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Guards;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.Core.Enums;
using StorePilot.Core.Models;
using StorePilot.UI.Customers;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Payments;
using StorePilot.UI.Properties;
using StorePilot.UI.Returns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI.Sales
{
    public partial class frmAddEditSaleInvoice : frmBase
    {
        private frmMode _Mode;

        private int _Id;
        private SaleInvoiceModel _Model;
        private SaleInvoiceService _Service;
        private BindingList<InvoiceItemViewModel> _InvoiceItems = 
            new BindingList<InvoiceItemViewModel>();

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        public frmAddEditSaleInvoice()
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
        }

        public frmAddEditSaleInvoice(int id)
        {
            InitializeComponent();

            _Mode = frmMode.Edit;
            _Id = id;
        }

        protected override void ApplyTheme()
        {
            lblTitle.BackColor = Theme.Background;
            lblTitle.ForeColor = Theme.Text;

            tlpContainer.BackColor = Theme.Border;
            tlpContainer.ForeColor = Theme.TextSecondary;

            foreach (var item in tlpContainer.Controls.OfType<TableLayoutPanel>())
                item.ForeColor = Theme.TextSecondary;

            foreach (var i in tlpUp.Controls.OfType<TableLayoutPanel>())
                i.BackColor = Theme.Background;


            flpFooter.BackColor = Theme.Background;
            flpFooter.ForeColor = Theme.Text;
        }

        private void frmAddEditSaleInvoice_Load(object sender, EventArgs e)
        {
            _SetDefaultAppearance();
            _LoadCustomers();

            switch (_Mode)
            {
                case frmMode.AddNew:
                    _ConfigureForAddNewInvoice();
                    break;

                case frmMode.Edit:
                    _ConfigureForEditInvoice();
                    break;
            }

            this.Text = lblTitle.Text;
        }

        private void _ConfigureForAddNewInvoice()
        {
            _Service = new SaleInvoiceService();

            lblTitle.Text = "إضافة بيانات فاتورة بيع جديدة";

            btnSavePrint.Text = "حفظ";
            btnSavePrint.Image = Resources.Save_32;
            btnSavePrint.Enabled = false;

            btnCancel.Visible = false;
            btnReturns.Visible = false;
            btnViewPayments.Visible = false;

            btnInvoiceItems.Text = "إضافة عناصر الفاتورة";

            cbStatuses.SelectedIndex = 0;

            using (var frm = new frmAddEditUpdateSaleItems())
            {
                frm.DataBack += Frm_DataBackInvoiceItems;
                frm.ShowDialog();
            }
        }

        private void _ConfigureForEditInvoice()
        {
            lblTitle.Text = "بيانات الفاتورة";

            btnSavePrint.Text = "طباعة";
            btnSavePrint.Image = Resources.print;

            btnInvoiceItems.Text = "عرض عناصر الفاتورة";

            _LoadData();

            _ConfigureForStatus();
        }

        private void _ConfigureForStatus()
        {
            Result<bool> result;

            if (_Model.InvoiceStatus == InvoiceStatus.Deferred.ToArabic())
            {
                if (!_Model.Cancelled)
                    btnViewPayments.Text = "إضافة دفعة جديدة";
                else
                    btnViewPayments.Enabled = false;
            }
            else
            {
                result = InvoiceService.HasPayments(_Model.InvoiceID);
                btnViewPayments.Text = "عرض المدفوعات";
                if (!result.IsSuccess)
                    btnViewPayments.Enabled = false;
                else
                    btnViewPayments.Enabled = true;
            }
            if (_Model.Cancelled)
            {
                btnCancel.Enabled = false;
                btnSavePrint.Enabled = false;
            }

            result = SaleInvoiceService.HasReturns(_Model.SaleInvoiceID);

            if (!result.IsSuccess)
            {
                btnReturns.Text = "إضافة مرتجع";
                if (_Model.Cancelled)
                    btnReturns.Enabled = false;
                else
                    btnReturns.Enabled = true;
            }
            else
            {
                btnReturns.Text = "عرض المرتجعات";
                if (_Model.Cancelled)
                    btnReturns.Enabled = true;
                else
                    btnReturns.Enabled = false;
            }
        }

        private void Frm_DataBackInvoiceItems(
            object sender, 
            BindingList<InvoiceItemViewModel> items)
        {
            if (!Guard.HasItems(items))
                return;

            btnInvoiceItems.Text = "تحديث عناصر الفاتورة";
            _InvoiceItems = items;

            _EnabledFields();

            btnAddNew.Visible = true;
            btnSavePrint.Enabled = true;

            _SetAmounts();
        }

        private void _SetAmounts()
        {
            switch (cbStatuses.Text.ToInvoiceStatus())
            {
                case InvoiceStatus.Paid:
                    tbPaidAmount.Text = _InvoiceItems
                        .Sum(i => i.TotalPrice)
                        .ToString("#,##0");
                    tbRemainingAmount.Text = "0";
                    tbTotalAmount.Text = tbPaidAmount.Text;
                    break;

                case InvoiceStatus.Deferred:
                    tbRemainingAmount.Text = _InvoiceItems
                        .Sum(i => i.TotalPrice)
                        .ToString("#,##0");
                    tbPaidAmount.Text = "0";
                    tbTotalAmount.Text = tbRemainingAmount.Text;
                    break;
            }
        }

        private void _LoadCustomers()
        {
            var result = CustomerService.GetForSelection();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            cbCustomers.DisplayMember = "Name";
            cbCustomers.ValueMember = "CustomerID";
            cbCustomers.DataSource = result.Data;

            cbCustomers.SelectedIndex = -1;
        }

        private void _SetDefaultAppearance()
        {
            _EnabledFields();

            dtpInvoiceDate.Value = DateTime.Now;
            cbStatuses.SelectedIndex = -1;
            tbPaidAmount.Text = "0";
            tbRemainingAmount.Text = "0";
            tbTotalAmount.Text = "0";

            btnAddNew.Visible = false;
        }

        private void _EnabledFields()
        {
            dtpInvoiceDate.Enabled = ((_Mode == frmMode.AddNew) && _InvoiceItems.Any());
            cbCustomers.Enabled = ((_Mode == frmMode.AddNew) && _InvoiceItems.Any());
            cbStatuses.Enabled = ((_Mode == frmMode.AddNew) && _InvoiceItems.Any());
            tbNotes.ReadOnly = !((_Mode == frmMode.AddNew) && _InvoiceItems.Any());
        }

        private void _LoadData()
        {
            var result = SaleInvoiceService.Find(_Id);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            _Service = result.Data;
            _Model = _Service.Model;

            dtpInvoiceDate.Value = _Model.InvoiceDate;
            if (_Model.CustomerID.HasValue)
                cbCustomers.SelectedValue = _Model.CustomerID.Value;
            cbStatuses.Text = _Model.InvoiceStatus;
            tbPaidAmount.Text = _Model.PaidAmount.ToString("#,##0");
            tbRemainingAmount.Text = _Model.RemainingAmount.ToString("#,##0");
            tbTotalAmount.Text = _Model.TotalAmount.ToString("#,##0");
            tbNotes.Text = _Model.Notes;
        }

        private void cbStatuses_SelectedIndexChanged(object sender, EventArgs e)
            => _SetAmounts();

        private async void btnSavePrint_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case frmMode.AddNew:
                    await _AddNew();
                    break;
            }
        }

        private async Task _AddNew()
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ تلك الفاتورة؟",
                Language.ar);

            if (Confirm != DialogResult.Yes)
                return;

            _Service.Model.InvoiceDate = dtpInvoiceDate.Value;
            _Service.Model.InvoiceStatus = cbStatuses.Text;
            _Service.Model.PaidAmount = _GetDecimalVal(tbPaidAmount.Text?.ToString());
            _Service.Model.TotalAmount = 
                _GetDecimalVal(tbTotalAmount.Text?.ToString());

            int? CustomerID = _GetIntVal(cbCustomers.SelectedValue?.ToString());

            _Service.Model.CustomerID = CustomerID == 0 ? null : CustomerID;
            _Service.Model.Notes = tbNotes.Text;

            List<InvoiceItemModel> list = new List<InvoiceItemModel>();
            foreach(var item in _InvoiceItems)
            {
                list.Add(new InvoiceItemModel
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                });
            }

            _Service.SetItems(list);

            var result = await Task.Run(() => _Service.Save());

            if (result.IsSuccess)
            {
                MessageBoxManager.ShowSuccess(result.Message, Language.ar);
                this.DataBack?.Invoke(this);
                this.Close();
            }
            else
                MessageBoxManager.ShowError(result.Message, Language.ar);
        }

        private int _GetIntVal(string key) => int.TryParse(key, out var val) ? val : 0;

        private decimal _GetDecimalVal(string key) 
            => decimal.TryParse(key, out var val) ? val : 0;

        private void btnInvoiceItems_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case frmMode.AddNew:
                    if (!_InvoiceItems.Any())
                    {
                        using (var frmAdd = new frmAddEditUpdateSaleItems())
                        {
                            frmAdd.DataBack += Frm_DataBackInvoiceItems;
                            frmAdd.ShowDialog();
                        }
                    }
                    else
                    {
                        using (var frmUpdate =
                            new frmAddEditUpdateSaleItems(_InvoiceItems))
                        {
                            frmUpdate.DataBack += Frm_DataBackInvoiceItems;
                            frmUpdate.ShowDialog();
                        }
                    }
                    break;

                case frmMode.Edit:
                    int InvoiceID = _Service.Model.InvoiceID;

                    using (var frmEdit = new frmAddEditUpdateSaleItems(InvoiceID))
                        frmEdit.ShowDialog();
                    break;
            }
        }

        private void btnViewPayments_Click(object sender, EventArgs e)
        {
            using (var frm = new frmPaymentsScreen(_Service.Model.InvoiceID))
            {
                frm.DataBack += Frm_UpdateTotalAmount;
                frm.ShowDialog();
            }
        }

        private void Frm_UpdateTotalAmount(object sender)
        {
            var result = SaleInvoiceService.Find(_Id);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                return;
            }

            _Service = result.Data;
            _Model = _Service.Model;

            cbStatuses.SelectedValue = (int)_Model.InvoiceStatus.ToInvoiceStatus();
            tbPaidAmount.Text = _Model.PaidAmount.ToString("#,##0");
            tbRemainingAmount.Text = _Model.RemainingAmount.ToString("#,##0");
            tbTotalAmount.Text = _Model.TotalAmount.ToString("#,##0");

            _ConfigureForStatus();
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد إلغاء تلك الفاتورة؟",
                Language.ar);

            if (Confirm != DialogResult.Yes)
                return;

            var result = await Task.Run(() => SaleInvoiceService.Cancell(_Id));

            if (result.IsSuccess)
            {
                MessageBoxManager.ShowSuccess(result.Message, Language.ar);
                this.DataBack?.Invoke(this);
                this.Close();
            }
            else
                MessageBoxManager.ShowError(result.Message, Language.ar);
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            using (var frm = new frmReturnsScreen(_Service.Model.SaleInvoiceID))
            {
                frm.DataBack += Frm_UpdateTotalAmount;
                frm.ShowDialog();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e) => _LoadCustomers();

        private void frmAddEditSaleInvoice_FormClosing(
            object sender, 
            FormClosingEventArgs e)
            => DataBack?.Invoke(this);

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
