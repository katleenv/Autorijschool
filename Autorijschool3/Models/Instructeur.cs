using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Instructeur : Persoon
    {
        public Instructeur()
            //wordt uitgevoerd bij new instructeur
        {
            LessenLijst = new List<Les>();
            TypeRijbewijzenLijst = new List<Rijbewijs>();
        }
        //staat al bij persoon
        //[Key]
        //public int ID { get; set; }
        public virtual List<Les> LessenLijst { get; set; }
        public virtual List<Rijbewijs> TypeRijbewijzenLijst { get; set; }

   
      

        public Boolean AddRijbewijs(Rijbewijs rij)
        {
            TypeRijbewijzenLijst.Add(rij);
            return true;

        }

        public Boolean AddRijbewijs(int id)
        {
            Autorijschool3DbContext db = new Autorijschool3DbContext();
            Rijbewijs nieuwRij = db.Rijbewijs.Find(id);
           //als we rijbewijs toevoegen zoeken op ID
            //als niet gevonden geven we een exception
            if(nieuwRij==null)
            {
                throw new ArgumentException("Id not found");
            
            }
            //nu gaan we het rijbewijs toevoegen
            AddRijbewijs(nieuwRij);
            return true;
        }
        public void RemoveRijbewijs(Rijbewijs rij)
        {

        }

        public void RemoveRijbewijs(int id)
        {

        }

    }


}