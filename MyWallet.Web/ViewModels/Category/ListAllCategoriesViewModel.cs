using System.Collections.Generic;

namespace MyWallet.Web.ViewModels.Category
{
    public class ListAllCategoriesViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }

        public ListAllCategoriesViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }
    }
}