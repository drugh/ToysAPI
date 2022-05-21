using Microsoft.AspNetCore.Mvc;

namespace ToysAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeController : Controller
    {
        private readonly DataContext context;

        public TypeController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Type>>> GetTypes()
        {
            return Ok(await context.Types.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.Type>>> AddType(string typeName)
        {
            context.Types.Add(new Models.Type()
            {
                TypeName = typeName
            });

            await context.SaveChangesAsync();

            return Ok(await context.Types.ToListAsync());
        }
    }
}
