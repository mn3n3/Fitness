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
    [Authorize]
    public class VisitorController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public VisitorController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.User.GetMyInfo(userId);
            int year = DateTime.Now.Year;
            var VisitorObj = new VisitorVM
            {
                Nationality = _unitOfWork.NativeSql.GetAllNationalities(UserInfo.fCompanyId),
                Source = _unitOfWork.NativeSql.GetAllSources(UserInfo.fCompanyId),
                Job = _unitOfWork.NativeSql.GetAllJob(UserInfo.fCompanyId),
                FromVistDate = new DateTime(year, 1, 1),
                ToDate = new DateTime(year, 12, 31)
            };
            


            return View(VisitorObj);
        }
        public JsonResult GetAllVisitor(VisitorVM Obj)
        {
            try
            {
                string sFromVisitorDate = Obj.FromVistDate.Day.ToString() + Obj.FromVistDate.Month.ToString() + Obj.FromVistDate.Year.ToString();
                int FromVisitorDate = int.Parse(sFromVisitorDate);
                string sToDate = Obj.ToDate.Day.ToString() + Obj.ToDate.Month.ToString() + Obj.ToDate.Year.ToString();
                int ToDate = int.Parse(sToDate);
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                var AllVisitor = _unitOfWork.NativeSql.GetAllVisitor(UserInfo.fCompanyId, FromVisitorDate,ToDate);

                if (!String.IsNullOrEmpty(Obj.VisitorName))
                {
                    AllVisitor = AllVisitor.Where(m => m.VisitorName.Contains(Obj.VisitorName)).ToList();
                }
                if (Obj.NationalityCode != 0)
                {
                    AllVisitor = AllVisitor.Where(m => m.NationalityCode == Obj.NationalityCode).ToList();
                }
                if (Obj.SourceCode != 0)
                {
                    AllVisitor = AllVisitor.Where(m => m.SourceCode == Obj.SourceCode).ToList();
                }
                if (Obj.JobCode != 0)
                {
                    AllVisitor = AllVisitor.Where(m => m.JobCode == Obj.JobCode).ToList();
                }
                if (Obj.IntersetedCaseInt != 0)
                {
                    AllVisitor = AllVisitor.Where(m => m.Interseted == Convert.ToBoolean(Obj.IntersetedCaseInt - 1)).ToList();
                }
                return Json(AllVisitor, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<VisitorVM>(), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Save()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.User.GetMyInfo(userId);
            var VisitorObj = new VisitorVM();
            VisitorObj.Nationality = _unitOfWork.NativeSql.GetAllNationalities(UserInfo.fCompanyId);
            VisitorObj.Source = _unitOfWork.NativeSql.GetAllSources(UserInfo.fCompanyId);
            VisitorObj.Job = _unitOfWork.NativeSql.GetAllJob(UserInfo.fCompanyId);
            VisitorObj.BirthDate = DateTime.Now;
            VisitorObj.VistDate = DateTime.Now;
            VisitorObj.VisitorCode = _unitOfWork.Visitor.GetMaxSerial(UserInfo.fCompanyId);
            return View(VisitorObj);
        }
        [HttpPost]
        public JsonResult SaveVisitor(VisitorVM ObjSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                var ObjVisitor = new Visitor();
                ObjVisitor.VisitorCode = _unitOfWork.Visitor.GetMaxSerial(UserInfo.fCompanyId);
                ObjVisitor.VisitorName = ObjSave.VisitorName;
                ObjVisitor.Phone1 = ObjSave.Phone1;
                ObjVisitor.Email = ObjSave.Email;
                ObjVisitor.Address = ObjSave.Address;
                ObjVisitor.NationalityCode = ObjSave.NationalityCode;
                ObjVisitor.SourceCode = ObjSave.SourceCode;
                ObjVisitor.JobCode = ObjSave.JobCode;
                ObjVisitor.GenderCode = ObjSave.GenderCode;
                ObjVisitor.Note = ObjSave.Note;
                ObjVisitor.Interseted = ObjSave.Interseted;
                ObjVisitor.InsDateTime = DateTime.Now;
                ObjVisitor.InsUserID = userId;
                ObjVisitor.CompanyID = UserInfo.fCompanyId;
                ObjVisitor.BirthDate = ObjSave.BirthDate;
                ObjVisitor.VistDate = ObjSave.VistDate;
                string sBirthDate = ObjSave.BirthDate.Day.ToString() + ObjSave.BirthDate.Month.ToString() + ObjSave.BirthDate.Year.ToString();
                ObjVisitor.BirthDateInt = int.Parse(sBirthDate);
                string sVistDate = ObjSave.VistDate.Day.ToString() + ObjSave.VistDate.Month.ToString() + ObjSave.VistDate.Year.ToString();
                ObjVisitor.VistDateInt = int.Parse(sVistDate);
                if (!ModelState.IsValid)
                {
                    string Err = " ";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (ModelError error in errors)
                    {
                        Err = Err + error.ErrorMessage + " * ";
                    }

                    Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + Err;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }
                _unitOfWork.Visitor.Add(ObjVisitor);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.Visitor.GetMaxSerial(UserInfo.fCompanyId).ToString();
                Msg.Code = 1;
                Msg.Msg = Resources.Resource.AddedSuccessfully;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + ex.Message.ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }

        }
    }
}