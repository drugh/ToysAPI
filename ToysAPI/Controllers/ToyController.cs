using Microsoft.AspNetCore.Mvc;
using ToysAPI.Repositories.Interfaces;

namespace ToysAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToyController : Controller
    {
        private readonly IToyRepository toyRepository;

        public ToyController(IToyRepository toyRepository)
        {
            this.toyRepository = toyRepository;
        }

        [HttpGet]
        public ActionResult<List<Models.Toy>> GetAll()
        {
            return Ok(toyRepository.GetAllToys());
        }

        [HttpPost]
        public ActionResult<List<Models.Toy>> AddToy(Models.Toy toy)
        {
            toyRepository.Insert(toy);
            
            return Ok(toyRepository.GetAllToys());
        }

        [HttpPut]
        public ActionResult<List<Models.Toy>> UpdateToy(Models.Toy toy)
        {
            var dbToy = toyRepository.GetToy(toy);
            if (dbToy == null)
            {
                return BadRequest("Toy not found!");
            }
            else
            {
                toyRepository.Modify(toy);
            }
            return Ok(toyRepository.GetAllToys());
        }

        [HttpDelete]
        public ActionResult<List<Models.Toy>> DeleteToy(int id)
        {
            var dbToy = toyRepository.GetAllToys().Find(t => t.ToyId == id);
            if (dbToy == null)
            {
                return BadRequest("Toy not found!");
            }
            else
            {
                toyRepository.Delete(dbToy);
            }
            return Ok(toyRepository.GetAllToys());
        }

    }
}
