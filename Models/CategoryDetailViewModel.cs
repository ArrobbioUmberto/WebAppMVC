using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class CategoryDetailViewModel : CategoryViewModel
    {
        public List<ItemViewModel> Products { get; set; } = new();
        public CategoryViewModel Category { get; set; } = new CategoryViewModel();
    }
}