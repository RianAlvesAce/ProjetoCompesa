using compesa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace compesa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly UserContext _userContext;

        public AnimalController(UserContext userContext)
        {
            this._userContext = userContext;
        }

        [HttpPost("/insertAnimal")]
        public async Task<HttpStatusCode> InsertAnimal(Animal animal)
        {
            var newAnimal = new Animal()
            {
                Name = animal.Name,
                Type = animal.Type,
            };

            _userContext.Animals.Add(newAnimal);
            await _userContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpGet("/getAnimals")]
        public async Task<ActionResult<List<Animal>>> GetAnimal()
        {
            var result = await _userContext.Animals.Select(
                s => new Animal
                {
                    Id = s.Id,
                    Name= s.Name,
                    Type = s.Type,
                }).ToListAsync();

            if (result.Count < 0)
            {
                return NotFound();
            } else
            {
                return result;
            }
        }
    }
}
