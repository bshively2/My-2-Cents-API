using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure.Models
{
  internal class TransactionDto
  {
    public int TransactionId { get; set; }
    public int? AccountId { get; set; }
    public decimal? Amount { get; set; }
    public string? TransactionName { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? Authorized { get; set; }

    public string? AccountType { get; set; }
    public decimal? TotalBalance { get; set; }
  }
}
