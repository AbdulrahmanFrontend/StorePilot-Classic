using DevToolkit.BaseWinForms.Controls.UserControls;
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

namespace StorePilot.UI.Global.Controls
{
    public partial class ucListScreen : ucListScreenBase
    {
        protected int _CurrentPage = 1;
        protected int _PageSize = 5;

        protected int _FilterMethodIndex = 0;
        protected int _FilterValueIndex = 0;
        protected string _FilterValue = string.Empty;

        public ucListScreen()
        {
            InitializeComponent();
        }

        private void ucListScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = Theme.Border;
            this.ForeColor = Theme.Text;

            this.TitleBackColor = Theme.Surface;
            this.TitleTextColor = Theme.Text;

            this.Grid.BackColor = Theme.Border;
            this.Grid.ForeColor = Theme.Text;

            this.Grid.AddNewButtonImage = Resources.add;
            this.Grid.Size = new Size(1457, 600);

            this.Grid.ImportButtonVisible = false;
            this.Grid.Searchbar.ShowCancelButton = false;

            Grid.SetPageSizes(new[] { 50, 100, 200, 300, 400 });
        }

        protected void _SetPagesCount(Result<int> result)
        {
            if (result.IsSuccess)
            {
                int Count = result.Data / _PageSize;

                if (result.Data % _PageSize != 0)
                    Count++;

                Grid.SetPagesCount(Count);
            }
            else
                MessageBoxManager.ShowError(result.Message, Language.ar);
        }

        protected void _ConfigureSearch(
            string[] filteringMethods, 
            string[] filteringValues)
        {
            Grid.Searchbar.SetFilteringMethods(filteringMethods);

            Grid.Searchbar.SetFilteringValues(filteringValues);
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

            Grid.DataSource = result.Data.DefaultView;
        }

        protected bool _TrySelectedID(int columnIndex, out int id)
        {
            id = 0;

            object value = Grid.GetSelectedRow(columnIndex);

            if (value == null)
                return false;

            return int.TryParse(
                value.ToString(),
                out id);
        }

        protected bool _TrySelectedID(string columnName, out int id)
        {
            id = 0;

            object value = Grid.GetSelectedRow(columnName);

            if (value == null)
                return false;

            return int.TryParse(
                value.ToString(),
                out id);
        }

        protected bool _IsActive()
        {
            object value = Grid.GetSelectedRow("Active");

            if (value == null)
                return false;

            return value.ToString() == "1" ? true : false;
        }

        protected bool _IsCancelled()
        {
            object value = Grid.GetSelectedRow("Cancelled");

            if (value == null)
                return false;

            return value.ToString() == "1" ? true : false;
        }
    }
}
