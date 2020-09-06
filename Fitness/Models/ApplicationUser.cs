using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}