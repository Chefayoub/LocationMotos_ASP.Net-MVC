using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocationMotos_ASP.Net_MVC.Models
{
    public class LocMotoDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Moto> Motos { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Table client
            modelBuilder.Entity<Client>()
                .HasKey(c => c.IDClient)
                .Property(p => p.IDClient).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//Auto-Increment

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Locations)
                .WithRequired(l => l.Client)
                .HasForeignKey(l => l.IDClient);

            //modelBuilder.Entity<Client>()
            //    .Property(c => c.Nom)
            //    .IsRequired()
            //    .HasMaxLength(150);

            //modelBuilder.Entity<Client>()
            //    .Property(c => c.NumeroTel)
            //    .IsRequired()
            //    .HasMaxLength(20);


            //Table location
            modelBuilder.Entity<Location>()
                .HasKey(c => c.IDLocation)
                .Property(p => p.IDLocation).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



            //Table moto
            modelBuilder.Entity<Moto>()
                .HasKey(c => c.IDMoto)
                .Property(p => p.IDMoto).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Moto>()
                .HasMany(m => m.Locations)
                .WithRequired(l => l.Moto)
                .HasForeignKey(l => l.IDMoto);


            //Table marque
            modelBuilder.Entity<Marque>()
                .HasKey(c => c.IDMarque)
                .Property(p => p.IDMarque).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Marque>()
                .HasMany(ma => ma.Motos)
                .WithRequired(m => m.Marque)
                .HasForeignKey(m => m.IDMarque);

            base.OnModelCreating(modelBuilder);
        }
    }
}