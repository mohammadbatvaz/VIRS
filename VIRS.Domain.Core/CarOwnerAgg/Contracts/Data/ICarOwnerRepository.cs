using VIRS.Domain.Core.CarOwnerAgg.DTOs;

namespace VIRS.Domain.Core.CarOwnerAgg.Contracts.Data
{
    public interface ICarOwnerRepository
    {
        public Guid Exists(string nid);

        public Guid Add(NewCarOwnerDTO dto);
    }
}
