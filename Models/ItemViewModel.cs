using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models.Value;

namespace WebAppMVC.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductImageString { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; } = int.MinValue;
        public string Brand { get; set; } = string.Empty;
        // per questa sezione Money è stato creato appositamente per regolare i prezzi e il legame con le valute
        public Money Discount { get; set; } = new Money(0.00m);
        public Money FullPrice { get; set; } = new Money(0.00m);

    };

}