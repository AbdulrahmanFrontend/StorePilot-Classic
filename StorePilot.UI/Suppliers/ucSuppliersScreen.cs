using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Customers;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Global.Controls;
using StorePilot.UI.Properties;
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
    public partial class ucSuppliersScreen : ucListScreen
    {
        public ucSuppliersScreen()
        {
            InitializeComponent();
        }

        private async void ucSuppliersScreen_Load(object sender, EventArgs e)
        {
            Title = "الموردون";
            TitleImage = Resources.supplier;

            _ConfigureSearch(
                new[]
                {
                    "الإسم",
                    "رقم الهاتف",
                    "العنوان"
                },
                new[]
                {
                    "مفعل",
                    "غير مفعل"
                });

            _BuildColumns();

            await _RefreshData();

            await _RefreshPagesCount();

            Grid.cmsData = ctrlCmsSuppliers;

            Grid.AddNewClicked += Grid_AddNewClicked;
            Grid.Filter += Grid_Filter;
            Grid.PageNumberSelected += Grid_PageNumberSelected;
            Grid.RowDoubleClicked += Grid_RowDoubleClicked;
            Grid.CellFormatting += Grid_CellFormatting;
        }

        private async void Grid_PageNumberSelected(
            object sender,
            ucDataGridView.FilterEventArgs e)
        {
            _FilterMethodIndex = e.FilteringMethodIndex;
            _FilterValueIndex = e.FilteringValueIndex;
            _FilterValue = e.Input;
            _PageSize = e.PageSize;
            _CurrentPage = e.PageNumber;

            await _RefreshData();
        }

        private async void Grid_Filter(object sender, ucDataGridView.FilterEventArgs e)
        {
            _FilterMethodIndex = e.FilteringMethodIndex;
            _FilterValueIndex = e.FilteringValueIndex;
            _FilterValue = e.Input;
            _PageSize = e.PageSize;
            _CurrentPage = 1;

            await _RefreshData();

            await _RefreshPagesCount();
        }

        private void Grid_RowDoubleClicked(object sender, EventArgs e)
            => _UpdateSupplier();

        private void Grid_AddNewClicked(object sender, EventArgs e)
        {
            using (frmAddEditUpdateSupplier frm = new frmAddEditUpdateSupplier())
            {
                frm.DataBack += Frm_DataBack;

                frm.ShowDialog();
            }
        }

        private async void Frm_DataBack(object sender)
        {
            await _RefreshData();

            await _RefreshPagesCount();
        }

        private void Grid_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (Grid.Columns[e.ColumnIndex].Name == "CreatedAt")
            {
                if (DateTime.TryParse(
                    e.Value?.ToString(),
                    out DateTime date))
                {
                    e.Value = date.ToString("tt   hh:mm   dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void _BuildColumns()
        {
            Grid.Columns.Clear();

            var columns = new DataGridViewTextBoxColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "SupplierID",
                    Visible = false,
                    DataPropertyName = "SupplierID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "الإسم",
                    DataPropertyName = "Name",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Phone",
                    HeaderText = "رقم الهاتف",
                    DataPropertyName = "Phone",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Address",
                    HeaderText = "العنوان",
                    DataPropertyName = "Address",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "CreatedAt",
                    HeaderText = "تاريخ الإنشاء",
                    DataPropertyName = "CreatedAt",
                },
            };

            Grid.Columns.AddRange(columns);

            var chbColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Active",
                HeaderText = "مفعل",
                DataPropertyName = "Active",
            };

            Grid.Columns.Add(chbColumn);
        }

        private async Task _RefreshData()
        {
            Result<DataTable> result = await Task.Run(() => SupplierService.GetSuppliers(
                _CurrentPage,
                _PageSize,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? true : false));

            _BindData(result);
        }

        private async Task _RefreshPagesCount()
        {
            Result<int> result = await Task.Run(() => SupplierService.GetCount(
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? true : false));

            _SetPagesCount(result);
        }

        private void tsmiView_Click(object sender, EventArgs e)
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = SupplierService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditUpdateSupplier(ID, frmMode.Edit))
                        frm.ShowDialog();
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
            => _UpdateSupplier();

        private void _UpdateSupplier()
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = SupplierService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditUpdateSupplier(ID, frmMode.Update))
                    {
                        frm.DataBack += Frm_DataBack;
                        frm.ShowDialog();
                    }
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }

        private async void tsmiActivate_Click(object sender, EventArgs e)
        {
            if (!_TrySelectedID(0, out int ID))
                return;

            var SupplierResult = SupplierService.Find(ID);

            if (!SupplierResult.IsSuccess)
            {
                MessageBoxManager.ShowError(
                    SupplierResult.Message,
                    Language.ar);

                return;
            }

            DialogResult dialog = MessageBoxManager.ShowConfirm(
                    SupplierResult.Data.Model.Active ?
                    "هل انت متأكد أنك تريد تعطيل هذا المورد؟" :
                    "هل انت متأكد أنك تريد تفعيل هذا المورد؟",
                    Language.ar);

            if (dialog == DialogResult.Yes)
            {
                SupplierResult.Data.Model.Active = !SupplierResult.Data.Model.Active;

                var result = await Task.Run(() => SupplierResult.Data.Save());

                if (result.IsSuccess)
                {
                    MessageBoxManager.ShowSuccess(
                        result.Message,
                        Language.ar);

                    await _RefreshData();

                    await _RefreshPagesCount();
                }
                else
                    MessageBoxManager.ShowError(
                        result.Message,
                        Language.ar);
            }
        }

        private void ctrlCmsSuppliers_Opening(object sender, CancelEventArgs e)
        {
            if (!_IsActive())
            {
                tsmiUpdate.Enabled = false;
                tsmiActivate.Text = "تفعيل";
            }
            else
            {
                tsmiUpdate.Enabled = false;
                tsmiActivate.Text = "تعطيل";
            }
        }
    }
}
