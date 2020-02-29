using System;
using System.Collections.Generic;

namespace MyWallet.Data.DTO.Report
{
    public class ReportFilterDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CategoryId { get; set; }
        public int? BankAccountId { get; set; }
        public decimal? StartValue { get; set; }
        public decimal? EndValue { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public int? Situation { get; set; }
        public int ContextId { get; set; }
    }
}
