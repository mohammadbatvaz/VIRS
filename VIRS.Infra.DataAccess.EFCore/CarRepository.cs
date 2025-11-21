using VIRS.Domain.Core.CarAgg.Contracts.Data;
using VIRS.Domain.Core.CarAgg.DTOs;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Infra.DataBase.EFCoreSqlServer;

namespace VIRS.Infra.DataAccess.EFCore
{
    public class CarRepository(AppDbContext _db) : ICarRepository
    {
        public Guid Exists(string vin)
        {
            var car = _db.Cars.SingleOrDefault(co => co.VIN == vin);
            return car?.Id ?? Guid.Empty;
        }

        public Guid Add(NewCarDTO dto, Guid carOwnerId)
        {
            var car = new Car
            {
                VIN = dto.VIN,
                CarModelId = dto.CarModelId,
                ManufactureYear = dto.ManufactureYear,
                CarOwnerId = carOwnerId,
                Plate = new LicensePlate()
                {
                    FirstPart = dto.Plate.FirstPart,
                    Letter = dto.Plate.Letter,
                    SecondPart = dto.Plate.SecondPart,
                    ProvinceCode = dto.Plate.ProvinceCode
                }
            };

            _db.Cars.Add(car);
            _db.SaveChanges();
            return car.Id;
        }
    }
}
