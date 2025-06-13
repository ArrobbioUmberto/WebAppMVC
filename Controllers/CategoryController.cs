using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using WebAppMVC.Models.Services.Application;

namespace WebAppMVC.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICategoryServices categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            var categories = categoryServices.GetCategories();
            return View(categories);
        }
        // public IActionResult Detail()
        // {
        //     return View();
        // }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
