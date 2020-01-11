using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWallet.Web.ViewModels.User;
using MyWallet.Data.Domain;
using MyWallet.Service;

namespace MyWallet.Web.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserViewModel userViewModel)
        {
            var user = new User
            {
                Name = userViewModel.Name,
                LastName = userViewModel.LastName,
                Email = userViewModel.Email,
                Password = userViewModel.Password
            };

            var userService = new UserService();
            userService.Add(user);

            return RedirectToAction("Create", "Context", user);
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}