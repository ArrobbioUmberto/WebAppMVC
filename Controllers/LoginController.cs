using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            // var items = itemServices.GetItems();  // ora prende i dati dal DB!
            return View();
        }
    }
}