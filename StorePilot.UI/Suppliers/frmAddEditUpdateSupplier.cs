using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
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

namespace StorePilot.UI.Suppliers
{
    public partial class frmAddEditUpdateSupplier : frmBase
    {
        private frmMode _Mode;

        private int _Id;
        private SupplierService _Service;
        private SupplierModel _Model;

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        public frmAddEditUpdateSupplier(int id, frmMode mode)
        {
            InitializeComponent();

            _Id = id;
            _Mode = mode;
        }

        public frmAddEditUpdateSupplier()
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
            this.tlpName.BackColor = Theme.Surface;
            this.tlpPhoneNumber.BackColor = Theme.Surface;
            this.tlpAddress.BackColor = Theme.Surface;
            this.tlpDown.BackColor = Theme.Surface;

            this.flpFooter.BackColor = Theme.Border;
        }

        private void frmAddUpdateSupplier_Load(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case frmMode.AddNew:
                    lblTitle.Text = "إضافة بيانات مورد جديد";
                    btnActivate.Visible = false;
                    _Service = new SupplierService();
                    break;

                case frmMode.Update:
                    lblTitle.Text = "تحديث بيانات المورد";
                    btnActivate.Text = _Service.Model.Active ? "تعطيل" : "تفعيل";
                    btnActivate.BackColor = _Service.Model.Active ?
                        btnActivate.BackColor :
                        Color.Orange;
                    _LoadData();
                    break;

                case frmMode.Edit:
                    lblTitle.Text = "بيانات المورد";
                    btnActivate.Visible = false;
                    btnSave.Visible = false;
                    EnableTextBoxes();
                    _LoadData();
                    break;
            }

            this.Text = lblTitle.Text;
            tbName.Focus();
        }

        private void _LoadData()
        {
            var result = SupplierService.Find(_Id);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            _Service = result.Data;
            _Model = _Service.Model;

            tbName.Text = _Service.Model.Name;
            tbPhone.Text = _Service.Model.Phone;
            tbAddress.Text = _Service.Model.Address;
            tbNotes.Text = _Service.Model.Notes;
        }

        private void EnableTextBoxes()
        {
            tbName.ReadOnly = true;
            tbPhone.ReadOnly = true;
            tbAddress.ReadOnly = true;
            tbNotes.ReadOnly = true;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.Name = tbName.Text;
            _Validate(tbName, e, _Service.ValidateName());
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.Phone = tbPhone.Text;
            _Validate(tbPhone, e, _Service.ValidatePhone());
        }

        private void _Validate(
            TextBox ctrl,
            CancelEventArgs e,
            Result result)
        {
            if (!result.IsSuccess)
            {
                e.Cancel = true;

                epSupplierData.SetError(ctrl, result.Message);

                ctrl.BackColor = Color.MistyRose;
            }
            else
            {
                epSupplierData.SetError(ctrl, string.Empty);

                ctrl.BackColor = Color.White;
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذا المورد؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.Name = _Model.Name;
                _Service.Model.Phone = _Model.Phone;
                _Service.Model.Active = !_Service.Model.Active;

                _Save();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذا المورد؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.Address = tbAddress.Text;
                _Service.Model.Notes = tbNotes.Text;

                if (!ValidateChildren())
                {
                    MessageBoxManager.ShowError(
                        "بيانات هذا المورد غير صالحة!", 
                        Language.ar);
                    return;
                }

                _Save();
            }
        }

        private void _Save()
        {
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
}
