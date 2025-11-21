using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.CarOwnerAgg.Entities;
using VIRS.Domain.Core.ImageAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;

namespace VIRS.Domain.Core.InspectionRequestAgg.Entities
{
    public class InspectionRequest : BaseEntity
    {
        public Guid CarId { get; set; }
        public Guid CarOwnerId { get; set; }

        public DateTime? InspectionDate { get; set; }
        public InspectionStatusEnum Status { get; set; }
        public DateTime? StatusChangedAt { get; set; }
        public string? TrackingNumber { get; set; }
        public bool IsAcceptable { get; set; }

        public Car Car { get; set; }
        public CarOwner CarOwner { get; set; }
        public List<Image> Images { get; set; }
     }
}
