using System.ComponentModel.DataAnnotations;
using VIRS.Domain.Core.CarAgg.Entities;

namespace VIRS.Domain.Core.CarAgg.DTOs
{
    public class NewCarDTO
    {
        public LicensePlate Plate { get; set; }
        public string VIN { get; set; }
        public int ManufactureYear { get; set; }
        public string CarModelManufacturer { get; set; }
        public string CarModelFamily { get; set; }
        public string CarModelName { get; set; }
        public Guid CarModelId { get; set; } = Guid.Empty;
    }
}
