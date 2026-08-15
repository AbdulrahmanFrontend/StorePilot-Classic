using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StorePilot.UI.CashTransactions
{
    public partial class frmAddEditUpdateTransaction : frmBase
    {
        private frmMode _Mode;

        private int _Id;
        private CashTransactionService _Service;
        private CashTransactionModel _Model;

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        public frmAddEditUpdateTransaction(int id, frmMode mode)
        {
            InitializeComponent();

            _Id = id;
            _Mode = mode;
        }

        public frmAddEditUpdateTransaction()
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
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

        private void frmAddEditUpdateTransaction_Load(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case frmMode.AddNew:
                    lblTitle.Text = "إضافة بيانات حركة جديدة";
                    btnCancel.Visible = false;
                    _Service = new CashTransactionService();
                    break;

                case frmMode.Update:
                    lblTitle.Text = "تحديث بيانات الحركة";
                    _LoadData();
                    break;

                case frmMode.Edit:
                    lblTitle.Text = "بيانات الحركة";
                    btnCancel.Visible = false;
                    btnSave.Visible = false;
                    EnableTextBoxes();
                    _LoadData();
                    break;
            }

            this.Text = lblTitle.Text;
        }

        private void _LoadData()
        {
            var result = CashTransactionService.Find(_Id);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            _Service = result.Data;
            _Model = _Service.Model;

            dtpTransactionDate.Value = _Model.TransactionDate;
            cbTransactionType.SelectedIndex = 
                (int)_Model.TransactionType.ToTransactionType();
            tbPaidAmount.Text = _Model.PaidAmount.ToString("#,##0");
            tbDescription.Text = _Model.Description;
            tbNotes.Text = _Model.Notes;
        }

        private void EnableTextBoxes()
        {
            dtpTransactionDate.Enabled = false;
            cbTransactionType.Enabled = false;
            tbPaidAmount.ReadOnly = true;
            tbDescription.ReadOnly = true;
            tbNotes.Enabled = false;
        }

        private void tbPaidAmount_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.PaidAmount = 
                decimal.TryParse(tbPaidAmount.Text?.ToString(), out decimal value) ?
                value :
                0;

            _Validate(tbPaidAmount, e, _Service.ValidatePaidAmount());
        }

        private void tbDescription_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.Description = tbDescription.Text;
            _Validate(tbDescription, e, _Service.ValidateDescription());
        }

        private void _Validate(
            TextBox ctrl,
            CancelEventArgs e,
            Result result)
        {
            if (!result.IsSuccess)
            {
                e.Cancel = true;

                epTransactionData.SetError(ctrl, result.Message);

                ctrl.BackColor = Color.MistyRose;
            }
            else
            {
                epTransactionData.SetError(ctrl, string.Empty);

                ctrl.BackColor = Color.White;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذه الحركة؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.TransactionDate = dtpTransactionDate.Value;
                _Service.Model.TransactionType = cbTransactionType.Text;
                _Service.Model.Notes = _Model.Notes;

                if (!ValidateChildren())
                {
                    MessageBoxManager.ShowError(
                        "بيانات هذه الحركة غير صالحة!",
                        Language.ar);
                    return;
                }

                var result = _Service.Save();

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذه الحركة؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.PaidAmount = _Model.PaidAmount;
                _Service.Model.Description = _Model.Description;

                var result = CashTransactionService.Cancell(_Model.TransactionID);

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
