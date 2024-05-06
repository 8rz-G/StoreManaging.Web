using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StoreManaging.Web.Data;
using StoreManaging.Web.Models;
using StoreManaging.Web.Models.Entities;

namespace StoreManaging.Web.Controllers
{
	public class ProductsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await dbContext.Products.ToListAsync();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            var product = new Products
            {
                Name = viewModel.Name,
                Category = viewModel.Category,
                Quantity = viewModel.Quantity,
                Price = viewModel.Price,
            };

            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var product = await dbContext.Products.FindAsync(Id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Products viewModel)
        {
            var product = await dbContext.Products.FindAsync(viewModel.ProductCode);

            if (product is not null)
            {
                product.ProductCode = viewModel.ProductCode;
                product.Name = viewModel.Name;
                product.Category = viewModel.Category;
                product.Quantity = viewModel.Quantity;
                product.Price = viewModel.Price;
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Products viewModel)
        {
            var product = await dbContext.Products.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductCode == viewModel.ProductCode);

            if (product is not null) 
            { 
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
	}
}
