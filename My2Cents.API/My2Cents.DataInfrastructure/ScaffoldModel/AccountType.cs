using System;
using System.Collections.Generic;

namespace My2Cents.DataInfrastructure
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public string AccountType1 { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
