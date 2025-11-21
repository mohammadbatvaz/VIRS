using VIRS.Domain.Core.CarAgg.DTOs;

namespace VIRS.Domain.Core.CarAgg.Contracts.Data
{
    public interface ICarRepository
    {
        Guid Exists(string nid);

        Guid Add(NewCarDTO dto, Guid carOwnerId);
    }
}
