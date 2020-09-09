using Fitness.Helpers;
using Fitness.Models;
using Fitness.Persistence;
using Fitness.Repositories;
using Fitness.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fitness.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly IUnitOfWork _unitOfWork;


        public AccountController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());

        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {

            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
            
            
       public async Task<ActionResult> CreateUser(UserAccountVM UserData)
        {
            MsgUnit Msg = new MsgUnit();
            ApplicationUser model = UserData.ApplicationUser;
            //  ObjToSave.AddBYUserID = userId;

            var UserId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.User.GetUserByID(UserId);



            int e = UserData.Email.IndexOf('@');
            int Co = UserInfo.Email.IndexOf('@');
            if (e < 0)
            {
                model.Email = UserData.Email + UserInfo.Email.Substring(Co);
            }
            else
            {
                //Msg.Msg = Resources.Resource.EmailMustBe;
                //Msg.Code = 0;
                //// return RedirectToAction("Index", "Users");
                //return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            if (!ModelState.IsValid)
            {
                string Err = " ";
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (ModelError error in errors)
                {
                    Err = Err + error.ErrorMessage + "  ";
                }

                Msg.Msg = Resources.Resource.SomthingWentWrong + " " + Err;
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }

            //   if (ModelState.IsValid)
            try
            {



                var user = new ApplicationUser();


                user = model;

                user.UserName = model.Email;
                user.Email = model.Email;
                user.UserType = model.UserType;
                user.fCompanyId = UserInfo.fCompanyId;

                var result = await UserManager.CreateAsync(user, UserData.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "CoUser");
                    string[] roleNames = {
                      "Admin", "CoOwner", "CoUser" ,



                 "ShowCompany","UpdateCompany", //Company Screen
				 "ShowUser","AddUser" ,"UpdateUser","DeleteUser","PrintUser", //User Screen
                 "ShowGroup" ,"AddGroup" ,"UpdateGroup" , "DeleteGroup" , "PrintGroup" , // Group Screen
                 "ShowSource" ,"AddSource" ,"UpdateSource" , "DeleteSource" , "PrintSource" , // Source Screen
                 "ShowTrainer", "AddTrainer" , "UpdateTrainer" , "DeleteTrainer" ,"PrintTrainer" , // Trainer Screen
                 "ShowItem" , "AddItem","UpdateItem" , "UpdateItem" , "DeleteItem" , "PrintItem" , // Item Screen
                 "ShowCustomerCompany" , "AddCustomerCompany" , "UpdateCustomerCompany" , "DeleteCustomerCompany" , "PrintCustomerCompany" , // Cust Screen
                 "ShowJob" , "AddJob" , "UpdateJob"  , "DeleteJob" , "PrintJob", // Job Screen
                 "ShowNationality" , "AddNationality" , "UpdateNationality" , "DeleteNationality" , "PrintNationality" , // Nationality Screen
                 "ShowPlaceOfBirth" , "AddPlaceOfBirth" , "UpdatePlaceOfBirth" , "DeletePlaceOfBirth" , "PrintPlaceOfBirth" // Place of Birth Screen 





                
  

            };

                    foreach (var roleName in roleNames)
                    {
                        if ((model.ShowCompany) && (roleName == "ShowCompany"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowCompany");
                        if ((model.UpdateCompany) && (roleName == "UpdateCompany"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateCompany");



                        if ((model.ShowUser) && (roleName == "ShowUser"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowUser");
                        if ((model.AddUser) && (roleName == "AddUser"))
                            await UserManager.AddToRoleAsync(user.Id, "AddUser");
                        if ((model.UpdateUser) && (roleName == "UpdateUser"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateUser");
                        if ((model.DeleteUser) && (roleName == "DeleteUser"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteUser");
                        if ((model.PrintUser) && (roleName == "PrintUser"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintUser");

                        if ((model.ShowGroup) && (roleName == "ShowGroup"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowGroup");
                        if ((model.AddGroup) && (roleName == "AddGroup"))
                            await UserManager.AddToRoleAsync(user.Id, "AddGroup");
                        if ((model.UpdateGroup) && (roleName == "UpdateGroup"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateGroup");
                        if ((model.DeleteGroup) && (roleName == "DeleteGroup"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteGroup");
                        if ((model.PrintGroup) && (roleName == "PrintGroup"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintGroup");


                        if ((model.ShowSource) && (roleName == "ShowSource"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowSource");
                        if ((model.AddSource) && (roleName == "AddSource"))
                            await UserManager.AddToRoleAsync(user.Id, "AddSource");
                        if ((model.UpdateSource) && (roleName == "UpdateSource"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateSource");
                        if ((model.DeleteSource) && (roleName == "DeleteSource"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteSource");
                        if ((model.PrintSource) && (roleName == "PrintSource"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintSource");



                        if ((model.ShowTrainer) && (roleName == "ShowTrainer"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowTrainer");
                        if ((model.AddTrainer) && (roleName == "AddTrainer"))
                            await UserManager.AddToRoleAsync(user.Id, "AddTrainer");
                        if ((model.UpdateTrainer) && (roleName == "UpdateTrainer"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateTrainer");
                        if ((model.DeleteTrainer) && (roleName == "DeleteTrainer"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteTrainer");
                        if ((model.PrintTrainer) && (roleName == "PrintTrainer"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintTrainer");


                        if ((model.ShowItem) && (roleName == "ShowItem"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowItem");
                        if ((model.AddItem) && (roleName == "AddItem"))
                            await UserManager.AddToRoleAsync(user.Id, "AddItem");
                        if ((model.UpdateItem) && (roleName == "UpdateItem"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateItem");
                        if ((model.DeleteItem) && (roleName == "DeleteItem"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteItem");
                        if ((model.PrintItem) && (roleName == "PrintItem"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintItem");


                        if ((model.ShowCustomerCompany) && (roleName == "ShowCustomerCompany"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowCustomerCompany");
                        if ((model.AddCustomerCompany) && (roleName == "AddCustomerCompany"))
                            await UserManager.AddToRoleAsync(user.Id, "AddCustomerCompany");
                        if ((model.UpdateCustomerCompany) && (roleName == "UpdateCustomerCompany"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateCustomerCompany");
                        if ((model.DeleteCustomerCompany) && (roleName == "DeleteCustomerCompany"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteCustomerCompany");
                        if ((model.PrintCustomerCompany) && (roleName == "PrintCustomerCompany"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintCustomerCompany");

                        if ((model.ShowJob) && (roleName == "ShowJob"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowJob");
                        if ((model.AddJob) && (roleName == "AddJob"))
                            await UserManager.AddToRoleAsync(user.Id, "AddJob");
                        if ((model.UpdateJob) && (roleName == "UpdateJob"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateJob");
                        if ((model.DeleteJob) && (roleName == "DeleteJob"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteJob");
                        if ((model.PrintJob) && (roleName == "PrintJob"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintJob");



                        if ((model.ShowNationality) && (roleName == "ShowNationality"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowNationality");
                        if ((model.AddNationality) && (roleName == "AddNationality"))
                            await UserManager.AddToRoleAsync(user.Id, "AddNationality");
                        if ((model.UpdateNationality) && (roleName == "UpdateNationality"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdateNationality");
                        if ((model.DeleteNationality) && (roleName == "DeleteNationality"))
                            await UserManager.AddToRoleAsync(user.Id, "DeleteNationality");
                        if ((model.PrintNationality) && (roleName == "PrintNationality"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintNationality");


                        if ((model.ShowPlaceOfBirth) && (roleName == "ShowPlaceOfBirth"))
                            await UserManager.AddToRoleAsync(user.Id, "ShowPlaceOfBirth");
                        if ((model.AddPlaceOfBirth) && (roleName == "AddPlaceOfBirth"))
                            await UserManager.AddToRoleAsync(user.Id, "AddPlaceOfBirth");
                        if ((model.UpdatePlaceOfBirth) && (roleName == "UpdatePlaceOfBirth"))
                            await UserManager.AddToRoleAsync(user.Id, "UpdatePlaceOfBirth");
                        if ((model.DeletePlaceOfBirth) && (roleName == "DeletePlaceOfBirth"))
                            await UserManager.AddToRoleAsync(user.Id, "DeletePlaceOfBirth");
                        if ((model.PrintPlaceOfBirth) && (roleName == "PrintPlaceOfBirth"))
                            await UserManager.AddToRoleAsync(user.Id, "PrintPlaceOfBirth");




                    }

                    Msg.Msg = Resources.Resource.AddedSuccessfully;
                    Msg.Code = 1;
                    // return RedirectToAction("Index", "Users");
                    return Json(Msg, JsonRequestBehavior.AllowGet);
                }

                AddErrors(result);
                Msg.Msg = Resources.Resource.SomthingWentWrong + " " + result.Errors.FirstOrDefault().ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }

            // If we got this far, something failed, redisplay form
            //   return View(model);
            catch (Exception ex)
            {
                string Err = " ";
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (ModelError error in errors)
                {
                    Err = Err + error.ErrorMessage + "  ";
                }
                Err = Err + " " + ex.Message;

                Msg.Msg = Resources.Resource.SomthingWentWrong + " " + Err;
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);

            }

        }

        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterJson(RegisterViewModel model)
        {
            MsgUnit Msg = new MsgUnit();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    fCompanyId = 0,

                    UserType = 1,
                    AccountStatus = 1,
                    RealPass = model.Password
                };



                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "CoOwner");
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);


                    Msg.Msg = Resources.Resource.YourrequesthasBeenSuccessfullySent;
                    Msg.Code = 1;
                    return Json(Msg, JsonRequestBehavior.AllowGet);
                }


                string Err = " ";
                //var errors = result.SelectMany();
                foreach (string error in result.Errors)
                {
                    Err = Err + error + " * ";
                }

                Msg.Msg = Resources.Resource.SomthingWentWrong + " * " + Err;
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);


            }
            else
            {
                string Err = " ";
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (ModelError error in errors)
                {
                    Err = Err + error.ErrorMessage + "  ";
                }

                Msg.Msg = Resources.Resource.SomthingWentWrong + " " + Err;
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }




            // If we got this far, something failed, redisplay form
            // return View(model);
        }

        //
        // GET: /Fitness/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Fitness/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Fitness/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Fitness/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Fitness/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Fitness/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Fitness/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Fitness/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Fitness/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Fitness/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Fitness/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Fitness/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Fitness/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Fitness/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Fitness/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Fitness/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Fitness/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Fitness/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Fitness/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}