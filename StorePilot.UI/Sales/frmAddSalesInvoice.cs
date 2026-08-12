using DevToolkit.BaseWinForms.Managers;
using StorePilot.BLL;
using StorePilot.Core.Models;
using StorePilot.UI.Global.Classes;
using System;
using DevToolkit.Core.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevToolkit.BaseWinForms.Forms;

namespace StorePilot.UI.Sales
{
    public partial class frmAddSalesInvoice : frmBase
    {
        private frmMode _Mode;

        private int _Id;
        private SaleInvoiceService _Service;
        private SaleInvoiceModel _Model;

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        public frmAddSalesInvoice()
        {
            InitializeComponent();

            _Mode = frmMode.AddNew;
        }

        public frmAddSalesInvoice(int saleInvoiceId)
        {
            InitializeComponent();

            _Mode = frmMode.Edit;
            _Id = saleInvoiceId;
        }

        private void frmAddSalesInvoice_Load(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case frmMode.AddNew:
                    break;

                case frmMode.Edit:
                    break;
            }
        }

        private void _LoadCustomers()
        {
            var result = CustomerService.GetForSelection();

            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(result.Message, Language.ar);
                this.Close();
            }

            cbCustomers.Items.Clear();

            cbCustomers.DisplayMember = "CustomerName";
            cbCustomers.ValueMember = "CustomerID";
            cbCustomers.DataSource = result.Data;

            cbCustomers.SelectedIndex = -1;
        }
    }
}
