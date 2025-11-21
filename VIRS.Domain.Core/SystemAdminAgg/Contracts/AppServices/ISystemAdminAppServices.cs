using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.SystemAdminAgg.DTOs;

namespace VIRS.Domain.Core.SystemAdminAgg.Contracts.AppServices
{
    public interface ISystemAdminAppServices
    {
        Result<LoginedAdminDataDTO> LoginToPanel(string username, string password);
    }
}
