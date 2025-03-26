using EntitySample.Database;
using EntitySample.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySample.Repositories
{
    public class DogRepository
    {
        private AnimalDbContext _dbContext;

        public DogRepository()
        {
            _dbContext = new AnimalDbContext();
        }

        public IEnumerable<Dog> GetAll()
        {
            // Penser au lazy loading (Si pas d'Include, la race n'est pas forcément chargée)
            return _dbContext.Dogs.Include(dog => dog.Breed);
        }

        public Dog GetById(int id)
        {
            return _dbContext.Dogs.First(dog => dog.DogId == id);
        }

        public void Create(string name, string race)
        {
            Dog dog = new Dog
            {
                Age = 7,
                Name = name,
                Breed = _dbContext.Breeds.First(breed => breed.Name == race)
            };

            _dbContext.Dogs.Add(dog);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Dog dog = GetById(id);

            if (dog == null)
            {
                Console.WriteLine($"Aucun chien avec l'id {id}");
                return;
            }

            _dbContext.Dogs.Remove(dog);
            _dbContext.SaveChanges();
        }

        public void UpdateById(int id, string name)
        {
            Dog dog = GetById(id);

            if (dog == null)
            {
                Console.WriteLine($"Aucun chien avec l'id {id}");
                return;
            }

            dog.Name = name;
            _dbContext.SaveChanges();
        }
    }
}
