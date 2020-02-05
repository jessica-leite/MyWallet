namespace MyWallet.Data.Repository
{
    public abstract class BaseRepository
    {
        protected MyWalletDBContext Context { get; set; }

        public BaseRepository()
        {
            Context = new MyWalletDBContext();
        }

        public string GetConnectionString
        {
            get
            {
                return Context.Database.Connection.ConnectionString;
            }
        }
    }
}
