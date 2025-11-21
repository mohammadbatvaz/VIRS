namespace VIRS.Domain.Core.InspectionRequestAgg.DTOs
{
    public class ListOfRequestInDayDTO
    {
        public DateTime Date { get; set; }
        public string ShamsiDate { get; set; }
        public List<InspectionRequestSummaryInfoDTO> RequestList { get; set; }
    }
}
