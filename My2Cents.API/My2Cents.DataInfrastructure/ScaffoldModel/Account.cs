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
        public int UserId { get; set; }
        public decimal TotalBalance { get; set; }
        public int AccountTypeId { get; set; }
        public decimal Interest { get; set; }

        public virtual AccountType AccountType { get; set; } = null!;
        public virtual UserProfile User { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
