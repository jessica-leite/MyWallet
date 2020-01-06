using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Data.Domain
{
    public class CurrencyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
