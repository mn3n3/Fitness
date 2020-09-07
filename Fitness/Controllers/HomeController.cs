using Fitness.Helpers;
using Fitness.Persistence;
using Fitness.Repositories;
using Fitness.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        [AllowAnonymous]
        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.GetImplementedCulture(culture);
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.User.GetMyInfo(userId);
            DashBoardVM Obj = new DashBoardVM();
            if (UserInfo == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (UserInfo.fCompanyId != 0)
            {
                var CoInfo = _unitOfWork.Company.GetMyCompany(UserInfo.fCompanyId);
                Obj.CompanyName = CoInfo.ArabicName;
            }
            ViewBag.CurrentDate = DateTime.Now.ToString();
            string D = DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year.ToString();

            if (Resources.Resource.CurLang == "Eng")
            {
                ViewBag.CuurentDay = D + "  " + DateTime.Now.ToString("dddd", CultureInfo.CreateSpecificCulture("en"));
            }
            else
            {
                ViewBag.CuurentDay = D + "  " + DateTime.Now.ToString("dddd", CultureInfo.CreateSpecificCulture("ar"));
            }
            return View(Obj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}