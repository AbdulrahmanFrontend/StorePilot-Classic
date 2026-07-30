using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Guards;
using DevToolkit.Core.Results;
using StorePilot.Core.Models;
using StorePilot.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePilot.BLL
{
    public class ProductService : BaseBusiness
    {
        public ProductModel Model { get; private set; }

        public ProductService()
        {
            this.Model = new ProductModel();
            this.Mode = Mode.AddNew;
        }

        private ProductService(ProductModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public static Result<ProductService> GetByID(int id)
        {
            Result<ProductModel> result = ProductData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<ProductService>.Success(
                        new ProductService(result.Data)
                        );

                return Result<ProductService>.Failure(
                    "هذا الصنف غير مسجل في هذا النظام!");
            }

            return Result<ProductService>.Failure(
                "فشلت عملية الوصول لبيانات هذا الصنف!");
        }

        protected override Result _AddNew() => ProductData.AddNew(this.Model);

        protected override Result _Update() => ProductData.Update(this.Model);

        public override Result Valid()
        {
            Result result = ValidateProductName();

            if (!result.IsSuccess)
                return result;

            result = ValidateBarCode();

            if (!result.IsSuccess)
                return result;

            result = ValidateGroupID();

            if (!result.IsSuccess)
                return result;

            result = ValidateUnitID();

            if (!result.IsSuccess)
                return result;

            result = ValidateMinQuantity();

            if (!result.IsSuccess)
                return result;

            result = ValidatePurchasePrice();

            if (!result.IsSuccess)
                return result;

            result = ValidateSalePrice();

            if (!result.IsSuccess)
                return result;

            result = ValidateNotes();

            if (!result.IsSuccess)
                return result;

            return Result.Success();
        }

        public Result ValidateProductName()
        {
            Result ValResult = _ValidateProperty(
                nameof(this.Model.ProductName),
                this.Model);

            if (!ValResult.IsSuccess)
                return ValResult;

            Result<bool> result = ProductData.IsProductNameFound(
                this.Model.ProductName,
                this.Model.ProductID);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Failure("اسم الصنف مسجل فعلا في النظام!");

                return Result.Success();
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود اسم الصنف في هذا النظام!");
        }

        public Result ValidateBarCode()
        {
            Result ValResult = _ValidateProperty(nameof(this.Model.BarCode), this.Model);

            if (!ValResult.IsSuccess)
                return ValResult;

            if (!Guard.HasValue(this.Model.BarCode))
                return Result.Success();

            Result<bool> result = ProductData.IsBarCodeFound(
                this.Model.BarCode,
                this.Model.ProductID);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Failure("هذا الباركود مسجل بالفعل في النظام!");

                return Result.Success();
            }
            else
                return Result.Failure("فشلت عملية التحقق من وجود هذا الباركود!");
        }

        public Result ValidateGroupID()
            => GroupService.IsExist(this.Model.GroupID);

        public Result ValidateUnitID()
            => UnitService.IsFound(this.Model.UnitID);

        public Result ValidateMinQuantity()
            => _ValidateProperty(nameof(this.Model.MinQuantity), this.Model);

        public Result ValidateSalePrice()
            => _ValidateProperty(nameof(this.Model.SalePrice), this.Model);

        public Result ValidatePurchasePrice()
            => _ValidateProperty(nameof(this.Model.PurchasePrice), this.Model);

        public Result ValidateNotes() =>
            _ValidateProperty(nameof(this.Model.Notes), this.Model);

        public static Result Activate(int id) => ProductData.Activate(id);

        public static Result Deactivate(int id) => ProductData.Deactivate(id);

        public static Result IsFound(int id)
        {
            Result<bool> result = ProductData.IsFound(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذا المنتج غير مسجل في هذا النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذا المنتج في النظام!");
        }

        //public static Result<bool> IsActive(int id)
        //{
        //    Result IsFoundResult = IsFound(id);

        //    if (!IsFoundResult.IsSuccess)
        //        return Result<bool>.Failure(IsFoundResult.Message);

        //    Result<bool> result = ProductData.IsActive(id);

        //    if (result.IsSuccess)
        //        return Result<bool>.Success(result.Data);

        //    return Result<bool>.Failure(
        //        "فشلت عملية التحقق من تفعيل هذا الصنف في النظام!");
        //}

        public static Result<int> GetCount()
        {
            Result<int> result = ProductData.GetCount();

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد الأصناف!");
        }

        public static Result<DataTable> GetLowStockProducts()
        {
            Result<DataTable> result = ProductData.GetLowStockProducts();

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<DataTable>.Success(default);
            }

            return Result<DataTable>.Failure(
                "فشلت عملية الحصول على أكثر 10 أصناف نقصا من المخزن!");
        }

        public static Result<DataTable> GetProducts(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = ProductData.GetProducts(
                offset,
                pageSize,
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return result;

                return Result<DataTable>.Success(default);
            }

            return Result<DataTable>.Failure(
                "فشلت عملية الحصول على جميع الأصناف!");
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            Result<int> result = ProductData.GetCount(
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure(
                "فشلت عملية الحصول على عدد الأصناف!");
        }

        public static Result<DataTable> GetForSelection()
        {
            Result<DataTable> result = ProductData.GetForSelection();

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure("فشلت عملية الوصول لبيانات جميع الأصناف!");
        }
    }
}
