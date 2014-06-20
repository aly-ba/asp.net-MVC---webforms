using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAI.Data
{
    public class ProductRepository
    {
        private const string Electronics = "Electronics";
        private const string Apparel = "Apparel";
        private const string Food ="Food";

        private readonly IEnumerable<Product>
            _products = new [] {
                new Product {Id  = 1, Name = "Computer", 
                    Category=Electronics, Price = 749.99m},
                new Product {Id = 2, Name = "MP3", 
                    Category=Electronics, Price = 49.99m},
                new Product {Id  = 3, Name = "Pho,e", 
                    Category=Electronics, Price = 79.99m} ,
                new Product {Id  = 4, Name = "Hat", 
                    Category=Apparel, Price = 749.99m},
                new Product {Id  = 5, Name = "Pants", 
                    Category=Apparel, Price = 749.99m},
                new Product {Id  = 6, Name = "Shirt", 
                    Category=Apparel, Price = 749.99m},
                new Product {Id  = 7, Name = "Pizza", 
                    Category=Food, Price = 749.99m}, 
                new Product {Id  = 8, Name = "Hat", 
                    Category=Food, Price = 749.99m},
               new Product {Id  = 9, Name = "Hat", 
                    Category=Food, Price = 749.99m}


            };

        public Product GetById(int productId)
        {
            return _products.SingleOrDefault(p => p.Id == productId);
        }
        /// <summary>
        /// retourne prodcuts by  category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        public  Product GetByCategory(string category)
        {
            return _products.Where(p => string.Compare(p.Category,category,true) == 0)
                    .ToArray();
        }

        /// <summary>
        /// retourne tous les products , notre collections 
        /// _products simplement
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAll()
        {
            return _products.ToList();
        }
    }
}