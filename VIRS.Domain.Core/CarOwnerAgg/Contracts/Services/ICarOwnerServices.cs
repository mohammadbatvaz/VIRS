using VIRS.Domain.Core.CarOwnerAgg.DTOs;

namespace VIRS.Domain.Core.CarOwnerAgg.Contracts.Services
{
    public interface ICarOwnerServices
    {
        Guid EnsureCarOwnerExists(NewCarOwnerDTO dto);
    }
}
