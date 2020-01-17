using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Context;
using MyWallet.Web.ViewModels.User;
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

        public ActionResult Create(CreateUserViewModel createdUser)
        {
            var contextViewModel = new ContextViewModel();

            var listCurrency = new CurrencyTypeService().GetAll();
            contextViewModel.CurrencyTypeSelectList = new SelectList(listCurrency, "Id", "Name");

            var listCountry = new CountryService().GetAll();
            contextViewModel.CountrySelectList = new SelectList(listCountry, "Id", "Name");

            contextViewModel.Id = createdUser.ContextId;
            contextViewModel.UserId = createdUser.Id;
            contextViewModel.CountryId = 1;

            return View(contextViewModel);
        }

        [HttpPost]
        public ActionResult Create(ContextViewModel contextViewModel)
        {
            if (ModelState.IsValid)
            {
                var context = new Context();
                context.Id = contextViewModel.Id;
                context.Name = contextViewModel.Name;
                context.CurrencyTypeId = contextViewModel.CurrencyTypeId;
                context.CountryId = contextViewModel.CountryId;

                if (contextViewModel.UserId == 0)
                    context.UserId = GetCurrentUserId();
                else
                    context.UserId = contextViewModel.UserId;

                _contextService.AddOrUpdate(context);

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                SendModelStateErrors();
                return View(contextViewModel);
            }

        }
    }
}