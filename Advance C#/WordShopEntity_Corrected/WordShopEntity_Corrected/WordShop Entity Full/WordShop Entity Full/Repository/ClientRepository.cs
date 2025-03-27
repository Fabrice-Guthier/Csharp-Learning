using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordShop_Entity_Full.Database;
using WordShop_Entity_Full.Models;

namespace WordShop_Entity_Full.Repository
{
    class ClientRepository
    {
        public DatabaseContexte dbContext { get; set; }

        public ClientRepository(DatabaseContexte dbContextToConnect)
        {
            dbContext = dbContextToConnect;
        }

        public IEnumerable<Client> GetAll()
        {
            return dbContext.Clients;
        }

        public Client GetByName(string name)
        {
            return dbContext.Clients.First(Client => Client.Name == name);
        }

        public Client Create(string name)
        {
            Client client = new Client { Name = name, Age = 2 };
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
            return client;
        }
    }
}
