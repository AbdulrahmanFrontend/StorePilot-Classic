using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Forms;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.UI.Global.Classes;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace StorePilot.UI.Global.Forms
{
    public partial class frmListScreen : frmBase
    {
        protected int _CurrentPage = 1;
        protected int _PageSize = 50;

        protected int _FilterMethodIndex = 0;
        protected int _FilterValueIndex = 0;
        protected string _FilterValue = string.Empty;

        [Category("Custom Properties")]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        [Category("Custom Properties")]
        public Color TitleTextColor
        {
            get => lblTitle.ForeColor;
            set => lblTitle.ForeColor = value;
        }

        [Category("Custom Properties")]
        public Image TitleImage
        {
            get => lblTitle.Image;
            set => lblTitle.Image = value;
        }

        [Category("Custom Properties")]
        public Color TitleBackColor
        {
            get => lblTitle.BackColor;
            set => lblTitle.BackColor = value;
        }

        protected ucDataGridView _Grid => GridView;

        public frmListScreen()
        {
            InitializeComponent();
        }

        private void frmListScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = Theme.Border;
            this.ForeColor = Theme.Text;

            this.lblTitle.BackColor = Theme.Surface;
            this.lblTitle.ForeColor = Theme.Text;

            this.GridView.BackColor = Theme.Border;
            this.GridView.ForeColor = Theme.Text;

            this.flpFooter.BackColor = Theme.Border;

            this.GridView.AddNewButtonImage = Resources.add;
            this.GridView.Size = new Size(1457, 600);

            this.GridView.ImportButtonVisible = false;
            this.GridView.Searchbar.ShowCancelButton = false;

            GridView.SetPageSizes(new[] { 50, 100, 200, 300, 400 });
        }

        protected void _SetPagesCount(Result<int> result)
        {
            if (result.IsSuccess)
            {
                int Count = result.Data / _PageSize;

                if (result.Data % _PageSize != 0)
                    Count++;

                GridView.SetPagesCount(Count);
            }
            else
                MessageBoxManager.ShowError(result.Message, Language.ar);
        }

        protected void _ConfigureSearch(
            string[] filteringMethods,
            string[] filteringValues)
        {
            GridView.Searchbar.SetFilteringMethods(filteringMethods);

            GridView.Searchbar.SetFilteringValues(filteringValues);
        }

        protected void _BindData(Result<DataTable> result)
        {
            if (!result.IsSuccess)
            {
                MessageBoxManager.ShowError(
                    result?.Message,
                    Language.ar);

                return;
            }

            GridView.DataSource = result.Data.DefaultView;
        }

        protected bool _TrySelectedID(int columnIndex, out int id)
        {
            id = 0;

            object value = GridView.GetSelectedRow(columnIndex);

            if (value == null)
                return false;

            return int.TryParse(
                value.ToString(),
                out id);
        }

        protected bool _TrySelectedID(string columnName, out int id)
        {
            id = 0;

            object value = GridView.GetSelectedRow(columnName);

            if (value == null)
                return false;

            return int.TryParse(
                value.ToString(),
                out id);
        }

        protected bool _IsCancelled()
        {
            object value = GridView.GetSelectedRow("Cancelled");

            if (value == null)
                return false;

            return value.ToString() == "1" ? true : false;
        }
    }
}
