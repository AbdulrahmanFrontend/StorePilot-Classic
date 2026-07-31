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
    public class UnitService
    {
        public UnitModel Model { get; private set; }

        public UnitService()
        {
            this.Model = new UnitModel();
        }

        public UnitService(UnitModel model)
        {
            this.Model = model;
        }

        public static Result<UnitService> Find(int id)
        {
            Result<UnitModel> result = UnitData.Find(id);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result<UnitService>.Failure("هذه الوحدة غير مسجلة في النظام!");

                return Result<UnitService>.Success(new UnitService(result.Data));
            }

            return Result<UnitService>.Failure("فشلت عملية الوصول لبيانات هذه الوحدة!");
        }

        public static Result<DataTable> GetAll()
        {
            Result<DataTable> result = UnitData.GetAll();

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure("فشلت عملية الوصول لجميع وحدات القياس!");
        }

        public static Result IsExist(int id)
        {
            Result<bool> result = UnitData.IsExist(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه الوحدة غير مسجلة في النظام!");
            }

            return Result.Failure("فشلت عملية التحقق من وجود هذه الوحدة في النظام!");
        }
    }
}
