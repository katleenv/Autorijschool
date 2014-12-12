using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Persoon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //geeft eeb automatische nummering in de database
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(32)]
        public string Familienaam { get; set; }
        [Required]
        [MaxLength(32)]
        public string Voornaam { get; set; }
        [Required]
        [MaxLength(55)]
        public string Adres { get; set; }
        [Required]
        [MaxLength(55)]
        public string Gemeente { get; set; }
    }
}