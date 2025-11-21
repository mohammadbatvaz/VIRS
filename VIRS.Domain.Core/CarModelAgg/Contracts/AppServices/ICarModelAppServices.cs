using VIRS.Domain.Core.CarModelAgg.DTOs;

namespace VIRS.Domain.Core.CarModelAgg.Contracts.AppServices
{
    public interface ICarModelAppServices
    {
        List<CarModelDTO> All();
    }
}
