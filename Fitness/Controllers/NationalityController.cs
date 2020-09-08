﻿using Fitness.Helpers;
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
    public class NationalityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NationalityController()
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
        public JsonResult GetAllNationality()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                var AllNationality = _unitOfWork.NativeSql.GetAllNationalities(UserInfo.fCompanyId);
                if (AllNationality == null)
                {
                    return Json(new List<Nationality>(), JsonRequestBehavior.AllowGet);
                }

                return Json(AllNationality, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<Nationality>(), JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Save()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.User.GetMyInfo(userId);
            Nationality Obj = new Nationality
            {
                NationalityCode = _unitOfWork.Nationality.GetMaxSerial(UserInfo.fCompanyId)
            };
            return PartialView(Obj);
        }

        [HttpPost]
        public JsonResult SaveNationality(Nationality ObjSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.User.GetMyInfo(userId);
                ObjSave.NationalityCode = _unitOfWork.Nationality.GetMaxSerial(UserInfo.fCompanyId);
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
                _unitOfWork.Nationality.Add(ObjSave);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.Nationality.GetMaxSerial(UserInfo.fCompanyId).ToString();
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

                    var Obj = _unitOfWork.Nationality.GetNationalityByID(UserInfo.fCompanyId, id);


                    return PartialView("Update", Obj);
                }
                return PartialView("Update", new Nationality());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }

        [HttpPost]
        public JsonResult UpdateNationality(Nationality ObjUpdate)
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
                _unitOfWork.Nationality.Update(ObjUpdate);
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

                    var Obj = _unitOfWork.Nationality.GetNationalityByID(UserInfo.fCompanyId, id);


                    return PartialView("Delete", Obj);
                }
                return PartialView("Delete", new Nationality());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }


        [HttpPost]
        public JsonResult DeleteNationality(Nationality ObjDelete)
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
                _unitOfWork.Nationality.Delete(ObjDelete);
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