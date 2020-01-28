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
                    Description = income.Description,
                    BankAccountId = income.BankAccountId,
                    BankAccount = income.BankAccount.Name,
                    Category = income.Category.Name,
                    CategoryId = income.CategoryId,
                    Context = income.Context.Name,
                    ContextId = income.ContextId,
                    CreationDate = income.CreationDate,
                    Date = income.Date,
                    Id = income.Id,
                    Observation = income.Observation,
                    Received = income.Received,
                    Value = income.Value,
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
                ContextId = viewModel.ContextId,
                CreationDate = DateTime.Now,
                Date = viewModel.Date,
                Description = viewModel.Description,
                Observation = viewModel.Observation,
                Received = viewModel.Received,
                Value = viewModel.Value
            };
            _incomeService.Add(income);

            return RedirectToAction("Index");
        }
    }
}