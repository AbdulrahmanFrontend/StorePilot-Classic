using DevToolkit.BaseWinForms.Controls.UserControls;
using DevToolkit.BaseWinForms.Managers;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
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
        protected int _PageSize = 50;

        protected int _FilterMethodIndex;
        protected string _FilterValue = string.Empty;

        public ucListScreen()
        {
            InitializeComponent();
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

        protected void _ConfigureSearch(params string[] methods)
            => Grid.Searchbar.SetFilteringMethod(methods);

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

        private void ucListScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = AutoPartsColors.Border;
            this.ForeColor = AutoPartsColors.TextLight;

            Headerbar.ButtonBackgroundImage = Resources.add;
            Headerbar.BackColor = AutoPartsColors.Surface;
            Headerbar.ForeColor = AutoPartsColors.TextPrimary;

            Grid.Size = new Size(1457, 600);
            Grid.BackColor = AutoPartsColors.Border;
            Grid.ForeColor = AutoPartsColors.TextPrimary;
            Grid.Searchbar.ShowCancelButton = false;
        }
    }
}
