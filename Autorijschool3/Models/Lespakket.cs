using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Lespakket
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Omschrijving { get; set; }
        [Required]
        public int Kostprijs { get; set; }
        [Required]
        public int AantalBlokken { get; set; }
        [Required]
        public virtual Rijbewijs TypeRijbewijs { get; set; }
        public virtual List<Bestelling> BestellingenLijst { get; set; }

    }
}