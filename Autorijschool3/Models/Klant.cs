using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Klant : Persoon
    {
       // [Key]
       // public int ID { get; set; }
        //staat al bij persoon
        public DateTime KlantSedert { get; set; }
        public virtual List<Bestelling> BestellingenLijst { get; set; }
    }
}