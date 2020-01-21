using MyWallet.Data.Domain;
using MyWallet.Service;
using MyWallet.Web.ViewModels.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    [Authorize]
    public class ExpenseController : BaseController
    {
        private ExpenseService _expenseService;

        public ExpenseController()
        {
            try
            {
                var user = GetUserToken();
            }
            catch (Exception ex)
            {
                var test = ex;
            }


            _expenseService = new ExpenseService();
        }

        public ActionResult Index()
        {
            var listAll = new ListAllExpensesViewModel();
            listAll.Currency = "€";

            //var expense = new ExpenseViewModel();
            //expense.Id = 1;
            //expense.Description = "potato";
            //expense.Category = "food";
            //expense.IsPaid = false;
            //expense.BankAccount = "Santander";
            //expense.Value = 854;

            //listAll.Expenses.Add(expense);

            //expense = new ExpenseViewModel();
            //expense.Id = 2;
            //expense.Description = "tomato";
            //expense.Category = "food";
            //expense.IsPaid = true;
            //expense.BankAccount = "ActivoBank";
            //expense.Value = 90;


            for (int i = 0; i < 500; i++)
            {
                var expense = new ExpenseViewModel();
                expense.Id = 1;
                expense.Description = $"{Guid.NewGuid()} potato {i}";
                expense.Category = "food";
                expense.IsPaid = false;
                expense.BankAccount = "Santander";
                expense.Value = 854;

                listAll.Expenses.Add(expense);
            }



            return View(listAll);
        }

        [HttpPost]
        public ActionResult Create(ExpenseViewModel expenseViewModel)
        {
            var user = GetUserToken();


            var expense = new Expense();
            expense.BankAccountId = expenseViewModel.BankAccountId;
            expense.CategoryId = expenseViewModel.CategoryId;
            expense.CreationDate = DateTime.Now;
            expense.Date = expenseViewModel.Date;
            expense.Description = expenseViewModel.Description;
            expense.IsPaid = expenseViewModel.IsPaid;
            expense.Observation = expenseViewModel.Observation;
            expense.Value = expenseViewModel.Value;

            _expenseService.Add(expense);
            return null;
        }


    }
}