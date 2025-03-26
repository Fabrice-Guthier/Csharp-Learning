using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_EF_CRUD.Models;
using TP_EF_CRUD.Database;


namespace TP_EF_CRUD.Repositories
{
    internal class ClientRepository
    {
        private DatabaseContext _dbContext;

        public ClientRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public IEnumerable<Models.Client> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        public Client GetById(int id)
        {
            return _dbContext.Clients.First(client => client.ClientId == id);
        }

        public Client GetByName(string name)
        {
            return _dbContext.Clients.First(client => client.Name == name);
        }

        public void Create(string name)
        {
            Client client = new Client
            {
                Name = name
            };
            _dbContext.Clients.Add(client);
            // PENSEZ Y A CHAQUE FOIS
            _dbContext.SaveChanges();
        }

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
