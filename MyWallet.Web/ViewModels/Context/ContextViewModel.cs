using MyWallet.Web.ViewModels.User;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyWallet.Web.ViewModels.Context
{
    public class ContextViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int CurrencyTypeId { get; set; }
        public CurrencyTypeViewModel CurrencyType { get; set; }
        public int CountryId { get; set; }
        public CountryViewModel Country { get; set; }
        public bool IsMainContext { get; set; }

        public SelectList CurrencyTypeSelectList { get; set; }
        public SelectList CountrySelectList { get; set; }
    }
}