using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddCategoryViewModel viewModel)
		{
			var category = new Category
			{
				Name = viewModel.Name,
				Description = viewModel.Description,
			};

			await dbContext.AddAsync(category);
			await dbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		[HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var category = await dbContext.Categories.FindAsync(Id);
            
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

			return RedirectToAction("Index");
		}
        [HttpPost]
        public async Task<IActionResult> Delete(Category viewModel)
        {
            var category = await dbContext.Categories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CategoryId == viewModel.CategoryId);
            
            if (category is not null) 
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Categories");
        }


    }
}
