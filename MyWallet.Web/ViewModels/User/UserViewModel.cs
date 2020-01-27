using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MyWallet.Web.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Repeat Password")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        [Display(Name = "Photo")]
        public HttpPostedFileBase Photo { get; set; }
    }
}