using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class SubscriberRepo :ISubscriberRepo

    {
        private readonly ApplicationDbContext _context;
        public SubscriberRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Subscriber ObjSave)
        {
            _context.Subscribers.Add(ObjSave);
        }

        public void Delete(Subscriber ObjDelete)
        {
            var ObjToDelete = _context.Subscribers.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.SubscriberCode == ObjDelete.SubscriberCode);
            if (ObjToDelete != null)
            {
                _context.Subscribers.Remove(ObjToDelete);
            }
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Subscribers.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Subscribers.Where(m => m.CompanyID == CompanyID).Max(p => p.SubscriberCode) + 1;
            }
        }

        public Subscriber GetSubscriberByID(int CompanyID, int SubscriberCode)
        {
            return _context.Subscribers.FirstOrDefault(m => m.CompanyID == CompanyID && m.SubscriberCode == SubscriberCode);
        }

        public void Update(Subscriber ObjUpdate)
        {

            var ObjToUpdate = _context.Subscribers.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.SubscriberCode == ObjUpdate.SubscriberCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.SubscriberName = ObjUpdate.SubscriberName;
                ObjToUpdate.SubscriberType = ObjUpdate.SubscriberType;
                ObjToUpdate.PlaceOfBirth = ObjUpdate.PlaceOfBirth;
                ObjToUpdate.BirthDate = ObjUpdate.BirthDate;
                ObjToUpdate.ParentsName = ObjUpdate.ParentsName;
                ObjToUpdate.Phone1 = ObjUpdate.Phone1;
                ObjToUpdate.Phone2 = ObjUpdate.Phone2;
                ObjToUpdate.SocialStatus = ObjUpdate.SocialStatus;
                ObjToUpdate.SourceCode = ObjUpdate.SourceCode;
                ObjToUpdate.JobCode = ObjUpdate.JobCode;
                ObjToUpdate.Length = ObjUpdate.Length;
                ObjToUpdate.Weight = ObjUpdate.Weight;
                ObjToUpdate.Type = ObjUpdate.Type;
                ObjToUpdate.JobCode = ObjUpdate.JobCode;
                ObjToUpdate.Image1 = ObjUpdate.Image1;
                ObjToUpdate.Image2 = ObjUpdate.Image2;
                ObjToUpdate.Active = ObjUpdate.Active;
                ObjToUpdate.Email = ObjUpdate.Email;
                ObjToUpdate.Address = ObjUpdate.Address;


            }
        }
    }
}