﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Database;
using System.Threading.Tasks;
using Shop.Application.CreateProducts;
using Shop.Application.GetProducts;
using System.Linq;
using System.Collections.Generic;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        
        private AppDBContext _ctx;

        public IndexModel(AppDBContext context)
        {
            _ctx = context;
        }
        [BindProperty]
        public Application.CreateProducts.ProductViewModel Product { get; set; }
        
        public IEnumerable<Application.GetProducts.ProductViewModel> Products { get; set; }
        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }
        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);

            return RedirectToPage("Index");
        }
    }
}
