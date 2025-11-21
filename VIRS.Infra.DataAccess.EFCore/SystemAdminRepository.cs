using Microsoft.EntityFrameworkCore;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.Data;
using VIRS.Domain.Core.SystemAdminAgg.DTOs;
using VIRS.Infra.DataBase.EFCoreSqlServer;

namespace VIRS.Infra.DataAccess.EFCore
{
    public class SystemAdminRepository(AppDbContext _db) : ISystemAdminRepository
    {
        public LoginedAdminDataDTO? Verification(string username, string password)
        {
            return _db.SystemsAdmins
                .AsNoTracking()
                .Where(sa => sa.Username == username && sa.Password == password)
                .Select(sa => new LoginedAdminDataDTO()
                {
                    Id = sa.Id,
                    FullName = sa.FirstName + " " + sa.LastName
                }).FirstOrDefault();
        }
    }
}
