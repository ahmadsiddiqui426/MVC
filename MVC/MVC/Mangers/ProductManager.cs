using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Models
{
    public static class ProductManager
    {
        private static List<Product> products = new List<Product>();

       
        public static List<Product> GetAllProducts()
        {
            return products;
        }

        
        public static Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        
        public static void CreateProduct(int id, string name, string description, decimal price, List<int> categoryIds)
        {
            
            int newId = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            Product product = new Product(newId, name, description, price, categoryIds);
            products.Add(product);
        }

        
        public static void UpdateProduct(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.CategoryIds = product.CategoryIds;
            }
        }

        
        public static void DeleteProduct(int id)
        {
            Product productToRemove = products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
        }

        
        public static void DeleteProductsByCategoryId(int categoryId)
        {
            
            products.RemoveAll(p => p.CategoryIds != null && p.CategoryIds.Contains(categoryId));
        }

        
        public static List<Product> GetProductsByCategoryId(int categoryId)
        {
            return products.Where(p => p.CategoryIds != null && p.CategoryIds.Contains(categoryId)).ToList();
        }
    }
}
