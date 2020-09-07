using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface IGroupRepo
    {
        Group GetGroupByID(int CompanyID, int GroupCode);
        void Add(Group ObjSave);
        void Update(Group ObjUpdate);
        void Delete(Group ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}