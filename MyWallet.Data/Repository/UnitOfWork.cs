using System;

namespace MyWallet.Data.Repository
{
    public class UnitOfWork : IDisposable
    {
        private MyWalletDBContext _context;

        public UnitOfWork()
        {
            _context = new MyWalletDBContext();
        }

        private BankAccountRepository _bankAccountRepository;
        private CategoryRepository _categoryRepository;
        private ContextRepository _contextRepository;
        private CountryRepository _countryRepository;
        private CurrencyTypeRepository _currencyTypeRepository;
        private ExpenseRepository _expenseRepository;
        private IncomeRepository _incomeRepository;
        private UserRepository _userRepository;
        private ReportRepository _reportRepository;
        private bool _disposed;

        public BankAccountRepository BankAccountRepository => _bankAccountRepository ?? new BankAccountRepository(_context);
        public CategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);
        public ContextRepository ContextRepository => _contextRepository ?? new ContextRepository(_context);
        public CountryRepository CountryRepository => _countryRepository ?? new CountryRepository(_context);
        public CurrencyTypeRepository CurrencyTypeRepository => _currencyTypeRepository ?? new CurrencyTypeRepository(_context);
        public ExpenseRepository ExpenseRepository => _expenseRepository ?? new ExpenseRepository(_context);
        public IncomeRepository IncomeRepository => _incomeRepository ?? new IncomeRepository(_context);
        public UserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public ReportRepository ReportRepository => _reportRepository ?? new ReportRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }
    }
}
