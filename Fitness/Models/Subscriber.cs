using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Fitness.Models
{
    public class Subscriber
    {
        public Company Company { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "SubscriberCode", ResourceType = typeof(Resources.Resource))]
        public int SubscriberCode { get; set; }

        [Display(Name = "SubscriberType", ResourceType = typeof(Resources.Resource))]
        public int SubscriberType { get; set; }

        [Display(Name = "CardNumber", ResourceType = typeof(Resources.Resource))]
        public string CardNumber { get; set; }

        [Display(Name = "SubscriberName", ResourceType = typeof(Resources.Resource))]
        public string SubscriberName { get; set; }

        [Display(Name = "BirthDate", ResourceType = typeof(Resources.Resource))]
        public int BirthDateInt { get; set; }
         
        public DateTime BirthDate { get; set; }

        [Display(Name = "Phone1", ResourceType = typeof(Resources.Resource))]

        public string Phone1 { get; set; }

        [Display(Name = "Phone2", ResourceType = typeof(Resources.Resource))]

        public string Phone2 { get; set; }

       [Display(Name = "Weight", ResourceType = typeof(Resources.Resource))]

        public double Weight { get; set; }

         [Display(Name = "Lenght", ResourceType = typeof(Resources.Resource))]

        public double Length { get; set; }


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


        [Display(Name = "CompanyName", ResourceType = typeof(Resources.Resource))]

        public int CompanyName { get; set; }

        [Display(Name = "CompanyAddress", ResourceType = typeof(Resources.Resource))]

        public string CompanyAddress { get; set; }


        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]

        public string Email { get; set; }

        [Display(Name = "SocialStatus", ResourceType = typeof(Resources.Resource))]

        public string SocialStatus { get; set; }

        [Display(Name = "PlaceOfBirth", ResourceType = typeof(Resources.Resource))]

        public string PlaceOfBirth { get; set; }

        [Display(Name = "IDNumber", ResourceType = typeof(Resources.Resource))]

        public string IDNumber { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Resources.Resource))]

        public int Type { get; set; }

        [Display(Name = "ParentsName", ResourceType = typeof(Resources.Resource))]

        public string ParentsName { get; set; }

        [Display(Name = "Image1", ResourceType = typeof(Resources.Resource))]

        public string Image1 { get; set; }

        [Display(Name = "Image2", ResourceType = typeof(Resources.Resource))]

        public string Image2 { get; set; }

        [Display(Name = "Active", ResourceType = typeof(Resources.Resource))]

        public bool Active { get; set; }


    }
}