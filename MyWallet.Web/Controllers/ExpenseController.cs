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
        private BankAccountService _bankAccountService;
        private CategoryService _categoryService;

        public ExpenseController()
        {
            _expenseService = new ExpenseService();
            _bankAccountService = new BankAccountService();
            _categoryService = new CategoryService();
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

        public PartialViewResult GetExpenseById(int id)
        {
            var expense = _expenseService.GetById(id);
            var expenseViewModel = new ExpenseViewModel
            {
                Id = expense.Id,
                Description = expense.Description,
                Value = expense.Value,
                Date = expense.Date,
                IsPaid = expense.IsPaid,
                BankAccountId = expense.BankAccountId,
                CategoryId = expense.CategoryId
            };

            var bankAccounts = _bankAccountService.GetByContextId(expense.ContextId);
            foreach (var item in bankAccounts)
            {
                expenseViewModel.SelectListBankAccount.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            var categories = _categoryService.GetByContextId(expense.ContextId);
            foreach (var item in categories)
            {
                expenseViewModel.SelectListCategory.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString()});
            }

            return PartialView("PartialView/_ExpenseEditFields", expenseViewModel);
        }

        [HttpPost]
        public HttpStatusCodeResult Edit(ExpenseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var expense = _expenseService.GetById(viewModel.Id);
                expense.Date = viewModel.Date.Value;
                expense.Description = viewModel.Description;
                expense.CategoryId = viewModel.CategoryId.Value;
                expense.BankAccountId = viewModel.BankAccountId.Value;
                expense.Value = viewModel.Value.Value;
                expense.IsPaid = viewModel.IsPaid;

                _expenseService.Update(expense);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public HttpStatusCodeResult Delete(int id)
        {
            _expenseService.Delete(id);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
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