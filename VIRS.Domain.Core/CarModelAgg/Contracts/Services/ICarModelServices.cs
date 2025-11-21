using VIRS.Domain.Core.CarAgg.DTOs;
using VIRS.Domain.Core.CarModelAgg.DTOs;

namespace VIRS.Domain.Core.CarModelAgg.Contracts.Services
{
    public interface ICarModelServices
    {
        List<CarModelDTO> GetAll();
        Guid EnsureCarModelExists(NewCarDTO dto);
    }
}
