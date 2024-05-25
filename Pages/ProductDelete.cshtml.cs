using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EX1_OOP.Pages
{
    public class ProductDelete : PageModel
    {
        private readonly ILogger<ProductDelete> _logger;

        public ProductDelete(ILogger<ProductDelete> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}