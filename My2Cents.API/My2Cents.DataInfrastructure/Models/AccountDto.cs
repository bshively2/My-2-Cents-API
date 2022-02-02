using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure.Models
{
  internal class AccountDto
  {
    public int AccountId { get; set; }
    public int? UserId { get; set; }
    public decimal? TotalBalance { get; set; }
    public string? AccountType { get; set; }
    public decimal? Interest { get; set; }
  }
}
