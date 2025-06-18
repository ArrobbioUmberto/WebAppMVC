using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Data;
using WebAppMVC.Entity;
using WebAppMVC.Models.Services.Application;


namespace WebAppMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserServices userServices;
        private readonly ShopContext _dbContext;
        public LoginController(IUserServices userServices, ShopContext dbContext)
        {
            _dbContext = dbContext;
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

                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("UserSummary");
            }


            ModelState.AddModelError("", "Username o password errati.");
            return View(model);
        }
        [HttpGet]

        public IActionResult UserSummary()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login");

            var user = userServices.GetRegisteredUsers()
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
                return RedirectToAction("Login");

            return View(user);
        }
        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Users user)
        {

            var users = userServices.GetRegisteredUsers();
            foreach (var registereduser in users)
            {
                if (registereduser.Email == user.Email)
                {
                    ModelState.AddModelError("Email", "La mail è già stata registrata");
                    break;
                }
                if (registereduser.Username == user.Username)
                {
                    ModelState.AddModelError("Username", "Questo username è già stato utilizzato");
                    break;
                }
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Alcuni dati non sono corretti");
                return View("Create", user);
            }
            var isAdmin = Request.Form["IsAdmin"].Count > 0;
            user.RoleId = isAdmin ? 1 : 2;



            _dbContext.users.Add(user);
            _dbContext.SaveChanges();

            HttpContext.Session.SetString("Username", user.Username);


            return RedirectToAction("UserSummary");
        }
        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Username", string.Empty);
            return RedirectToAction("Index", "Home");
        }




    }
}