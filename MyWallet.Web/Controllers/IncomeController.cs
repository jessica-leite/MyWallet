using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Income;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class IncomeController : BaseController
    {
        private IncomeService _incomeService;

        public IncomeController()
        {
            _incomeService = new IncomeService();
        }

        // GET: Income
        public ActionResult Index()
        {
            var incomeList = _incomeService.GetByContextId(GetCurrentContextId());
            var viewModelList = new ListAllIncomeViewModel();
            viewModelList.Currency = "€";

            foreach (var income in incomeList)
            {
                var viewModel = new IncomeViewModel()
                {
                    Id = income.Id,
                    Description = income.Description,
                    CategoryId = income.CategoryId,
                    Received = income.Received,
                    BankAccountId = income.BankAccountId,
                    Value = income.Value,
                    Date = income.Date,
                    Observation = income.Observation,
                    BankAccount = income.BankAccount.Name,
                    Category = income.Category.Name,
                };

                viewModelList.IncomeList.Add(viewModel);
            }

            return View(viewModelList);
        }

        public ActionResult Create(IncomeViewModel viewModel)
        {
            var income = new Income()
            {
                BankAccountId = viewModel.BankAccountId,
                CategoryId = viewModel.CategoryId,
                ContextId = GetCurrentContextId(),
                CreationDate = DateTime.Now,
                Date = viewModel.Date.Value,
                Description = viewModel.Description,
                Observation = viewModel.Observation,
                Received = viewModel.Received,
                Value = viewModel.Value.Value
            };
            _incomeService.Add(income);

            return RedirectToAction("Index");
        }

        public PartialViewResult GetByContext()
        {
            var incomeList = _incomeService.GetByContextId(GetCurrentContextId());

            var viewModelList = new ListAllIncomeViewModel();
            viewModelList.Currency = "€";

            foreach (var item in incomeList)
            {
                var income = new IncomeViewModel
                {
                    Id = item.Id,
                    Description = item.Description,
                    Value = item.Value,
                    Date = item.Date,
                    Received = item.Received,
                    BankAccount = item.BankAccount.Name,
                    Category = item.Category.Name
                };

                viewModelList.IncomeList.Add(income);
            }
            return PartialView("PartialView/_IncomeList",viewModelList);
        }
    }
}