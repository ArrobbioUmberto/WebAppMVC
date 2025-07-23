using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAppMVC.Data;
using WebAppMVC.Entity;
using WebAppMVC.Models;
using WebAppMVC.Models.Services.Application;

namespace WebAppMVC.Controllers
{
    public class ItemController : Controller
    {

        private readonly IItemServices itemServices;
        private readonly ShopContext _dbContext;
        private readonly ICategoryServices categoryServices;

        public ItemController(IItemServices itemServices, ShopContext dbContext, ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
            _dbContext = dbContext;
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


        // SEZIONE CREAZIONE NUOVO PRODOTTO 
        [HttpGet("/create/product")]
        public IActionResult Create()
        {
            var categories = categoryServices.GetCategories();
            ViewBag.Categories = categories;
            return View("Create");
        }
        [HttpPost("/create/product")]
        public IActionResult CreateProduct(Item item)
        {
            // var allItem = itemServices.GetItems();
            // Console.WriteLine($"Nome: {item.ProductName}");
            // Console.WriteLine($"Descrizione: {item.Description}");
            // Console.WriteLine($"Brand: {item.Brand}");
            // Console.WriteLine($"FullPrice: {item.FullPrice.Amount}");
            // Console.WriteLine($"Discount: {item.Discount.Amount}");
            // Console.WriteLine($"String: {item.ProductImageString}");
            if (item.FullPrice.Amount < item.Discount.Amount)
            {
                ModelState.AddModelError("Discount", "Lo sconto non può essere maggiore del prezzo imposto");
            }

            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    var key = entry.Key;
                    var state = entry.Value;

                    Console.WriteLine($"Field: {key}");
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"  Error: {error.ErrorMessage}");
                    }
                }

                var categories = categoryServices.GetCategories();
                ViewBag.Categories = categories;
                return View("Create", item);  // importante passare il modello per mostrare i valori e gli errori
            }


            _dbContext.Products.Add(item);
            _dbContext.SaveChanges();

            return RedirectToAction("Detail", "Item", new { id = item.Id });
        }

    }
}