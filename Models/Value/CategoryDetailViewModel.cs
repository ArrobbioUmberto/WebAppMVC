using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models.Value
{
    public class CategoryDetailViewModel : CategoryViewModel
    {
        public CategoryViewModel Category { get; set; } = new CategoryViewModel();
    }
}