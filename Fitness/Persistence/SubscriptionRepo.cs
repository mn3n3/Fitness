using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class SubscriptionRepo : ISubscriptionRepo
    {

        private readonly ApplicationDbContext _context;
        public SubscriptionRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Subscription ObjSave)
        {
            _context.Subscriptions.Add(ObjSave);
        }

        public void Delete(Subscription ObjDelete)
        {
            var ObjToDelete = _context.Subscriptions.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.SubscriptionCode == ObjDelete.SubscriptionCode);
            if (ObjToDelete != null)
            {
                _context.Subscriptions.Remove(ObjToDelete);
            }
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Subscriptions.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Subscriptions.Where(m => m.CompanyID == CompanyID).Max(p => p.SubscriptionCode) + 1;
            }
        }

        public Subscription GetSubscriptionByID(int CompanyID, int SubscriptionCode)
        {
            return _context.Subscriptions.FirstOrDefault(m => m.CompanyID == CompanyID && m.SubscriptionCode == SubscriptionCode);
        }

        public void Update(Subscription ObjUpdate)
        {
            var ObjToUpdate = _context.Subscriptions.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.SubscriptionCode == ObjUpdate.SubscriptionCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.PeriodByDay = ObjUpdate.PeriodByDay;
                ObjToUpdate.PeriodByMonth = ObjUpdate.PeriodByMonth;
                ObjToUpdate.Classes = ObjUpdate.Classes;
                ObjToUpdate.SubscriptionName = ObjUpdate.SubscriptionName;
                ObjToUpdate.Free = ObjUpdate.Free;
                ObjToUpdate.AddByAdmin = ObjUpdate.AddByAdmin;
                ObjToUpdate.Stop = ObjUpdate.Stop;
                ObjToUpdate.Group = ObjUpdate.Group;
                ObjToUpdate.Classes = ObjUpdate.Classes;
                ObjToUpdate.AccountNumber = ObjUpdate.AccountNumber;
                ObjToUpdate.CostCenterNumber = ObjUpdate.CostCenterNumber;
                ObjToUpdate.Type = ObjUpdate.Type;
            }
        }
    }
}