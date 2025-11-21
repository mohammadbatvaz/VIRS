using VIRS.Domain.Core.CarAgg.DTOs;

namespace VIRS.Domain.Core.CarAgg.Contracts.Services
{
    public interface ICarServices
    {
        Guid EnsureCarExists(NewCarDTO dto, Guid carOwnerId);
    }
}
