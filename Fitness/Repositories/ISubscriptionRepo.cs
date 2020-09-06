using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface ISubscriptionRepo
    {
        Subscription GetSubscriptionByID(int CompanyID, int SubscriptionCode);
        void Add(Subscription ObjSave);
        void Update(Subscription ObjUpdate);
        void Delete(Subscription ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}