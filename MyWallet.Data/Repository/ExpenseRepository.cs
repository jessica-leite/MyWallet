using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using MyWallet.Data.DTO;
using System.Globalization;

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

        public DashboardDTO GetAnnualExpensesByMonthAndContextIdAndCategory(int contextId, DashboardDTO dashboardDTO)
        {
            var expensesByYearAndCategory = _context.Expense
                    .Where(e => e.Date.Year == DateTime.Now.Year
                        && e.ContextId == contextId
                        && e.IsPaid)
                    .Include(c => c.Category)
                    .GroupBy(e => new
                    {
                        e.Date.Month,
                        Category = e.Category.Name
                    })
                    .Select(e => new
                    {
                        e.Key.Month,
                        e.Key.Category,
                        Value = e.Sum(expense => expense.Value)
                    })
                    .ToList();

            var format = new DateTimeFormatInfo();
            foreach (var expense in expensesByYearAndCategory)
            {
                var monthName = format.GetMonthName(expense.Month);

                if (dashboardDTO.AnnualExpensesByMonth.ContainsKey(monthName))
                {
                    dashboardDTO.AnnualExpensesByMonth[monthName] += expense.Value;
                }
                else
                {
                    dashboardDTO.AnnualExpensesByMonth.Add(monthName, expense.Value);
                }

                if (expense.Month == DateTime.Now.Month)
                {
                    if (dashboardDTO.MontlhyExpensesByCategory.ContainsKey(expense.Category))
                    {
                        dashboardDTO.MontlhyExpensesByCategory[expense.Category] += expense.Value;
                    }
                    else
                    {
                        dashboardDTO.MontlhyExpensesByCategory.Add(expense.Category, expense.Value);
                    }

                    dashboardDTO.TotalCurrentMonthExpenses += expense.Value;
                }
            }

            var top5Categories = dashboardDTO.MontlhyExpensesByCategory
                                        .OrderByDescending(e => e.Value)
                                        .Take(5);

            dashboardDTO.MontlhyExpensesByCategory = top5Categories.ToDictionary(e => e.Key, e => e.Value);

            return dashboardDTO;
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
