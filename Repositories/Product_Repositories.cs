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
    }
}