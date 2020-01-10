using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWallet.Web.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}