using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fitness.Models
{
    public class Trainer
    {

        public Company Company { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "TrainerCode", ResourceType = typeof(Resources.Resource))]
        public int TrainerCode { get; set; }
        [Display(Name = "TrainerName", ResourceType = typeof(Resources.Resource))]
        public string TrainerName { get; set; }
        
        [Display(Name = "Suspension", ResourceType = typeof(Resources.Resource))]
        public bool Suspension { get; set; }

         [Display(Name = "Percentage", ResourceType = typeof(Resources.Resource))]
        public double Percentage { get; set; }


        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }


    }
}