using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EX1_OOP.Entities
{
    public class Product
    {
        public int ProductId {get;set;}
        public string ProductName {get;set;}
        public float ProductPrice {get;set;}
        public int CountOfProducts {get;set;}
        public Product(int ProductId, string ProductName, float ProductPrice, int CountOfProduct)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
            this.CountOfProducts = CountOfProduct;
        }
    }
}