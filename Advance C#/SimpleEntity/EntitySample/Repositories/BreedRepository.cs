using EntitySample.Database;
using EntitySample.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySample.Repositories
{
    public class BreedRepository
    {
        private AnimalDbContext _dbContext;

        public BreedRepository()
        {
            _dbContext = new AnimalDbContext();
        }

        public IEnumerable<Breed> GetAll()
        {
            return _dbContext.Breeds;
        }

        public Breed GetByName(string name)
        {
            return _dbContext.Breeds.First(breed => breed.Name == name);
        }

        public void Create(string name)
        {
            Breed breed = new Breed
            {
                Name = name
            };

            _dbContext.Breeds.Add(breed);

            // PENSEZ Y A CHAQUE FOIS
            _dbContext.SaveChanges();
        }
    }
}
