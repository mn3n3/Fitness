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
            throw new NotImplementedException();
        }

        public void AddModifyFromCreateCompnay(ApplicationUser ObjToSave)
        {
            throw new NotImplementedException();
        }

        public void ChangePass(ApplicationUser ObjToSave)
        {
            throw new NotImplementedException();
        }

        public void DeActivate(ApplicationUser ObjToSave)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserPermission(ApplicationUser model)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompanyID(string UserID, int CompanyID)
        {
            var UserInfo = _context.Users.SingleOrDefault(m => m.Id == UserID);
            if (UserInfo != null)
            {
                UserInfo.fCompanyId = CompanyID;
            }
        }

        public Task<bool> UpdateUserPermission(ApplicationUser model)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPers(ApplicationUser model)
        {
            throw new NotImplementedException();
        }
    }
}