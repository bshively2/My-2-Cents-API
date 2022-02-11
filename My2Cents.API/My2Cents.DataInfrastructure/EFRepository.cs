
﻿using Microsoft.AspNetCore.Mvc;

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


        private readonly My2CentsContext _context;
        private readonly ILogger<EfRepository> _logger;

        public EfRepository(My2CentsContext context, ILogger<EfRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // ----------------------- Transaction btw accounts ------------------------
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

        // ----------------------- Get User Info ------------------------

        public async Task<ActionResult<IEnumerable<UserProfileDto>>> GetUserInfo(int UserId)
        {
            return await (from io in _context.UserLogins
                          join ic in _context.UserProfiles
                          on io.UserId equals ic.UserId
                          where ic.UserId == UserId
                          select new UserProfileDto
                          {
                              UserId = ic.UserId,
                              FirstName = ic.FirstName,
                              LastName = ic.LastName,
                              Email = io.Email,
                              SecondaryEmail = ic.SecondaryEmail,
                              MailingAddress = ic.MailingAddress,
                              Phone = ic.Phone,
                              City = ic.City,
                              State = ic.State,
                              Employer = ic.Employer,
                              WorkAddress = ic.WorkAddress,
                              WorkPhone = ic.WorkPhone
                          }).ToListAsync();
        }

        public async Task<UserProfile> PostNewUserInfo(UserProfile profile)
        {
            await _context.UserProfiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            var newUserProfileInfo = await _context.UserProfiles
                .Where(u => u.UserId == profile.UserId)
                .FirstOrDefaultAsync();

            return newUserProfileInfo!;
        }

        public async Task<UserProfile> PutUserInfo(int UserId, UserProfileDto profile)
        {
            UserProfile userProfile = new()
            {
                UserId = UserId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                SecondaryEmail = profile.SecondaryEmail,
                MailingAddress = profile.MailingAddress,
                Phone = profile.Phone,
                City = profile.City,
                State = profile.State,
                Employer = profile.Employer,
                WorkAddress = profile.WorkAddress,
                WorkPhone = profile.WorkPhone
            };

            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();

            var updateUserProfileInfo = await _context.UserProfiles
                .Where(u => u.UserId == UserId)
                .FirstOrDefaultAsync();

            return updateUserProfileInfo!;
        }

        public async Task<ActionResult<IEnumerable<AccountListDto>>> GetUserAccounts(int userId)
        {

            return await (from ic in _context.Accounts
                          join io in _context.AccountTypes
                          on ic.AccountTypeId equals io.AccountTypeId
                          where ic.UserId == userId
                          select new AccountListDto
                          {
                              AccountID = ic.AccountId,
                              TotalBalance = ic.TotalBalance,
                              AccountType = io.AccountType1,
                              Interest = ic.Interest
                          }).ToListAsync();
        }

      private readonly string _connectionString;


    private readonly My2CentsContext _context;
    private readonly ILogger<EfRepository> _logger;

    public EfRepository(My2CentsContext context, ILogger<EfRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<IEnumerable<TransactionDto>> GetTransactions(int AccountId)
    {

      return await (from ac in _context.Accounts
                    join tr in _context.Transactions on ac.AccountId equals tr.AccountId into trjoin
                    from tran in trjoin.DefaultIfEmpty()                    
                    join at in _context.AccountTypes on ac.AccountTypeId equals at.AccountTypeId
                    where tran.AccountId == AccountId
                    orderby tran.TransactionDate descending
                    select new TransactionDto
                    {
                      TransactionId = tran.TransactionId,
                      AccountId = tran.AccountId,
                      Amount = tran.Amount,
                      TransactionName = tran.TransactionName,
                      TransactionDate = tran.TransactionDate,
                      Authorized = tran.Authorized,
                      LineAmount=tran.LineAmount,
                      AccountType=at.AccountType1,
                      TotalBalance= ac.TotalBalance
                    }).ToListAsync();


    


    _logger.LogInformation("function GetTransaction Account Id {int AccountId}", AccountId);
    }



    public EfRepository(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

    }
  }
}
