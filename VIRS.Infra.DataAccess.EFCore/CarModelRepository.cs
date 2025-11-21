using System.Security.Cryptography;
using VIRS.Domain.Core.CarAgg.DTOs;
using VIRS.Domain.Core.CarModelAgg.Contracts.Data;
using VIRS.Domain.Core.CarModelAgg.DTOs;
using VIRS.Infra.DataBase.EFCoreSqlServer;

namespace VIRS.Infra.DataAccess.EFCore
{
    public class CarModelRepository(AppDbContext _db) : ICarModelRepository
    {
        public List<CarModelDTO> GetAll()
        {
            return _db.CarModels
                .Select(cm => new CarModelDTO()
                {
                    Id = cm.Id,
                    Name = cm.Name,
                    Family = cm.Family,
                    Manufacturer = cm.Manufacturer
                }).ToList();
        }

        public Guid Exists(string manufacturer, string family, string name)
        {
            var model = _db.CarModels.SingleOrDefault(cm => cm.Manufacturer == manufacturer 
                                                            && cm.Family == family
                                                            && cm.Name == name);
            return model?.Id ?? Guid.Empty;
        }
    }
}
