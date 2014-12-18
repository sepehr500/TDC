using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class ShockLU
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }
        //1 = Ind, 2 = Community, 3 = Global 
        public int ShockType { get; set; }
        
        public virtual ICollection<ShockUser> ShockUser { get; set; }
    }
}