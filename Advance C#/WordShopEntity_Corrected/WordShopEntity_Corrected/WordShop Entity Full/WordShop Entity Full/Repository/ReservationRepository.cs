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
            //return dbContext.Reservations;
        }

        public Reservation GetById(int id)
        {
            return dbContext.Reservations.First(Reservation => Reservation.ReservationId == id);
        }

        public void Create(Animal animal,Client client)
        {
            Reservation reservation = new Reservation { Animal = animal, Client = client };
            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();
            //return reservation;
        }
    }
}
