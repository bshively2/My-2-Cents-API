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

        public async Task<ActionResult<UserProfile>> GetUserInfo(int UserId)
        {
            _logger.LogInformation($"GetUserInfo {UserId}", UserId);


            var userProfileInfo = await _context.UserProfiles
                .Include(l => l.User)
                .Where(u => u.UserId == UserId)
                .FirstOrDefaultAsync();

            return userProfileInfo!;

        }
    }
}
