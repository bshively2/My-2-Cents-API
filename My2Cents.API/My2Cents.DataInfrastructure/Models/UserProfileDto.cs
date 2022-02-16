
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure.Models
{
    public class UserProfileDto
    {
        public int UserId { get; set; }
        [StringLength(30, ErrorMessage = "First name length can't be more than {1} and less than {2}.", MinimumLength = 1)]
        public string FirstName { get; set; } = null!;
        [StringLength(30, ErrorMessage = "Last name length can't be more than {1} and less than {2}.", MinimumLength = 1)]
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string? SecondaryEmail { get; set; }
        [StringLength(46, ErrorMessage = "Mailing address length can't be more than {1} and less than {2}.", MinimumLength = 3)]
        public string MailingAddress { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = null!;
        [StringLength(40, ErrorMessage = "City length can't be more than {1} and less than {2}.", MinimumLength = 2)]
        public string City { get; set; } = null!;
        [StringLength(40, ErrorMessage = "State length can't be more than {1} and less than {2}.", MinimumLength = 2)]
        public string State { get; set; } = null!;
        [StringLength(150, ErrorMessage = "Employer length can't be more than {1} and less than {2}.", MinimumLength = 2)]
        public string Employer { get; set; } = null!;
        [StringLength(46, ErrorMessage = "Work address length can't be more than {1} and less than {2}.", MinimumLength = 3)]
        public string WorkAddress { get; set; } = null!;
        [Phone]
        public string WorkPhone { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
