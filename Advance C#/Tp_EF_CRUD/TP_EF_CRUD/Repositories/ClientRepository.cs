using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_EF_CRUD.Models;
using TP_EF_CRUD.Database;


namespace TP_EF_CRUD.Repositories
{
    public class ClientRepository
    {
        private DatabaseContext _dbContext;

        // Constructeur pour initialiser le contexte de la base de données
        public ClientRepository()
        {
            _dbContext = new DatabaseContext();
        }

        // Méthode pour récupérer tous les clients
        public IEnumerable<Models.Client> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        // Méthode pour récupérer un client par son identifiant
        public Client GetById(int id)
        {
            return _dbContext.Clients.First(client => client.ClientId == id);
        }

        // Méthode pour récupérer un client par son nom
        public Client GetByName(string name)
        {
            return _dbContext.Clients.First(client => client.Name == name);
        }

        // Méthode pour créer un nouveau client
        public Client Create(string name)
        {
            Client client = new Client
            {
                Name = name
            };
            _dbContext.Clients.Add(client);
            // Sauvegarder les changements dans la base de données
            _dbContext.SaveChanges();
            return client;
        }

        // Méthode pour supprimer un client par son identifiant
        public string DeleteById(int id)
        {
            Client client = GetById(id);

            if (client == null)
            {
                Console.WriteLine("Aucun client n'existe avec cet identifiant");
            }
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return client.Name;
        }

        // Méthode pour mettre à jour un client par son identifiant
        public string UpdateById(int id, string name)
        {
            Client client = GetById(id);

            if (client == null)
            {
                Console.WriteLine("Aucun client n'existe avec cet identifiant");
            }
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return client.Name;
        }
    }
}
