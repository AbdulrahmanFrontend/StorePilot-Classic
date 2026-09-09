using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.FakeData
{
    public sealed class FakePartyDataSource : IPartyDataSource
    {
        private readonly FakeDataStore _store = FakeDataStore.Instance;

        public IReadOnlyList<FakeParty> GetCustomers() => _store.Customers;
        public IReadOnlyList<FakeParty> GetSuppliers() => _store.Suppliers;

        public void AddCustomer(FakeParty party) => _store.AddCustomer(party);
        public void AddSupplier(FakeParty party) => _store.AddSupplier(party);
    }
}
