using Autorijschool3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Autorijschool3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //hier kan je testen met zaken toe te voegen aan db
            //start bij begin applicatie
           // VoegToe();
        }
        public void VoegToe() 
        {
            Autorijschool3DbContext db = new Autorijschool3DbContext();
        //nieuwe klant maken
          /*  Klant klant = new Klant
            {
                Familienaam="Janssens",
                Voornaam="Jan",
                Adres="Hoofdstraat",
                KlantSedert= DateTime.Now,
                Gemeente = "Brussel"
                
            };

            db.Klants.Add(klant);
           db.SaveChanges();*/

            //onderstaande werkt nog niet, aan alle requirements voeldoen om te kunnen testen

           // Bestelling best = new Bestelling()
           // {
           //     Klant = klant

           // };

            //dan hoeft het bovenstaande bij klant niet meer gebeuren, hij gaat kijken naar een nieuwe klant en voegt deze samen toe
            //db.Bestellings.Add(best);
            //db.SaveChanges();

            Rijbewijs r1 = new Rijbewijs() 
            { 
            Naam="A"
            };
            db.Rijbewijs.Add(r1);

            Rijbewijs r2 = new Rijbewijs()
            {
                Naam = "B"
            };
            db.Rijbewijs.Add(r2);

            Instructeur ins1 = new Instructeur()
            {
                Familienaam="Jannsens",
                Voornaam="Jan",
                Adres="Kerkstraat",
                Gemeente="Mechelen"

            };


            db.Instructeurs.Add(ins1);
            ins1.AddRijbewijs(r1);
            ins1.AddRijbewijs(r2);
            db.SaveChanges();
        }

    }
}
