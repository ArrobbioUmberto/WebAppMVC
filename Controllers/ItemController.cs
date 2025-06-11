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
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var items = new ItemServices();
            List<ItemViewModel> itemlist = items.GetItems();
            return View(itemlist);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public IActionResult Detail(int id)
        {
            var item = new ItemServices();
            ItemViewModel itemDetail = item.GetItem(id);
            List<ItemViewModel> allItems = item.GetItems();
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