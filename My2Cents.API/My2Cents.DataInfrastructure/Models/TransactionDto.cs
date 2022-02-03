using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure.Models
{
  public class TransactionDto
  {
    public int TransactionId { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public string TransactionName { get; set; } = null!;
    public DateTime TransactionDate { get; set; }
    public string Authorized { get; set; } = null!;
    public decimal LineAmount { get; set; }
    public string? AccountType { get; set; }
    public decimal? TotalBalance { get; set; }
  }
}
