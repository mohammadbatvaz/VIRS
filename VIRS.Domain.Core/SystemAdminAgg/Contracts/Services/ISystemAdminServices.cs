using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.SystemAdminAgg.DTOs;

namespace VIRS.Domain.Core.SystemAdminAgg.Contracts.Services
{
    public interface ISystemAdminServices
    {
        Result<LoginedAdminDataDTO> Authentication(string username, string password);
    }
}
