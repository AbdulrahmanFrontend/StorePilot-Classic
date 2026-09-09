using StorePilot.WinForms.Foundation.FakeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Pages
{
    public sealed class GroupsPage : ReferenceDataPage
    {
        public GroupsPage() : base("المجموعات", FakeDataStore.Instance.Groups) { }
    }
}
