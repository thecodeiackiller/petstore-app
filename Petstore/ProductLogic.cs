﻿    using System;
    using System.Collections.Generic;
    using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
    using System.Threading.Tasks;

    namespace Petstore
    {
    internal class ProductLogic : IProductLogic
    {

        private List<Product> _products; 
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catsFood;

        public ProductLogic()
        {
            this._products = new List<Product>();
            this._dogLeash = new Dictionary<string, DogLeash>();
            this._catsFood = new Dictionary<string, CatFood>();

            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5 }); // This is object initializer syntax
            AddProduct(new DogLeash { Name = "Beddazzled Leash", Price = 50.00M, Quantity = 0 });
        }

        public void AddProduct(Product product)
        {
            this._products.Add(product);

            if (product is DogLeash)   
            {
                this._dogLeash.Add(product.Name, product as DogLeash); 
            }

            if (product is CatFood)
            {
                this._catsFood.Add(product.Name, product as CatFood); 
            }
        }
        
    
        
        public void GetAllProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine($"{product.Name}");
            }
        }

        public DogLeash GetDogLeashByName(string name)
        {
            if(this._dogLeash.ContainsKey(name))
            {
                return _dogLeash[name];
            }
            else
            {
                throw new Exception("Cannot find product. Please enter new name or add new Dog Leash product.");
            }                      
        }

   
        public void GetInStockItems()
        {
            List<string> productsAsStrings = new List<string>();
            foreach (Product product in _products)
            {
                if(product.Quantity != 0)
                {
                    productsAsStrings.Add(product.Name);
                }
                
            }
            foreach(string  product in productsAsStrings)
            {
                Console.WriteLine(product + " is still available!");
            }
        }

        public void GetOutOfStockItems()
        {
            List<string> outOfItems = new List<string>();

            var outofItems = _products.Where(propa => propa.Quantity == 0).Select(propa => propa.Name).ToList();

            foreach(string product in outofItems)
            {
                Console.WriteLine(product + " is out of stock! We apologize for the inconvenience. Just kidding, we could care less about you.");
            }
        }
    }
}
