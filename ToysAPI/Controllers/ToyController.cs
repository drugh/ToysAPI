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
            return Ok(await context.Toys.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.Toy>>> AddToy(Models.Toy toy)
        {
            context.Toys.Add(toy);
            await context.SaveChangesAsync();

            return Ok(await context.Toys.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Models.Toy>>> UpdateToy(Models.Toy toy)
        {
            var dbToy = await context.Toys.FindAsync(toy.ToyId);
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

            return Ok(await context.Toys.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Models.Toy>>> DeleteToy(int id)
        {
            var dbToy = await context.Toys.FindAsync(id);
            if (dbToy == null)
            {
                return BadRequest("Toy not found");
            }

            context.Toys.Remove(dbToy);
            await context.SaveChangesAsync();

            return Ok(await context.Toys.ToListAsync());
        }

    }
}
