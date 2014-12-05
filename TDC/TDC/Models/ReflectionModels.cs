using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class Reflection

    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [StringLength(140, ErrorMessage = "Message can't be longer than 140 characters.")]
        public string Memo { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}