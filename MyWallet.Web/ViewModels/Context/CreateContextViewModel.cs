using MyWallet.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWallet.Web.ViewModels.Context
{
    public class CreateContextViewModel
    {
        public string Name { get; set; }
        public int CurrencyTypeId { get; set; }
        public SelectList CurrencyTypeSelectList { get; set; }
        public int CountryId { get; set; }
        public SelectList CountrySelectList { get; set; }
        public int UserId { get; set; }
    }
}