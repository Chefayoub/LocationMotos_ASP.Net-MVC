namespace LocationMotos_ASP.Net_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "FraisDeLocation", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Locations", "Date_debut", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locations", "Date_fin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "Nom", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Clients", "Prenom", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Clients", "Adresse", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Clients", "NumeroTel", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Motoes", "Carburant", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Motoes", "Kilometrage", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Motoes", "Disponible", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Marques", "MarqueM", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Marques", "Model", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Locations", "Nom");
            DropColumn("dbo.Locations", "Prenom");
            DropColumn("dbo.Locations", "Adresse");
            DropColumn("dbo.Locations", "NumeroTel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "NumeroTel", c => c.String());
            AddColumn("dbo.Locations", "Adresse", c => c.String());
            AddColumn("dbo.Locations", "Prenom", c => c.String());
            AddColumn("dbo.Locations", "Nom", c => c.String());
            AlterColumn("dbo.Marques", "Model", c => c.String());
            AlterColumn("dbo.Marques", "MarqueM", c => c.String());
            AlterColumn("dbo.Motoes", "Disponible", c => c.String());
            AlterColumn("dbo.Motoes", "Kilometrage", c => c.String());
            AlterColumn("dbo.Motoes", "Carburant", c => c.String());
            AlterColumn("dbo.Clients", "NumeroTel", c => c.String());
            AlterColumn("dbo.Clients", "Adresse", c => c.String());
            AlterColumn("dbo.Clients", "Prenom", c => c.String());
            AlterColumn("dbo.Clients", "Nom", c => c.String());
            DropColumn("dbo.Locations", "Date_fin");
            DropColumn("dbo.Locations", "Date_debut");
            DropColumn("dbo.Locations", "FraisDeLocation");
        }
    }
}
