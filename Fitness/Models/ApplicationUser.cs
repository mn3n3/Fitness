﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Fitness.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserType { get; set; }
        public int fCompanyId { get; set; }
        public int AccountStatus { get; set; }
        public string EmployeeID { get; set; }

        //public string FCOREFID { get; set; }
        //public int FCoID { get; set; }
        //public int AccountStatus { get; set; }

        //public string EmployeeID { get; set; }

        public string RealPass { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowCompany { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateCompany { get; set; }


        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowUser { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddUser { get; set; }


        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateUser { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteUser { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintUser { get; set; }



         [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowGroup { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool  AddGroup { get; set; }

         [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateGroup { get; set; }

          [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteGroup { get; set; }

         [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintGroup { get; set; }


        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowSource { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddSource { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateSource { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteSource { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintSource { get; set; }




        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowTrainer { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddTrainer { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateTrainer { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteTrainer { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintTrainer { get; set; }





        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowItem { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddItem { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateItem { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteItem { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintItem { get; set; }



        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowCustomerCompany { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddCustomerCompany { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateCustomerCompany { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteCustomerCompany { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintCustomerCompany { get; set; }




        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowJob { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddJob { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateJob { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteJob { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintJob { get; set; }



        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowNationality { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddNationality { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdateNationality { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeleteNationality { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintNationality { get; set; }




        [Display(Name = "Show", ResourceType = typeof(Resources.Resource))]
        public bool ShowPlaceOfBirth { get; set; }

        [Display(Name = "Add", ResourceType = typeof(Resources.Resource))]
        public bool AddPlaceOfBirth { get; set; }

        [Display(Name = "Update", ResourceType = typeof(Resources.Resource))]
        public bool UpdatePlaceOfBirth { get; set; }

        [Display(Name = "Delete", ResourceType = typeof(Resources.Resource))]
        public bool DeletePlaceOfBirth { get; set; }

        [Display(Name = "Print", ResourceType = typeof(Resources.Resource))]
        public bool PrintPlaceOfBirth { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;


        }
    }
}