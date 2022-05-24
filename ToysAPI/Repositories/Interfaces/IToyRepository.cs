using ToysAPI.Models;

namespace ToysAPI.Repositories.Interfaces
{
    public interface IToyRepository
    {
        public List<Toy> GetAllToys();
        public Toy? GetToy(Toy toy);
        public void Insert(Toy toy);
        public void Modify(Toy toy);
        public void Delete(Toy toy);

    }
}
