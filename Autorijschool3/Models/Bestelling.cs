using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Bestelling
    {
        [Key]
        public int ID { get; set; }
        [Required]
        //virtual : niet meteen klant gaan invullen
        public virtual Klant Klant { get; set; }
        public DateTime BestelDatum { get; set; }
        [Required]
        public virtual Lespakket Lespakket { get; set; }
        public virtual List<Les> LessenLijst { get; set; }
        public Boolean Betaald { get; set; }
    }
}