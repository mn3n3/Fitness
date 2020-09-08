using Fitness.Helpers;
using Fitness.Models;
using Fitness.Persistence;
using Fitness.Repositories;
using Fitness.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscriberController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}