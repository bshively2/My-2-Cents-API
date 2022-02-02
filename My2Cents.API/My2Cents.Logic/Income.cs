using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.Logic
{
    internal class Income
    {
        public string? name { get; set; }
        public int? account { get; set; }
        public decimal? amount { get; set; }

        public Income(string name, int account, decimal amount)
        {
            this.name = name;
            this.account = account;
            this.amount = amount;
        }
    }
}
