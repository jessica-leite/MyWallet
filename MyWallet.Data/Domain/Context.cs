namespace MyWallet.Data.Domain
{
    public class Context
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CurrencyTypeId { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public bool IsMainContext { get; set; }

        public bool IsNew()
        {
            return Id == 0;
        }
    }
}
