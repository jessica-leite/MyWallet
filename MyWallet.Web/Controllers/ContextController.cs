using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Context;
using MyWallet.Web.ViewModels.User;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class ContextController : BaseController
    {
        // GET: Context
        public ActionResult Create(CreateUserViewModel createdUserId)
        {
            var contextViewModel = new CreateContextViewModel();

            var listCurrency = new CurrencyTypeService().GetAll();
            contextViewModel.CurrencyTypeSelectList = new SelectList(listCurrency, "Id", "Name");

            var listCountry = new CountryService().GetAll();
            contextViewModel.CountrySelectList = new SelectList(listCountry, "Id", "Name");

            contextViewModel.UserId = createdUserId.Id;

            return View(contextViewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateContextViewModel contextViewModel)
        {
            var context = new Context();
            context.Name = contextViewModel.Name;
            context.CurrencyTypeId = contextViewModel.CurrencyTypeId;
            context.CountryId = contextViewModel.CountryId;
            context.UserId = contextViewModel.UserId;

            var contextService = new ContextService();
            contextService.Add(context);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}