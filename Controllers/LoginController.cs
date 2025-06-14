using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Entity;
using WebAppMVC.Models.Services.Application;


namespace WebAppMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserServices userServices;
        public LoginController(IUserServices userServices)
        {
            this.userServices = userServices;
        }
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Users model)
        {
            var registeredUsers = userServices.GetRegisteredUsers();
            var user = registeredUsers
       .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user != null)
            {
                TempData["Username"] = user.Username;
                return RedirectToAction("UserSummary");
            }

            ModelState.AddModelError("", "Username o password errati.");
            return View(model);
        }
        [HttpGet]
        public IActionResult UserSummary()
        {

            return View("UserSummary");
        }



    }
}