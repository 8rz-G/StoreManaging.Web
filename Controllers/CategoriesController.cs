﻿using Microsoft.AspNetCore.Mvc;

namespace StoreManaging.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
