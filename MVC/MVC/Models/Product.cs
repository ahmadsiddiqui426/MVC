namespace MVC.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
#pragma warning disable CS8618 
        public string Description { get; set; } 
#pragma warning restore CS8618 
        public decimal Price { get; set; } 
        public List<int>? CategoryIds { get; set; }

        public Product(int id, string name, string description, decimal price, List<int> categoryIds)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryIds = categoryIds;
        }
        public Product() { }
    }
}