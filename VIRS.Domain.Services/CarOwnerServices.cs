using VIRS.Domain.Core.CarOwnerAgg.Contracts.Data;
using VIRS.Domain.Core.CarOwnerAgg.Contracts.Services;
using VIRS.Domain.Core.CarOwnerAgg.DTOs;

namespace VIRS.Domain.Services
{
    public class CarOwnerServices(
        ICarOwnerRepository coRepository) : ICarOwnerServices
    {
        public Guid EnsureCarOwnerExists(NewCarOwnerDTO dto)
        {
            var result = coRepository.Exists(dto.NID);

            return result == Guid.Empty 
                ? coRepository.Add(dto) 
                : result;
        }
    }
}
