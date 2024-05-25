using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Entities;
using EX1_OOP.Repositories;
namespace EX1_OOP.Services
{
    public class Product_Services : IProduct_Services
    {
        private IProduct_Repositories _Repositories = new Product_Repositories();
        public List<Product> GetAllProducts()
        {
            List<Product> products = _Repositories.ReadProduct();
            if(products == null)
            {
                return new List<Product>();
            }
            return products;
        }
        public List<Product>? GetAllProducts(string key)
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
    }
}