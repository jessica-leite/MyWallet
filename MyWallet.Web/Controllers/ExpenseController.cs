using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Expense;
using System;
using System.Net;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class ExpenseController : BaseController
    {
        private ExpenseService _expenseService;

        public ExpenseController()
        {
            _expenseService = new ExpenseService();
        }

        public ActionResult Index()
        {
            var contextId = GetCurrentContextId();

            var expenseList = _expenseService.GetByContextId(contextId);

            var viewModelList = new ListAllExpensesViewModel();
            viewModelList.Currency = "€";

            foreach (var item in expenseList)
            {
                var expense = new ExpenseViewModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
                    IsPaid = item.IsPaid,
                    BankAccountId = item.BankAccountId,
                    Value = item.Value,
                    Date = item.Date,
                    Observation = item.Observation,
                    BankAccount = item.BankAccount.Name,
                    Category = item.Category.Name
                };

                viewModelList.Expenses.Add(expense);
            }
            return View(viewModelList);
        }

        [HttpPost]
        public HttpStatusCodeResult Create(ExpenseViewModel expenseViewModel)
        {
            if (ModelState.IsValid)
            {
                var expense = new Expense();
                expense.BankAccountId = expenseViewModel.BankAccountId.Value;
                expense.CategoryId = expenseViewModel.CategoryId.Value;
                expense.CreationDate = DateTime.Now;
                expense.Date = expenseViewModel.Date.Value;
                expense.Description = expenseViewModel.Description;
                expense.IsPaid = expenseViewModel.IsPaid;
                expense.Observation = expenseViewModel.Observation;
                expense.Value = expenseViewModel.Value.Value;
                expense.ContextId = GetCurrentContextId();

                _expenseService.Add(expense);
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public PartialViewResult GetExpenses()
        {
            var contextId = GetCurrentContextId();

            var expenseList = _expenseService.GetByContextId(contextId);

            var viewModelList = new ListAllExpensesViewModel();
            viewModelList.Currency = "€";

            foreach (var item in expenseList)
            {
                var expense = new ExpenseViewModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
                    IsPaid = item.IsPaid,
                    BankAccountId = item.BankAccountId,
                    Value = item.Value,
                    Date = item.Date,
                    Observation = item.Observation,
                    BankAccount = item.BankAccount.Name,
                    Category = item.Category.Name
                };

                viewModelList.Expenses.Add(expense);
            }
            return PartialView("~/Views/Expense/PartialView/_ExpensesList.cshtml", viewModelList);
        }
    }
}