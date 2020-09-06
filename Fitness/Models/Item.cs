using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fitness.Models
{
    public class Item
    {
        public Company Company { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }

        [Display(Name = "ItemCode", ResourceType = typeof(Resources.Resource))]

        public string ItemCode { get; set; }

        [Display(Name = "ItemName", ResourceType = typeof(Resources.Resource))]

        public string ItemName { get; set; }

        [Display(Name = "ItemPrice", ResourceType = typeof(Resources.Resource))]

        public double ItemPrice { get; set; }

        [Display(Name = "ItemCost", ResourceType = typeof(Resources.Resource))]

        public double ItemCost { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }




    }
}