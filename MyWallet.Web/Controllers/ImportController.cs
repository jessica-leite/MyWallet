using MyWallet.Data.Domain;
using MyWallet.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace MyWallet.Web.Controllers
{
    public class ImportController : Controller
    {
        private ImportService _importService;
        private ExpenseService _expenseService;

        public ImportController()
        {
            _importService = new ImportService();
            _expenseService = new ExpenseService();
        }

        public ActionResult Import()
        {
            try
            {
                var filePath = @"C:\Users\Jéssica\Documents\Projetos\MyWallet\TestFiles\uploadExpenses";
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                using (var file = new StreamReader(fileStream))
                {

                    var expenses = new List<Expense>();
                    string line = file.ReadLine();
                    while (!file.EndOfStream)
                    {
                        line = file.ReadLine();
                        var expense = _importService.ConvertLineToExpense(line);
                        expenses.Add(expense);
                    }

                    _expenseService.Add(expenses);
                }
                TempData["Message"] = "Import performed successfully";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Erro: " + ex;
            }

            return RedirectToAction("Index", "Expense");

        }
    }
}