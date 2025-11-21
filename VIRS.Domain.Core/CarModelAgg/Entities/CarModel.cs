using System.Diagnostics.Metrics;
using VIRS.Domain.Core._CommentAgg.Entities;

namespace VIRS.Domain.Core.CarModelAgg.Entities
{
    public class CarModel
    {
        public Guid Id { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer} - {Family} {Name}";
        }
    }
}
