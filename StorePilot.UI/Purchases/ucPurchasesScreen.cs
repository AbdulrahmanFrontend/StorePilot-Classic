using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Global.Controls;
using StorePilot.UI.Payments;
using StorePilot.UI.Properties;
using StorePilot.UI.Returns;
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

namespace StorePilot.UI.Purchases
{
    public partial class ucPurchasesScreen : ucListScreen
    {
        public ucPurchasesScreen()
        {
            InitializeComponent();
        }

        private async void ucPurchasesScreen_Load(object sender, EventArgs e)
        {
            Title = "المشتريات";
            TitleImage = Resources.purchases;

            _ConfigureSearch(
                new[]
                {
                    "رقم فاتورة الشراء",
                    "رقم الفاتورة",
                    "اسم المورد",
                    "تاريخ الشراء",
                    "حالة الفاتورة"
                },
                new[]
                {
                    "غير ملغي",
                    "ملغي"
                });

            _BuildColumns();

            await _RefreshData();

            await _RefreshPagesCount();

            Grid.cmsData = ctrlCmsPurchases;

            Grid.AddNewClicked += Grid_AddNewClicked;
            Grid.Filter += Grid_Filter;
            Grid.PageNumberSelected += Grid_PageNumberSelected;
            Grid.Searchbar.InputEntered += Searchbar_InputEntered;
            Grid.RowDoubleClicked += Grid_RowDoubleClicked;
            Grid.CellFormatting += Grid_CellFormatting;
        }

        private void Searchbar_InputEntered(object sender, KeyPressEventArgs e)
        {
            if (_FilterMethodIndex == 0 || _FilterMethodIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
            => _ViewPurchaseInvoice();

        private void Grid_AddNewClicked(object sender, EventArgs e)
        {
            using (frmAddEditPurchaseInvoice frm = new frmAddEditPurchaseInvoice())
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
            if (Grid.Columns[e.ColumnIndex].Name == "InvoiceDate" ||
                Grid.Columns[e.ColumnIndex].Name == "CreatedAt")
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
                    Name = "PurchaseInvoiceID",
                    HeaderText = "رقم فاتورة الشراء",
                    DataPropertyName = "PurchaseInvoiceID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "InvoiceID",
                    HeaderText = "رقم الفاتورة",
                    DataPropertyName = "InvoiceID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "InvoiceDate",
                    HeaderText = "تاريخ الشراء",
                    DataPropertyName = "InvoiceDate",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "InvoiceStatus",
                    HeaderText = "حالة الفاتورة",
                    DataPropertyName = "InvoiceStatus",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "SupplierName",
                    HeaderText = "اسم المورد",
                    DataPropertyName = "SupplierName",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PaidAmount",
                    HeaderText = "المبلغ المدفوع",
                    DataPropertyName = "PaidAmount",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "RemainingAmount",
                    HeaderText = "المبلغ المتبقي",
                    DataPropertyName = "RemainingAmount",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalAmount",
                    HeaderText = "إجمالي الفاتورة",
                    DataPropertyName = "TotalAmount",
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
                Name = "Cancelled",
                HeaderText = "ملغي",
                DataPropertyName = "Cancelled",
            };

            Grid.Columns.Add(chbColumn);

            Grid.Columns[5].DefaultCellStyle.Format = string.Format("N2");
            Grid.Columns[6].DefaultCellStyle.Format = string.Format("N2");
            Grid.Columns[7].DefaultCellStyle.Format = string.Format("N2");
        }

        private async Task _RefreshData()
        {
            Result<DataTable> result = await Task.Run(() => PurchaseInvoiceService.GetInvoices(
                _CurrentPage,
                _PageSize,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _BindData(result);
        }

        private async Task _RefreshPagesCount()
        {
            Result<int> result = await Task.Run(() => PurchaseInvoiceService.GetCount(
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _SetPagesCount(result);
        }

        private void tsmiView_Click(object sender, EventArgs e)
            => _ViewPurchaseInvoice();

        private void _ViewPurchaseInvoice()
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = PurchaseInvoiceService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditPurchaseInvoice(ID))
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
            if (!_TrySelectedID(0, out int ID))
                return;

            var PurchaseInvoiceResult = PurchaseInvoiceService.IsExist(ID);

            if (!PurchaseInvoiceResult.IsSuccess)
            {
                MessageBoxManager.ShowError(
                    PurchaseInvoiceResult.Message,
                    Language.ar);

                return;
            }

            DialogResult dialog = MessageBoxManager.ShowConfirm(
                "هل انت متأكد أنك تريد إلغاء هذه الفاتورة؟",
                Language.ar);

            if (dialog == DialogResult.Yes)
            {
                var result = await Task.Run(() => PurchaseInvoiceService.Cancell(ID));

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

        private void tsmiPrint_Click(object sender, EventArgs e)
        {

        }

        private void tsmiAddPayments_Click(object sender, EventArgs e)
        {
            if (_TrySelectedID(1, out int ID))
            {
                var result = PurchaseInvoiceService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditPayment(ID))
                    {
                        frm.DataBack += Frm_DataBack;
                        frm.ShowDialog();
                    }
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }

        private void tsmiViewPayments_Click(object sender, EventArgs e)
        {

        }

        private void ctrlCmsPurchases_Opening(object sender, CancelEventArgs e)
        {
            if (_TrySelectedID(1, out int InvoiceId))
            {
                var HasPaymentsResult = InvoiceService.HasPayments(InvoiceId);

                if (!HasPaymentsResult.IsSuccess)
                    tsmiViewPayments.Enabled = false;
            }

            if (_IsCancelled())
                tsmiCancel.Enabled = false;
            else
                tsmiCancel.Enabled = true;
        }
    }
}
