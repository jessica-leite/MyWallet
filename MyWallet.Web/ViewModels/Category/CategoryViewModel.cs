using System.ComponentModel.DataAnnotations;

namespace MyWallet.Web.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}