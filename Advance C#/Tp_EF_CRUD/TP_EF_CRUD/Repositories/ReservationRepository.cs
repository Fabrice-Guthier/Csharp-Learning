using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_EF_CRUD.Models;
using TP_EF_CRUD.Database;


namespace TP_EF_CRUD.Repositories
{
    internal class ReservationRepository
    {
        private DatabaseContext _dbContext;

        public ReservationRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public IEnumerable<Models.Reservation> GetAll()
        {
            return _dbContext.Reservations.ToList();
        }
        public void Create(string animalName, string clientName)
        {
            

            //_dbContext.Reservations.Add();
            //_dbContext.SaveChanges();
        }

    }
}
