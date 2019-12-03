namespace UOWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UOWSDBmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ankieta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pytanie = c.String(),
                        Data_dodania = c.DateTime(nullable: false),
                        WydarzenieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wydarzenie", t => t.WydarzenieId, cascadeDelete: true)
                .Index(t => t.WydarzenieId);
            
            CreateTable(
                "dbo.Wydarzenie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Data_rozpoczecia = c.DateTime(nullable: false),
                        Data_zakonczenia = c.DateTime(nullable: false),
                        Opis = c.String(),
                        Adres = c.String(),
                        OrganizatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizator", t => t.OrganizatorId, cascadeDelete: true)
                .Index(t => t.OrganizatorId);
            
            CreateTable(
                "dbo.Organizator",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Email = c.String(),
                        Adres = c.String(),
                        URL_Zdjecia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Komentarz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(),
                        Data_dodania = c.DateTime(nullable: false),
                        SubskrypcjaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subskrypcja", t => t.SubskrypcjaId, cascadeDelete: true)
                .Index(t => t.SubskrypcjaId);
            
            CreateTable(
                "dbo.Subskrypcja",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data_subskrypcji = c.DateTime(nullable: false),
                        WydarzenieId = c.Int(nullable: false),
                        SubskrybentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subskrybent", t => t.SubskrybentId, cascadeDelete: true)
                .ForeignKey("dbo.Wydarzenie", t => t.WydarzenieId, cascadeDelete: true)
                .Index(t => t.WydarzenieId)
                .Index(t => t.SubskrybentId);
            
            CreateTable(
                "dbo.Subskrybent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Data_urodzenia = c.DateTime(nullable: false),
                        Adres = c.String(),
                        URL_Zdjecia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Odpowiedz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(),
                        Glosy = c.Int(nullable: false),
                        AnkietaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ankieta", t => t.AnkietaId, cascadeDelete: true)
                .Index(t => t.AnkietaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Odpowiedz", "AnkietaId", "dbo.Ankieta");
            DropForeignKey("dbo.Komentarz", "SubskrypcjaId", "dbo.Subskrypcja");
            DropForeignKey("dbo.Subskrypcja", "WydarzenieId", "dbo.Wydarzenie");
            DropForeignKey("dbo.Subskrypcja", "SubskrybentId", "dbo.Subskrybent");
            DropForeignKey("dbo.Ankieta", "WydarzenieId", "dbo.Wydarzenie");
            DropForeignKey("dbo.Wydarzenie", "OrganizatorId", "dbo.Organizator");
            DropIndex("dbo.Odpowiedz", new[] { "AnkietaId" });
            DropIndex("dbo.Subskrypcja", new[] { "SubskrybentId" });
            DropIndex("dbo.Subskrypcja", new[] { "WydarzenieId" });
            DropIndex("dbo.Komentarz", new[] { "SubskrypcjaId" });
            DropIndex("dbo.Wydarzenie", new[] { "OrganizatorId" });
            DropIndex("dbo.Ankieta", new[] { "WydarzenieId" });
            DropTable("dbo.Odpowiedz");
            DropTable("dbo.Subskrybent");
            DropTable("dbo.Subskrypcja");
            DropTable("dbo.Komentarz");
            DropTable("dbo.Organizator");
            DropTable("dbo.Wydarzenie");
            DropTable("dbo.Ankieta");
        }
    }
}
