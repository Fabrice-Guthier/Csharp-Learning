using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WordShop_Entity_Full.Models;

namespace WordShop_Entity_Full.Database
{
    class DatabaseContexte : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Said-PC\SQLEXPRESS;Database=DatabaseContexte;Trusted_Connection=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Reservation>()
            //.HasOne(r => r.animal)
            //.WithOne(a => a.reservation)
            //.HasForeignKey<Reservation>(r => r.AnimalId);

            //modelBuilder.Entity<Reservation>()
            //.HasOne(r => r.client)
            //.WithOne(a => a.reservation)
            //.HasForeignKey<Reservation>(r => r.ClientId);


            Client cedric = new Client();
            cedric.Age = 30;
            cedric.ClientId = 1;
            cedric.Name = "Cédric";

            modelBuilder.Entity<Client>().HasData(cedric);

            Animal doggo = new Animal();
            doggo.AnimalId = 1;
            doggo.Name = "Doggo";
            doggo.Age = 12;
            modelBuilder.Entity<Animal>().HasData(doggo);




            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, AnimalId = 1, ClientId = 1, Name = "Reservation truc machin", });
        }
    }
}
