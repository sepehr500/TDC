using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TDC.Models
{
    public class Income
    {
        public int ID { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

    
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }

}