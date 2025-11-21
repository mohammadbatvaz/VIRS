using VIRS.Domain.Core.CarModelAgg.DTOs;

namespace VIRS.Domain.Core.CarModelAgg.Contracts.Data
{
    public interface ICarModelRepository
    {
        List<CarModelDTO> GetAll();

        Guid Exists(string manufacturer, string family, string name);
    }
}
