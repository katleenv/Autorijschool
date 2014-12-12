using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Rijbewijs
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(12)]
        public string Naam { get; set; }
        public virtual List<Instructeur> InstructeursLijst { get; set; }

        private Autorijschool3DbContext db = new Autorijschool3DbContext();
        private Instructeur inst = new Instructeur();

        public void AddInstructeur(Instructeur inst) {
            
        }

        public void AddInstructeur(int inst)
        {

        }
        public void RemoveInstructeur(Instructeur inst)
        {

        }

        public void RemoveInstructeur(int inst)
        {

        }

        

    }
}