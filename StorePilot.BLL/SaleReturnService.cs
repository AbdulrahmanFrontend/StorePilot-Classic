using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using StorePilot.Core.Models;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public class SaleReturnService : BaseBusiness
    {
        public SaleReturnModel Model { get; private set; }

        private List<SaleReturnItemModel> _Items { get; set; }

        public SaleReturnService()
        {
            this.Model = new SaleReturnModel();
            _Items = new List<SaleReturnItemModel>();
            this.Mode = Mode.AddNew;
        }

        public SaleReturnService(SaleReturnModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public void SetItems(IEnumerable<SaleReturnItemModel> items)
        {
            _Items.Clear();

            _Items.AddRange(items);
        }

        public static Result<SaleReturnService> GetByID(int id)
        {
            Result<SaleReturnModel> result = SaleReturnData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result<SaleReturnService>.Success(
                        new SaleReturnService(result.Data)
                        );

                return Result<SaleReturnService>.Failure(
                    "فاتورة المرتجع هذه غير مسجلة في النظام!");
            }

            return Result<SaleReturnService>.Failure(
                "فشلت عملية الوصول لفاتورة المرتجع هذه!");
        }

        protected override Result _AddNew()
        {
            throw new NotImplementedException();
        }

        protected override Result _Update()
        {
            throw new NotImplementedException();
        }

        public Result ValidateItems()
        {
            foreach(SaleReturnItemModel item in _Items)
            {
                Result<InvoiceItemModel> result = InvoiceItemData.GetSaleInvoiceItem(
                    this.Model.SaleInvoiceID,
                    item.ProductID);

                if (result.IsSuccess && result.Data == null)
                    return Result.Failure("هذا العنصر ليس موجودا ضمن فاتورة البيع!");
                else if (!result.IsSuccess)
                    return Result.Failure(
                        "فشلت عملية الوصول لعنصر من عناصر فاتورة البيع!");

                if (item.Quantity <= 0)
                    return Result.Failure(
                        "يوجد عنصر الكمية المطلوبة منه أصغر من أو تساوي الصفر!");

                if (item.Quantity > result.Data.Quantity)
                    return Result.Failure(
                        "يوجد عنصر الكمية المطلوبة منه " +
                        "أكبر من الكمية المتوفرة في المخزن!");

                item.UnitPrice = result.Data.UnitPrice;
            }

            return Result.Success();
        }
    }
}
