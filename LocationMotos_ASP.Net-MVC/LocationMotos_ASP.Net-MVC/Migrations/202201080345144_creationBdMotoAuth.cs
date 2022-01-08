namespace LocationMotos_ASP.Net_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creationBdMotoAuth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        NumeroTel = c.String(),
                    })
                .PrimaryKey(t => t.IDClient);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        IDLocation = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        NumeroTel = c.String(),
                        IDClient = c.Int(nullable: false),
                        IDMoto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDLocation)
                .ForeignKey("dbo.Motoes", t => t.IDMoto, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.IDClient, cascadeDelete: true)
                .Index(t => t.IDClient)
                .Index(t => t.IDMoto);
            
            CreateTable(
                "dbo.Motoes",
                c => new
                    {
                        IDMoto = c.Int(nullable: false, identity: true),
                        Carburant = c.String(),
                        Kilometrage = c.String(),
                        Disponible = c.String(),
                        IDMarque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDMoto)
                .ForeignKey("dbo.Marques", t => t.IDMarque, cascadeDelete: true)
                .Index(t => t.IDMarque);
            
            CreateTable(
                "dbo.Marques",
                c => new
                    {
                        IDMarque = c.Int(nullable: false, identity: true),
                        MarqueM = c.String(),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.IDMarque);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "IDClient", "dbo.Clients");
            DropForeignKey("dbo.Motoes", "IDMarque", "dbo.Marques");
            DropForeignKey("dbo.Locations", "IDMoto", "dbo.Motoes");
            DropIndex("dbo.Motoes", new[] { "IDMarque" });
            DropIndex("dbo.Locations", new[] { "IDMoto" });
            DropIndex("dbo.Locations", new[] { "IDClient" });
            DropTable("dbo.Marques");
            DropTable("dbo.Motoes");
            DropTable("dbo.Locations");
            DropTable("dbo.Clients");
        }
    }
}
