using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWallet.Web.ViewModels.BankAccount
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Opening Balance")]
        public decimal? OpeningBalance { get; set; }
    }
}