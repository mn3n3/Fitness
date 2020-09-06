using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class GroupRepo : IGroupRepo
    {
        private readonly ApplicationDbContext _context;
        public GroupRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Group ObjSave)
        {
            _context.Groups.Add(ObjSave);
        }

        public void Delete(Group ObjDelete)
        {
            var ObjToDelete = _context.Groups.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.GroupCode == ObjDelete.GroupCode);
            if (ObjToDelete != null)
            {
                _context.Groups.Remove(ObjToDelete);
            }
        }

        public IEnumerable<Group> GetAllGroup(int CompanyID)
        {
            return _context.Groups.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public Group GetGroupByID(int CompanyID, int GroupCode)
        {
            return _context.Groups.FirstOrDefault(m => m.CompanyID == CompanyID && m.GroupCode == GroupCode);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Groups.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Groups.Where(m => m.CompanyID == CompanyID).Max(p => p.GroupCode) + 1;
            }
        }

        public void Update(Group ObjUpdate)
        {
            var ObjToUpdate = _context.Groups.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.GroupCode == ObjUpdate.GroupCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
                ObjToUpdate.Suspension = ObjUpdate.Suspension;
                ObjToUpdate.InsDateTime = ObjUpdate.InsDateTime;
                ObjToUpdate.InsUserID = ObjUpdate.InsUserID;
            }
        }
    }
}