using Microsoft.AspNetCore.Mvc;

namespace ToysAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToyController : Controller
    {
        private readonly DataContext context;

        public ToyController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Toy>>> GetAll()
        {
            return Ok(await context.toys.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.Toy>>> AddToy(Models.Toy toy)
        {
            context.toys.Add(toy);
            await context.SaveChangesAsync();

            return Ok(await context.toys.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Models.Toy>>> UpdateToy(Models.Toy toy)
        {
            var dbToy = await context.toys.FindAsync(toy.ToyId);
            if (dbToy == null)
            {
                return BadRequest("Toy not found");
            }
            dbToy.ToyId = toy.ToyId;
            dbToy.Description = toy.Description;
            dbToy.Price = toy.Price;
            dbToy.TypeId = toy.TypeId;
            dbToy.CategoryId = toy.CategoryId;

            await context.SaveChangesAsync();

            return Ok(await context.toys.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Models.Toy>>> DeleteToy(int id)
        {
            var dbToy = await context.toys.FindAsync(id);
            if (dbToy == null)
            {
                return BadRequest("Toy not found");
            }

            context.toys.Remove(dbToy);
            await context.SaveChangesAsync();

            return Ok(await context.toys.ToListAsync());
        }

    }
}
