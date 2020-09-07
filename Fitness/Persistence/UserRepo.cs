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
            throw new NotImplementedException();
        }

        public ApplicationUser GetMyInfo(string UserID)
        {
            return _context.Users.SingleOrDefault(m => m.Id == UserID);
        }

        public ApplicationUser GetUserByEmailAndPassword(string Email, string Passord)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserByEmpIdAndCo(int CoId, string UId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserByID(string UId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserByIDAndCo(int CoId, string UId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserEmailID(string UId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserEmailIDForEmailValidation(string UId, string Email)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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