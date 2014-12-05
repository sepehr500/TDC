using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class Income
    {
        public int ID { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }

}