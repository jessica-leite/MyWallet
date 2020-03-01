using MyWallet.Data.Domain;
using MyWallet.Data.DTO.Report;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace MyWallet.Data.Repository
{
    public class ReportRepository
    {
        private MyWalletDBContext _context;

        public ReportRepository(MyWalletDBContext context)
        {
            _context = context;
        }

        public IEnumerable<EntryDTO> GetByFilter(ReportFilterDTO filter)
        {
            if (filter.Type == 1)
            {
                return GetExpenseByFilter(filter);
            }

            return GetIncomeByFilter(filter);
        }

        public IEnumerable<EntryDTO> GetExpenseByFilter(ReportFilterDTO filter)
        {
            using (var connection = new SqlConnection(_context.Database.Connection.ConnectionString))
            {
                connection.Open();

                var sqlText = @"SELECT 
                                	 e.Id, 
                                     e.Date, 
                                     e.Description, 
                                     c.Name AS Category, 
                                     b.Name AS BankAccount, 
                                     e.Value, 
                                     e.IsPaid
                                 FROM 
                                	 Expense e
                                 INNER JOIN Category c
                                    ON c.Id = e.CategoryId
                                 INNER JOIN BankAccount b
                                    ON b.Id = e.BankAccountId
                                 WHERE 
                                	 e.ContextId = @ContextId";

                var command = new SqlCommand();
                command.Parameters.AddWithValue("ContextId", filter.ContextId);

                if (filter.StartDate.HasValue)
                {
                    sqlText += " AND e.Date >= @StartDate";
                    command.Parameters.AddWithValue("StartDate", filter.StartDate);
                }
                if (filter.EndDate.HasValue)
                {
                    sqlText += " AND e.Date <= @EndDate";
                    command.Parameters.AddWithValue("EndDate", filter.EndDate);
                }
                if (filter.CategoriesId != null)
                {
                    sqlText += $" AND e.CategoryId IN ({string.Join(",", filter.CategoriesId)})";
                }
                if (filter.BankAccountsId != null)
                {
                    sqlText += $" AND e.BankAccountId IN({string.Join(",", filter.BankAccountsId)})";
                }
                if (filter.StartValue.HasValue)
                {
                    sqlText += " AND e.Value >= @StartValue";
                    command.Parameters.AddWithValue("StartValue", filter.StartValue);
                }
                if (filter.EndValue.HasValue)
                {
                    sqlText += " AND e.Value <= @EndValue";
                    command.Parameters.AddWithValue("EndValue", filter.EndValue);
                }
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    sqlText += " AND e.Description LIKE @Description";
                    command.Parameters.AddWithValue("Description", $"%{filter.Description}%");
                }
                if (filter.Situation.HasValue)
                {
                    sqlText += " AND e.IsPaid = @Situation";
                    command.Parameters.AddWithValue("Situation", filter.Situation);
                }

                command.CommandText = sqlText;
                command.Connection = connection;

                var result = command.ExecuteReader();

                var entries = new List<EntryDTO>();
                while (result.Read())
                {
                    var entry = new EntryDTO();
                    entry.Date = (DateTime)result["Date"];
                    entry.Description = result["Description"].ToString();
                    entry.Category = result["Category"].ToString();
                    entry.BankAccount = result["BankAccount"].ToString();
                    entry.Value = (decimal)result["Value"];
                    entry.IsPaid = (bool)result["IsPaid"];

                    entries.Add(entry);
                }

                return entries;
            }
        }

        public IEnumerable<EntryDTO> GetIncomeByFilter(ReportFilterDTO filter)
        {
            IQueryable<Income> query = _context
                .Income
                .Include(i => i.BankAccount)
                .Include(i => i.Category)
                .Where(i => i.ContextId == filter.ContextId);


            if (filter.StartDate.HasValue)
            {
                query = query.Where(i => i.Date >= filter.StartDate);
            }
            if (filter.EndDate.HasValue)
            {
                query = query.Where(i => i.Date <= filter.EndDate);
            }
            if (filter.CategoriesId != null)
            {
                query = query.Where(i => filter.CategoriesId.Contains(i.CategoryId));
            }
            if (filter.BankAccountsId != null)
            {
                query = query.Where(i => filter.BankAccountsId.Contains(i.BankAccountId));
            }
            if (filter.StartValue.HasValue)
            {
                query = query.Where(i => i.Value >= filter.StartValue);
            }
            if (filter.EndValue.HasValue)
            {
                query = query.Where(i => i.Value <= filter.EndValue);
            }
            if (!string.IsNullOrEmpty(filter.Description))
            {
                query = query.Where(i => i.Description.Contains(filter.Description));
            }
            if (filter.Situation.HasValue)
            {
                query = query.Where(i => i.Received == filter.Situation);
            }

            var querySQL = query.ToString();

            return query.Select(i => new EntryDTO
            {
                BankAccount = i.BankAccount.Name,
                Category = i.Category.Name,
                Date = i.Date,
                Description = i.Description,
                IsPaid = i.Received,
                Value = i.Value
            })
            .ToList();
        }
    }
}
