using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Company ObjTOSave)
        {
            _context.Companies.Add(ObjTOSave);
        }
        public Company GetMyCompany(int CompanyID)
        {
            return _context.Companies.SingleOrDefault(m => m.CompanyID == CompanyID);
        }

        public void Update(Company ObjUpdate)
        {
            var ObjToUpdate = _context.Companies.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
                ObjToUpdate.ArabicAddress = ObjUpdate.ArabicAddress;
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.Email = ObjUpdate.Email;
                ObjToUpdate.EnglishAddress = ObjUpdate.EnglishAddress;
                ObjToUpdate.LogoPath = ObjUpdate.LogoPath;
                ObjToUpdate.Mobile = ObjUpdate.Mobile;
                ObjToUpdate.TeleFax = ObjUpdate.TeleFax;
                ObjToUpdate.Telephone = ObjUpdate.Telephone;
                ObjToUpdate.Website = ObjUpdate.Website;
                ObjToUpdate.DecimalPoint = ObjUpdate.DecimalPoint;
            }

        }
    }
}