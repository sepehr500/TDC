using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TDC.Tools;

namespace TDC.Models
{
    public class Income : IFundControl
    {
        public int ID { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

    
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public decimal getAmt()
        {
            return Amount;
        }


        public string getType()
        {
            return "Income";
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