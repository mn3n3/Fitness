using Fitness.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fitness.ViewModels
{
    public class GroupVM
    {
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
        public string Suspension { get; set; }
        public string  UserName { get; set; }
        public double Percentage { get; set; }

    }
}