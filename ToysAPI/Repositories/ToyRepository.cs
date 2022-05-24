using ToysAPI.Models;
using ToysAPI.Repositories.Interfaces;

namespace ToysAPI.Repositories
{
    public class ToyRepository : IToyRepository
    {
        private readonly DataContext _context;

        public ToyRepository(DataContext context)
        {
            _context = context;
        }

        public List<Toy> GetAllToys()
        {
            return _context.Toys.ToList();
        }

        public Toy? GetToy(Toy toy)
        {
            return GetAllToys().FirstOrDefault(t => t.ToyId == toy.ToyId);
        }

        public void Insert(Toy toy)
        {
            _context.Toys.Add(toy);
            _context.SaveChanges();
        }

        public void Modify(Toy toy)
        {
            var dbToy = GetToy(toy);

            dbToy.Description = toy.Description;
            dbToy.Price = toy.Price;
            dbToy.TypeId = toy.TypeId;
            dbToy.CategoryId = toy.CategoryId;

            _context.SaveChanges();
        }

        public void Delete(Toy toy)
        {
            _context.Toys.Remove(toy);
            _context.SaveChanges();
        }
    }
}
