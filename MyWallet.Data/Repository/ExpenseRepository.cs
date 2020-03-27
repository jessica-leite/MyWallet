using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class ExpenseRepository
    {
        private MyWalletDBContext _context;

        public ExpenseRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public void Add(Expense expense)
        {
            _context.Expense.Add(expense);
        }

        public void Update(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
        }

        public IDictionary<int, decimal> GetAnnualExpensesByContextId(int contextId)
        {
            var query = _context.Expense
                .Where(e => e.Date.Year == DateTime.Now.Year
                    && e.ContextId == contextId
                    && e.IsPaid);

            IQueryable<IGrouping<int, Expense>> group = query.GroupBy(e => e.Date.Month);

            var result = group.ToDictionary(x => x.Key, x => x.Sum(i => i.Value));

            return result;
        }

        public void Delete(int id)
        {
            _context.Entry(new Expense { Id = id }).State = EntityState.Deleted;
        }

        public Expense GetById(int id)
        {
            return _context.Expense.Find(id);
        }

        public IEnumerable<Expense> GetAllByContextId(int contextId)
        {
            using (var connection = new SqlConnection(_context.Database.Connection.ConnectionString))
            {
                connection.Open();

                var sqlText = @"SELECT 
                                    e.Id, 
	                                e.Description, 
	                                e.Value, 
	                                e.Date, 
	                                e.IsPaid, 
	                                e.Observation, 
	                                b.Name BankAccount,
                                    c.Name Category
                                FROM
                                    Expense e
                                INNER JOIN Category c ON c.Id = e.CategoryId
                                INNER JOIN BankAccount b ON b.Id = e.BankAccountId
                                WHERE
                                    e.ContextId = @ContextId";

                var command = new SqlCommand(sqlText, connection);
                command.Parameters.AddWithValue("ContextId", contextId);

                var result = command.ExecuteReader();

                var expenses = new List<Expense>();
                while (result.Read())
                {
                    var expense = new Expense();
                    expense.Id = int.Parse(result["Id"].ToString());
                    expense.Description = result["Description"].ToString();
                    expense.Value = decimal.Parse(result["Value"].ToString());
                    expense.Date = DateTime.Parse(result["Date"].ToString());
                    expense.IsPaid = bool.Parse(result["IsPaid"].ToString());
                    expense.Observation = result["Observation"].ToString();
                    expense.BankAccount = new BankAccount { Name = result["BankAccount"].ToString() };
                    expense.Category = new Category { Name = result["Category"].ToString() };

                    expenses.Add(expense);
                }
                return expenses;
            }
        }
    }
}
