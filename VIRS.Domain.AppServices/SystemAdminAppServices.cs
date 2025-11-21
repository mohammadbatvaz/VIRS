using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.AppServices;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.Services;
using VIRS.Domain.Core.SystemAdminAgg.DTOs;

namespace VIRS.Domain.AppServices
{
    public class SystemAdminAppServices(
        ISystemAdminServices saServices) : ISystemAdminAppServices
    {
        public Result<LoginedAdminDataDTO> LoginToPanel(string username, string password)
            => saServices.Authentication(username, password);
    }
}
