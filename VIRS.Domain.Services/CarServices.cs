using VIRS.Domain.Core.CarAgg.Contracts.Data;
using VIRS.Domain.Core.CarAgg.Contracts.Services;
using VIRS.Domain.Core.CarAgg.DTOs;
using VIRS.Domain.Core.CarOwnerAgg.Entities;

namespace VIRS.Domain.Services
{
    public class CarServices(
        ICarRepository cRepository) : ICarServices
    {
        public Guid EnsureCarExists(NewCarDTO dto, Guid carOwnerId)
        {
            var result = cRepository.Exists(dto.VIN);

            return result == Guid.Empty
                ? cRepository.Add(dto, carOwnerId)
                : result;
        }
    }
}
