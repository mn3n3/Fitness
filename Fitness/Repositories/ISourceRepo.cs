using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Repositories
{
    public interface ISourceRepo
    { 
        Source GetSourceByID(int CompanyID, int SourceCode);
        void Add(Source ObjSave);
        void Update(Source ObjUpdate);
        void Delete(Source ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}