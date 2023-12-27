namespace MVC.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string? Name { get; set; } 
        public List<int>? ProductIds { get; set; } 
        public Category(int id, string name, List<int> productIds)
        {
            Id = id;
            Name = name;
            ProductIds = productIds;
        }
        public Category() { }
    }
}