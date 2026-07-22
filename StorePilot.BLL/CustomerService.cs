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
    public class CustomerService : BaseBusiness
    {
        public CustomerModel Model { get; private set; }

        public CustomerService()
        {
            Model = new CustomerModel();
            this.Mode = Mode.AddNew;
        }

        private CustomerService(CustomerModel model)
        {
            this.Model = model;
            this.Mode = Mode.Update;
        }

        public static Result<CustomerService> GetByID(int id)
        {
            Result<CustomerModel> result = CustomerData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                    return Result<CustomerService>.Success(
                        new CustomerService(result.Data)
                        );

                return Result<CustomerService>.Failure("هذا العميل غير مسجل في النظام.");
            }

            return Result<CustomerService>.Failure(
                "فشلت عملية الوصول لبيانات هذا العميل.");
        }

        protected override Result _AddNew()
        {
            Result result = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    if (this.Model == null)
                        throw new InvalidOperationException("عميل غير صالح!");

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

                    AddNewResult = CustomerData.AddNew(con, trans, this.Model);

                    _ThrowException(AddNewResult);
                });

            if (result.IsSuccess)
            {
                LogManager.LogInfo(
                    $"تمت عملية إضافة هذا العميل {Model.CustomerID} بنجاح.");
                return Result.Success("تمت عملية حفظ بيانات هذا العميل بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات هذا العميل!");
        }

        protected override Result _Update()
        {
            Result result = DbManager.Current?.ExecuteTransaction(
                (con, trans) =>
                {
                    if (this.Model == null)
                        throw new InvalidOperationException("عميل غير صالح!");

                    PersonModel person = new PersonModel
                    {
                        PersonID = Model.PersonID,
                        Name = Model.Name,
                        Phone = Model.Phone,
                        Address = Model.Address,
                    };

                    Result UpdateResult = PersonData.Update(con, trans, person);

                    _ThrowException(UpdateResult);

                    UpdateResult = CustomerData.Update(
                        con,
                        trans,
                        this.Model);

                    _ThrowException(UpdateResult);
                });

            if (result.IsSuccess)
            {
                LogManager.LogInfo(
                    $"تمت عملية تحديث بيانات هذا العميل {Model.CustomerID} بنجاح.");
                return Result.Success("تمت عملية حفظ بيانات هذا العميل بنجاح.");
            }

            return Result.Failure("فشلت عملية حفظ بيانات هذا العميل!");
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

            Result<bool> result = PersonData.IsFound(
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
                this.Model); ;

            if (!ValResult.IsSuccess)
                return ValResult;

            Result<bool> result = PersonData.IsPhoneFound(
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

        public static Result Activate(int id) => CustomerData.Activate(id);

        public static Result Deactivate(int id) => CustomerData.Deactivate(id);

        public static Result IsFound(int id)
        {
            Result<bool> result = CustomerData.IsFound(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذا العميل غير مسجل في النظام!");
            }

            return Result.Failure(
                "فشلت عملية التحقق من وجود هذا العميل في النظام!");
        }

        public static Result<bool> IsActive(int id)
        {
            Result IsFoundResult = IsFound(id);

            if (!IsFoundResult.IsSuccess)
                return Result<bool>.Failure(IsFoundResult.Message);

            Result<bool> result = CustomerData.IsActive(id);

            if (result.IsSuccess)
                return Result<bool>.Success(result.Data);

            return Result<bool>.Failure(
                "فشلت عملية التحقق من تفعيل هذا العميل في النظام!");
        }

        public static Result<int> GetCount()
        {
            Result<int> result = CustomerData.GetCount();

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد العملاء!");
        }

        public static Result<int> GetCount(
            int filterMethodIndex,
            string filterValue)
        {
            Result<int> result = CustomerData.GetCount(
                filterMethodIndex,
                filterValue);

            if (result.IsSuccess)
                return result;

            return Result<int>.Failure("فشلت عملية الحصول على عدد العملاء!");
        }

        public static Result<DataTable> GetCustomers(
            int currentPage,
            int pageSize,
            int filterMethodIndex,
            string filterValue)
        {
            int offset = (currentPage - 1) * pageSize;

            Result<DataTable> result = CustomerData.GetCustomers(
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
                "فشلت عملية الحصول على جميع العملاء!");
        }

        public static Result<DataTable> GetForSelection()
        {
            Result<DataTable> result = CustomerData.GetForSelection();

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure("فشلت عملية الوصول للعملاء!");
        }
    }
}
