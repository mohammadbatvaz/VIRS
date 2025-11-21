using VIRS.Domain.Core.InspectionRequestAgg.Entities;

namespace VIRS.Domain.Core.ImageAgg.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid InspectionRequestId { get; set; }
        public string ImagePath { get; set; }

        public InspectionRequest InspectionRequest { get; set; }
    }
}
