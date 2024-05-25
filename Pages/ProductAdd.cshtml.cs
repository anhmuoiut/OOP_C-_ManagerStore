using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Entities;
using EX1_OOP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EX1_OOP.Pages
{
    public class ProductAdd : PageModel
    {
        private readonly ILogger<ProductAdd> _logger;
        private IProduct_Services _Services = new Product_Services();

        public ProductAdd(ILogger<ProductAdd> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    public int productId {get;set;}
    [BindProperty]
    public string productName {get;set;}
    [BindProperty]
    public float productPrice {get;set;}
     [BindProperty]
    public int countOfProducts {get;set;}
    public string message = string.Empty;
        public void OnPost()
        {
            if(countOfProducts < 1)
            {
                message = "total must greater / equals than 1";
            }
            if(productPrice < 1 && productPrice >100)
            {
                message = "Price be started from 1 to 99";
            }
            Product? prd = _Services.InitializeProduct(productName, productPrice, countOfProducts);
            if(prd == null)
            {
                message = "Valid product name";
            }else
            {
                 bool isUpdate = _Services.AddProduct(prd);
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