using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using WebAppMVC.Models.Services.Application;
using WebAppMVC.Models.Value;

namespace WebAppMVC.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICategoryServices categoryServices;
        private readonly IItemServices itemServices;
        public CategoryController(ICategoryServices categoryServices, IItemServices itemServices)
        {
            this.itemServices = itemServices;
            this.categoryServices = categoryServices;
        }




        public IActionResult Index()
        {
            var categories = categoryServices.GetCategories();
            return View(categories);
        }
        public IActionResult Detail(int id)
        {
            var categoryDetails = categoryServices.GetCategory(id);
            var allItems = itemServices.GetItems();
            var allProducts = allItems
                .Where(i => i.CategoryId == id)
                .ToList();
            var viewModel = new CategoryDetailViewModel
            {
                CategoryName = categoryDetails.CategoryName,
                Products = allProducts,
            };
            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
