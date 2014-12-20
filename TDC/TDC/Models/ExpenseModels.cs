using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TDC.Tools;

namespace TDC.Models
{
    public class Expense : IFundControl
    {
        public int ID { get; set; }

        [Display(Name = "Enter name of product (eg. pasta)")]
        public string product { get; set; }
        [Display(Name = "Enter price of product")]
        public decimal cost { get; set; }

        public DateTime Date { get; set; }

        public string UserID { get; set; }
        
        public virtual User User { get; set; }





        public decimal getAmt()
        {
            return cost;
        }

        public string getType()
        {
            return "Expense";
        }

        public DateTime getDate()
        {
            return Date;
        }
        public int CompareTo(IFundControl other)
        {
            return Date.CompareTo(other.getDate());
        }
    }
}