using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.Calendar.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;

namespace VIRS.Domain.Core.InspectionRequestAgg.Contracts.AppServices
{
    public interface IInspectionRequestAppServices
    {
        List<List<CalendarDayDataDTO>> ReservationsCalendarGenerator();
        Result<string> InspectionRequestGenerator(NewInspectionRequestDTO request);
        Result<InspectionRequestInfoDTO> LoadingRequestInfo(string trackingNumber);
        RequestStatisticsDTO RequestStatistics();
        List<ListOfRequestInDayDTO> RequestList();
        void ChangeOfStatus(string trackingNumber, InspectionStatusEnum newStatus);
    }
}
