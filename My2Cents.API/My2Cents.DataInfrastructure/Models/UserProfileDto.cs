
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure.Models
{
    public class UserProfileDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? SecondaryEmail { get; set; }
        public string MailingAddress { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Employer { get; set; } = null!;
        public string WorkAddress { get; set; } = null!;
        public string WorkPhone { get; set; } = null!;
    }
}
