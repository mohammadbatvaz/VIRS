namespace VIRS.Domain.Core.InspectionRequestAgg.DTOs
{
    public class RequestStatisticsDTO
    {
        public int Total { get; set; }
        public int Rejected { get; set; }
        public int Approved { get; set; }
        public int Pending { get; set; }
    }
}
