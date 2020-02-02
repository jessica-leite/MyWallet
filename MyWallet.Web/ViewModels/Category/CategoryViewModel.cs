using MyWallet.Web.ViewModels.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWallet.Web.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContextId { get; set; }
        public ContextViewModel Context { get; set; }
    }
}