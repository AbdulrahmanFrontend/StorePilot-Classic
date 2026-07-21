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
    public class GroupService
    {
        public GroupModel Model { get; private set; }

        public GroupService()
        {
            Model = new GroupModel();
        }

        public GroupService(GroupModel model)
        {
            Model = model;
        }

        public static Result<GroupService> GetByID(int id)
        {
            Result<GroupModel> result = GroupData.GetByID(id);

            if (result.IsSuccess)
            {
                if (result.Data == null)
                    return Result<GroupService>.Failure(
                        "هذه المجموعة غير مسجلة في النظام!");

                return Result<GroupService>.Success(new GroupService(result.Data));
            }

            return Result<GroupService>.Failure(
                "فشلت عملية الوصول لبيانات هذه المجموعة!");
        }

        public static Result<DataTable> GetAll()
        {
            Result<DataTable> result = GroupData.GetAll();

            if (result.IsSuccess)
                return result;

            return Result<DataTable>.Failure("فشلت عملية الوصول لجميع المجموعات!");
        }

        public static Result IsFound(int id)
        {
            Result<bool> result = GroupData.IsFound(id);

            if (result.IsSuccess)
            {
                if (result.Data)
                    return Result.Success();

                return Result.Failure("هذه المجموعة غير مسجلة في النظام!");
            }

            return Result.Failure("فشلت عملية التحقق من وجود هذه المجموعة في النظام!");
        }
    }
}
