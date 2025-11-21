using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;

namespace VIRS.Domain.Core.InspectionRequestAgg.Contracts.Services
{
    public interface IInspectionRequestServices
    {
        List<DayReservationCountsDTO> GetDailyReservationCounts(DateTime startDate, DateTime endDate);
        int DayReservationCount(DateTime date);
        bool IsVisitedThisYear(LicensePlate plate);
        string? AddRequest(NewInspectionRequestDTO dto);
        Result<InspectionRequestInfoDTO> LoadRequest(string trackingNumber);
        RequestStatisticsDTO Statistics();
        List<InspectionRequestSummaryInfoDTO> GetAllRequestInDay(DateTime date);
        void ChangeOfStatus(string trackingNumber, InspectionStatusEnum newStatus);
    }
}
