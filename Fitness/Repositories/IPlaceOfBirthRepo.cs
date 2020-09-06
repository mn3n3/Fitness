using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface IPlaceOfBirthRepo
    {
        IEnumerable<PlaceOfBirth> GetAllBirth(int CompanyID);
        PlaceOfBirth GetBirthByID(int CompanyID, int PlaceCode);
        void Add(PlaceOfBirth ObjSave);
        void Update(PlaceOfBirth ObjUpdate);
        void Delete(PlaceOfBirth ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}