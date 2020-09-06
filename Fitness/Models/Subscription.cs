using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Fitness.Models
{
    public class Subscription
    {
        public Company Company { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "SubscriptionCode", ResourceType = typeof(Resources.Resource))]
        public int SubscriptionCode { get; set; } 
        
        [Display(Name = "SubscriptionName", ResourceType = typeof(Resources.Resource))]
        public int SubscriptionName { get; set; }


        [Display(Name = "PeriodByMonth", ResourceType = typeof(Resources.Resource))]
        public int PeriodByMonth { get; set; }

         [Display(Name = "PeriodByDay", ResourceType = typeof(Resources.Resource))]
        public int PeriodByDay { get; set; }

        [Display(Name = "PeriodByWeeks", ResourceType = typeof(Resources.Resource))]
        public int PeriodByWeeks { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
        public double Price { get; set; }
        
        [Display(Name = "Group", ResourceType = typeof(Resources.Resource))]
        public string Group { get; set; }
        
        [Display(Name = "Type", ResourceType = typeof(Resources.Resource))]
        public int Type { get; set; }
        
        [Display(Name = "Classes", ResourceType = typeof(Resources.Resource))]
        public int Classes { get; set; } 


        [Display(Name = "AccountNumber", ResourceType = typeof(Resources.Resource))]
        public int AccountNumber { get; set; }

       [Display(Name = "CostCenterNumber", ResourceType = typeof(Resources.Resource))]
        public int CostCenterNumber { get; set; }


        [Display(Name = "Free", ResourceType = typeof(Resources.Resource))]
        public bool Free { get; set; } 

        [Display(Name = "AddByAdmin", ResourceType = typeof(Resources.Resource))]
        public bool AddByAdmin { get; set; }  
        
        [Display(Name = "Stop", ResourceType = typeof(Resources.Resource))]
        public  bool Stop { get; set; }




    }
}