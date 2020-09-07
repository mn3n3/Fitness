using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class PlaceOfBirthRepo : IPlaceOfBirthRepo
    {
        private readonly ApplicationDbContext _context;
        public PlaceOfBirthRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(PlaceOfBirth ObjSave)
        {
            _context.PlaceOfBirths.Add(ObjSave);
        }

        public void Delete(PlaceOfBirth ObjDelete)
        {
            var ObjToDelete = _context.PlaceOfBirths.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.PlaceCode == ObjDelete.PlaceCode);
            if (ObjToDelete != null)
            {
                _context.PlaceOfBirths.Remove(ObjToDelete);
            }
        }

       
        public PlaceOfBirth GetBirthByID(int CompanyID, int PlaceCode)
        {
            return _context.PlaceOfBirths.FirstOrDefault(m => m.CompanyID == CompanyID && m.PlaceCode == PlaceCode);

        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.PlaceOfBirths.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.PlaceOfBirths.Where(m => m.CompanyID == CompanyID).Max(p => p.PlaceCode) + 1;
            }
        }

        public void Update(PlaceOfBirth ObjUpdate)
        {

            var ObjToUpdate = _context.PlaceOfBirths.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.PlaceCode == ObjUpdate.PlaceCode);
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