using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Entities;
using EX1_OOP.Repositories;
namespace EX1_OOP.Services
{
    public class Product_Services : IProduct_Services
    {
        private IProduct_Repositories _Repositories = new Product_Repositories();
        public List<Product>? GetAllProducts()
        {
            List<Product> products = _Repositories.ReadProduct();
            if(products == null)
            {
                return new List<Product>();
            }
            return products;
        }
        public List<Product>? GetAllProducts(string key = "")
        {
            List<Product> products = _Repositories.ReadProduct();
            List<Product> Nprd = new List<Product>();

            if(products == null)
            {
                return null;
            }
            foreach(var prd in products)
            {
                if(prd.ProductName.Contains(key))
                {
                    Nprd.Add(prd);
                }
            }
            if(Nprd == null || Nprd.Count == 0)
            {
                return null;
            }
            return Nprd;
        }
        public Product? InitializeProduct(string productName, float productPrice, int countOfProducts)
        {
            List<Product> prds = _Repositories.ReadProduct();
            int id = 1;
            if(prds == null)
            {
                return new Product(id, productName, productPrice, countOfProducts);
            }
            foreach(var prd in prds)
            {
                if(prd.ProductName.Contains(productName))
                {
                return null;
                }
                id ++;
            }
                return new Product(id, productName, productPrice, countOfProducts);

        }
        public Product? InitializeProduct(int Id, string productName, float productPrice, int countOfProducts)
        {
            List<Product> prds = _Repositories.ReadProduct();
            if(prds == null)
            {
                return new Product(Id, productName, productPrice, countOfProducts);
            }
            foreach(var prd in prds)
            {
                if(prd.ProductName.Contains(productName))
                {
                return null;
                }
            }
                return new Product(Id, productName, productPrice, countOfProducts);
        }
        
        public bool AddProduct(Product prd)
        {
            return _Repositories.AddProduct(prd);
        }
        public Product? GetProductById(int Id)
        {
            List<Product> prds = _Repositories.ReadProduct();
            if(prds == null)
            {
                return null;
            }
            return prds.Find(p => p.ProductId == Id);
        }
        public bool DeleteProduct(int id)
        {
            return _Repositories.DeleteProduct(id);
        }
        public bool EditProduct(Product prd)
        {
            return _Repositories.EditProduct(prd);
        }
    }
}