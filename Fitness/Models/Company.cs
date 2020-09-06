﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fitness.Models
{
    public class Company
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Display(Name = "ArabicName", ResourceType = typeof(Resources.Resource))]
        public string ArabicName { get; set; }
        [Display(Name = "EnglishName", ResourceType = typeof(Resources.Resource))]
        public string EnglishName { get; set; }
        [Display(Name = "Website", ResourceType = typeof(Resources.Resource))]
        public string Website { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }
        [Display(Name = "Phone1", ResourceType = typeof(Resources.Resource))]
        public string Telephone { get; set; }
        [Display(Name = "Phone2", ResourceType = typeof(Resources.Resource))]
        public string Mobile { get; set; }
        [Display(Name = "TeleFax", ResourceType = typeof(Resources.Resource))]
        public string TeleFax { get; set; }
        [Display(Name = "ArabicAddress", ResourceType = typeof(Resources.Resource))]
        public string ArabicAddress { get; set; }
        [Display(Name = "EnglishAddress", ResourceType = typeof(Resources.Resource))]
        public string EnglishAddress { get; set; }
        [Display(Name = "LogoPath", ResourceType = typeof(Resources.Resource))]
        public string LogoPath { get; set; }
        [Display(Name = "DecimalPoint", ResourceType = typeof(Resources.Resource))]
        public int DecimalPoint { get; set; }



        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public static implicit operator int(Company v)
        {
            throw new NotImplementedException();
        }
    }
}