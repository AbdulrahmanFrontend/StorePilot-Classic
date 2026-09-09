using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.FakeData
{
    public sealed class FakeProductDataSource : IProductDataSource
    {
        private readonly FakeDataStore _store = FakeDataStore.Instance;

        public IReadOnlyList<FakeProduct> GetProducts() => _store.Products;
        public void Add(FakeProduct product) => _store.AddProduct(product);
    }
}
