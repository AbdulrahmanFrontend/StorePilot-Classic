using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.FakeData
{
    public interface IPartyDataSource
    {
        IReadOnlyList<FakeParty> GetCustomers();
        IReadOnlyList<FakeParty> GetSuppliers();
        void AddCustomer(FakeParty party);
        void AddSupplier(FakeParty party);
    }
}
