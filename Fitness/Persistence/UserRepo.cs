using Fitness.Models;
using Fitness.Repositories;
using Fitness.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Persistence
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddModify(ApplicationUser ObjToSave)
        {
            var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id && (m.fCompanyId == ObjToSave.fCompanyId || m.fCompanyId == 0));
            if (User != null)
            {


                User.AccountStatus = ObjToSave.AccountStatus;
                User.fCompanyId = ObjToSave.fCompanyId;
                User.PasswordHash = ObjToSave.PasswordHash;




            }
            else
            {
                _context.Users.Add(ObjToSave);

            }
        }

        public void AddModifyFromCreateCompnay(ApplicationUser ObjToSave)
        {
            var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id);
            if (User != null)
            {


                User.AccountStatus = ObjToSave.AccountStatus;
                User.fCompanyId = ObjToSave.fCompanyId;
                User.PasswordHash = ObjToSave.PasswordHash;



            }
            else
            {
                _context.Users.Add(ObjToSave);

            }
        }


        public void ChangePass(ApplicationUser ObjToSave)
        {
            var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id);
            if (User != null)
            {


                User.PasswordHash = ObjToSave.PasswordHash;
                User.RealPass = ObjToSave.RealPass;


            }

        }

        public void DeActivate(ApplicationUser ObjToSave)
        {
            if (_context.Users.SingleOrDefault(m => m.fCompanyId == ObjToSave.fCompanyId && m.Id == ObjToSave.Id) != null)
            {
                var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id);
                if (User != null)
                {
                    User.AccountStatus = ObjToSave.AccountStatus;
                }
            }
        }

        public void Delete(ApplicationUser ObjToSave)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllUsers(int CoId)
        {
            return _context.Users.Where(m => m.fCompanyId == CoId).ToList();
        }

        public ApplicationUser GetMyInfo(string UserID)
        {
            return _context.Users.SingleOrDefault(m => m.Id == UserID);
        }

        public ApplicationUser GetUserByEmailAndPassword(string Email, string Passord)
        {
            return _context.Users.SingleOrDefault(m => m.Email == Email && m.PasswordHash == Passord);
        }

        public ApplicationUser GetUserByEmpIdAndCo(int CoId, string UId)
        {
            return _context.Users.SingleOrDefault(m => m.fCompanyId == CoId && m.Id == UId);
        }

        public ApplicationUser GetUserByID(string UId)
        {
            return _context.Users.SingleOrDefault(m => m.Id == UId);
        }

        public ApplicationUser GetUserByIDAndCo(int CoId, string UId)
        {
            return _context.Users.SingleOrDefault(m => m.fCompanyId == CoId && m.Id == UId);
        }

        public ApplicationUser GetUserEmailID(string UId)
        {
            return _context.Users.SingleOrDefault(m => m.Email == UId);
        }

        public ApplicationUser GetUserEmailIDForEmailValidation(string UId, string Email)
        {
            return _context.Users.SingleOrDefault(m => m.Email == Email && m.Id != UId);
        }

        public ApplicationUser LoginMobile(string UserName, string Password)
        {
            return _context.Users.SingleOrDefault(m => m.Email == UserName && m.RealPass == Password);

        }

        public async Task<bool> RemoveUserPermission(ApplicationUser model)
        {
            var store = new UserStore<ApplicationUser>(_context);
            var UserManager = new ApplicationUserManager(store);

            var user = _context.Users.FirstOrDefault(m => m.fCompanyId == model.fCompanyId && m.Id == model.Id);

            if (user != null)
            {


                user = model;



                string[] roleNames = {

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
                var userid = model.Id;
                var roles = await UserManager.GetRolesAsync(userid);
                await UserManager.RemoveFromRolesAsync(userid, roles.ToArray());




            }
            return true;
        }


        public void UpdateCompanyID(string UserID, int CompanyID)
        {
            var UserInfo = _context.Users.SingleOrDefault(m => m.Id == UserID);
            if (UserInfo != null)
            {
                UserInfo.fCompanyId = CompanyID;
            }
        }

        public async Task<bool> UpdateUserPermission(ApplicationUser model)
        {
            var store = new UserStore<ApplicationUser>(_context);
            var UserManager = new ApplicationUserManager(store);

            var user = _context.Users.FirstOrDefault(m => m.fCompanyId == model.fCompanyId && m.Id == model.Id);

            if (user != null)
            {


                user = model;



                string[] roleNames = {

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

                var userid = user.Id;
                var roles = await UserManager.GetRolesAsync(userid);
                await UserManager.RemoveFromRolesAsync(userid, roles.ToArray());
                await UserManager.AddToRoleAsync(userid, "CoUser");

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
            }
            return true;
        }

        public void UpdateUserPers(ApplicationUser model)
        {
            var user = _context.Users.FirstOrDefault(m => m.fCompanyId == model.fCompanyId && m.Id == model.Id);

            if (user != null)
            {
                user.ShowCompany = model.ShowCompany;

                user.UpdateCompany = model.UpdateCompany;
               
                user.ShowUser = model.ShowUser;
                user.AddUser = model.AddUser;
                user.UpdateUser = model.UpdateUser;
                user.DeleteUser = model.DeleteUser;
                user.PrintUser = model.PrintUser;

                user.ShowGroup = model.ShowGroup;
                user.AddGroup = model.AddGroup;
                user.UpdateGroup = model.UpdateGroup;
                user.DeleteGroup = model.DeleteGroup;
                user.PrintGroup = model.PrintGroup;

                user.ShowSource = model.ShowSource;
                user.AddSource = model.AddSource;
                user.UpdateSource = model.UpdateSource;
                user.DeleteSource = model.DeleteSource;
                user.PrintSource = model.PrintSource;


                user.ShowTrainer = model.ShowTrainer;
                user.AddTrainer = model.AddTrainer;
                user.UpdateTrainer = model.UpdateTrainer;
                user.DeleteTrainer = model.DeleteTrainer;
                user.PrintTrainer = model.PrintTrainer;

                user.ShowItem = model.ShowItem;
                user.AddItem = model.AddItem;
                user.UpdateItem = model.UpdateItem;
                user.DeleteItem = model.DeleteItem;
                user.PrintItem = model.PrintItem;

                user.ShowCustomerCompany = model.ShowCustomerCompany;
                user.AddCustomerCompany = model.AddCustomerCompany;
                user.UpdateCustomerCompany = model.UpdateCustomerCompany;
                user.DeleteCustomerCompany = model.DeleteCustomerCompany;
                user.PrintCustomerCompany = model.PrintCustomerCompany;

                user.ShowJob = model.ShowJob;
                user.AddJob = model.AddJob;
                user.UpdateJob = model.UpdateJob;
                user.DeleteJob = model.DeleteJob;
                user.PrintJob = model.PrintJob;


                user.ShowNationality = model.ShowNationality;
                user.AddNationality = model.AddNationality;
                user.UpdateNationality = model.UpdateNationality;
                user.DeleteNationality = model.DeleteNationality;
                user.PrintNationality = model.PrintNationality;

                user.ShowPlaceOfBirth = model.ShowPlaceOfBirth;
                user.AddPlaceOfBirth = model.AddPlaceOfBirth;
                user.UpdatePlaceOfBirth = model.UpdatePlaceOfBirth;
                user.DeletePlaceOfBirth = model.DeletePlaceOfBirth;
                user.PrintPlaceOfBirth = model.PrintPlaceOfBirth;




            }
        }



    }
}