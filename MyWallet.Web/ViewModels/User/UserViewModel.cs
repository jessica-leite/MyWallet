using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MyWallet.Web.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Repeat Password")]
        [Required(ErrorMessage = "Repeat password is required")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        [Display(Name = "Photo")]
        public HttpPostedFileBase Photo { get; set; }
    }
}