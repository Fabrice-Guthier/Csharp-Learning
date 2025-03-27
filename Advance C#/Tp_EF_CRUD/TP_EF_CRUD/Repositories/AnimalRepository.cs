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

        // Constructeur pour initialiser le contexte de la base de données
        public AnimalRepository()
        {
            _dbContext = new DatabaseContext();
        }

        // Récupère tous les animaux de la base de données
        public IEnumerable<Models.Animal> GetAll()
        {
            return _dbContext.Animals;
        }

        // Récupère un animal par son nom
        public Animal GetByName(string name)
        {
            return _dbContext.Animals.First(animal => animal.Name == name);
        }

        // Récupère un animal par son identifiant
        public Animal GetById(int id)
        {
            return _dbContext.Animals.First(animal => animal.AnimalId == id);
        }

        // Crée un nouvel animal et l'ajoute à la base de données
        public Animal Create(string name)
        {
            Animal animal = new Animal
            {
                Name = name
            };
            _dbContext.Animals.Add(animal);
            // Sauvegarde les changements dans la base de données
            _dbContext.SaveChanges();
            return animal;
        }

        // Supprime un animal par son identifiant
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

        // Met à jour le nom d'un animal par son identifiant
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
