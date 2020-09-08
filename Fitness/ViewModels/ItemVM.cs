using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.ViewModels
{
    public class ItemVM
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double  ItemPrice { get; set; }
        public double ItemCost { get; set; }
        public string UserName { get; set; }
    }
}