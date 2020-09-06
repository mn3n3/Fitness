using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class TrainerRepo : ITrainerRepo
    {

        private readonly ApplicationDbContext _context;
        public TrainerRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Trainer ObjSave)
        {
            _context.Trainers.Add(ObjSave);
        }

        public void Delete(Trainer ObjDelete)
        {
            var ObjToDelete = _context.Trainers.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.TrainerCode == ObjDelete.TrainerCode);
            if (ObjToDelete != null)
            {
                _context.Trainers.Remove(ObjToDelete);
            }
        }

        public IEnumerable<Trainer> GetAllTrainer(int CompanyID)
        {
            return _context.Trainers.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public int GetMaxSerial(int CompanyID)
        {

            var Obj = _context.Trainers.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Trainers.Where(m => m.CompanyID == CompanyID).Max(p => p.TrainerCode) + 1;
            }
        }

        public Trainer GetTrainerByID(int CompanyID, int TrainerCode)
        {
            return _context.Trainers.FirstOrDefault(m => m.CompanyID == CompanyID && m.TrainerCode == TrainerCode);
        }

        public void Update(Trainer ObjUpdate)
        {
            var ObjToUpdate = _context.Trainers.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.TrainerCode == ObjUpdate.TrainerCode);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.TrainerName = ObjUpdate.TrainerName;
                ObjToUpdate.Suspension = ObjUpdate.Suspension;
                ObjToUpdate.InsDateTime = ObjUpdate.InsDateTime;
                ObjToUpdate.InsUserID = ObjUpdate.InsUserID;
                ObjToUpdate.Percentage = ObjUpdate.Percentage;
            }
        }
    }
}