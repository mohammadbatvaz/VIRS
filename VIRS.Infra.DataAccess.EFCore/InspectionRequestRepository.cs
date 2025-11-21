using Microsoft.EntityFrameworkCore;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.ImageAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.Data;
using VIRS.Domain.Core.InspectionRequestAgg.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.Entities;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;
using VIRS.Infra.DataBase.EFCoreSqlServer;

namespace VIRS.Infra.DataAccess.EFCore
{
    public class InspectionRequestRepository(AppDbContext _db) : IInspectionRequestRepository
    {
        public List<DayReservationCountsDTO> GetReservationCountByDateRange(DateTime startDate, DateTime endDate)
        {
            return _db.InspectionRequests
                .AsNoTracking()
                .Where(ir => ir.InspectionDate.HasValue 
                          && ir.InspectionDate.Value.Date >= startDate.Date
                          && ir.InspectionDate.Value.Date <= endDate.Date)
                .GroupBy(ir => ir.InspectionDate.Value.Date)
                .Select(ir => new DayReservationCountsDTO()
                {
                    Date = ir.Key,
                    Count = ir.Count()
                })
                .ToList();
        }

        public int GetReservationCountByDate(DateTime date)
        {
            return _db.InspectionRequests
                .Where(ir => ir.InspectionDate.HasValue 
                             && ir.InspectionDate.Value.Date == date.Date)
                .GroupBy(ir => ir.InspectionDate.Value.Date).Count();
        }

        public bool IsVisited(LicensePlate plate)
        {
            var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);

            return _db.InspectionRequests
                .Include(ir => ir.Car.Plate)
                .Any(ir =>
                    ir.InspectionDate.HasValue &&
                    ir.Car.Plate.FirstPart == plate.FirstPart &&
                    ir.Car.Plate.Letter == plate.Letter &&
                    ir.Car.Plate.SecondPart == plate.SecondPart &&
                    ir.Car.Plate.ProvinceCode == plate.ProvinceCode &&
                    ir.InspectionDate.Value >= startOfYear
                );
        }

        public string? Add(NewInspectionRequestDTO dto, string? trackingNumber = null)
        {
            _db.InspectionRequests.Add(new InspectionRequest()
            {
                CarOwnerId = dto.CarOwnerId,
                CarId = dto.CarId,
                InspectionDate = dto.IsAcceptable ? dto.InspectionDate : null,
                IsAcceptable = dto.IsAcceptable,
                TrackingNumber = trackingNumber,
                Status = InspectionStatusEnum.Pending,
                Images = dto.ImagePaths.Select(ip => new Image 
                    {
                        ImagePath = ip
                    })
                    .ToList()
            });
            _db.SaveChanges();
            return trackingNumber;
        }

        public InspectionRequestInfoDTO? GetAcceptedRequest(string trackingNumber)
        {
            return _db.InspectionRequests
                .AsNoTracking()
                .Include(ir => ir.Images)
                .Where(ir => ir.TrackingNumber == trackingNumber && ir.IsAcceptable)
                .Select(ir => new InspectionRequestInfoDTO()
                {
                    CarManufactureYear = ir.Car.ManufactureYear,
                    InspectionDate = ir.InspectionDate.Value,
                    PhoneNumber = ir.CarOwner.PhoneNumber,
                    CarModel = ir.Car.CarModel.ToString(),
                    TrackingNumber = ir.TrackingNumber,
                    FullName = ir.CarOwner.ToString(),
                    CarOwnerNID = ir.CarOwner.NID,
                    CarVIN = ir.Car.VIN,
                    Status = ir.Status,
                    RequestId = ir.Id,
                    CarPlat = $"{ir.Car.Plate.ProvinceCode} |" +
                              $" {ir.Car.Plate.SecondPart}" +
                              $" {ir.Car.Plate.Letter}" +
                              $" {ir.Car.Plate.FirstPart}",
                    ImagesPaths = ir.Images.Select(img => img.ImagePath).ToList()
                }).FirstOrDefault();
        }

        public int CountTotal() 
            => _db.InspectionRequests.Count(ir => ir.IsAcceptable);

        public int CountRejected() 
            => _db.InspectionRequests.Count(ir => ir.Status == InspectionStatusEnum.Rejected && ir.IsAcceptable);

        public int CountApproved() 
            => _db.InspectionRequests.Count(ir => ir.Status == InspectionStatusEnum.Confirmed && ir.IsAcceptable);

        public int CountPending() 
            => _db.InspectionRequests.Count(ir => ir.Status == InspectionStatusEnum.Pending && ir.IsAcceptable);

        public List<InspectionRequestSummaryInfoDTO> GetAllRequestInDay(DateTime date)
        {
            return _db.InspectionRequests
                .AsNoTracking()
                .Where(ir => ir.InspectionDate.Value.Date == date.Date)
                .Select(ir => new InspectionRequestSummaryInfoDTO()
                {
                    RequestId = ir.Id,
                    TrackingNumber = ir.TrackingNumber,
                    Status = ir.Status,
                    FullName = ir.CarOwner.ToString(),
                    CarModel = ir.Car.CarModel.ToString(),
                    CarPlat = $"{ir.Car.Plate.ProvinceCode} |" +
                              $" {ir.Car.Plate.SecondPart}" +
                              $" {ir.Car.Plate.Letter}" +
                              $" {ir.Car.Plate.FirstPart}"
                }).ToList();
        }

        public void UpdateStatus(string trackingNumber, InspectionStatusEnum status)
        {
            _db.InspectionRequests
                .Where(ir => ir.TrackingNumber == trackingNumber)
                .ExecuteUpdate(s => s
                    .SetProperty(s => s.Status, status)
                    .SetProperty(s => s.StatusChangedAt, DateTime.Now));
        }
    }
}
