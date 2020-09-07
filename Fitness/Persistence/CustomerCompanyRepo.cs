using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class CustomerCompanyRepo : ICustomerCompanyRepo
    {

        private readonly ApplicationDbContext _context;
        public CustomerCompanyRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public void Add(CustomerCompany ObjSave)
        {
            _context.CustomerCompanies.Add(ObjSave);
        }

        public void Delete(CustomerCompany ObjDelete)
        {
            var ObjToDelete = _context.CustomerCompanies.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.CompanyCode == ObjDelete.CompanyCode);
            if (ObjToDelete != null)
            {
                _context.CustomerCompanies.Remove(ObjToDelete);
            }
        }

       

        public CustomerCompany GetCustomerCompanyByID(int CompanyID, int CompanyCode)
        {
            return _context.CustomerCompanies.FirstOrDefault(m => m.CompanyID == CompanyID && m.CompanyCode == CompanyCode);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.CustomerCompanies.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.CustomerCompanies.Where(m => m.CompanyID == CompanyID).Max(p => p.CompanyCode) + 1;
            }
        }

        public void Update(CustomerCompany ObjUpdate)
        {
            var ObjToUpdate = _context.CustomerCompanies.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.CompanyCode == ObjUpdate.CompanyCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.CompanyName = ObjUpdate.CompanyName;
                ObjToUpdate.InsDateTime = ObjUpdate.InsDateTime;
                ObjToUpdate.InsUserID = ObjUpdate.InsUserID;
            }
        }
    }
}