using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data;
using WebAppMVC.Models.Value;

namespace WebAppMVC.Models.Services.Application
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ShopContext _context;

        public CategoryServices(ShopContext context)
        {
            _context = context;
        }
        public List<CategoryViewModel> GetCategories()
        {
            return _context.Category
                .AsNoTracking()
                .Select(category => new CategoryViewModel
                {
                    Id = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                })
                .ToList();
        }
        public CategoryViewModel GetCategory(int id)
        {
            return _context.Category
                .AsNoTracking()
                .Select(category => new CategoryViewModel
                {
                    Id = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                })
                .FirstOrDefault(c => c.Id == id) ?? new CategoryViewModel();
        }
    }

}
