﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class Expense
    {
        public int ID { get; set; }

        public string product { get; set; }

        public decimal cost { get; set; }

        //public int ApplicationUserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        
    }
}