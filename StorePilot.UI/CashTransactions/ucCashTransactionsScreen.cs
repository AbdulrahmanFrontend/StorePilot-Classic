using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.BLL;
using StorePilot.UI.Global.Classes;
using StorePilot.UI.Global.Controls;
using StorePilot.UI.Payments;
using StorePilot.UI.Properties;
using StorePilot.UI.Purchases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorePilot.UI.CashTransactions
{
    public partial class ucCashTransactionsScreen : ucListScreen
    {
        public ucCashTransactionsScreen()
        {
            InitializeComponent();
        }

        private async void ucCashTransactionsScreen_Load(object sender, EventArgs e)
        {
            Title = "حركات الصندوق";
            TitleImage = Resources.cash;

            _ConfigureSearch(
                new[]
                {
                    "تاريخ الحركة",
                    "نوع الحركة",
                    "توصيف الحركة",
                },
                new[]
                {
                    "مفعل",
                    "ملغي"
                });

            _BuildColumns();

            await _RefreshData();

            await _RefreshPagesCount();

            Grid.cmsData = ctrlCmsCashTransactions;

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
            => _UpdateTransaction();

        private void Grid_AddNewClicked(object sender, EventArgs e)
        {
            using (frmAddEditUpdateTransaction frm = new frmAddEditUpdateTransaction())
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
            if (Grid.Columns[e.ColumnIndex].Name == "TransactionDate" ||
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
                    Name = "TransactionID",
                    Visible = false,
                    DataPropertyName = "TransactionID",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TransactionDate",
                    HeaderText = "تاريخ الحركة",
                    DataPropertyName = "TransactionDate",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TransactionType",
                    HeaderText = "نوع الحركة",
                    DataPropertyName = "TransactionType",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PaidAmount",
                    HeaderText = "المبلغ المدفوع",
                    DataPropertyName = "PaidAmount",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Description",
                    HeaderText = "توصيف الحركة",
                    DataPropertyName = "Description",
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

            Grid.Columns[4].DefaultCellStyle.Format = string.Format("N2");
        }

        private async Task _RefreshData()
        {
            Result<DataTable> result = 
                await Task.Run(() => CashTransactionService.GetCashTransactions(
                _CurrentPage,
                _PageSize,
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _BindData(result);
        }

        private async Task _RefreshPagesCount()
        {
            Result<int> result = await Task.Run(() => CashTransactionService.GetCount(
                _FilterMethodIndex,
                _FilterValue,
                _FilterValueIndex == 0 ? false : true));

            _SetPagesCount(result);
        }

        private void tsmiView_Click(object sender, EventArgs e)
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = CashTransactionService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = 
                        new frmAddEditUpdateTransaction(ID, frmMode.Edit))
                        frm.ShowDialog();
                }
                else
                    MessageBoxManager.ShowError(result.Message, Language.ar);
            }
        }

        private void _UpdateTransaction()
        {
            if (_TrySelectedID(0, out int ID))
            {
                var result = CashTransactionService.IsExist(ID);

                if (result.IsSuccess)
                {
                    using (var frm = new frmAddEditUpdateTransaction(ID, frmMode.Update))
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

            DialogResult dialog = MessageBoxManager.ShowConfirm(
                "هل انت متأكد أنك تريد تحديث بيانات هذه الحركة؟",
                Language.ar);

            if (dialog != DialogResult.Yes)
                return;

            var TransactionResult = CashTransactionService.Find(ID);

            if (!TransactionResult.IsSuccess)
            {
                MessageBoxManager.ShowError(
                    TransactionResult.Message,
                    Language.ar);

                return;
            }

            TransactionResult.Data.Model.Cancelled = 
                !TransactionResult.Data.Model.Cancelled;

            var result = await Task.Run(() => TransactionResult.Data.Save());

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

        private void ctrlCmsCashTransactions_Opening(object sender, CancelEventArgs e)
        {
            if (_IsCancelled())
            {
                tsmiUpdate.Enabled = false;
                tsmiCancel.Text = "تفعيل";
            }
            else
            {
                tsmiUpdate.Enabled = true;
                tsmiCancel.Text = "إلغاء";
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
            => _UpdateTransaction();
    }
}
