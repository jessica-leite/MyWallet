﻿using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using MyWallet.Web.Util;
using MyWallet.Web.ViewModels.User;
using System;
using System.IO;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class UserController : BaseController
    {
        private UnitOfWork _unitOfWork;
        

        public UserController()
        {
            _unitOfWork = new UnitOfWork();
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
                var user = new User();

                user.Name = userViewModel.Name;
                user.LastName = userViewModel.LastName;
                user.Email = userViewModel.Email;
                user.Password = CryptographyUtil.Encrypt(userViewModel.Password);
                user.CreationDate = DateTime.Now;
                

                var mainContext = new Context
                {
                    UserId = user.Id,
                    IsMainContext = true,
                    Name = "My Finances (Default)",
                    CountryId = 1, //TODO implement
                    CurrencyTypeId = 1
                };


                var categories = _unitOfWork.CategoryRepository.GetStandardCategories();
                foreach (var category in categories)
                {
                    category.ContextId = mainContext.Id;
                }

                var mainBankAccount = new BankAccount
                {
                    ContextId = mainContext.Id,
                    Name = "My Bank Account (Default)",
                    CreationDate = DateTime.Now,
                };

                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.ContextRepository.Add(mainContext);
                _unitOfWork.CategoryRepository.Add(categories);
                _unitOfWork.BankAccountRepository.Add(mainBankAccount);
                _unitOfWork.Commit();

                // Login into plataform - bacause of the Autorization (attribute)
                CookieUtil.SetAuthCookie(user.Id, user.Name, user.GetTheMainContextId());

                return RedirectToAction("Index", "Dashboard");
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
            var user = _unitOfWork.UserRepository.GetById(GetCurrentUserId());

            var viewModel = new UserViewModel()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email
            };

            if (user.Photo != null)
                viewModel.PhotoBase64 = "data:image/jpeg;base64," + Convert.ToBase64String(user.Photo);
            else
                viewModel.PhotoBase64 = "/Content/Img/img_avatar.png";

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel) 
        {
            if (string.IsNullOrWhiteSpace(userViewModel.Password) && string.IsNullOrWhiteSpace(userViewModel.RepeatPassword))
            {
                ModelState.Remove("Password");
                ModelState.Remove("RepeatPassword");
            }

            if (ModelState.IsValid)
            {
                var user = _unitOfWork.UserRepository.GetById(GetCurrentUserId());

                if (userViewModel.NewPhoto != null)
                {
                    byte[] photo = null;
                    using (var memoryStream = new MemoryStream())
                    {
                        userViewModel.NewPhoto.InputStream.CopyTo(memoryStream);
                        photo = memoryStream.ToArray();
                    }
                    user.Photo = photo;
                }

                user.Name = userViewModel.Name;
                user.LastName = userViewModel.LastName;
                user.Email = userViewModel.Email;

                if (!string.IsNullOrWhiteSpace(userViewModel.Password) && !string.IsNullOrWhiteSpace(userViewModel.RepeatPassword)) //TODO think better about this condition
                {
                    user.Password = CryptographyUtil.Encrypt(userViewModel.Password);
                }

                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Commit();

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                SendModelStateErrors();
                return View(userViewModel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}