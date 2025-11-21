using VIRS.Domain.Core.CarOwnerAgg.Contracts.Data;
using VIRS.Domain.Core.CarOwnerAgg.DTOs;
using VIRS.Domain.Core.CarOwnerAgg.Entities;
using VIRS.Infra.DataBase.EFCoreSqlServer;

namespace VIRS.Infra.DataAccess.EFCore
{
    public class CarOwnerRepository(AppDbContext _db) : ICarOwnerRepository
    {
        public Guid Exists(string nid)
        {
            var owner = _db.CarOwners.SingleOrDefault(co => co.NID == nid);
            return owner?.Id ?? Guid.Empty;
        }

        public Guid Add(NewCarOwnerDTO dto)
        {
            var owner = new CarOwner
            {
                NID = dto.NID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber
            };
            
            _db.CarOwners.Add(owner);
            _db.SaveChanges();
            return owner.Id;
        }
    }
}
