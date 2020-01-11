using MyWallet.Data.Repository;
using MyWallet.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWallet.Data.Domain;
using MyWallet.Service;
using System.Web.Security;

namespace MyWallet.Web.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDatabase = new UserService().GetByEmailAndPassword(loginViewModel.Email, loginViewModel.Password);
                if (userDatabase == null)
                {
                    return View(loginViewModel);
                }

                FormsAuthentication.SetAuthCookie(userDatabase.Id.ToString(), loginViewModel.RememberMe);
                return RedirectToAction("Index", "Dashboard");
            }

            return View(loginViewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}