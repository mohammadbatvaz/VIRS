using Microsoft.AspNetCore.Mvc;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.AppServices;
using VIRS.Domain.Core.InspectionRequestAgg.Enums;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.AppServices;
using VIRS.Presentation.WebApp.MVC.Models;

namespace VIRS.Presentation.WebApp.MVC.Controllers
{
    public class Panel(
        ISystemAdminAppServices saAppservices,
        IInspectionRequestAppServices irAppServices) : Controller
    {
        private void FillViewData()
        {
            var statistics = irAppServices.RequestStatistics();
            ViewData["FullName"] = CurrentUser.FullName;
            ViewData["TotalNumberOfRequests"] = statistics.Total;
            ViewData["NumberOfRejectedRequests"] = statistics.Rejected;
            ViewData["NumberOfApprovedRequests"] = statistics.Approved;
            ViewData["NumberOfPendingRequests"] = statistics.Pending;
        }
        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = saAppservices.LoginToPanel(model.Username, model.Password);
            if (result.IsSuccess)
            {
                CurrentUser.Set(result.Data.Id, result.Data.FullName);
                return RedirectToAction("index");
            }

            ModelState.AddModelError(nameof(model.Username), result.Message);
            return View(model);
        }

        public IActionResult Logout()
        {
            CurrentUser.Clear();
            return RedirectToAction("Login");
        }
        #endregion

        public IActionResult index()
        {
            FillViewData();
            ViewData["ListOfAllRequests"] = irAppServices.RequestList();
            return View();
        }

        public IActionResult Approved(string id)
        {
            irAppServices.ChangeOfStatus(id, InspectionStatusEnum.Confirmed);
            return RedirectToAction("index");
        }

        public IActionResult Rejected(string id)
        {
            irAppServices.ChangeOfStatus(id, InspectionStatusEnum.Rejected);
            return RedirectToAction("index");
        }

        public IActionResult Information(string id)
        {
            var result = irAppServices.LoadingRequestInfo(id);
            if (result.IsSuccess)
            {
                ViewData["FullName"] = CurrentUser.FullName;
                ViewData["RequestsInfo"] = result.Data;
                return View();
            }

            FillViewData();
            ViewData["ListOfAllRequests"] = irAppServices.RequestList();
            return RedirectToAction("index");
        }
    }
}
