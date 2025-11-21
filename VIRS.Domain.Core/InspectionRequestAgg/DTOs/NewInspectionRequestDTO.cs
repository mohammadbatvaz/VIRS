using VIRS.Domain.Core.CarAgg.DTOs;
using VIRS.Domain.Core.CarOwnerAgg.DTOs;

namespace VIRS.Domain.Core.InspectionRequestAgg.DTOs
{
    public class NewInspectionRequestDTO
    {
        public NewCarOwnerDTO NewCarOwner { get; set; } = new();
        public Guid CarOwnerId { get; set; } = Guid.Empty;

        public NewCarDTO NewCar { get; set; } = new();
        public Guid CarId { get; set; } = Guid.Empty;

        public List<Stream> ImageStreams { get; set; }
        public List<string> ImagePaths { get; set; }

        public DateTime InspectionDate { get; set; }
        public bool IsAcceptable { get; set; }
    }
}
