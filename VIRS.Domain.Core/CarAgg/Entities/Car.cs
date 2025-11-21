using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.CarOwnerAgg.Entities;
using VIRS.Domain.Core.CarModelAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.Entities;

namespace VIRS.Domain.Core.CarAgg.Entities
{
    public class Car : BaseEntity
    {
        public LicensePlate Plate { get; set; }
        public string VIN { get; set; }
        public int ManufactureYear { get; set; }
        public Guid CarOwnerId { get; set; }
        public Guid CarModelId { get; set; }

        public CarOwner CarOwner { get; set; }
        public CarModel CarModel { get; set; }
        public List<InspectionRequest> InspectionRequests { get; set; }
    }
}
