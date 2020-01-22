using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWallet.Web.ViewModels.User;
using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.Util;
using MyWallet.Web.ViewModels.Context;
using System.IO;

namespace MyWallet.Web.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            var user = new User
            {
                Name = userViewModel.Name,
                LastName = userViewModel.LastName,
                Email = userViewModel.Email,
                Password = userViewModel.Password
            };

            var mainContext = new Context()
            {
                UserId = user.Id,
                IsMainContext = true,
                Name = string.Empty,
                CountryId = 1,
                CurrencyTypeId = 1
            };

            user.AddNewContext(mainContext);

            var userService = new UserService();
            userService.Add(user);

            // Login into plataform - bacause of the Autorization (attribute)
            CookieUtil.SetAuthCookie(user.Id, user.Name, user.GetTheMainContextId());

            // Context - redirect (for update the main context)
            var contextViewModel = new ContextViewModel();
            contextViewModel.Id = mainContext.Id;
            contextViewModel.IsMainContext = true;
            contextViewModel.UserId = user.Id;
            contextViewModel.CountryId = 1;
            contextViewModel.CurrencyTypeId = 1;

            return RedirectToAction("CreateFirstContext", "Context", contextViewModel);
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase profilePhoto)
        {
            

            return View();
        }
    }
}