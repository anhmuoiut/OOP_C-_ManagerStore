using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Entities;
using Newtonsoft.Json;
using System.IO;

namespace EX1_OOP.Repositories
{
    public class Product_Repositories : IProduct_Repositories
    {
        private static string path = "File\\Product.json";
        public void SaveProduct (List<Product> products)
        {
            try
            {
                string json = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(path, json);
            }catch(Exception ex)
            {
                throw new Exception("invalid path "+ ex.Message);
            }
        }
        public List<Product> ReadProduct()
        {
            try
            {
                string json = File.ReadAllText(path);
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                return products;
            }catch(Exception ex)
            {
                throw new Exception("invalid path "+ ex.Message);
            }
        }
        public bool AddProduct(Product prd)
        {
            List<Product> prds = ReadProduct();
            if(prd == null)
            {
                return false;
            }
            if(prds == null)
            {
                prds = new List<Product>();
            }
            prds.Add(prd);
            SaveProduct(prds);
            return true;
        }
        public bool DeleteProduct(int id)
        {
            List<Product> prds = ReadProduct();
            if(prds == null)
            {
                return false;
            }
            int df = prds.Count;
            int index = prds.FindIndex(p =>p.ProductId == id);
            if(index != -1)
            {
                prds.RemoveAt(index);
            }
            if(df == prds.Count)
            {
                return false;
            }
            SaveProduct(prds);
            return true;
        }
        public bool EditProduct(Product prd)
        {
            List<Product> prds = ReadProduct();
            if(prds == null)
            {
                return false;
            }
            int index = prds.FindIndex(p => p.ProductId == prd.ProductId);
            if(index != -1)
            {
                prds[index].ProductName = prd.ProductName;
                prds[index].ProductPrice = prd.ProductPrice;
                prds[index].CountOfProducts = prd.CountOfProducts;
            }
            else
            {
                return false;
            }
            SaveProduct(prds);
            return true;
        }
    }
}