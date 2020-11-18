using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using SpaDay.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            User newUser = new User()
            {
                Username = "Hello, Test",
            };
            return View(newUser);
        }

        public IActionResult Add()
        {
            AddUserViewModel login = new AddUserViewModel();
            return View(login);
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(AddUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                if (newUser.Password == newUser.VerifyPassword)
                {
                    User user = new User
                    {
                        Username = newUser.Username,
                        Email = newUser.Email,
                        Password = newUser.Password
                    };

                    return View("Index", user);
                }
                else
                {
                    ViewBag.error = "Passwords do not match! Try again!";
                    return View("Add", newUser);
                }

            }

            return View("Add", newUser);
        }

    }
}
