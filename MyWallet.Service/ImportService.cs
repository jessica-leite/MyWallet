using MyWallet.Data.Domain;
using System;

namespace MyWallet.Service
{
    public class ImportService
    {
        public Expense ConvertLineToExpense(string line)
        {
            string[] field = line.Split(',');

            var expense = new Expense()
            {
                //BankAccount = field[4],
                BankAccountId = 11,
                //Category = field[3],
                CategoryId = 1,
                //Context = field[7],
                ContextId = 1,
                CreationDate = DateTime.Now,
                //Date = DateTime.ParseExact(field[0], "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                Date = DateTime.Now,
                Description = field[1],
                IsPaid = field[5] == "1" ? true : false,
                Observation = field[6],
                Value = decimal.Parse(field[2])
            };
            return expense;
        }
    }
}
