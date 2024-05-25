using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Entities;
namespace EX1_OOP.Repositories
{
    public interface IProduct_Repositories
    {
        void SaveProduct (List<Product> products);
        List<Product> ReadProduct();
        bool AddProduct(Product prd);
        bool DeleteProduct(int id);
        bool EditProduct(Product prd);
    }
}