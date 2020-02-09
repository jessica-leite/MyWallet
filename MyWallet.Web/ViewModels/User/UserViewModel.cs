using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MyWallet.Web.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Repeat Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }

        [Display(Name = "Photo")]
        public HttpPostedFileBase Photo { get; set; }
    }
}