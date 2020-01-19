using MyWallet.Web.ViewModels.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
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
            return Json(expenseViewModel);
        }


    }
}