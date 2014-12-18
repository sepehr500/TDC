using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class GlobalDate
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        //if int = 1: Global, if int = 2 : Community
        public int Type { get; set; }
    }
}