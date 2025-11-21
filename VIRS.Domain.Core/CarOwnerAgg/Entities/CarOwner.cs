using System.Diagnostics.Metrics;
using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.Entities;

namespace VIRS.Domain.Core.CarOwnerAgg.Entities
{
    public class CarOwner : BaseEntity
    {
        public string NID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public List<Car> Cars { get; set; }
        public List<InspectionRequest> inspectionRequests { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
