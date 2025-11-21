using VIRS.Domain.Core.CarModelAgg.Contracts.AppServices;
using VIRS.Domain.Core.CarModelAgg.Contracts.Services;
using VIRS.Domain.Core.CarModelAgg.DTOs;

namespace VIRS.Domain.AppServices
{
    public class CarModelAppServices(
        ICarModelServices cmServices) : ICarModelAppServices
    {
        public List<CarModelDTO> All() => cmServices.GetAll();
    }
}
