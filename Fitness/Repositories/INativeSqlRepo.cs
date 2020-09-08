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
        
        IEnumerable<NationalityVM> GetAllNationalities(int CompanyID);
        IEnumerable<CustomerCompanyVM> GetAllCompanies(int CompanyID);
        IEnumerable<PlaceOfBirthVM> GetAllPlaces(int CompanyID);   
        IEnumerable<SourceVM> GetAllSources(int CompanyID);  
        IEnumerable<TrainerVM> GetAllTrainers(int CompanyID);
        IEnumerable<VisitorVM> GetAllVisitor(int CompanyID, DateTime FromVisitorDate, DateTime ToDate);      
        IEnumerable<ItemVM> GetAllItems(int CompanyID);
    }
}