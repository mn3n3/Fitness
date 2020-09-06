using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fitness.Models
{
    public class Visitor
    {

        public Company Company { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "VisitorCode", ResourceType = typeof(Resources.Resource))]
        public int VisitorCode { get; set; }

        [Display(Name = "VisitorName", ResourceType = typeof(Resources.Resource))]
        public string VisitorName { get; set; }

        [Display(Name = "BirthDate", ResourceType = typeof(Resources.Resource))]
        public int BirthDateInt { get; set; }

        public DateTime BirthDate { get; set; }

      
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]

        public string Email { get; set; }

        [Display(Name = "Phone1", ResourceType = typeof(Resources.Resource))]

        public string Phone1 { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources.Resource))]

        public string Address { get; set; }

        [Display(Name = "GenderCode", ResourceType = typeof(Resources.Resource))]

        public int GenderCode { get; set; }

        [Display(Name = "NationalityCode", ResourceType = typeof(Resources.Resource))]

        public int NationalityCode { get; set; }


        [Display(Name = "SourceCode", ResourceType = typeof(Resources.Resource))]

        public int SourceCode { get; set; }


        [Display(Name = "JobCode", ResourceType = typeof(Resources.Resource))]

        public int JobCode { get; set; }

        [Display(Name = "Note", ResourceType = typeof(Resources.Resource))]

        public string Note { get; set; }

         [Display(Name = "Interseted", ResourceType = typeof(Resources.Resource))]

        public bool Interseted { get; set; }

       [Display(Name = "UnInterseted", ResourceType = typeof(Resources.Resource))]

        public bool UnInterseted { get; set; }

    }
}