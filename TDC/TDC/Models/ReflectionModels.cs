using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TDC.Models
{
    public class Reflection

    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(140, ErrorMessage = "Message can't be longer than 140 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Reflection")]
        public string Memo { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}