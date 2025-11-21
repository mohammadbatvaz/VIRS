using System.Collections.Generic;
using System.Globalization;
using VIRS.Domain.AppServices.Exceptions;
using VIRS.Domain.Core._CommentAgg.Entities;
using VIRS.Domain.Core.Calendar.Contracts.Services;
using VIRS.Domain.Core.Calendar.DTOs;
using VIRS.Domain.Core.CarAgg.Contracts.Services;
using VIRS.Domain.Core.CarModelAgg.Contracts.Services;
using VIRS.Domain.Core.CarOwnerAgg.Contracts.Services;
using VIRS.Domain.Core.ImageAgg.Contracts.Services;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.AppServices;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.Services;
using VIRS.Domain.Core.InspectionRequestAgg.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;


namespace VIRS.Domain.AppServices
{
    public class InspectionRequestAppServices(
        IInspectionRequestServices irServices,
        ICalendarServices calenderServices,
        ICarOwnerServices coServices,
        ICarModelServices cmServices,
        IImageServices iServices,
        ICarServices cServices,
        PersianCalendar pc) : IInspectionRequestAppServices
    {
        public List<List<CalendarDayDataDTO>> ReservationsCalendarGenerator()
        {
            var startDate = DateTime.Now.AddDays(1);
            var endDate = startDate.AddMonths(1);

            var allDays = irServices.GetDailyReservationCounts(startDate, endDate);
            var emptyDaysAtStart = calenderServices.ShamsiDayOfWeek(startDate);

            const int daysInWeek = 7;
            var totalCells = allDays.Count + emptyDaysAtStart;
            var totalRows = (int)Math.Ceiling(totalCells / (double)daysInWeek);
            
            var calendar = new List<List<CalendarDayDataDTO>>();
            var dayIndex = 0;

            for (var i = 0; i < totalRows; i++)
            {
                var row = new List<CalendarDayDataDTO>();
                for (var j = 0; j < daysInWeek; j++)
                {
                    if (i == 0 && j < emptyDaysAtStart || dayIndex >= allDays.Count)
                    {
                        row.Add(new CalendarDayDataDTO()
                        {
                            IsEmpty = true,
                            IsAvailable = false
                        });
                    }
                    else
                    {
                        var day = allDays[dayIndex++];
                        var dayOfWeek = calenderServices.ShamsiDayOfWeek(day.Date);
                        var notReservedCount = dayOfWeek % 2 == 0 ? 15 - day.Count : 10 - day.Count;
                        row.Add(new CalendarDayDataDTO
                        {
                            IsEmpty = false,
                            IsAvailable = dayOfWeek != 6 || notReservedCount == 0,
                            DateValue = day.Date,
                            ShamsiDate = $"{pc.GetMonth(day.Date)}-{pc.GetDayOfMonth(day.Date)}",
                            NotReservedCunt = notReservedCount,
                            Message = dayOfWeek != 6 ? $"ظرفیت {notReservedCount}" : "تعطیل"
                        });
                    }
                }
                calendar.Add(row);
            }
            return calendar;
        }
        
        public Result<string> InspectionRequestGenerator(NewInspectionRequestDTO request)
        {
            #region Car model validation
                request.NewCar.CarModelId = cmServices.EnsureCarModelExists(request.NewCar);
            if (request.NewCar.CarModelId == Guid.Empty)
                throw new CarModelValidationException("مدل انتخابی خودرو اشتباه است");
            #endregion

            #region Calculating the age of a car
            var currentYear = pc.GetYear(DateTime.Now);
                var carAge = currentYear - request.NewCar.ManufactureYear;
            #endregion

            #region Acceptability car age
                request.IsAcceptable = carAge <= 5;
            #endregion

            #region Check the day of the week
                var dayOfWeek = calenderServices.ShamsiDayOfWeek(request.InspectionDate);
                
                if (dayOfWeek == 6)
                    throw new InspectionDateValidationException("روز های جمعه خدماتی ارائه نمیشود");

                bool isEvenDay = dayOfWeek is 0 or 2 or 4;
                bool isOddDay = dayOfWeek is 1 or 3 or 5;
            #endregion

            #region Rules of the day of visit
                if (isEvenDay && request.NewCar.CarModelManufacturer != "ایرانخودرو")
                    throw new InspectionDateValidationException("در روز های زوج فقط خودرو های ایرانخودرو پذیرش میشود");
                
                if (isOddDay && request.NewCar.CarModelManufacturer != "سایپا")
                    throw new InspectionDateValidationException("در روز های فرد فقط خودرو های سایپا پذیرش میشود");
            #endregion

            #region Daily capacity
                var capacityUsed = irServices.DayReservationCount(request.InspectionDate);

                if ((isEvenDay && capacityUsed > 15) || 
                    (isOddDay && capacityUsed > 10))
                    throw new InspectionDateValidationException("ظرفیت پذیرش روز انتخابی تکمیل است");
            #endregion

            #region Review of this year's license plate number
                if (irServices.IsVisitedThisYear(request.NewCar.Plate))
                    throw new CarPlatValidationException("قبلا این شماره پلاک در سال جاری مراجعه کرده است");
            #endregion

            #region Check the number of images
                if (request.ImageStreams.Count != 3)
                    throw new ImagesValidationException("همه 3 تصویر را اپلود کنید");
            #endregion

            #region Register or find the CarOwner and Vehicle and save image
                request.CarOwnerId = coServices.EnsureCarOwnerExists(request.NewCarOwner);
                request.CarId = cServices.EnsureCarExists(request.NewCar, request.CarOwnerId);
                request.ImagePaths = request.ImageStreams
                    .Select((stream, i) => iServices.SaveOnDisk(stream, request.ImagePaths[i]))
                    .ToList();
            #endregion

            var trackingCode = irServices.AddRequest(request);

            return carAge > 5 
                ? throw new ManufactureYearValidationException("خودروهای بالای 5 سال پذیرش نمیشد") 
                : Result<string>.Success(trackingCode);
        }

        public Result<InspectionRequestInfoDTO> LoadingRequestInfo(string trackingNumber)
        {
            var result = irServices.LoadRequest(trackingNumber);
            if (!result.IsSuccess) return result;
            result.Data.ShamsiInspectionDate = calenderServices.CompleteShamsiDate(result.Data.InspectionDate);
            return result;
        }

        public RequestStatisticsDTO RequestStatistics()
            => irServices.Statistics();

        public List<ListOfRequestInDayDTO> RequestList()
        {
            var startDate = new DateTime(2025, 11, 19); ;
            var endDate = DateTime.Now.AddMonths(1);

            var allDays = irServices.GetDailyReservationCounts(startDate, endDate);

            return allDays
                .Where(day => day.Count != 0)
                .Select(day => new ListOfRequestInDayDTO 
                {
                    Date = day.Date,
                    ShamsiDate = calenderServices.CompleteShamsiDate(day.Date),
                    RequestList = irServices.GetAllRequestInDay(day.Date)
                }).ToList();
        }

        public void ChangeOfStatus(string trackingNumber, InspectionStatusEnum newStatus)
            => irServices.ChangeOfStatus(trackingNumber, newStatus);
    }
}
