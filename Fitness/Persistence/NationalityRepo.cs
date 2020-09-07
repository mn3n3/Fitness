using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class NationalityRepo : INationalityRepo
    {
        private readonly ApplicationDbContext _context;
        public NationalityRepo(ApplicationDbContext context)
        {
            _context = context;
        }
              

        public void Add(Nationality ObjSave)
        {
            _context.Nationalities.Add(ObjSave);
        }

        public void Delete(Nationality ObjDelete)
        {
            var ObjToDelete = _context.Nationalities.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.NationalityCode == ObjDelete.NationalityCode);
            if (ObjToDelete != null)
            {
                _context.Nationalities.Remove(ObjToDelete);
            }
        }


        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Nationalities.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Nationalities.Where(m => m.CompanyID == CompanyID).Max(p => p.NationalityCode) + 1;
            }
        }

        public Nationality GetNationalityByID(int CompanyID, int NationalityCode)
        {
            return _context.Nationalities.FirstOrDefault(m => m.CompanyID == CompanyID && m.NationalityCode == NationalityCode);

        }

        public void Update(Nationality ObjUpdate)
        {
            var ObjToUpdate = _context.Nationalities.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.NationalityCode == ObjUpdate.NationalityCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
                ObjToUpdate.InsDateTime = ObjUpdate.InsDateTime;
                ObjToUpdate.InsUserID = ObjUpdate.InsUserID;
            }
        }

       
    }
}