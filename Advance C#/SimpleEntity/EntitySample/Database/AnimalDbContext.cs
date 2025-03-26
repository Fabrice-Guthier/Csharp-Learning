using EntitySample.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySample.Database
{
    public class AnimalDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Breed> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CEDRICPC\\SQLEXPRESS;Database=CDA_Animal_Entity;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>().HasData(new Breed { BreedId = 1, Name = "Akita inu" });
            modelBuilder.Entity<Breed>().HasData(new Breed { BreedId = 2, Name = "Labrador" });
        }
    }
}
