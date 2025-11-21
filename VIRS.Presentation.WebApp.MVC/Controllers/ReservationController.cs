using Microsoft.AspNetCore.Mvc;
using VIRS.Domain.AppServices.Exceptions;
using VIRS.Domain.Core.CarAgg.DTOs;
using VIRS.Domain.Core.CarAgg.Entities;
using VIRS.Domain.Core.CarModelAgg.Contracts.AppServices;
using VIRS.Domain.Core.CarOwnerAgg.DTOs;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.AppServices;
using VIRS.Domain.Core.InspectionRequestAgg.DTOs;
using VIRS.Presentation.WebApp.MVC.Models;

namespace VIRS.Presentation.WebApp.MVC.Controllers
{
    public class ReservationController(
        ICarModelAppServices cmAppServices,
        IInspectionRequestAppServices irAppServices) : Controller
    {
        private void FillViewData()
        {
            ViewData["CarModel"] = cmAppServices.All();
            ViewData["ReservationsCalendar"] = irAppServices.ReservationsCalendarGenerator();
        }

        public IActionResult index()
        {
            FillViewData();
            return View();
        }

        [HttpPost]
        public IActionResult index(IRInformationVM model)
        {
            if (!ModelState.IsValid)
            {
                FillViewData();
                return View(model);
            }
            var inspectionRequest = new NewInspectionRequestDTO
            {
                NewCarOwner = new NewCarOwnerDTO()
                {
                    NID = model.NID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber
                },
                NewCar = new NewCarDTO()
                {
                    VIN = model.CarVIN,
                    Plate = new LicensePlate()
                    {
                        FirstPart = model.CarPlatFirstPart,
                        Letter = model.CarPlatLetter,
                        SecondPart = model.CarPlatSecondPart,
                        ProvinceCode = model.CarPlatProvinceCode
                    },
                    ManufactureYear = model.CarManufactureYear,
                    CarModelManufacturer = model.CarModelManufacturer,
                    CarModelFamily = model.CarModelFamily,
                    CarModelName = model.CarModelName
                },
                InspectionDate = model.InspectionDate,
                IsAcceptable = false,
                ImageStreams = model.Images
                    .Where(f => f.Length > 0)
                    .Select(f => f.OpenReadStream())
                    .ToList(),
                ImagePaths = model.Images
                    .Where(f => f.Length > 0)
                    .Select(f => Path.GetExtension(f.FileName))
                    .ToList()
            };

            try
            {
                var result = irAppServices.InspectionRequestGenerator(inspectionRequest);
                return RedirectToAction("Final", new { id = result.Message });
            }
            catch (BaseValidationException ex)
            {
                ModelState.AddModelError(ex.FieldName, ex.Message);
                FillViewData();
                return View(model);
            }
        }

        public IActionResult Final(string id)
        {
            var result = irAppServices.LoadingRequestInfo(id);
            if (result.IsSuccess)
            {
                ViewData["ConfirmationReceipt"] = result.Data;
                return View();
            }
            return RedirectToAction("NotFound");
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
