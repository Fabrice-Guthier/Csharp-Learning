using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordShop_Entity_Full.Database;
using WordShop_Entity_Full.Models;

namespace WordShop_Entity_Full.Repository
{
    class AnimalRepository
    {
        public DatabaseContexte dbContext { get; set; }

        public AnimalRepository(DatabaseContexte dbContextToConnect)
        {
            dbContext = dbContextToConnect;
        }

        public IEnumerable<Animal> GetAll()
        {
            return dbContext.Animals;
        }

        public Animal GetByName(string name)
        {
            return dbContext.Animals.First(Animal => Animal.Name == name);
        }

        public Animal Create(string name)
        {
            Animal animal = new Animal { Name = name,Age = 2 };
            dbContext.Animals.Add(animal);
            dbContext.SaveChanges();
            return animal;
        }
    }
}
