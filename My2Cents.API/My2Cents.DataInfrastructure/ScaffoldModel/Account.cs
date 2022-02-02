using System;
using System.Collections.Generic;

namespace My2Cents.DataInfrastructure
{
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int AccountId { get; set; }
        public int? UserId { get; set; }
        public decimal? TotalBalance { get; set; }
        public string? AccountType { get; set; }
        public decimal? Interest { get; set; }

        public virtual UserProfile? User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
