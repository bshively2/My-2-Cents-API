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

        public async Task<ActionResult<IEnumerable<UserProfileDto>>> GetUserInfo(int UserId)
        {
            return await (from ic in _context.UserProfiles
                          where ic.UserId == UserId
                          select new UserProfileDto
                          {
                              UserId = UserId,
                              FirstName = ic.FirstName,
                              LastName = ic.LastName,
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

        public async Task<UserProfile> PutUserInfo(UserProfileDto profile)
        {
            UserProfile userProfile = new()
            {
                UserId = profile.UserId,
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
                .Where(u => u.UserId == profile.UserId)
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
    }
}
