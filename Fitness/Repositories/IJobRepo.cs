using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface IJobRepo
    {

        Job GetJobByID(int CompanyID, int JobCode);
        void Add(Job ObjSave);
        void Update(Job ObjUpdate);
        void Delete(Job ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}