using MVC.Models;

public static class CategoryManager
{
    private static List<Category> categories = new List<Category>();

   
    public static List<Category> GetAllCategories()
    {
        return categories;
    }

    
    public static Category GetCategoryById(int id)
    {
        return categories.FirstOrDefault(c => c.Id == id);
    }

    
    public static void CreateCategory(Category category)
    {
        
        category.Id = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1;
        categories.Add(category);
    }

    
    public static void UpdateCategory(Category category)
    {
        var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
            existingCategory.ProductIds = category.ProductIds;
        }
    }

    
    public static void DeleteCategory(int id)
    {
        var category = categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            categories.Remove(category);
        }
    }
}
