using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class Expense
    {
        public int ID { get; set; }

        [Display(Name = "Enter name of product (eg. pasta)")]
        public string product { get; set; }
        [Display(Name = "Enter price of product")]
        public decimal cost { get; set; }

        public string UserID { get; set; }
        
        public virtual User User { get; set; }

        
    }
}