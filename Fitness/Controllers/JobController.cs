using Fitness.Helpers;
using Fitness.Models;
using Fitness.Persistence;
using Fitness.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.Controllers
{
    [Authorize]
    public class JobController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.User.GetMyInfo(userId);
            return View();
        }
        [HttpGet]
        public JsonResult GetAllJob()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                var AllJob = _unitOfWork.NativeSql.GetAllJob(UserInfo.fCompanyId);
                if (AllJob == null)
                {
                    return Json(new List<Job>(), JsonRequestBehavior.AllowGet);
                }

                return Json(AllJob, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<Job>(), JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Save()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.User.GetMyInfo(userId);
            Job Obj = new Job
            {
                JobCode = _unitOfWork.Job.GetMaxSerial(UserInfo.fCompanyId)
            };
            return PartialView(Obj);
        }

        [HttpPost]
        public JsonResult SaveJob(Job ObjSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                ObjSave.JobCode = _unitOfWork.Job.GetMaxSerial(UserInfo.fCompanyId);
                ObjSave.InsDateTime = DateTime.Now;
                ObjSave.InsUserID = userId;
                ObjSave.CompanyID = UserInfo.fCompanyId;
                if (String.IsNullOrEmpty(ObjSave.EnglishName))
                    ObjSave.EnglishName = ObjSave.ArabicName;
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
                _unitOfWork.Job.Add(ObjSave);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.Job.GetMaxSerial(UserInfo.fCompanyId).ToString();
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



        public ActionResult Update(int id)
        {
            try
            {
                if (id != 0)
                {
                    var userId = User.Identity.GetUserId();

                    var UserInfo = _unitOfWork.User.GetUserByID(userId);
                    if (UserInfo == null)
                    {
                        RedirectToAction("", "");
                    }

                    var Obj = _unitOfWork.Job.GetJobByID(UserInfo.fCompanyId, id);


                    return PartialView("Update", Obj);
                }
                return PartialView("Update", new Job());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }


        [HttpPost]
        public JsonResult UpdateJob(Job ObjUpdate)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                ObjUpdate.InsDateTime = DateTime.Now;
                ObjUpdate.InsUserID = userId;
                ObjUpdate.CompanyID = UserInfo.fCompanyId;
                if (String.IsNullOrEmpty(ObjUpdate.EnglishName))
                    ObjUpdate.EnglishName = ObjUpdate.ArabicName;

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
                _unitOfWork.Job.Update(ObjUpdate);
                _unitOfWork.Complete();

                Msg.Code = 1;
                Msg.Msg = Resources.Resource.UpdatedSuccessfully;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + ex.Message.ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    var userId = User.Identity.GetUserId();

                    var UserInfo = _unitOfWork.User.GetUserByID(userId);
                    if (UserInfo == null)
                    {
                        RedirectToAction("", "");
                    }

                    var Obj = _unitOfWork.Job.GetJobByID(UserInfo.fCompanyId, id);


                    return PartialView("Delete", Obj);
                }
                return PartialView("Delete", new Job());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }


        [HttpPost]
        public JsonResult DeleteJob(Job ObjDelete)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                ObjDelete.CompanyID = UserInfo.fCompanyId;
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
                _unitOfWork.Job.Delete(ObjDelete);
                _unitOfWork.Complete();

                Msg.Code = 1;
                Msg.Msg = Resources.Resource.DeletedSuccessfully;
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