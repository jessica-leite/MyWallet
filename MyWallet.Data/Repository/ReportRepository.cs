using MyWallet.Data.DTO.Report;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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


    }
}
