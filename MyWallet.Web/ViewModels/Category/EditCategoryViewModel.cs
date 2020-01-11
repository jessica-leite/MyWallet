using System.ComponentModel.DataAnnotations;

namespace MyWallet.Web.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public int UserId { get; set; }
    }
}