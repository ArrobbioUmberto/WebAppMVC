using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models.Value;

namespace WebAppMVC.Entity
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; private set; } = string.Empty;
        [Required]
        public string ProductImageString { get; private set; } = string.Empty;
        [Required]
        public string Description { get; private set; } = string.Empty;

        public int Rating { get; private set; }
        [Required]
        public string Brand { get; private set; } = string.Empty;
        [Required]
        public Money Discount { get; private set; } = new Money(0);
        [Required]
        public Money FullPrice { get; private set; } = new Money(0);

        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; } = null!; // Navigation property
    }
}