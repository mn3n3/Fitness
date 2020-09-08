using Fitness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.ViewModels
{
    public class VisitorVM
    {
        public int CompanyID { get; set; }

        [Display(Name = "VisitorCode", ResourceType = typeof(Resources.Resource))]
        public int VisitorCode { get; set; }

        [Display(Name = "VisitorName", ResourceType = typeof(Resources.Resource))]
        public string VisitorName { get; set; }
        public int BirthDateInt { get; set; }
        [Display(Name = "BirthDate", ResourceType = typeof(Resources.Resource))]
        public DateTime BirthDate { get; set; }
        public int VistDateInt { get; set; }
        [Display(Name = "VistDate", ResourceType = typeof(Resources.Resource))]
        public DateTime VistDate { get; set; }


        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]

        public string Email { get; set; }

        [Display(Name = "Phone1", ResourceType = typeof(Resources.Resource))]

        public string Phone1 { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources.Resource))]

        public string Address { get; set; }

        [Display(Name = "GenderCode", ResourceType = typeof(Resources.Resource))]

        public int GenderCode { get; set; }
        public string GenderName { get; set; }

        [Display(Name = "NationalityCode", ResourceType = typeof(Resources.Resource))]

        public int NationalityCode { get; set; }

        [Display(Name = "NationalityName", ResourceType = typeof(Resources.Resource))]
        public IEnumerable<NationalityVM> Nationality { get; set; }

        [Display(Name = "NationalityName", ResourceType = typeof(Resources.Resource))]

        public string NationalityName { get; set; }

        [Display(Name = "SourceCode", ResourceType = typeof(Resources.Resource))]

        public int SourceCode { get; set; }
        public IEnumerable<SourceVM> Source { get; set; }

        [Display(Name = "SourceName", ResourceType = typeof(Resources.Resource))]

        public string SourceName { get; set; }


        [Display(Name = "JobCode", ResourceType = typeof(Resources.Resource))]

        public int JobCode { get; set; }
        public IEnumerable<JobVM> Job { get; set; }

        [Display(Name = "JobName", ResourceType = typeof(Resources.Resource))]

        public string JobName { get; set; }

        [Display(Name = "Note", ResourceType = typeof(Resources.Resource))]

        public string Note { get; set; }

        [Display(Name = "Interseted", ResourceType = typeof(Resources.Resource))]

        public bool Interseted { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }

        [Display(Name = "FromVistDate", ResourceType = typeof(Resources.Resource))]
        public DateTime FromVistDate { get; set; }
        [Display(Name = "ToDate", ResourceType = typeof(Resources.Resource))]
        public DateTime ToDate { get; set; }
        public string UserName { get; set; }
        public string IntersetedCase { get; set; }
        [Display(Name = "IntersetedCase", ResourceType = typeof(Resources.Resource))]
        public int IntersetedCaseInt { get; set; }

    }
}
