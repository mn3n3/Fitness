using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.Controllers
{
    [Authorize]
    public class CompanySettingsDashController : BaseController
    {
        // GET: CompanySettingsDash
        public ActionResult Index()
        {
            return View();
        }
    }
}