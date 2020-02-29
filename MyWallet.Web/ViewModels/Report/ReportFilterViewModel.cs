using MyWallet.Data.DTO.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace MyWallet.Web.ViewModels.Report
{
    public class ReportFilterViewModel
    {
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Category")]
        public int? CategoryId { get; set; }

        [DisplayName("Bank Account")]
        public int? BankAccountId { get; set; }

        [DisplayName("Start Value")]
        public decimal? StartValue { get; set; }

        [DisplayName("End Value")]
        public decimal? EndValue { get; set; }

        [DisplayName("Type")]
        public int? Type { get; set; }

        [DisplayName("Situation")]
        public int? Situation { get; set; }
        public string Description { get; set; }
        public string CurrencySymbol { get; set; }

        public List<SelectListItem> SelectListType { get; set; }
        public List<SelectListItem> SelectListSituation { get; set; }
        public List<SelectListItem> SelectListBankAccount { get; set; }
        public List<SelectListItem> SelectListCategory { get; set; }
        public IEnumerable<EntryDTO> Entries { get; set; }

        public ReportFilterViewModel()
        {
            SelectListType = new List<SelectListItem>();
            SelectListSituation = new List<SelectListItem>();
            SelectListBankAccount = new List<SelectListItem>();
            SelectListCategory = new List<SelectListItem>();
            Entries = new List<EntryDTO>();
        }
    }
}