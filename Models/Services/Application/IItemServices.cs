using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models.Services.Application
{
    public interface IItemServices
    {
        List<ItemViewModel> GetItems();
        ItemViewModel GetItem(int id);
    }
}