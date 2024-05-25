using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Entities;

namespace EX1_OOP.Services
{
    public interface IProduct_Services
    {
        List<Product> GetAllProducts();
        List<Product>? GetAllProducts(string key);
        Product? InitializeProduct(string productName, float productPrice, int countOfProducts);
        Product? InitializeProduct(int Id, string productName, float productPrice, int countOfProducts);
        bool AddProduct(Product prd);
        Product? GetProductById(int Id);
        bool DeleteProduct(int id);
        bool EditProduct(Product prd);
    }
}