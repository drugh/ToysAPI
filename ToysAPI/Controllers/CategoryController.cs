using Microsoft.AspNetCore.Mvc;

namespace ToysAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly DataContext context;

        public CategoryController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Category>>> getCategories()
        {
            return Ok(await context.categories.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.Category>>> addCategory(string categoryName)
        {
            context.categories.Add(new Models.Category
            {
                CategoryName = categoryName
            });
            await context.SaveChangesAsync();

            return Ok(await context.categories.ToListAsync());
        }
    }
}
