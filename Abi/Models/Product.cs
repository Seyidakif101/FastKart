namespace Abi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int ReytingCount { get; set; }
        public string? MainImageUrl { get; set; }
        public string? HoverImageUrl { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } = [];
    }
}

