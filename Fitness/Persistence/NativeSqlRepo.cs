using Fitness.Models;
using Fitness.Repositories;
using Fitness.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace Fitness.Persistence
{
    public class NativeSqlRepo : INativeSqlRepo
    {
        private readonly ApplicationDbContext _context;
        public NativeSqlRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GroupVM> GetAllGroup(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<GroupVM>(
                    " Select G.GroupCode, G.ArabicName As GroupName,A.UserName, " +
                    " ( " +
                      " Case When " +
                      " G.Suspension = 0 Then N'فعال' " +
                      " Else " +
                      " N'موقوف' " +
                      " End " +
                    " ) As Suspension " +
                    " From Groups G,AspNetUsers A " +
                    " Where " +
                    " G.CompanyID = @CompanyID " +
                    " And " +
                    " G.CompanyID = A.fCompanyId " +
                    " And " +
                    " G.InsUserID = A.Id " +
                    " Order By G.GroupCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<GroupVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<GroupVM>(
                    " Select G.GroupCode, G.EnglishName As GroupName,A.UserName, " +
                    " ( " +
                      " Case When " +
                      " G.Suspension = 0 Then 'Active' " +
                      " Else " +
                      " 'Suspension' " +
                      " End " +
                    " ) As Suspension " +
                    " From Groups G,AspNetUsers A " +
                    " Where " +
                    " G.CompanyID = @CompanyID " +
                    " And " +
                    " G.CompanyID = A.fCompanyId " +
                    " And " +
                    " G.InsUserID = A.Id " +
                    " Order By G.GroupCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<GroupVM>();
                }

            }
        }

        public IEnumerable<JobVM> GetAllJob(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<JobVM>(
                      " Select J.JobCode, J.ArabicName As JobName,A.UserName  " +
                    "  From Jobs J,AspNetUsers A " +
                     " Where  " +
                    "  J.CompanyID = @CompanyID " +
                    "  And  " +
                    "  J.CompanyID = A.fCompanyId " +
                   "   And  " +
                    "  J.InsUserID = A.Id  " +
                   "   Order By J.JobCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<JobVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<JobVM>(
                      " Select J.JobCode, J.ArabicName As JobName,A.UserName  " +

                    "  From Jobs J,AspNetUsers A " +
                     " Where  " +
                    "  J.CompanyID = @CompanyID " +
                    "  And  " +
                    "  J.CompanyID = A.fCompanyId " +
                   "   And  " +
                    "  J.InsUserID = A.Id  " +
                   "   Order By J.JobCode "

                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<JobVM>();
                }

            }
        }
    }
}