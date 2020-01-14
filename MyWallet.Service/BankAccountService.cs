using MyWallet.Data.Domain;
using MyWallet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Service
{
    public class BankAccountService
    {
        private BankAccountRepository _bankAccountRepository = new BankAccountRepository();

        public void Add(BankAccount bankAccount)
        {
            _bankAccountRepository.Add(bankAccount);
        }
    }
}
