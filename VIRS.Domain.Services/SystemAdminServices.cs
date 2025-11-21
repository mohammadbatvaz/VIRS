using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.Data;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.Services;
using VIRS.Domain.Core.SystemAdminAgg.DTOs;

namespace VIRS.Domain.Services
{
    public class SystemAdminServices(
        ISystemAdminRepository saRepository) : ISystemAdminServices
    {
        public Result<LoginedAdminDataDTO> Authentication(string username, string password)
        {
            var result = saRepository.Verification(username, password);
            if (result is not null)
                return Result<LoginedAdminDataDTO>.Success("با موفقیت وارد شدید", result);
            return Result<LoginedAdminDataDTO>.Failure("نام کاربری یا رمز عبور وارد شده اشتباه است");
        }
    }
}
