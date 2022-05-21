namespace ToysAPI.Models
{
    public class Toy
    {
        public int ToyId { get; set; }
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; } = 0.0m;
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
    }
}
