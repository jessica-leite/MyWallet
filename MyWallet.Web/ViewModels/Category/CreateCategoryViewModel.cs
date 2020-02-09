namespace MyWallet.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryViewModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }

            public int ContextId { get; set; }
        }
}