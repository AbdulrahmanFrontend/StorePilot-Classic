using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Global.Controls;
using StorePilot.UI.Properties;
using StorePilot.UI.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI.Products
{
    public partial class ucProductsScreen : ucListScreen
    {
        public ucProductsScreen()
        {
            InitializeComponent();
        }

        private async void ucProductsScreen_Load(object sender, EventArgs e)
        {
            Title = "الأصناف";
            TitleImage = Resources.product;

            _ConfigureSearch(
                new[]
                {
                    "اسم الصنف",
                    "الباركود",
                    "المجموعة",
                    "وحدة القياس"
                },
                new[]
                {
                    "مفعل",
                    "غير مفعل"
                });

            _BuildColumns();

            await _RefreshData();

            await _RefreshPagesCount();

            Grid.cmsData = ctrlCmsProducts;

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
            => _UpdateProduct();

        private void Grid_AddNewClicked(object sender, EventArgs e)
        {
            using (frmAddEditUpdateProduct frm = new frmAddEditUpdateProduct())
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
                    e.Value = date.ToString("dd/MM/yyyy hh:mm tt");
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
                    Name = "ProductID",
                    Visible = false,
                    DataPropertyName = "ProductID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "اسم الصنف",
                    DataPropertyName = "ProductName",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "BarCode",
                    HeaderText = "الباركود",
                    DataPropertyName = "BarCode",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "GroupName",
                    HeaderText = "المجموعة",
                    DataPropertyName = "GroupName",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "UnitName",
                    HeaderText = "وحدة القياس",
                    DataPropertyName = "UnitName",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "الكمية الحالية",
                    DataPropertyName = "Quantity",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "MinQuantity",
                    HeaderText = "الحد الأدنى",
                    DataPropertyName = "MinQuantity",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PurchasePrice",
                    HeaderText = "سعر الشراء",
                    DataPropertyName = "PurchasePrice",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "SalePrice",
                    HeaderText = "سعر البيع",
                    DataPropertyName = "SalePrice",
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

            Grid.Columns[5].DefaultCellStyle.Format = string.Format("N2");
            Grid.Columns[6].DefaultCellStyle.Format = string.Format("N2");
            Grid.Columns[7].DefaultCellStyle.Format = string.Format("N2");
            Grid.Columns[8].DefaultCellStyle.Format = string.Format("N2");
        }

        private async Task _RefreshData()
        {
            Result<DataTable> result = await Task.Run(() => ProductService.GetProducts(
                _CurrentPage,
                _PageSize,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? true : false));

            _BindData(result);
        }

        private async Task _RefreshPagesCount()
        {
            Result<int> result = await Task.Run(()=> ProductService.GetCount(
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? true : false));

            _SetPagesCount(result);
        }

        private void tsmiView_Click(object sender, EventArgs e)
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = ProductService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditUpdateProduct(ID, frmMode.Edit))
                        frm.ShowDialog();
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
            => _UpdateProduct();

        private void _UpdateProduct()
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = ProductService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditUpdateProduct(ID, frmMode.Update))
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

            var ProductResult = ProductService.Find(ID);

            if (!ProductResult.IsSuccess)
            {
                MessageBoxManager.ShowError(
                    ProductResult.Message,
                    Language.ar);

                return;
            }

            DialogResult dialog = MessageBoxManager.ShowConfirm(
                    ProductResult.Data.Model.Active ?
                    "هل انت متأكد أنك تريد تعطيل هذا الصنف؟" :
                    "هل انت متأكد أنك تريد تفعيل هذا الصنف؟",
                    Language.ar);

            if (dialog == DialogResult.Yes)
            {
                ProductResult.Data.Model.Active = !ProductResult.Data.Model.Active;

                var result = await Task.Run(() => ProductResult.Data.Save());

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

        private void ctrlCmsProducts_Opening(object sender, CancelEventArgs e)
        {
            if (!_IsActive())
            {
                tsmiUpdate.Enabled = false;
                tsmiActivate.Text = "تفعيل";
            }
            else
            {
                tsmiUpdate.Enabled = true;
                tsmiActivate.Text = "تعطيل";
            }
        }
    }
}
