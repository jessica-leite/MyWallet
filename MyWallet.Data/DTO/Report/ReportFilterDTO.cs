using System;

namespace MyWallet.Data.DTO.Report
{
    public class ReportFilterDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int[] CategoriesId { get; set; }
        public int[] BankAccountsId { get; set; }
        public decimal? StartValue { get; set; }
        public decimal? EndValue { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public bool? Situation { get; set; }
        public int ContextId { get; set; }
    }
}
