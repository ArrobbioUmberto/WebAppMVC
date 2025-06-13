using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebAppMVC.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public List<Item> Products { get; set; } = new(); // Navigation property
    }
}