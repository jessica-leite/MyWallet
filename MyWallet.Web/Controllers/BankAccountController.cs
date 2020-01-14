using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels;
using MyWallet.Web.ViewModels.BankAccount;
using System;
using System.Web.Mvc;


namespace MyWallet.Web.Controllers
{
    //[Authorize]
    public class BankAccountController : BaseController
    {
        private BankAccountService _bankAccountService;

        public BankAccountController()
        {
            _bankAccountService = new BankAccountService();
        }


        public ActionResult Index()
        {
            var viewModel = new ListAllBankAccountsViewModel();

            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BankAccountViewModel bankAccountViewModel)
        {
            var bankAccount = new BankAccount();
            bankAccount.Name = bankAccountViewModel.Name;
            bankAccount.OpeningBalance = bankAccountViewModel.OpeningBalance.Value;
            bankAccount.ContextId = GetCurrentContextId();
            bankAccount.CreationDate = DateTime.Now;

            _bankAccountService.Add(bankAccount);

            return RedirectToAction("Index", "Dashboard");
        }


    }
}