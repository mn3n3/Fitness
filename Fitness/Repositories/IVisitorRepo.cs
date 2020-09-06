using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface IVisitorRepo
    {

        Visitor GetVisitorByID(int CompanyID, int VisitorCode);
        void Add(Visitor ObjSave);
        void Update(Visitor ObjUpdate);
        void Delete(Visitor ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}