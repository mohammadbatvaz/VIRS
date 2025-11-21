using System.ComponentModel;
using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.Data;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.Services;
using VIRS.Domain.Core.InspectionRequestAgg.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;

namespace VIRS.Domain.Services
{
    public class InspectionRequestServices(
        IInspectionRequestRepository irRepository) : IInspectionRequestServices
    {
        public List<DayReservationCountsDTO> GetDailyReservationCounts(DateTime startDate, DateTime endDate)
        {
            var DaysReserved = irRepository.GetReservationCountByDateRange(startDate, endDate);
            var allDays = new List<DayReservationCountsDTO>();
            while (startDate <= endDate)
            {
                var dayData = DaysReserved.FirstOrDefault(dr => dr.Date.Date == startDate.Date);
                allDays.Add(new DayReservationCountsDTO()
                {
                    Date = startDate,
                    Count = dayData?.Count ?? 0
                });
                startDate = startDate.AddDays(1);
            }
            return allDays;
        }

        public int DayReservationCount(DateTime date)
            => irRepository.GetReservationCountByDate(date);

        public bool IsVisitedThisYear(LicensePlate plate)
            => irRepository.IsVisited(plate);

        public string? AddRequest(NewInspectionRequestDTO dto)
        {
            if (!dto.IsAcceptable) return irRepository.Add(dto);
            var trackingNumber = $"VIRS-{dto.InspectionDate.Year}{dto.InspectionDate.Month}{dto.InspectionDate.Day}-{dto.NewCar.VIN}";
            return irRepository.Add(dto, trackingNumber);
        }

        public Result<InspectionRequestInfoDTO> LoadRequest(string trackingNumber)
        {
            var result = irRepository.GetAcceptedRequest(trackingNumber);
            return result is not null
                ? Result<InspectionRequestInfoDTO>.Success("اطلاعات پیدا شد", result)
                : Result<InspectionRequestInfoDTO>.Failure("اطلاعات پیدا نشد");
        }

        public RequestStatisticsDTO Statistics()
        {
            return new RequestStatisticsDTO
            {
                Total = irRepository.CountTotal(),
                Approved = irRepository.CountApproved(),
                Rejected = irRepository.CountRejected(),
                Pending = irRepository.CountPending()
            };
        }

        public List<InspectionRequestSummaryInfoDTO> GetAllRequestInDay(DateTime date)
            => irRepository.GetAllRequestInDay(date);

        public void ChangeOfStatus(string trackingNumber, InspectionStatusEnum newStatus)
            => irRepository.UpdateStatus(trackingNumber, newStatus);
    }
}
