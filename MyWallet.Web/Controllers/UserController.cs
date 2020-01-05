using MyWallet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Create()
        {
            var userService = new UserService();

            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}