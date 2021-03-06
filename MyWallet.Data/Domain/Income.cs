﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Data.Domain
{
    public class Income
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public bool Received { get; set; }
        public DateTime CreationDate { get; set; }
        public string Observation { get; set; }
        public int ContextId { get; set; }
        public Context Context { get; set; }
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
