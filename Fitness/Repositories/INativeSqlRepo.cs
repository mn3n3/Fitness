using Fitness.Models;
using Fitness.ViewModels;
using System;
using System.Collections.Generic;

namespace Fitness.Repositories
{
    public interface INativeSqlRepo
    {
        IEnumerable<GroupVM> GetAllGroup(int CompanyID);
        IEnumerable<JobVM> GetAllJob(int CompanyID);
    }
}