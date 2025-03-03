﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure.Models
{
    public class AccountListDto
    {
        public int AccountID { get; set; }
        public decimal TotalBalance { get; set; }
        public string? AccountType { get; set; } = null!;
        public decimal Interest { get; set; }
    }
}
