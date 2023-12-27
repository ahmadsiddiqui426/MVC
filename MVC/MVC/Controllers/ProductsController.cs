using Microsoft.AspNetCore.Mvc;
using MVC.Models; 
using System.Collections.Generic;

public class ProductsController : Controller
{
    
    public IActionResult Index()
    {
        List<Product> products = ProductManager.GetAllProducts(); 
        return View(products);
    }

    
    public IActionResult Details(int id)
    {
        Product product = ProductManager.GetProductById(id); 
        if (product == null)
        {
            return NotFound(); 
        }
        return View(product);
    }

    
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    
    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            
            ProductManager.CreateProduct(product.Id, product.Name, product.Description, product.Price, product.CategoryIds);
            return RedirectToAction("Index");
        }
        return View(product);
    }


    
    public IActionResult Edit(int id)
    {
        Product product = ProductManager.GetProductById(id); 
        if (product == null)
        {
            return NotFound(); 
        }
        return View(product);
    }

    
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            ProductManager.UpdateProduct(product); 
            return RedirectToAction("Index");
        }
        return View(product);
    }

    
    public IActionResult Delete(int id)
    {
        Product product = ProductManager.GetProductById(id); 
        if (product == null)
        {
            return NotFound(); 
        }
        return View(product);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    public IActionResult DeleteConfirmed(int id)
    {
        ProductManager.DeleteProduct(id); 
        return RedirectToAction("Index");
    }

}