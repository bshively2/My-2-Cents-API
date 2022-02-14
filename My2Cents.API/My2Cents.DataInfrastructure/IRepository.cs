
﻿using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2Cents.DataInfrastructure
{
    public interface IRepository
    {

        Task<ActionResult<IEnumerable<UserProfileDto>>> GetUserInfo(int userId);
        Task<int> PostNewUserInfo(int UserId,
            string FirstName,
            string LastName,
            string SecondaryEmail,
            string MailingAddress,
            string Phone,
            string City,
            string State,
            string Employer,
            string WorkAddress,
            string WorkPhone
            );
        Task<int> PutUserInfo(
            int UserId,
            string FirstName,
            string LastName,
            string SecondaryEmail,
            string MailingAddress,
            string Phone,
            string City,
            string State,
            string Employer,
            string WorkAddress,
            string WorkPhone
            );
        Task<ActionResult<IEnumerable<AccountListDto>>> GetUserAccounts(int userId);
        Task<IEnumerable<TransactionDto>> GetTransactions(int AccountId);
        Task<int> PostUserAccount(int userId, decimal totalBalance, int accountTypeId, decimal interest);
        Task<int> PostTransactionsAsync(int from, int to, decimal amount);
    }


    
  

}
