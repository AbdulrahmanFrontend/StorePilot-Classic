using StorePilot.WinForms.Foundation.FakeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Pages
{
    public sealed class UnitsPage : ReferenceDataPage
    {
        public UnitsPage() : base("الوحدات", FakeDataStore.Instance.Units) { }
    }
}
