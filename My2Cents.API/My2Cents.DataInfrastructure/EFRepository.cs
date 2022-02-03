using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using My2Cents.DataInfrastructure.Models;

namespace My2Cents.DataInfrastructure
{
    public class EfRepository : IRepository
    {
  //      private readonly string _connectionString;


    private readonly My2CentsContext _context;
    private readonly ILogger<EfRepository> _logger;

    public EfRepository(My2CentsContext context, ILogger<EfRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<IEnumerable<TransactionDto>> GetTransactions(int userId)
    {

      return await (from tr in _context.Transactions
                    join ac in _context.Accounts on tr.AccountId equals ac.AccountId
                    join at in _context.AccountTypes on ac.AccountTypeId equals at.AccountTypeId
                    where ac.UserId == userId
                    select new TransactionDto
                    {
                      TransactionId = tr.TransactionId,
                      AccountId = tr.AccountId,
                      Amount = tr.Amount,
                      TransactionName = tr.TransactionName,
                      TransactionDate = tr.TransactionDate,
                      Authorized = tr.Authorized,
                      LineAmount=tr.LineAmount,
                      AccountType=at.AccountType1,
                      TotalBalance=ac.TotalBalance
                    }).ToListAsync();


    //  public int TransactionId { get; set; }
    //public int AccountId { get; set; }
    //public decimal Amount { get; set; }
    //public string TransactionName { get; set; } = null!;
    //public DateTime TransactionDate { get; set; }
    //public string Authorized { get; set; } = null!;
    //public decimal LineAmount { get; set; }
    //public string? AccountType { get; set; }
    //public decimal? TotalBalance { get; set; }


    _logger.LogInformation("function GetIncome user id {userId}", userId);
    }



    //public EfRepository(string connectionString)
    //    {
    //        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    //    }
  }
}
