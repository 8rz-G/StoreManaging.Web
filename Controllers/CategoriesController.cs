using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManaging.Web.Data;
using StoreManaging.Web.Models;
using StoreManaging.Web.Models.Entities;

namespace StoreManaging.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CategoriesController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
		
        [HttpGet]
		public async Task<IActionResult> Index()
        {
            var categories = await dbContext.Categories.ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category viewModel)
        {
            var category = await dbContext.Categories.FindAsync(viewModel.CategoryId);

            if (category is not null) 
            { 
                category.CategoryId = viewModel.CategoryId;
                category.Name = viewModel.Name;
                category.Description = viewModel.Description;
            }

            await dbContext.SaveChangesAsync();

            return View("Index", "Categories");
        }


    }
}
