using Microsoft.EntityFrameworkCore;

namespace ToysAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Models.Toy> toys { get; set; }
        public DbSet<Models.Type> types { get; set; }
        public DbSet<Models.Category> categories { get; set; }
    }
}
