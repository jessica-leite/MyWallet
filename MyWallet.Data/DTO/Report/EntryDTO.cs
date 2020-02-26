using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Data.DTO.Report
{
    public class EntryDTO
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string BankAccount { get; set; }
        public string Value { get; set; }
        public bool IsPaid { get; set; }
    }
}
