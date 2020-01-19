namespace MyWallet.Data.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContextId { get; set; }
        public Context Context { get; set; }
    }
}
