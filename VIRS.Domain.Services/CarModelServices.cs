using VIRS.Domain.Core.CarAgg.DTOs;
using VIRS.Domain.Core.CarModelAgg.Contracts.Data;
using VIRS.Domain.Core.CarModelAgg.Contracts.Services;
using VIRS.Domain.Core.CarModelAgg.DTOs;

namespace VIRS.Domain.Services
{
    public class CarModelServices(
        ICarModelRepository cmRepositoryRepo) : ICarModelServices
    {
        public List<CarModelDTO> GetAll() 
            => cmRepositoryRepo.GetAll();

        public Guid EnsureCarModelExists(NewCarDTO dto)
            => cmRepositoryRepo.Exists(dto.CarModelManufacturer, dto.CarModelFamily, dto.CarModelName);
    }
}
