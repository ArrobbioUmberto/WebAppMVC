using System;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data;
using WebAppMVC.Models.Value;

namespace WebAppMVC.Models.Services.Application
{
    public class ItemServices : IItemServices
    {
        private readonly ShopContext _context;

        public ItemServices(ShopContext context)
        {
            _context = context;
        }
        public ItemViewModel GetItem(int id)
        {
            return _context.Products
                .AsNoTracking()
                .Select(item => new ItemViewModel
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Category = item.Category,
                    Brand = item.Brand,
                    Description = item.Description,
                    ProductImageString = item.ProductImageString,
                    Rating = item.Rating,
                    FullPrice = new Money(item.FullPrice.Amount),
                    Discount = new Money(item.Discount.Amount)
                })
                .FirstOrDefault(i => i.Id == id) ?? new ItemViewModel();
        }



        public List<ItemViewModel> GetItems()
        {
            return _context.Products
                 .AsNoTracking()
                 .Select(item => new ItemViewModel
                 {
                     Id = item.Id,
                     ProductName = item.ProductName,
                     Category = item.Category,
                     Brand = item.Brand,
                     Description = item.Description,
                     ProductImageString = item.ProductImageString,
                     Rating = item.Rating,
                     FullPrice = new Money(item.FullPrice.Amount),
                     Discount = new Money(item.Discount.Amount)
                 })
                 .ToList();
        }
    }
}

