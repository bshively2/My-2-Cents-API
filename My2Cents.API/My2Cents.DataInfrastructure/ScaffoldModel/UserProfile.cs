using System;
using System.Collections.Generic;

namespace My2Cents.DataInfrastructure
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Accounts = new HashSet<Account>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? SecondaryEmail { get; set; }
        public string? MailingAddress { get; set; }
        public double? Phone { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Employer { get; set; }
        public string? WorkAddress { get; set; }
        public double? WorkPhone { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
