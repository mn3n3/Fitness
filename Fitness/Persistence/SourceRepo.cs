using Fitness.Models;
using Fitness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Persistence
{
    public class SourceRepo : ISourceRepo

    {
        private readonly ApplicationDbContext _context;
        public SourceRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Source ObjSave)
        {
            _context.Sources.Add(ObjSave);
        }

        public void Delete(Source ObjDelete)
        {
            var ObjToDelete = _context.Sources.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.SourceCode == ObjDelete.SourceCode);
            if (ObjToDelete != null)
            {
                _context.Sources.Remove(ObjToDelete);
            }
        }

        public IEnumerable<Source> GetAllSource(int CompanyID)
        {
            return _context.Sources.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Sources.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Sources.Where(m => m.CompanyID == CompanyID).Max(p => p.SourceCode) + 1;
            }
        }

        public Source GetSourceByID(int CompanyID, int SourceCode)
        {
            return _context.Sources.FirstOrDefault(m => m.CompanyID == CompanyID && m.SourceCode == SourceCode);

        }

        public void Update(Source ObjUpdate)
        {
            var ObjToUpdate = _context.Sources.SingleOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.SourceCode == ObjUpdate.SourceCode);
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