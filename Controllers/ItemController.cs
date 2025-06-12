using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppMVC.Models;
using WebAppMVC.Models.Services.Application;

namespace WebAppMVC.Controllers
{
    public class ItemController : Controller
    {

        private readonly IItemServices itemServices;

        public ItemController(IItemServices itemServices)
        {
            this.itemServices = itemServices;
        }

        public IActionResult Index()
        {
            var items = itemServices.GetItems();  // ora prende i dati dal DB!
            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public IActionResult Detail(int id)
        {
            var itemDetail = itemServices.GetItem(id);
            var allItems = itemServices.GetItems();
            ViewData["Title"] = itemDetail.ProductName;
            var relatedProduct = allItems
                .Where(i => i.Id != id && i.Category == itemDetail.Category)
                .ToList();
            var allItemData = new ItemDetailModel
            {
                Product = itemDetail,
                Related = relatedProduct
            };
            return View(allItemData);
        }
    }
}