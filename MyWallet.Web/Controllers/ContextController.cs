using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using MyWallet.Web.ViewModels.Context;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class ContextController : BaseController
    {
        private UnitOfWork _unitOfWork;

        public ContextController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<Context> listContext = _unitOfWork.ContextRepository.GetByUserId(GetCurrentUserId());
            List<ContextViewModel> viewModel = new List<ContextViewModel>();

            foreach (var context in listContext)
            {
                var contextVM = new ContextViewModel();
                contextVM.Id = context.Id;
                contextVM.Name = context.Name;
                contextVM.IsMainContext = context.IsMainContext;
                contextVM.CountryName = context.Country.Name;
                contextVM.CurrencySymbol = context.CurrencyType.Symbol;

                viewModel.Add(contextVM);
            }

            return View(viewModel);
        }

        public ActionResult Create()
        {
            LoadDropDownListCountryAndCurrency();

            return View();
        }

        [HttpPost]
        public ActionResult Create(ContextViewModel contextViewModel)
        {
            if (ModelState.IsValid)
            {
                var context = new Context();
                context.Name = contextViewModel.Name;
                context.CurrencyTypeId = contextViewModel.CurrencyTypeId.Value;
                context.CountryId = contextViewModel.CountryId.Value;
                context.IsMainContext = contextViewModel.IsMainContext;
                context.UserId = GetCurrentUserId();

                if (context.IsMainContext)
                {
                    _unitOfWork.ContextRepository.SetTheMainContextAsNonMain(context.UserId);
                }

                _unitOfWork.ContextRepository.Add(context);
                _unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                LoadDropDownListCountryAndCurrency();
                SendModelStateErrors();
                return View(contextViewModel);
            }
        }

        public ActionResult Update(int id)
        {
            var context = _unitOfWork.ContextRepository.GetById(id);

            var contextViewModel = new ContextViewModel
            {
                Id = context.Id,
                Name = context.Name,
                IsMainContext = context.IsMainContext,
                CountryId = context.CountryId,
                CurrencyTypeId = context.CurrencyTypeId
            };

            LoadDropDownListCountryAndCurrency();

            return View(contextViewModel);
        }

        [HttpPost]
        public ActionResult Update(ContextViewModel contextViewModel)
        {
            if (ModelState.IsValid)
            {
                var oldContext = _unitOfWork.ContextRepository.GetById(contextViewModel.Id);
                oldContext.Name = contextViewModel.Name;
                oldContext.CurrencyTypeId = contextViewModel.CurrencyTypeId.Value;
                oldContext.CountryId = contextViewModel.CountryId.Value;
                oldContext.UserId = GetCurrentUserId();

                if (!oldContext.IsMainContext && contextViewModel.IsMainContext)
                {
                    _unitOfWork.ContextRepository.SetTheMainContextAsNonMain(oldContext.UserId);
                    oldContext.IsMainContext = contextViewModel.IsMainContext;
                }

                _unitOfWork.ContextRepository.Update(oldContext);
                _unitOfWork.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                SendModelStateErrors();
                LoadDropDownListCountryAndCurrency();
                return View(contextViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var context = _unitOfWork.ContextRepository.GetById(id);
            var viewModel = new ContextViewModel()
            {
                Id = context.Id,
                Name = context.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ContextViewModel viewModel)
        {
            var context = new Context()
            {
                Id = viewModel.Id
            };
            _unitOfWork.ContextRepository.Delete(context);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

        private void LoadDropDownListCountryAndCurrency()
        {
            var countries = _unitOfWork.CountryRepository.GetAll();
            var currencies = _unitOfWork.CurrencyTypeRepository.GetAll();

            ViewBag.CountrySelectList = new SelectList(countries, "Id", "Name");
            ViewBag.CurrencyTypeSelectList = new SelectList(currencies, "Id", "Name");
        }
    }
}