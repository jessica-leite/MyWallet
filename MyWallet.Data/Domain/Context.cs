namespace MyWallet.Data.Domain
{
    public class Context
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int CountryId { get; set; }
    }
}
