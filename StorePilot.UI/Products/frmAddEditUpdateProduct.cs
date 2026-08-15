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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StorePilot.UI.Products
{
    public partial class frmAddEditUpdateProduct : frmBase
    {
        private frmMode _Mode;

        private int _Id;
        private ProductService _Service;
        private ProductModel _Model;

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        public frmAddEditUpdateProduct(int id, frmMode mode)
        {
            InitializeComponent();

            _Id = id;
            _Mode = mode;
        }

        public frmAddEditUpdateProduct()
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
        }

        protected override void ApplyTheme()
        {
            this.BackColor = Theme.Background;
            this.ForeColor = Theme.Text;

            this.lblTitle.BackColor = Theme.Border;

            this.tlpBody.ForeColor = Theme.Text;

            this.tlpProductName.BackColor = Theme.Surface;
            this.tlpBarCode.BackColor = Theme.Surface;
            this.tlpGroups.BackColor = Theme.Surface;
            this.tlpUnits.BackColor = Theme.Surface;
            this.tlpQuantity.BackColor = Theme.Surface;
            this.tlpMinQuantity.BackColor = Theme.Surface;
            this.tlpPurchasePrice.BackColor = Theme.Surface;
            this.tlpSalePrice.BackColor = Theme.Surface;

            this.flpFooter.BackColor = Theme.Border;
        }

        private void frmAddEditUpdateProduct_Load(object sender, EventArgs e)
        {
            _FillComboBoxes();

            switch (_Mode)
            {
                case frmMode.AddNew:
                    lblTitle.Text = "إضافة بيانات صنف جديد";
                    tbQuantity.ReadOnly = true;
                    btnActivate.Visible = false;
                    _Service = new ProductService();
                    break;

                case frmMode.Update:
                    lblTitle.Text = "تحديث بيانات الصنف";
                    btnActivate.Text = _Service.Model.Active ? "تعطيل" : "تفعيل";
                    btnActivate.BackColor = _Service.Model.Active ?
                        btnActivate.BackColor :
                        Color.Orange;
                    _LoadData();
                    break;

                case frmMode.Edit:
                    lblTitle.Text = "بيانات الصنف";
                    btnActivate.Visible = false;
                    btnSave.Visible = false;
                    EnableFields();
                    _LoadData();
                    break;
            }

            this.Text = lblTitle.Text;
            tbProductName.Focus();
        }

        private void _FillComboBoxes()
        {
            _LoadGroups();

            _LoadUnits();
        }

        private void _LoadGroups()
        {
            var result = GroupService.GetAll();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            cbGroups.DisplayMember = "GroupName";
            cbGroups.ValueMember = "GroupID";
            cbGroups.DataSource = result.Data;

            cbGroups.SelectedIndex = 0;
        }

        private void _LoadUnits()
        {
            var result = UnitService.GetAll();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            cbUnits.DisplayMember = "UnitName";
            cbUnits.ValueMember = "UnitID";
            cbUnits.DataSource = result.Data;

            cbUnits.SelectedIndex = 0;
        }

        private void _LoadData()
        {
            var result = ProductService.Find(_Id);

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            _Service = result.Data;
            _Model = _Service.Model;

            tbProductName.Text = _Service.Model.ProductName;
            tbBarCode.Text = _Service.Model.BarCode;
            cbGroups.SelectedValue = _Service.Model.GroupID;
            cbUnits.SelectedValue = _Service.Model.UnitID;
            tbQuantity.Text = _Service.Model.Quantity.ToString("#,##0");
            tbMinQuantity.Text = _Service.Model.MinQuantity.ToString("#,##0");
            tbSalePrice.Text = _Service.Model.SalePrice.ToString("#,##0");
            tbPurchasePrice.Text = _Service.Model.PurchasePrice.ToString("#,##0");
            tbNotes.Text = _Service.Model.Notes;
        }

        private void EnableFields()
        {
            tbProductName.ReadOnly = true;
            tbBarCode.ReadOnly = true;
            cbGroups.Enabled = false;
            cbUnits.Enabled = false;
            tbMinQuantity.ReadOnly = true;
            tbSalePrice.ReadOnly = true;
            tbPurchasePrice.ReadOnly = true;
            tbNotes.ReadOnly = true;
        }

        private void tbProductName_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.ProductName = tbProductName.Text;
            _Validate((TextBox)sender, e, _Service.ValidateProductName());
        }

        private void tbBarCode_Validating(object sender, CancelEventArgs e)
        {
            _Service.Model.BarCode = tbBarCode.Text;
            _Validate((TextBox)sender, e, _Service.ValidateBarCode());
        }

        private void tbMinQuantity_Validating(object sender, CancelEventArgs e)
        {
            _Validate(sender, e);
            _Service.Model.MinQuantity = _GetDecimalValue(tbMinQuantity.Text);
            _Validate((TextBox)sender, e, _Service.ValidateMinQuantity());
        }

        private void tbPurchasePrice_Validating(object sender, CancelEventArgs e)
        {
            _Validate(sender, e);
            _Service.Model.PurchasePrice = _GetDecimalValue(tbPurchasePrice.Text);
            _Validate((TextBox)sender, e, _Service.ValidatePurchasePrice());
        }

        private void tbSalePrice_Validating(object sender, CancelEventArgs e)
        {
            _Validate(sender, e);
            _Service.Model.SalePrice = _GetDecimalValue(tbSalePrice.Text);
            _Validate((TextBox)sender, e, _Service.ValidateSalePrice());
        }

        private void tbQuantity_Validating(object sender, CancelEventArgs e)
        {
            _Validate(sender, e);
            _Service.Model.Quantity = _GetDecimalValue(tbQuantity.Text);
            _Validate((TextBox)sender, e, _Service.ValidateMinQuantity());
        }

        private decimal _GetDecimalValue(string value)
            => decimal.TryParse(value?.ToString(), out decimal result) ? result : 0;

        private void _Validate(TextBox ctrl, CancelEventArgs e, Result result)
        {
            if (!result.IsSuccess)
            {
                e.Cancel = true;

                epProductData.SetError(ctrl, result.Message);

                ctrl.BackColor = Color.MistyRose;
            }
            else
            {
                epProductData.SetError(ctrl, string.Empty);

                ctrl.BackColor = Color.White;
            }
        }

        private void _Validate(object sender, CancelEventArgs e)
        {
            TextBox ctrl = sender as TextBox;
            if (!decimal.TryParse(ctrl.Text?.ToString(), out decimal value))
            {
                e.Cancel = true;

                epProductData.SetError(
                    ctrl,
                    "لا يسمح إلا بإدخال أرقام صحيحة أو عشرية فقط!");

                ctrl.BackColor = Color.MistyRose;
            }
            else
            {
                epProductData.SetError(ctrl, string.Empty);

                ctrl.BackColor = Color.White;
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذا الصنف؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.ProductName = _Model.ProductName;
                _Service.Model.BarCode = _Model.BarCode;
                _Service.Model.MinQuantity = _Model.MinQuantity;
                _Service.Model.PurchasePrice = _Model.PurchasePrice;
                _Service.Model.SalePrice = _Model.SalePrice;
                _Service.Model.Active = !_Service.Model.Active;

                _Save();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult Confirm = MessageBoxManager.ShowConfirm(
                "هل أنت متأكد من أنك تريد حفظ بيانات هذا الصنف؟",
                Language.ar);

            if (Confirm == DialogResult.Yes)
            {
                _Service.Model.GroupID = 
                    _GetIntValue(cbGroups.SelectedValue?.ToString());
                _Service.Model.UnitID = 
                    _GetIntValue(cbUnits.SelectedValue?.ToString());
                _Service.Model.Notes = tbNotes.Text;

                if (!ValidateChildren())
                {
                    MessageBoxManager.ShowError(
                        "بيانات هذا الصنف غير صالحة!",
                        Language.ar);
                    return;
                }

                _Save();
            }
        }

        private int _GetIntValue(string value)
            => int.TryParse(value?.ToString(), out int result) ? result : 0;

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
