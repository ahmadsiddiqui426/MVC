using Microsoft.AspNetCore.Mvc;
using MVC.Models; 
using System.Collections.Generic;

public class CategoriesController : Controller
{
    
    public IActionResult Index()
    {
        List<Category> categories = CategoryManager.GetAllCategories(); 
        return View(categories);
    }

    
    public IActionResult Details(int id)
    {
        Category category = CategoryManager.GetCategoryById(id);
        if (category == null)
        {
            return NotFound();
        }

        
        List<Product> products = ProductManager.GetProductsByCategoryId(id);

        
        var viewModel = new CategoryDetailsViewModel
        {
            Category = category,
            Products = products
        };

        return View(viewModel); 
    }




    
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            CategoryManager.CreateCategory(category); 
            return RedirectToAction("Index");
        }
        return View(category);
    }

    
    public IActionResult Edit(int id)
    {
        Category category = CategoryManager.GetCategoryById(id); 
        if (category == null)
        {
            return NotFound(); 
        }
        return View(category);
    }

    
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            CategoryManager.UpdateCategory(category); 
            return RedirectToAction("Index");
        }
        return View(category);
    }

    
    public IActionResult Delete(int id)
    {
        Category category = CategoryManager.GetCategoryById(id); 
        if (category == null)
        {
            return NotFound(); 
        }
        return View(category);
    }

    
    [HttpPost, ActionName("DeleteConfirmed")]
    public IActionResult DeleteConfirmed(int id)
    {
        
        Category category = CategoryManager.GetCategoryById(id);
        if (category == null)
        {
            return NotFound(); 
        }

        
        ProductManager.DeleteProductsByCategoryId(id);

        
        CategoryManager.DeleteCategory(id);

        return RedirectToAction("Index");
    }
}


public class CategoryDetailsViewModel
{
    public Category Category { get; set; }
    public List<Product> Products { get; set; }
}
