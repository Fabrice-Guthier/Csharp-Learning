using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP_EF_CRUD.Models;

namespace TP_EF_CRUD.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ZE-PC-OF-THE-FA\\MSSQLSERVER01;Database=BDD_TP_EF_CRUD;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Client fabrice = new Client();
            fabrice.ClientId = 1;
            fabrice.Name = "Fabrice";
            modelBuilder.Entity<Client>().HasData(fabrice);

            Animal cat = new Animal();
            cat.AnimalId = 1;
            cat.Name = "Dynamite";
            cat.Age = 12;
            cat.Species = "Chat";
            modelBuilder.Entity<Animal>().HasData(cat);

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation 
                { 
                    ReservationId = 1, 
                    AnimalId = 1, 
                    ClientId = 1
                });
        }
    }
}
