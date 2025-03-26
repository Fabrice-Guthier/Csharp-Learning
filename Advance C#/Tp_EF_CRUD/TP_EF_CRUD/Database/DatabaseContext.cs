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
            var animal = new Animal { AnimalId = 1, Name = "Toutou", Species = "chien" };
            var client = new Client { ClientId = 2, Name = "Mr Cocktail"};
            modelBuilder.Entity<Animal>().HasData(animal);
            modelBuilder.Entity<Client>().HasData(client);
        }
    }
}
