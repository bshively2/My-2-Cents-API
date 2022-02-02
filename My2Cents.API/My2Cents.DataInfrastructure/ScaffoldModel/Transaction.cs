using System;
using System.Collections.Generic;

namespace My2Cents.DataInfrastructure
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? AccountId { get; set; }
        public decimal? Amount { get; set; }
        public string? TransactionName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? Authorized { get; set; }

        public virtual Account? Account { get; set; }
    }
}
