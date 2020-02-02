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
using System.Text;

namespace MyWallet.Web.Controllers
{
    public class UserController : BaseController
    {
        private UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
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

                _userService.Add(user);

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
            else
            {
                SendModelStateErrors();
                return View(userViewModel);
            }
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var user = _userService.GetById(GetCurrentUserId());
            var viewModel = new UserViewModel()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                byte[] photo = null;
                using (var memoryStream = new MemoryStream())
                {
                    userViewModel.Photo.InputStream.CopyTo(memoryStream);
                    photo = memoryStream.ToArray();
                }

                var oldUser = _userService.GetById(GetCurrentUserId());

                var updateUser = new User()
                {
                    Id = GetCurrentUserId(),
                    Name = userViewModel.Name,
                    LastName = userViewModel.LastName,
                    CreationDate = oldUser.CreationDate,
                    Email = userViewModel.Email,
                    Password = userViewModel.Password,
                    Photo = photo
                };
                _userService.Update(updateUser);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                SendModelStateErrors();
                return View();
            }

        }
    }
}