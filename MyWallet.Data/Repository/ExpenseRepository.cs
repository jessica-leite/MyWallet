using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MyWallet.Data.Repository
{
    public class ExpenseRepository : BaseRepository
    {
        public void Add(Expense expense)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Expense.Add(expense);
                context.SaveChanges();
            }
        }

        public void Add(IEnumerable<Expense> expenses)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Expense.AddRange(expenses);
                context.SaveChanges();
            }
        }

        public void Update(Expense expense)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Entry(expense).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Expense expense)
        {
            using (var context = new MyWalletDBContext())
            {
                context.Entry(expense).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Expense GetById(int id)
        {
            using (var context = new MyWalletDBContext())
            {
                return context.Expense.Find(id);
            }
        }

        public IEnumerable<Expense> GetAllByContextId(int contextId)
        {
            using (var connection = new SqlConnection(GetConnectionString))
            {
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

                connection.Open();

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
