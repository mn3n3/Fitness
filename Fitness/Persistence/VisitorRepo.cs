using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class VisitorRepo : IVisitorRepo
    {

        private readonly ApplicationDbContext _context;
        public VisitorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Visitor ObjSave)
        {
            _context.Visitors.Add(ObjSave);
        }

        public void Delete(Visitor ObjDelete)
        {
            var ObjToDelete = _context.Visitors.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.VisitorCode == ObjDelete.VisitorCode);
            if (ObjToDelete != null)
            {
                _context.Visitors.Remove(ObjToDelete);
            }
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Visitors.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Visitors.Where(m => m.CompanyID == CompanyID).Max(p => p.VisitorCode) + 1;
            }
        }

        public Visitor GetVisitorByID(int CompanyID, int VisitorCode)
        {
            return _context.Visitors.FirstOrDefault(m => m.CompanyID == CompanyID && m.VisitorCode == VisitorCode);

        }

        public void Update(Visitor ObjUpdate)
        {
            var ObjToUpdate = _context.Visitors.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.VisitorCode == ObjUpdate.VisitorCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.VisitorName = ObjUpdate.VisitorName;
                ObjToUpdate.BirthDate = ObjUpdate.BirthDate;
                ObjToUpdate.BirthDateInt = ObjUpdate.BirthDateInt;
                ObjToUpdate.Phone1 = ObjUpdate.Phone1;
                ObjToUpdate.SourceCode = ObjUpdate.SourceCode;
                ObjToUpdate.JobCode = ObjUpdate.JobCode;
                ObjToUpdate.NationalityCode = ObjUpdate.NationalityCode;
                ObjToUpdate.Interseted = ObjUpdate.Interseted;
                ObjToUpdate.Email = ObjUpdate.Email;
                ObjToUpdate.Address = ObjUpdate.Address;
                ObjToUpdate.Note = ObjUpdate.Note;
                ObjToUpdate.VistDate = ObjUpdate.VistDate;
                ObjToUpdate.VistDateInt = ObjUpdate.VistDateInt;
                ObjToUpdate.InsUserID = ObjUpdate.InsUserID;
                ObjToUpdate.InsDateTime = ObjUpdate.InsDateTime;
            }
        }
    }
}