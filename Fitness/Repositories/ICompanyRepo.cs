using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface ICompanyRepo
    {
        void Add(Company ObjTOSave);
        void Update(Company ObjToUpdate);
        Company GetMyCompany(int CompanyID);
    }
}