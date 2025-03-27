using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WordShop_Entity_Full.Database;
using WordShop_Entity_Full.Models;

namespace WordShop_Entity_Full.Repository
{
    class ReservationRepository
    {
        public DatabaseContexte dbContext { get; set; }

        public ReservationRepository(DatabaseContexte dbContextToConnect)
        {
            dbContext = dbContextToConnect;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return dbContext.Reservations.Include(animal => animal.Animal).Include(client => client.Client);
        }

        public Reservation GetById(int id)
        {
            return dbContext.Reservations.First(Reservation => Reservation.ReservationId == id);
        }

        public Reservation Create(string name,Animal animal,Client client)
        {
            Reservation reservation = new Reservation { Name = name, Animal = animal, Client = client, AnimalId = animal.AnimalId,ClientId = client.ClientId };
            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();
            return reservation;
        }
    }
}
