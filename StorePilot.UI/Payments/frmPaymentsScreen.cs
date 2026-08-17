using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Global.Forms;
using StorePilot.UI.Properties;
using StorePilot.UI.Returns;
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
    public partial class frmPaymentsScreen : frmListScreen
    {
        private int _InvoiceId;

        public frmPaymentsScreen(int invoiceId)
        {
            InitializeComponent();

            _InvoiceId = invoiceId;
        }

        private async void frmPaymentsScreen_Load(object sender, EventArgs e)
        {
            Title = "المدفوعات";
            TitleImage = Resources.payment;

            _ConfigureSearch(
                new[]
                {
                    "رقم الدفعة",
                    "رقم الفاتورة",
                    "تاريخ الدفع",
                    "طريقة الدفع",
                },
                new[]
                {
                    "غير ملغي",
                    "ملغي"
                });

            _BuildColumns();

            await _RefreshData();

            await _RefreshPagesCount();

            _Grid.cmsData = ctrlCmsPayments;

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
            => _ViewPaymentsInvoice();

        private void _Grid_AddNewClicked(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditPayment(_InvoiceId))
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
            if (_Grid.Columns[e.ColumnIndex].Name == "PaymentDate")
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
                    Name = "PaymentID",
                    HeaderText = "رقم الدفعة",
                    DataPropertyName = "PaymentID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "InvoiceID",
                    HeaderText = "رقم الفاتورة",
                    DataPropertyName = "InvoiceID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PaymentDate",
                    HeaderText = "تاريخ الدفع",
                    DataPropertyName = "PaymentDate",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PaidAmount",
                    HeaderText = "المبلغ المدفوع",
                    DataPropertyName = "PaidAmount",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "MethodName",
                    HeaderText = "طريقة الدفع",
                    DataPropertyName = "MethodName",
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

            _Grid.Columns[4].DefaultCellStyle.Format = string.Format("N2");
        }

        private async Task _RefreshData()
        {
            Result<DataTable> result =
                await Task.Run(() => PaymentService.GetPaymentsInvoice(
                _InvoiceId,
                _CurrentPage,
                _PageSize,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _BindData(result);
        }

        private async Task _RefreshPagesCount()
        {
            Result<int> result = await Task.Run(() => PaymentService.GetCount(
                _InvoiceId,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _SetPagesCount(result);
        }

        private void tsmiView_Click(object sender, EventArgs e)
            => _ViewPaymentsInvoice();

        private void _ViewPaymentsInvoice()
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = PaymentService.IsExist(ID);

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

        private async void tsmiCancel_Click(object sender, EventArgs e)
        {
            if (!_TrySelectedID(0, out int ID))
                return;

            var PaymentResult = PaymentService.IsExist(ID);

            if (!PaymentResult.IsSuccess)
            {
                MessageBoxManager.ShowError(
                    PaymentResult.Message,
                    Language.ar);

                return;
            }

            DialogResult dialog = MessageBoxManager.ShowConfirm(
                "هل انت متأكد أنك تريد إلغاء هذه الدفعة؟",
                Language.ar);

            if (dialog == DialogResult.Yes)
            {
                var result = await Task.Run(() => PaymentService.Cancell(ID));

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

        private void ctrlCmsPayments_Opening(object sender, CancelEventArgs e)
        {
            if (_IsCancelled())
                tsmiCancel.Enabled = false;
            else
                tsmiCancel.Enabled = true;
        }
    }
}
