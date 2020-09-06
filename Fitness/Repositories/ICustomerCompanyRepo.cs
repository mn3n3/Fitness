using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface ICustomerCompanyRepo
    {
        IEnumerable<CustomerCompany> GetAllCustomerCompany(int CompanyID);
        CustomerCompany GetCustomerCompanyByID(int CompanyID, int CompanyCode);
        void Add(CustomerCompany ObjSave);
        void Update(CustomerCompany ObjUpdate);
        void Delete(CustomerCompany ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}