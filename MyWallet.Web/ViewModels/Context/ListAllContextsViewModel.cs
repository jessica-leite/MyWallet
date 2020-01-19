using System.Collections.Generic;

namespace MyWallet.Web.ViewModels.Context
{
    public class ListAllContextsViewModel
    {
        public List<ContextViewModel> Contexts { get; set; }

        public ListAllContextsViewModel()
        {
            Contexts = new List<ContextViewModel>();
        }
    }
}