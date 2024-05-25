using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EX1_OOP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EX1_OOP.Entities;
using EX1_OOP.Services;
using System.Runtime.CompilerServices;

namespace EX1_OOP.Pages
{
    public class ProductDelete : PageModel
    {
        private readonly ILogger<ProductDelete> _logger;
        private IProduct_Services _Services = new Product_Services();

        public ProductDelete(ILogger<ProductDelete> logger)
        {
            _logger = logger;
        }

[BindProperty(SupportsGet = true)]
public int ProductId {get;set;}
public Product? prd;
public string message = string.Empty;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            bool isDelete = _Services.DeleteProduct(ProductId);
            if(isDelete)
            {
                message =$"Delete ProductID: {ProductId} successfully ";
            }
            else
            {
                message ="Delete Failure~";
            }
        }
    }
}