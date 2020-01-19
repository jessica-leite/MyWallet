using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Context;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class ContextController : BaseController
    {
        ContextService _contextService;

        public ContextController()
        {
            _contextService = new ContextService();
        }

        public ActionResult Index()
        {
            IEnumerable<Context> listContext = _contextService.GetAll();
            List <ContextViewModel> viewModel = new List<ContextViewModel>();

            foreach (var context in listContext)
            {
                var contextVM = new ContextViewModel();
                contextVM.Id = context.Id;
                contextVM.Name = context.Name;

                viewModel.Add(contextVM);
            }

            return View(viewModel);
        }

        public ActionResult CreateFirstContext(ContextViewModel contextViewModel)
        {
            var listCurrency = new CurrencyTypeService().GetAll();
            contextViewModel.CurrencyTypeSelectList = new SelectList(listCurrency, "Id", "Name");

            var listCountry = new CountryService().GetAll();
            contextViewModel.CountrySelectList = new SelectList(listCountry, "Id", "Name");

            return View(contextViewModel);
        }

        [HttpPost]
        public ActionResult Update(ContextViewModel contextViewModel)
        {
            if (ModelState.IsValid)
            {
                var context = new Context();
                context.Id = contextViewModel.Id;
                context.Name = contextViewModel.Name;
                context.IsMainContext = contextViewModel.IsMainContext;
                context.CurrencyTypeId = contextViewModel.CurrencyTypeId;
                context.CountryId = contextViewModel.CountryId;
                context.UserId = GetCurrentUserId(); 

                _contextService.AddOrUpdate(context);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                SendModelStateErrors();
                return View(contextViewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var context = _contextService.GetById(id);
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
            _contextService.Delete(context);

            return RedirectToAction("Index");
        }
    }
}