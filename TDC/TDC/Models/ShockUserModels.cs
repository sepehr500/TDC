using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class ShockUser
    {
        public int ID { get; set; }

        public string UserId { get; set; }

        public int ShockLUId { get; set; }

        public virtual User User { get; set; }

        public virtual ShockLU ShockLU { get; set; }

        public DateTime Date { get; set; }

        
    }
}