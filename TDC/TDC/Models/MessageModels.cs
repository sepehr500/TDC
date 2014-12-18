using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string notification { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}