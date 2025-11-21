using VIRS.Domain.Core.InspectionRequestAgg.Enums;

namespace VIRS.Domain.Core.InspectionRequestAgg.DTOs
{
    public class InspectionRequestInfoDTO
    {
        public Guid RequestId { get; set; }
        public string CarOwnerNID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlat { get; set; }
        public string CarVIN { get; set; }
        public string CarModel { get; set; }
        public string TrackingNumber { get; set; }
        public int CarManufactureYear { get; set; }
        public DateTime InspectionDate { get; set; }
        public string? ShamsiInspectionDate { get; set; }
        public InspectionStatusEnum Status { get; set; }
        public List<string> ImagesPaths { get; set; }
    }
}
