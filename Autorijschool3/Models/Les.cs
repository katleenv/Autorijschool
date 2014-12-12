using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Les
    {
        [Key]
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public DateTime UurStart { get; set; }
        public DateTime UurEinde { get; set; }
        [Required]
        public virtual Bestelling Bestelling { get; set; }
        [Required]
        public virtual Instructeur Instructeur { get; set; }
    }
}