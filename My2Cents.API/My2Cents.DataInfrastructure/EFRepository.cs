using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using My2Cents.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure
{
    public class EfRepository : IRepository
    {
        private readonly My2CentsContext _context;
        private readonly ILogger<EfRepository> _logger;

        public EfRepository(My2CentsContext context, ILogger<EfRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> PostTransactionsAsync(int from, int to, decimal amount)
        {
            
            var payFromAccount = _context.Accounts.SingleOrDefault(c => c.AccountId == from);
            var payToAccount = _context.Accounts.SingleOrDefault(b => b.AccountId == to);

            if (payFromAccount != null && payToAccount != null && payFromAccount.TotalBalance >= amount)
            {
                // Transfer Funds
                payFromAccount.TotalBalance -= amount;
                payToAccount.TotalBalance += amount;

                //Enter Records
                var PayFromRecord = new Transaction
                {
                    AccountId = from,
                    Amount = -amount,
                    TransactionName = $"To Account # {to}",
                    Authorized = "Authorized by Bank",
                    LineAmount = 12345
                };
                var PayToRecord = new Transaction
                {
                    AccountId = to,
                    Amount = amount,
                    TransactionName = $"From Account # {from}",
                    Authorized = "Authorized by Bank",
                    LineAmount = 12345
                };

                await _context.AddAsync(PayFromRecord);
                await _context.AddAsync(PayToRecord);
                return await _context.SaveChangesAsync();


            }
            else
            {
                return 0;
            }

        }


    }
}
