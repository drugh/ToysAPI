using Microsoft.EntityFrameworkCore;

namespace ToysAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Models.Toy> Toys { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
    }
}
