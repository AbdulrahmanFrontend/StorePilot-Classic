using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Guards;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.Core.Enums;
using StorePilot.Core.Models;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Properties;
using StorePilot.UI.Purchases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI.Returns
{
    public partial class frmAddEditReturnInvoice : frmBase
    {
        private frmMode _Mode;

        private int _SaleInvoiceId;
        private int _ReturnId;
        private SaleReturnModel _Model;
        private SaleReturnService _Service;
        private BindingList<InvoiceItemViewModel> _InvoiceItems =
            new BindingList<InvoiceItemViewModel>();

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;
        
        public frmAddEditReturnInvoice(int saleInvoiceId, int returnId)
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
            _ReturnId = returnId;
            _SaleInvoiceId = saleInvoiceId;
        }

        public frmAddEditReturnInvoice(int saleInvoiceId)
        {
            InitializeComponent();

            _Mode = frmMode.Edit;
            _SaleInvoiceId = saleInvoiceId;
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

        private void frmAddEditReturnInvoice_Load(object sender, EventArgs e)
        {
            _SetDefaultAppearance();

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
            _Service = new SaleReturnService();

            lblTitle.Text = "إضافة بيانات فاتورة مرتجع جديدة";

            btnSavePrint.Text = "حفظ";
            btnSavePrint.Image = Resources.Save_32;
            btnSavePrint.Enabled = false;

            btnCancel.Visible = false;

            btnInvoiceItems.Text = "إضافة عناصر الفاتورة";

            using (var frm = new frmAddEditUpdateReturnItems())
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
        }

        private void _SetDefaultAppearance()
        {
            _EnabledFields();

            dtpInvoiceDate.Value = DateTime.Now;
            tbTotalAmount.Text = "0";
        }

        private void _EnabledFields()
        {
            dtpInvoiceDate.Enabled = ((_Mode == frmMode.AddNew) && _InvoiceItems.Any());
            tbNotes.ReadOnly = !((_Mode == frmMode.AddNew) && _InvoiceItems.Any());
        }

        private void _LoadData()
        {
            var result = SaleReturnService.Find(_ReturnId);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            _Service = result.Data;
            _Model = _Service.Model;

            dtpInvoiceDate.Value = _Model.ReturnDate;
            tbTotalAmount.Text = _Model.TotalReturnAmount.ToString("#,##0");
            tbNotes.Text = _Model.Notes;
        }

        private void dtpInvoiceDate_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.ReturnDate = dtpInvoiceDate.Value;

            Result result = _Service.ValidateReturnDate();

            if (!result.IsSuccess)
            {
                e.Cancel = true;

                epReturnData.SetError(dtpInvoiceDate, result.Message);

                dtpInvoiceDate.BackColor = Color.MistyRose;
            }
            else
            {
                epReturnData.SetError(dtpInvoiceDate, string.Empty);

                dtpInvoiceDate.BackColor = Color.White;
            }
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case frmMode.AddNew:
                    _AddNew();
                    break;
            }
        }

        private void _AddNew()
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ تلك الفاتورة؟",
                Language.ar);

            if (Confirm != DialogResult.Yes)
                return;

            _Service.Model.ReturnDate = dtpInvoiceDate.Value;
            _Service.Model.TotalReturnAmount =
                _GetDecimalVal(tbTotalAmount.Text?.ToString());
            _Service.Model.Notes = tbNotes.Text;

            List<SaleReturnItemModel> list = new List<SaleReturnItemModel>();
            foreach (var item in _InvoiceItems)
            {
                list.Add(new SaleReturnItemModel
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                });
            }

            _Service.SetItems(list);

            var result = _Service.Save();

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
                        using (var frmAdd = new frmAddEditUpdateReturnItems())
                        {
                            frmAdd.DataBack += Frm_DataBackInvoiceItems;
                            frmAdd.ShowDialog();
                        }
                    }
                    else
                    {
                        using (var frmUpdate =
                            new frmAddEditUpdateReturnItems(_InvoiceItems))
                        {
                            frmUpdate.DataBack += Frm_DataBackInvoiceItems;
                            frmUpdate.ShowDialog();
                        }
                    }
                    break;

                case frmMode.Edit:
                    int InvoiceID = _Service.Model.ReturnID;

                    using (var frmEdit = new frmAddEditUpdateReturnItems(InvoiceID))
                        frmEdit.ShowDialog();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد إلغاء تلك الفاتورة؟",
                Language.ar);

            if (Confirm != DialogResult.Yes)
                return;

            var result = SaleInvoiceService.Cancell(_ReturnId);

            if (result.IsSuccess)
            {
                MessageBoxManager.ShowSuccess(result.Message, Language.ar);
                this.DataBack?.Invoke(this);
                this.Close();
            }
            else
                MessageBoxManager.ShowError(result.Message, Language.ar);
        }
    }
}
