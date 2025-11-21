using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;

namespace VIRS.Domain.Core.InspectionRequestAgg.Contracts.Data
{
    public interface IInspectionRequestRepository
    {
        List<DayReservationCountsDTO> GetReservationCountByDateRange(DateTime startDate, DateTime endDate);
        int GetReservationCountByDate(DateTime date);
        bool IsVisited(LicensePlate plate);
        string? Add(NewInspectionRequestDTO dto, string? trackingNumber = null);
        InspectionRequestInfoDTO? GetAcceptedRequest(string trackingNumber);
        int CountTotal();
        int CountRejected();
        int CountApproved();
        int CountPending();
        List<InspectionRequestSummaryInfoDTO> GetAllRequestInDay(DateTime date);
        void UpdateStatus(string trackingNumber, InspectionStatusEnum status);
    }
}
