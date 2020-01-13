using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWallet.Web.ViewModels.User;
using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.Util;

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

            var mainContext = new Context()
            {
                UserId = user.Id,
                IsMainContext = true,
                Name = string.Empty,
                CountryId = userViewModel.CountryId,
                CurrencyTypeId = userViewModel.CurrencyTypeId
            };

            user.AddNewContext(mainContext);

            var userService = new UserService();
            userService.Add(user);


            //Context
            userViewModel.ContextId = mainContext.Id;
            userViewModel.ContextName = mainContext.Name;
            userViewModel.Id = mainContext.UserId;

            //Login into plataform - bacause of the Autorization (attribute)
            CookieUtil.SetAuthCookie(user.Id, user.Name, user.GetTheMainContextId());

            return RedirectToAction("Create", "Context", userViewModel);
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}