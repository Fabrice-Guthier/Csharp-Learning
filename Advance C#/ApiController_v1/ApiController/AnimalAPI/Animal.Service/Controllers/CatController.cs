using Animal.Service.DTO;
using Animal.Service.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Service.Controllers
{
    [ApiController]
    [Route("cat")]
    public class CatController : ControllerBase
    {
        private static readonly List<Cat> Cats = new List<Cat>
        {
            new Cat {
                Id = Guid.NewGuid(),
                Name = "Tigrou",
                Age = 17,
                Color = "Tigré"
            },
            new Cat {
                Id = Guid.NewGuid(),
                Name = "Nala",
                Age = 5,
                Color = "Blanc"
            },
            new Cat {
                Id = Guid.NewGuid(),
                Name = "Chaussette",
                Age = 19,
                Color = "Tigré"
            },
        };

        [HttpGet]
        public List<CatDisplayDto> GetAll()
        {
            var catDtos = new List<CatDisplayDto>();

            Cats.ForEach(cat => catDtos.Add(new CatDisplayDto(cat.Id, cat.Name, cat.Color)));

            return catDtos;
        }

        [HttpGet("{id}")]
        public ActionResult<CatDisplayDto> GetById(Guid id)
        {
            var cat = Cats.Where(cat => cat.Id == id).FirstOrDefault();

            if (cat == null)
                return NotFound();

            var catDto = new CatDisplayDto(cat.Id, cat.Name, cat.Color);

            return catDto;
        }

        [HttpPost]
        public IActionResult Create(AddCatDto addCatDto)
        {
            var cat = new Cat
            {
                Id = Guid.NewGuid(),
                Name = addCatDto.Name,
                Age = addCatDto.Age,
                Color = addCatDto.Color
            };

            Cats.Add(cat);

            return Ok(cat);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateCatDto updatedCat)
        {
            var cat = Cats.Where(cat => cat.Id == id).FirstOrDefault();

            if (cat == null)
                return NotFound();

            cat.Name = updatedCat.Name;
            cat.Age = updatedCat.Age;
            cat.Color = updatedCat.Color;

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var cat = Cats.Where(cat => cat.Id == id).FirstOrDefault();

            if (cat == null)
                return NotFound();

            Cats.Remove(cat);

            return Ok();
        }
    }
}
