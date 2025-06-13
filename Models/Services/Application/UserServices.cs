using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Data;
using WebAppMVC.Entity;

namespace WebAppMVC.Models.Services.Application
{

    public class UserServices : IUserServices
    {
        private readonly ShopContext _context;

        public UserServices(ShopContext context)
        {
            _context = context;
        }

        // una volta richiamato il metodo e il contenuto dal database manipolo i dati

        public List<Users> GetRegisteredUsers()
        {
            return _context.users.ToList();
        }
    }

}