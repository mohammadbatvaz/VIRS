using VIRS.Domain.Core.SystemAdminAgg.DTOs;

namespace VIRS.Domain.Core.SystemAdminAgg.Contracts.Data
{
    public interface ISystemAdminRepository
    {
        LoginedAdminDataDTO? Verification(string username, string password);
    }
}
