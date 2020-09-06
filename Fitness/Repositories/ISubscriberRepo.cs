using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface ISubscriberRepo
    {
        Subscriber GetSubscriberByID(int CompanyID, int SubscriberCode);
        void Add(Subscriber ObjSave);
        void Update(Subscriber ObjUpdate);
        void Delete(Subscriber ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}