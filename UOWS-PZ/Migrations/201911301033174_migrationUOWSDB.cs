namespace UOWS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationUOWSDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ankietas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pytanie = c.String(),
                        Data_dodania = c.DateTime(nullable: false),
                        WydarzenieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wydarzenies", t => t.WydarzenieId, cascadeDelete: true)
                .Index(t => t.WydarzenieId);
            
            CreateTable(
                "dbo.Wydarzenies",
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
                .ForeignKey("dbo.Organizators", t => t.OrganizatorId, cascadeDelete: true)
                .Index(t => t.OrganizatorId);
            
            CreateTable(
                "dbo.Organizators",
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
                "dbo.Komentarzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(),
                        Data_dodania = c.DateTime(nullable: false),
                        SubskrypcjaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wydarzenies", t => t.SubskrypcjaId, cascadeDelete: true)
                .Index(t => t.SubskrypcjaId);
            
            CreateTable(
                "dbo.Odpowiedzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(),
                        Glosy = c.Int(nullable: false),
                        AnkietaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ankietas", t => t.AnkietaId, cascadeDelete: true)
                .Index(t => t.AnkietaId);
            
            CreateTable(
                "dbo.Subskrybents",
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
                "dbo.Subskrypcjas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data_subskrypcji = c.DateTime(nullable: false),
                        WydarzenieId = c.Int(nullable: false),
                        SubskrybentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subskrybents", t => t.SubskrybentId, cascadeDelete: true)
                .ForeignKey("dbo.Wydarzenies", t => t.WydarzenieId, cascadeDelete: true)
                .Index(t => t.SubskrybentId)
                .Index(t => t.WydarzenieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subskrypcjas", "WydarzenieId", "dbo.Wydarzenies");
            DropForeignKey("dbo.Subskrypcjas", "SubskrybentId", "dbo.Subskrybents");
            DropForeignKey("dbo.Odpowiedzs", "AnkietaId", "dbo.Ankietas");
            DropForeignKey("dbo.Komentarzs", "SubskrypcjaId", "dbo.Wydarzenies");
            DropForeignKey("dbo.Ankietas", "WydarzenieId", "dbo.Wydarzenies");
            DropForeignKey("dbo.Wydarzenies", "OrganizatorId", "dbo.Organizators");
            DropIndex("dbo.Subskrypcjas", new[] { "WydarzenieId" });
            DropIndex("dbo.Subskrypcjas", new[] { "SubskrybentId" });
            DropIndex("dbo.Odpowiedzs", new[] { "AnkietaId" });
            DropIndex("dbo.Komentarzs", new[] { "SubskrypcjaId" });
            DropIndex("dbo.Ankietas", new[] { "WydarzenieId" });
            DropIndex("dbo.Wydarzenies", new[] { "OrganizatorId" });
            DropTable("dbo.Subskrypcjas");
            DropTable("dbo.Subskrybents");
            DropTable("dbo.Odpowiedzs");
            DropTable("dbo.Komentarzs");
            DropTable("dbo.Organizators");
            DropTable("dbo.Wydarzenies");
            DropTable("dbo.Ankietas");
        }
    }
}
