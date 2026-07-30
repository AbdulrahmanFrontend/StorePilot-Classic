using DevToolkit.Core;
using DevToolkit.Core.Common;
using DevToolkit.Core.Results;
using DevToolkit.Data.Core;
using DevToolkit.Logging.Managers;
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
    public class SupplierService : BaseBusiness
    {
        public SupplierModel Model { get; private set; }

        public SupplierService()
        {
            Model = new SupplierModel();
            this.Mode = Mode.AddNew;
        }

        private SupplierService(SupplierModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public static Result<SupplierService> GetByID(int id)
        {
            Result<SupplierModel> result = SupplierData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<SupplierService>.Success(
                        new SupplierService(result.Data)
                        );

                return Result<SupplierService>.Failure(
                    "هذا المورد غير مسجل في النظام!");
            }

            return Result<SupplierService>.Failure(
                "فشلت عملية الوصول لبيانات هذا المورد!");
        }

        protected override Result _AddNew()
        {
            Result result = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    if (this.Model == null)
                        throw new InvalidOperationException("مورد غير صالح!");

                    PersonModel person = new PersonModel
                    {
                        PersonID = Model.PersonID,
                        Name = Model.Name,
                        Phone = Model.Phone,
                        Address = Model.Address,
                    };

                    Result AddNewResult = PersonData.AddNew(con, trans, person);

                    _ThrowException(AddNewResult);

                    this.Model.PersonID = person.PersonID;

                    AddNewResult = SupplierData.AddNew(
                        con,
                        trans,
                        this.Model);

                    _ThrowException(AddNewResult);
                });

            if (result.IsSuccess)
            {
                LogManager.LogInfo(
                    $"تمت عملية إضافة المورد {Model.SupplierID} بنجاح.");
                return Result.Success("تمت عملية حفظ بيانات هذا المورد بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات هذا المورد!");
        }

        protected override Result _Update()
        {
            Result result = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    if (this.Model == null)
                        throw new InvalidOperationException("مورد غير صالح!");

                    PersonModel person = new PersonModel
                    {
                        PersonID = Model.PersonID,
                        Name = Model.Name,
                        Phone = Model.Phone,
                        Address = Model.Address,
                    };

                    Result AddNewResult = PersonData.Update(con, trans, person);

                    _ThrowException(AddNewResult);

                    AddNewResult = SupplierData.Update(
                        con,
                        trans,
                        this.Model);

                    _ThrowException(AddNewResult);
                });

            if (result.IsSuccess)
            {
                LogManager.LogInfo(
                    $"تمت عملية تحديث بيانات المورد {Model.SupplierID} بنجاح.");
                return Result.Success(
                    "تمت عملية حفظ بيانات هذا المورد بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات هذا المورد!");
        }

        public override Result Valid()
        {
            Result result = ValidateName();

            if (!result.IsSuccess)
                return result;

            result = ValidatePhone();

            if (!result.IsSuccess)
                return result;

            result = ValidateAddress();

            if (!result.IsSuccess)
                return result;

            result = ValidateNotes();

            if (!result.IsSuccess)
                return result;

            return Result.Success();
        }

        public Result ValidateName()
        {
            Result ValResult = _ValidateProperty(
                nameof(this.Model.Name),
                this.Model);

            if (!ValResult.IsSuccess)
                return ValResult;

            Result<bool> result = PersonData.IsNameExist(
                this.Model.Name,
                this.Model.PersonID);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Failure("هذا الإسم مسجل فعلا في النظام!");

                return Result.Success();
            }

            return Result.Failure("فشلت عملية التحقق من وجود هذا الإسم في النظام!");
        }

        public Result ValidatePhone()
        {
            Result ValResult = _ValidateProperty(
                nameof(this.Model.Phone),
                this.Model);

            if (!ValResult.IsSuccess)
                return ValResult;

            Result<bool> result = PersonData.IsPhoneExist(
                this.Model.Phone,
                this.Model.PersonID);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Failure("رقم الهاتف هذا مسجل فعلا في النظام!");

                return Result.Success();
            }

            return Result.Failure("فشلت عملية التحقق من وجود رقم الهاتف في النظام!");
        }

        public Result ValidateAddress()
            => _ValidateProperty(nameof(this.Model.Address), this.Model);

        public Result ValidateNotes()
            => _ValidateProperty(nameof(this.Model.Notes), this.Model);

        public static Result Activate(int id) => SupplierData.Activate(id);

        public static Result Deactivate(int id) => SupplierData.Deactivate(id);

        public static Result IsExist(int id)
        {
            Result<bool> result = SupplierData.IsFound(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذا المورد غير مسجل في النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذا المورد في النظام!");
        }

        //public static Result<bool> IsActive(int id)
        //{
        //    Result IsFoundResult = IsFound(id);

        //    if (!IsFoundResult.IsSuccess)
        //        return Result<bool>.Failure(IsFoundResult.Message);

        //    Result<bool> result = SupplierData.IsActive(id);

        //    if (result.IsSuccess)
        //        return Result<bool>.Success(result.Data);

        //    return Result<bool>.Failure(
        //        "فشلت عملية التحقق من تفعيل هذا المورد في النظام!");
        //}

        public static Result<DataTable> GetSuppliers(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = SupplierData.GetSuppliers(
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
                "فشلت عملية الحصول على جميع الموردين!");
        }

        public static Result<int> GetCount()
        {
            Result<int> result = SupplierData.GetCount();

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد الموردين!");
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            Result<int> result = SupplierData.GetCount(
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد الموردين!");
        }

        public static Result<DataTable> GetForSelection()
        {
            Result<DataTable> result = SupplierData.GetForSelection();

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure("فشلت عملية الوصول للموردين!");
        }
    }
}
