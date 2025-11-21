using VIRS.Domain.Core.InspectionRequestAgg.Enums;

namespace VIRS.Domain.Core.InspectionRequestAgg.DTOs
{
    public class InspectionRequestSummaryInfoDTO
    {
        public Guid RequestId { get; set; }
        public string TrackingNumber { get; set; }
        public string FullName { get; set; }
        public string CarPlat { get; set; }
        public string CarModel { get; set; }
        public InspectionStatusEnum Status { get; set; }
    }
}
