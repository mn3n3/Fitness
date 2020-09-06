using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class JobRepo : IJobRepo
    {

        private readonly ApplicationDbContext _context;
        public JobRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Job ObjSave)
        {
            _context.Jobs.Add(ObjSave);
        }

        public void Delete(Job ObjDelete)
        {
            var ObjToDelete = _context.Jobs.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.JobCode == ObjDelete.JobCode);
            if (ObjToDelete != null)
            {
                _context.Jobs.Remove(ObjToDelete);
            }
        }

        public IEnumerable<Job> GetAllJob(int CompanyID)
        {
            return _context.Jobs.Where(m => m.CompanyID == CompanyID).ToList();

        }

        public Job GetJobByID(int CompanyID, int JobCode)
        {
            return _context.Jobs.FirstOrDefault(m => m.CompanyID == CompanyID && m.JobCode == JobCode);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Jobs.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Jobs.Where(m => m.CompanyID == CompanyID).Max(p => p.JobCode) + 1;
            }
        }

        public void Update(Job ObjUpdate)
        {
            var ObjToUpdate = _context.Jobs.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.JobCode == ObjUpdate.JobCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
                ObjToUpdate.InsDateTime = ObjUpdate.InsDateTime;
                ObjToUpdate.InsUserID = ObjUpdate.InsUserID;
            }
        }
    }
}