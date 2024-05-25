using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EX1_OOP.Services;
using EX1_OOP.Entities;

namespace EX1_OOP.Pages
{
    public class Product_Home : PageModel
    {
        private readonly ILogger<Product_Home> _logger;
        private IProduct_Services _Services = new Product_Services();

        public Product_Home(ILogger<Product_Home> logger)
        {
            _logger = logger;
        }

public string message = string.Empty;
[BindProperty]
public string key {get;set;} = string.Empty;

public List<Product> products = new List<Product>();
        public void OnGet()
        {
            products = _Services.GetAllProducts();
        }
        public void OnPost()
        {
            products = _Services.GetAllProducts(key) ?? "";
        }
    }
}