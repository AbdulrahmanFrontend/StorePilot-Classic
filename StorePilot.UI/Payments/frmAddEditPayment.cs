using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Guards;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.Core.Enums;
using StorePilot.Core.Models;
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

namespace StorePilot.UI.Payments
{
    public partial class frmAddEditPayment : frmBase
    {
        private frmMode _Mode;

        private int _PaymentId;
        private int _InvoiceID;
        private PaymentService _Service;
        private PaymentModel _Model;

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        public frmAddEditPayment(int invoiceId)
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
            _InvoiceID = invoiceId;
        }

        public frmAddEditPayment(int paymentId, int invoiceId)
        {
            InitializeComponent();

            _Mode = frmMode.Edit;
            _PaymentId = paymentId;
            _InvoiceID = invoiceId;
        }

        protected override void ApplyTheme()
        {
            this.BackColor = Theme.Background;
            this.ForeColor = Theme.Text;

            this.lblTitle.BackColor = Theme.Border;

            this.tlpContainer.ForeColor = Theme.Text;

            tlpUp.Controls.OfType<TableLayoutPanel>()
                .ToList()
                .ForEach(i => i.BackColor = Theme.Surface);

            tlpNotes.BackColor = Theme.Surface;

            this.flpFooter.BackColor = Theme.Border;
        }

        private void frmAddEditPayment_Load(object sender, EventArgs e)
        {
            _LoadPaymentMethods();

            switch (_Mode)
            {
                case frmMode.AddNew:
                    lblTitle.Text = "إضافة بيانات دفعة جديدة";
                    btnCancel.Visible = false;
                    _Service = new PaymentService();
                    break;

                case frmMode.Edit:
                    lblTitle.Text = "بيانات الدفعة";
                    btnCancel.Visible = false;
                    btnSave.Visible = false;
                    EnableTextBoxes();
                    _LoadData();
                    break;
            }

            this.Text = lblTitle.Text;
        }

        private void _LoadPaymentMethods()
        {
            var result = PaymentMethodService.GetAll();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            cbPaymentMethods.DisplayMember = "MethodName";
            cbPaymentMethods.ValueMember = "MethodID";
            cbPaymentMethods.DataSource = result.Data;

            cbPaymentMethods.SelectedIndex = 0;
        }

        private void _LoadData()
        {
            var result = PaymentService.Find(_PaymentId);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            _Service = result.Data;
            _Model = _Service.Model;

            dtpPaymentDate.Value = _Model.PaymentDate;
            cbPaymentMethods.SelectedValue = _Model.MethodID;
            tbPaidAmount.Text = _Model.PaidAmount.ToString("#,##0");
            tbInvoiceID.Text = _Model.InvoiceID.ToString();
            tbNotes.Text = _Model.Notes;
        }

        private void EnableTextBoxes()
        {
            dtpPaymentDate.Enabled = false;
            cbPaymentMethods.Enabled = false;
            tbPaidAmount.ReadOnly = true;
            tbNotes.ReadOnly = true;
        }

        private void tbPaidAmount_Validating(object sender, CancelEventArgs e)
        {
            decimal Quantity =
                decimal.TryParse(tbPaidAmount.Text?.ToString(), out Quantity) ?
                Quantity :
                0;

            _Service.Model.PaidAmount = Quantity;

            if (!Guard.HasValue(tbPaidAmount.Text))
            {
                e.Cancel = true;

                epPaymentData.SetError(tbPaidAmount, "مطلوب!");

                tbPaidAmount.BackColor = Color.MistyRose;

                return;
            }
            else if (!decimal.TryParse(
                tbPaidAmount.Text?.ToString(),
                out decimal value))
            {
                e.Cancel = true;

                epPaymentData.SetError(
                    tbPaidAmount,
                    "لا يسمح إلا بإدخال أرقام صحيحة أو عشرية فقط!");

                tbPaidAmount.BackColor = Color.MistyRose;

                return;
            }

            _Validate(tbPaidAmount, e, _Service.ValidatePaidAmount());
        }

        private void dtpPaymentDate_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.PaymentDate = dtpPaymentDate.Value;
            _Validate(dtpPaymentDate, e, _Service.ValidatePaymentDate());
        }

        private void _Validate(
            object sender,
            CancelEventArgs e,
            Result result)
        {
            Control ctrl = sender as Control;

            if (!result.IsSuccess)
            {
                e.Cancel = true;

                epPaymentData.SetError(ctrl, result.Message);

                ctrl.BackColor = Color.MistyRose;
            }
            else
            {
                epPaymentData.SetError(ctrl, string.Empty);

                ctrl.BackColor = Color.White;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذه الدفعة؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.MethodID = 
                    _GetIntValue(cbPaymentMethods.SelectedValue?.ToString());
                _Service.Model.Notes = _Model.Notes;

                if (!ValidateChildren())
                {
                    MessageBoxManager.ShowError(
                        "بيانات هذه الدفعة غير صالحة!",
                        Language.ar);
                    return;
                }

                var result = await Task.Run(() => _Service.Save());

                if (result.IsSuccess)
                {
                    MessageBoxManager.ShowSuccess(result.Message, Language.ar);
                    DataBack?.Invoke(this);
                    this.Close();
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }

        private int _GetIntValue(string value)
            => int.TryParse(value?.ToString(), out int result) ? result : 0;

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذه الدفعة؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.PaidAmount = _Model.PaidAmount;
                _Service.Model.PaymentDate = _Model.PaymentDate;

                var result = await Task.Run(
                    () => PaymentService.Cancell(_Model.TransactionID)
                    );

                if (result.IsSuccess)
                {
                    MessageBoxManager.ShowSuccess(result.Message, Language.ar);
                    DataBack?.Invoke(this);
                    this.Close();
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }
    }
}
