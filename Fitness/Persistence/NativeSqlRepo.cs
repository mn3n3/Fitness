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
                      " Select J.JobCode, J.EnglishName As JobName,A.UserName  " +
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
        public IEnumerable<NationalityVM> GetAllNationalities(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<NationalityVM>(
                    " Select N.NationalityCode, N.ArabicName As NationalityName ,A.UserName  " +
                    "  From Nationalities N ,AspNetUsers A " +
                    "  Where  " +
                    "  N.CompanyID = @CompanyID " +
                    "  And  " +
                     "  N.CompanyID = A.fCompanyId " +
                      "  And  " +
                     "  N.InsUserID = A.Id   " +
                     "  Order By N.NationalityCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<NationalityVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<NationalityVM>(
                   " Select N.NationalityCode, N.ArabicName As NationalityName ,A.UserName  " +
                    "  From Nationalities N ,AspNetUsers A " +
                    "  Where  " +
                    "  N.CompanyID = @CompanyID " +
                    "  And  " +
                     "  N.CompanyID = A.fCompanyId " +
                      "  And  " +
                     "  N.InsUserID = A.Id   " +
                     "  Order By N.NationalityCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<NationalityVM>();
                }

            }
        }
        public IEnumerable<CustomerCompanyVM> GetAllCompanies(int CompanyID)
        {
            try
            {
                return _context.Database.SqlQuery<CustomerCompanyVM>(
                "  Select C.CompanyCode, C.CompanyName ,A.UserName  " +
                "  From CustomerCompanies C,AspNetUsers A " +
                "  Where   " +
                  "  C.CompanyID = @CompanyID " +
               "   And   " +
                 "  C.CompanyID = A.fCompanyId  " +
                 "   And   " +
                 "  C.InsUserID = A.Id    " +
                 "  Order By C.CompanyCode "
                , new SqlParameter("@CompanyID", CompanyID)

            ).ToList();
            }
            catch
            {
                return new List<CustomerCompanyVM>();
            }
        }
        public IEnumerable<PlaceOfBirthVM> GetAllPlaces(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<PlaceOfBirthVM>(

                   "  Select P.PlaceCode, P.ArabicName As PlaceName ,A.UserName   " +
                   "    From PlaceOfBirths P,AspNetUsers A  " +
                    "   Where    " +
                    "     P.CompanyID = @CompanyID " +
                    "   And  " +
                    "    P.CompanyID = A.fCompanyId " +
                    "     And  " +
                    "    P.InsUserID = A.Id   " +
                    "    Order By P.PlaceCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<PlaceOfBirthVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<PlaceOfBirthVM>(
                     "  Select P.PlaceCode, P.EnglishName As PlaceName ,A.UserName   " +
                   "    From PlaceOfBirths P ,AspNetUsers A  " +
                    "   Where    " +
                    "     P.CompanyID = @CompanyID " +
                    "   And  " +
                    "    P.CompanyID = A.fCompanyId " +
                    "     And  " +
                    "    P.InsUserID = A.Id   " +
                    "    Order By P.PlaceCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<PlaceOfBirthVM>();
                }

            }
        }
        public IEnumerable<SourceVM> GetAllSources(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<SourceVM>(
                      " Select S.SourceCode, S.ArabicName As SourceName, A.UserName " +
                      "  From Sources S, AspNetUsers A " +
                      "  Where " +
                      "    S.CompanyID = @CompanyID " +
                     "   And " +
                      "   S.CompanyID = A.fCompanyId " +
                      "   And " +
                      "   S.InsUserID = A.Id " +
                      "   Order By S.SourceCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<SourceVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<SourceVM>(
                    "  Select S.SourceCode, S.EnglishName As SourceName, A.UserName " +
                      "  From Sources S, AspNetUsers A " +
                      "  Where " +
                      "    S.CompanyID = @CompanyID " +
                     "   And " +
                      "   S.CompanyID = A.fCompanyId " +
                      "   And " +
                      "   S.InsUserID = A.Id " +
                      "   Order By S.SourceCode "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<SourceVM>();
                }

            }
        }
        public IEnumerable<TrainerVM> GetAllTrainers(int CompanyID)
        {
            try
            {
                return _context.Database.SqlQuery<TrainerVM>(
                  " Select T.TrainerCode, T.TrainerName, A.UserName,T.[Percentage], " +
                  " ( " +
                  " Case When " +
                  " T.Suspension = 0 Then N'فعال' " +
                  " Else " +
                  " N'موقوف' " +
                  " End " +
                  " ) As Suspension " +
                  "  From Trainers T, AspNetUsers A " +
                  "  Where " +
                  "  T.CompanyID =  @CompanyID " +
                  "  And " +
                  "   T.CompanyID = A.fCompanyId " +
                  "   And " +
                  "  T.InsUserID = A.Id " +
                  "  Order By T.TrainerCode "
                , new SqlParameter("@CompanyID", CompanyID)

            ).ToList();
            }
            catch
            {
                return new List<TrainerVM>();
            }
        }

        public IEnumerable<ItemVM> GetAllItems(int CompanyID )
        {
            try
            {
                return _context.Database.SqlQuery<ItemVM>(
                    " Select I.ItemCode, I.ItemName, A.UserName, I.ItemPrice, I.ItemCost " +
                   "  From Items I, AspNetUsers A " +
                   "  Where " +
                   "  I.CompanyID = @CompanyID " +
                   "  And " +
                   "   I.CompanyID = A.fCompanyId " +
                    "  And " +
                   "  I.InsUserID = A.Id " +
                   "  Order By I.ItemCode " 
                , new SqlParameter("@CompanyID", CompanyID)
        

            ).ToList();
            }
            catch
            {
                return new List<ItemVM>();
            }
        }
        public IEnumerable<VisitorVM> GetAllVisitor(int CompanyID,int FromVisitorDate , int ToDate)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<VisitorVM>(
                      " Select V.VisitorCode, V.VisitorName, V.VistDate, N.ArabicName As NationalityName,V.Interseted, " +
                        " S.ArabicName As SourceName, J.ArabicName As JobName, A.UserName, " +
                         " ( " +
                         " Case When " +
                         " V.Interseted = 0 Then N'غير مهتم' " +
                         " Else " +
                         " N'مهتم' " +
                         " End " +
                         " ) As IntersetedCase " +
                        " From AspNetUsers A,Visitors V " +
                        " Left Join Nationalities N On " +
                        " V.NationalityCode = N.NationalityCode " +
                        " And " +
                        " V.CompanyID = N.CompanyID " +
                        " Left Join Sources S On " +
                        " V.SourceCode = S.SourceCode " +
                        " And " +
                        " V.CompanyID = S.CompanyID " +
                        " Left Join Jobs J On " +
                        " V.JobCode = J.JobCode " +
                        " And " +
                        " V.CompanyID = J.CompanyID " +
                        " Where " +
                        " V.CompanyID = A.fCompanyId " +
                        " And " +
                        " V.InsUserID = A.Id " +
                        " And " +
                        " V.CompanyID >= @CompanyID " +
                        " And " +
                        " V.VistDateInt >= @FromVisitorDate " +
                        " And " +
                        " V.VistDateInt <= @ToDate " +
                      "  Order By V.VisitorCode "
                    , new SqlParameter("@CompanyID", CompanyID)
                    , new SqlParameter("@FromVisitorDate", FromVisitorDate)
                    , new SqlParameter("@ToDate", ToDate)
                ).ToList();
                }
                catch
                {
                    return new List<VisitorVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<VisitorVM>(
                      " Select V.VisitorCode, V.VisitorName, V.VistDate, N.EnglishName As NationalityName, " +
                        " S.EnglishName As SourceName, J.EnglishName As JobName, A.UserName, " +
                         " ( " +
                         " Case When " +
                         " V.Interseted = 0 Then 'UnInterseted' " +
                         " Else " +
                         " 'Interseted' " +
                         " End " +
                         " ) As IntersetedCase " +
                        " From AspNetUsers A,Visitors V " +
                        " Left Join Nationalities N On " +
                        " V.NationalityCode = N.NationalityCode " +
                        " And " +
                        " V.CompanyID = N.CompanyID " +
                        " Left Join Sources S On " +
                        " V.SourceCode = S.SourceCode " +
                        " And " +
                        " V.CompanyID = S.CompanyID " +
                        " Left Join Jobs J On " +
                        " V.JobCode = J.JobCode " +
                        " And " +
                        " V.CompanyID = J.CompanyID " +
                        " Where " +
                        " V.CompanyID = A.fCompanyId " +
                        " And " +
                        " V.InsUserID = A.Id " +
                        " And " +
                        " V.CompanyID >= @CompanyID " +
                        " And " +
                        " V.VistDateInt >= @FromVisitorDate " +
                        " And " +
                        " V.VistDateInt <= @ToDate " +
                      "  Order By V.VisitorCode "
                    , new SqlParameter("@CompanyID", CompanyID)
                    , new SqlParameter("@FromVisitorDate", FromVisitorDate)
                    , new SqlParameter("@ToDate", ToDate)
                ).ToList();
                }
                catch
                {
                    return new List<VisitorVM>();
                }

            }
            
        }
    }

}