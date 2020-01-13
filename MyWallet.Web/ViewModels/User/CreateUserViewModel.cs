namespace MyWallet.Web.ViewModels.User
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }

        //For the Main Context
        public int ContextId { get; set; }
        public string ContextName { get; set; }
        public int CountryId { get; set; }
        public int CurrencyTypeId { get; set; }
    }
}