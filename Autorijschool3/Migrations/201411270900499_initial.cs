namespace Autorijschool3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bestellings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BestelDatum = c.DateTime(nullable: false),
                        Betaald = c.Boolean(nullable: false),
                        Klant_ID = c.Int(nullable: false),
                        Lespakket_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Klants", t => t.Klant_ID, cascadeDelete: true)
                .ForeignKey("dbo.Lespakkets", t => t.Lespakket_ID, cascadeDelete: true)
                .Index(t => t.Klant_ID)
                .Index(t => t.Lespakket_ID);
            
            CreateTable(
                "dbo.Klants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KlantSedert = c.DateTime(nullable: false),
                        Familienaam = c.String(nullable: false, maxLength: 32),
                        Voornaam = c.String(nullable: false, maxLength: 32),
                        Adres = c.String(nullable: false, maxLength: 55),
                        Gemeente = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lespakkets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Omschrijving = c.String(nullable: false, maxLength: 255),
                        Kostprijs = c.Int(nullable: false),
                        AantalBlokken = c.Int(nullable: false),
                        TypeRijbewijs_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rijbewijs", t => t.TypeRijbewijs_ID, cascadeDelete: true)
                .Index(t => t.TypeRijbewijs_ID);
            
            CreateTable(
                "dbo.Rijbewijs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Instructeurs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Familienaam = c.String(nullable: false, maxLength: 32),
                        Voornaam = c.String(nullable: false, maxLength: 32),
                        Adres = c.String(nullable: false, maxLength: 55),
                        Gemeente = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Les",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        UurStart = c.DateTime(nullable: false),
                        UurEinde = c.DateTime(nullable: false),
                        Bestelling_ID = c.Int(nullable: false),
                        Instructeur_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bestellings", t => t.Bestelling_ID, cascadeDelete: true)
                .ForeignKey("dbo.Instructeurs", t => t.Instructeur_ID, cascadeDelete: true)
                .Index(t => t.Bestelling_ID)
                .Index(t => t.Instructeur_ID);
            
            CreateTable(
                "dbo.InstructeurRijbewijs",
                c => new
                    {
                        Instructeur_ID = c.Int(nullable: false),
                        Rijbewijs_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructeur_ID, t.Rijbewijs_ID })
                .ForeignKey("dbo.Instructeurs", t => t.Instructeur_ID, cascadeDelete: true)
                .ForeignKey("dbo.Rijbewijs", t => t.Rijbewijs_ID, cascadeDelete: true)
                .Index(t => t.Instructeur_ID)
                .Index(t => t.Rijbewijs_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bestellings", "Lespakket_ID", "dbo.Lespakkets");
            DropForeignKey("dbo.Lespakkets", "TypeRijbewijs_ID", "dbo.Rijbewijs");
            DropForeignKey("dbo.InstructeurRijbewijs", "Rijbewijs_ID", "dbo.Rijbewijs");
            DropForeignKey("dbo.InstructeurRijbewijs", "Instructeur_ID", "dbo.Instructeurs");
            DropForeignKey("dbo.Les", "Instructeur_ID", "dbo.Instructeurs");
            DropForeignKey("dbo.Les", "Bestelling_ID", "dbo.Bestellings");
            DropForeignKey("dbo.Bestellings", "Klant_ID", "dbo.Klants");
            DropIndex("dbo.InstructeurRijbewijs", new[] { "Rijbewijs_ID" });
            DropIndex("dbo.InstructeurRijbewijs", new[] { "Instructeur_ID" });
            DropIndex("dbo.Les", new[] { "Instructeur_ID" });
            DropIndex("dbo.Les", new[] { "Bestelling_ID" });
            DropIndex("dbo.Lespakkets", new[] { "TypeRijbewijs_ID" });
            DropIndex("dbo.Bestellings", new[] { "Lespakket_ID" });
            DropIndex("dbo.Bestellings", new[] { "Klant_ID" });
            DropTable("dbo.InstructeurRijbewijs");
            DropTable("dbo.Les");
            DropTable("dbo.Instructeurs");
            DropTable("dbo.Rijbewijs");
            DropTable("dbo.Lespakkets");
            DropTable("dbo.Klants");
            DropTable("dbo.Bestellings");
        }
    }
}
