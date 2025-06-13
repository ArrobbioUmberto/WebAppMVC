using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Entity;

namespace WebAppMVC.Models.Services.Application
{
    public interface IUserServices
    {
        List<Users> GetRegisteredUsers();
    }
}