using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Autorijschool3.Models
{
    public class Autorijschool3DbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Autorijschool3DbContext() : base("name=Autorijschool3DbContext")
        {
        }

        public virtual System.Data.Entity.DbSet<Autorijschool3.Models.Bestelling> Bestellings { get; set; }

        public virtual System.Data.Entity.DbSet<Autorijschool3.Models.Instructeur> Instructeurs { get; set; }

        public virtual System.Data.Entity.DbSet<Autorijschool3.Models.Klant> Klants { get; set; }

        public virtual System.Data.Entity.DbSet<Autorijschool3.Models.Les> Les { get; set; }

        public virtual System.Data.Entity.DbSet<Autorijschool3.Models.Lespakket> Lespakkets { get; set; }

        //public virtual System.Data.Entity.DbSet<Autorijschool3.Models.Persoon> Persoons { get; set; }
       //erft over dus aparte tabel is niet nodig

        public virtual System.Data.Entity.DbSet<Autorijschool3.Models.Rijbewijs> Rijbewijs { get; set; }

        //constraints wegdoen zodat je de een tabel leeg kan meken zonder dat de foreign keys problemen geven:

       // protected override void OnModelCreating(DbModelBuilder modelBuilder)
       // {
        //    base.OnModelCreating(modelBuilder);
        //   modelBuilder.Conventions.Remove(ManyToManyCascadeDeleteConvention);
       // }
    
    }
}
