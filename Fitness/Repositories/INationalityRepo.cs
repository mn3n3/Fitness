using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface INationalityRepo
    {
        IEnumerable<Nationality> GetAllNationality(int CompanyID);
        Nationality GetNationalityByID(int CompanyID, int NationalityCode);
        void Add(Nationality ObjSave);
        void Update(Nationality ObjUpdate);
        void Delete(Nationality ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}