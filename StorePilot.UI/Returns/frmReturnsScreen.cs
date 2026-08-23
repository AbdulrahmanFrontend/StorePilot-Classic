using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Global.Forms;
using StorePilot.UI.Payments;
using StorePilot.UI.Properties;
using StorePilot.UI.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StorePilot.UI.Returns
{
    public partial class frmReturnsScreen : frmListScreen
    {
        private int _SaleInvoiceId;

        public frmReturnsScreen(int saleInvoiceId)
        {
            InitializeComponent();

            _SaleInvoiceId = saleInvoiceId;
        }

        private async void frmReturnsScreen_Load(object sender, EventArgs e)
        {
            Title = "المرتجعات";
            TitleImage = Resources.invoice;

            _ConfigureSearch(
                new[]
                {
                    "رقم فاتورة المرتجع",
                    "رقم فاتورة البيع",
                    "تاريخ المرتجع"
                },
                new[]
                {
                    "مفعل",
                    "ملغي"
                });

            _BuildColumns();

            await _RefreshData();

            await _RefreshPagesCount();

            _Grid.cmsData = ctrlCmsReturns;

            _Grid.AddNewClicked += _Grid_AddNewClicked;
            _Grid.Filter += _Grid_Filter;
            _Grid.PageNumberSelected += _Grid_PageNumberSelected;
            _Grid.Searchbar.InputEntered += _Searchbar_InputEntered;
            _Grid.RowDoubleClicked += _Grid_RowDoubleClicked;
            _Grid.CellFormatting += _Grid_CellFormatting;
        }

        private void _Searchbar_InputEntered(object sender, KeyPressEventArgs e)
        {
            if (_FilterMethodIndex == 0)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void _Grid_PageNumberSelected(
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

        private async void _Grid_Filter(
            object sender,
            ucDataGridView.FilterEventArgs e)
        {
            _FilterMethodIndex = e.FilteringMethodIndex;
            _FilterValueIndex = e.FilteringValueIndex;
            _FilterValue = e.Input;
            _PageSize = e.PageSize;
            _CurrentPage = 1;

            await _RefreshData();

            await _RefreshPagesCount();
        }

        private void _Grid_RowDoubleClicked(object sender, EventArgs e)
            => _ViewReturnsInvoice();

        private void _Grid_AddNewClicked(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditReturnInvoice(_SaleInvoiceId))
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

        private void _Grid_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (_Grid.Columns[e.ColumnIndex].Name == "ReturnDate")
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
            _Grid.Columns.Clear();

            var columns = new DataGridViewTextBoxColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ReturnID",
                    HeaderText = "رقم فاتورة المرتجع",
                    DataPropertyName = "ReturnID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "SaleInvoiceID",
                    HeaderText = "رقم الفاتورة البيع",
                    DataPropertyName = "SaleInvoiceID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ReturnDate",
                    HeaderText = "تاريخ المرتجع",
                    DataPropertyName = "ReturnDate",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalReturnAmount",
                    HeaderText = "إجمالي الفاتورة",
                    DataPropertyName = "TotalReturnAmount",
                },
            };

            _Grid.Columns.AddRange(columns);

            var chbColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Cancelled",
                HeaderText = "ملغي",
                DataPropertyName = "Cancelled",
            };

            _Grid.Columns.Add(chbColumn);

            _Grid.Columns[3].DefaultCellStyle.Format = string.Format("N2");
        }

        private async Task _RefreshData()
        {
            Result<DataTable> result = 
                await Task.Run(() => SaleReturnService.GetReturns(
                _SaleInvoiceId,
                _CurrentPage,
                _PageSize,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _BindData(result);
        }

        private async Task _RefreshPagesCount()
        {
            Result<int> result = await Task.Run(() => SaleReturnService.GetCount(
                _SaleInvoiceId,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _SetPagesCount(result);
        }

        private void tsmiView_Click(object sender, EventArgs e)
            => _ViewReturnsInvoice();

        private void _ViewReturnsInvoice()
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = SaleReturnService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditReturnInvoice(ID, frmMode.Edit))
                    {
                        frm.DataBack += Frm_DataBack;
                        frm.ShowDialog();
                    }
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }

        private async void tsmiCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBoxManager.ShowConfirm(
                "هل انت متأكد أنك تريد إلغاء هذه الفاتورة؟",
                Language.ar);

            if (dialog != DialogResult.Yes)
                return;

            if (!_TrySelectedID(0, out int ID))
                return;

            var SaleReturnResult = SaleReturnService.IsExist(ID);

            if (!SaleReturnResult.IsSuccess)
            {
                MessageBoxManager.ShowError(
                    SaleReturnResult.Message,
                    Language.ar);

                return;
            }

            var result = await Task.Run(() => SaleReturnService.Cancell(ID));

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

        private void tsmiPrint_Click(object sender, EventArgs e)
        {

        }

        private void ctrlCmsReturns_Opening(object sender, CancelEventArgs e)
        {
            if (_IsCancelled())
            {
                tsmiCancel.Enabled = false;
                tsmiPrint.Enabled = false;
            }
            else
            {
                tsmiCancel.Enabled = true;
                tsmiPrint.Enabled = true;
            }
        }
    }
}
