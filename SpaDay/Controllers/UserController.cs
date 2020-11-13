using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(string username, string email, string password, string verify)
        {
            User newUser = new User(username, email, password);
            if (newUser.Password == verify)
            {
                ViewBag.User = newUser;
                return View("Index");
            }
            else
            {
                ViewBag.userName = username;
                ViewBag.email = email;
                ViewBag.error = "Passwords did not match";
                return View("Add");
            }
        }
    }
}
