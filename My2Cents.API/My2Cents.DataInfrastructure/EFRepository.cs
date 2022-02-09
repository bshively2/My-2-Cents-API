using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<UserProfileDto>> GetUserInfo(int UserId)
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

        public async Task<UserProfile> PutUserInfo(int UserId, UserProfile profile)
        {
            await _context.UserProfiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            var updateUserProfileInfo = await _context.UserProfiles
                .Where(u => u.UserId == UserId)
                .FirstOrDefaultAsync();

            return updateUserProfileInfo!;
        }

        public async Task<IEnumerable<AccountListDto>> GetUserAccounts(int userId)
        {

            return await (from ic in _context.Accounts
                          join io in _context.AccountTypes
                          on ic.AccountTypeId equals io.AccountTypeId
                          where ic.UserId == userId
                          select new AccountListDto
                          {
                              AccountID = ic.AccountId,
                              UserID = ic.UserId,
                              TotalBalance = ic.TotalBalance,
                              AccountType = io.AccountType1,
                              Interest = ic.Interest
                          }).ToListAsync();
        }
    }
}
