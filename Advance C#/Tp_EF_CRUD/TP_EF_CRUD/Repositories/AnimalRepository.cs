using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_EF_CRUD.Database;
using TP_EF_CRUD.Models;


namespace TP_EF_CRUD.Repositories
{
    public class AnimalRepository
    {
        private DatabaseContext _dbContext;

        public AnimalRepository()
        {
            _dbContext = new DatabaseContext();
        }

        public IEnumerable<Models.Animal> GetAll()
        {
            return _dbContext.Animals.ToList();
        }

        public Animal GetByName(string name)
        {
            return _dbContext.Animals.First(animal => animal.Name == name);
        }

        public Animal GetById(int id)
        {
            return _dbContext.Animals.First(animal => animal.AnimalId == id);
        }

        public void Create(string name, string species)
        {
            Animal animal = new Animal
            {
                Name = name,
                Species = species
            };
            _dbContext.Animals.Add(animal);
            // PENSEZ Y A CHAQUE FOIS
            _dbContext.SaveChanges();
        }

        public string DeleteById(int id)
        {

            Animal animal = GetById(id);

            if (animal == null)
            {
                Console.WriteLine("Aucun animal n'existe avec cet identifiant");
            }
            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();
            return animal.Name;

        }

        public string UpdateById(int id, string name)
        {
            Animal animal = GetById(id);

            if (animal == null)
            {
                Console.WriteLine("Aucun animal n'existe avec cet identifiant");
            }
            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();
            return animal.Name;
        }
    }
}
