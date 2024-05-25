using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Entities;
using EX1_OOP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EX1_OOP.Entities;
using EX1_OOP.Services;

namespace EX1_OOP.Pages
{
    public class ProductEdit : PageModel
    {
        private readonly ILogger<ProductEdit> _logger;
        private IProduct_Services _Services = new Product_Services();

        public ProductEdit(ILogger<ProductEdit> logger)
        {
            _logger = logger;
        }
public Product? product;
[BindProperty(SupportsGet = true)]
public int ProductId {get;set;}
[BindProperty]
public string ProductName {get;set;}
[BindProperty]
public float ProductPrice {get;set;}
[BindProperty]
public int CountOfProducts {get;set;}

public string message = string.Empty;
        public void OnGet()
        {
            product = _Services.GetProductById(ProductId);
        }
        public void OnPost()
        {
            if(CountOfProducts < 1)
            {
                message = "total must greater / equals than 1";
            }
            if(ProductPrice < 1 && ProductPrice >100)
            {
                message = "Price be started from 1 to 99";
            }
            product = _Services.InitializeProduct(ProductId, ProductName, ProductPrice, CountOfProducts);
            if(product == null)
            {
                message = "Valid product name";
            }else
            {
                 bool isUpdate = _Services.EditProduct(product);
                 if(!isUpdate)
                 {
                    message = "Add product failures";
                 }
                 else
                 {
                    Response.Redirect("/Product_Home");
                 }
            }
        }
    }
}