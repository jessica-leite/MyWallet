using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MyWallet.Web.ViewModels.Import
{
    public class ImportViewModel
    {
        [Display(Name = "File")]
        public HttpPostedFileBase File { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public decimal Value { get; set; }
        public bool IsPaid { get; set; }
        public string Observation { get; set; }
    }
}