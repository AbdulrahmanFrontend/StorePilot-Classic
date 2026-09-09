using StorePilot.WinForms.Foundation.FakeData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Pages
{
    public sealed class PaymentMethodsPage : ReferenceDataPage
    {
        public PaymentMethodsPage() : base("طرق الدفع", FakeDataStore.Instance.PaymentMethods) { }
    }
}
