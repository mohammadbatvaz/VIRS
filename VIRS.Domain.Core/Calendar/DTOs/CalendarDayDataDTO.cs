namespace VIRS.Domain.Core.Calendar.DTOs
{
    public class CalendarDayDataDTO
    {
        public bool IsEmpty { get; set; }
        public bool IsAvailable { get; set; }
        public int? NotReservedCunt { get; set; }
        public string? Message { get; set; }
        public string? ShamsiDate { get; set; }
        public DateTime? DateValue { get; set; }
    }
}
