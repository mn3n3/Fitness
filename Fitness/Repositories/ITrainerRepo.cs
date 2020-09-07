using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface ITrainerRepo
    {
       
        Trainer GetTrainerByID(int CompanyID, int TrainerCode);
        void Add(Trainer ObjSave);
        void Update(Trainer ObjUpdate);
        void Delete(Trainer ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}