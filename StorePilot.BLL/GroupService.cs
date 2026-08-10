using DevToolkit.Core.Results;
using StorePilot.Core.Models;
using StorePilot.DAL;
using System.Data;

namespace StorePilot.BLL
{
    public class GroupService
    {
        public GroupModel Model { get; private set; }

        public GroupService()
        {
            this.Model = new GroupModel();
        }

        public GroupService(GroupModel model)
        {
            this.Model = model;
        }

        public static Result<GroupService> Find(int id)
        {
            Result<GroupModel> result = GroupData.Find(id);

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
            {
                if (result.Data != null)
                    return result;

                return Result<DataTable>.Failure(
                    "لا يوجد أي مجموعات مسجلة في النظام!");
            }

            return Result<DataTable>.Failure("فشلت عملية الوصول لجميع المجموعات!");
        }

        public static Result IsExist(int id)
        {
            Result<bool> result = GroupData.IsExist(id);

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
