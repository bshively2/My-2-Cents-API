using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public async Task<UserProfile> GetUserInfo(int UserId)
        {
            _logger.LogInformation($"GetUserInfo {UserId}", UserId);


            var userProfileInfo = await _context.UserProfiles
                .Include(l => l.User)
                .Where(u => u.UserId == UserId)
                .FirstOrDefaultAsync();

            return userProfileInfo!;
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
    }
}
