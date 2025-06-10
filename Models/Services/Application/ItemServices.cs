using System;
using WebAppMVC.Models.Value;

namespace WebAppMVC.Models.Services.Application
{
    public class ItemServices
    {
        public List<ItemViewModel> GetItems()
        {
            var itemList = new List<ItemViewModel>();
            var randomicNumber = new Random();
            for (int i = 1; i < 21; i++)
            {
                var item = new ItemViewModel
                {
                    Id = i,
                    Category = $"Categoria {randomicNumber.Next(1, 5)}",
                    ProductName = $"Prodotto {i}",
                    Description = $"Descrizione del prodotto {i}",
                    ProductImageString = $"/img/prodotto-test.png",
                    Rating = randomicNumber.Next(1, 6),
                    Discount = randomicNumber.Next(0, 2) == 0 ? new Money(0.00m) : new Money(randomicNumber.Next(1, 100)),
                    FullPrice = new Money(randomicNumber.Next(10, 500))
                };
                itemList.Add(item);
            }
            return itemList;
        }
    }
}

