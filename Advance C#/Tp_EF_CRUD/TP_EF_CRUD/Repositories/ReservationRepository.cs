using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_EF_CRUD.Models;
using TP_EF_CRUD.Database;


namespace TP_EF_CRUD.Repositories
{
    public class ReservationRepository
    {
        private DatabaseContext _dbContext;

        // Constructeur pour initialiser le contexte de la base de données
        public ReservationRepository()
        {
            _dbContext = new DatabaseContext();
        }

        // Méthode pour récupérer toutes les réservations
        public IEnumerable<Models.Reservation> GetAll()
        {
            return _dbContext.Reservations.ToList();
        }

        // Méthode pour récupérer une réservation par son identifiant
        public Models.Reservation GetById(int id)
        {
            return _dbContext.Reservations.FirstOrDefault(reservation => reservation.ReservationId == id);
        }

        // Méthode pour récupérer une réservation par le nom de l'animal
        public Models.Reservation GetByAnimalName(string name)
        {
            return _dbContext.Reservations.FirstOrDefault(reservation => reservation.Animal.Name == name);
        }

        // Méthode pour récupérer une réservation par le nom du client
        public Models.Reservation GetByClientName(string name)
        {
            return _dbContext.Reservations.FirstOrDefault(reservation => reservation.Client.Name == name);
        }

        // Méthode pour créer une réservation
        public void Create(Animal animal, Client client)
        {
            Reservation reservation = new Reservation { Animal = animal, Client = client};
            _dbContext.Reservations.Add(reservation);
            // Sauvegarder les changements dans la base de données
            _dbContext.SaveChanges();
        }
    }
}
