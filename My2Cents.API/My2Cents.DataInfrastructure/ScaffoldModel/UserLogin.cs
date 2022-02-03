using System;
using System.Collections.Generic;

namespace My2Cents.DataInfrastructure
{
    public partial class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual UserProfile UserProfile { get; set; } = null!;
    }
}
