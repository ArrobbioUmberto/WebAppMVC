using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models.Services.Application
{
    public interface ICategoryServices
    {
        List<CategoryViewModel> GetCategories();
        public CategoryViewModel GetCategory(int id);
    }
}