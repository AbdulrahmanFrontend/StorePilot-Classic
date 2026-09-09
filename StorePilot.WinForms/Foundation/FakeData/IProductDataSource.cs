using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.WinForms.Foundation.FakeData
{
    public interface IProductDataSource
    {
        IReadOnlyList<FakeProduct> GetProducts();
        void Add(FakeProduct product);
    }
}
