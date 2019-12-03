using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using UOWS.Models;

namespace UOWS.DAL
{
    //klasa łącząca się z naszą baza danych poprzez connectionString ktory jest w Web.Config
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("conString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<DatabaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Organizator> Organizatorzy { get; set; }
        public DbSet<Subskrybent> Subskrybenci { get; set; }
        public DbSet<Wydarzenie> Wydarzenia { get; set; }
        public DbSet<Komentarz> Komentarze { get; set; }
        public DbSet<Subskrypcja> Subskrypcje { get; set; }
        public DbSet<Ankieta> Ankiety { get; set; }
        public DbSet<Odpowiedz> Odpowiedzi { get; set; }


    }
}