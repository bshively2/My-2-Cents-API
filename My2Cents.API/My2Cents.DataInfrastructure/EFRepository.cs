using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace My2Cents.DataInfrastructure
{
    public class EfRepository : IRepository
    {
        private readonly string _connectionString;

        public EfRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private readonly My2CentsContext _context;
        private readonly ILogger<EfRepository> _logger;

        public EfRepository(My2CentsContext context, ILogger<EfRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> GetUserInfo(int UserId)
        {
            _logger.LogInformation($"GetUserInfo {UserId}", UserId);

            var userProfileInfo = await _context.UserProfiles
                .Where(u => u.UserId == UserId)
                .Include(l => l.User)
                .FirstOrDefaultAsync();

            if (userProfileInfo == null)
            {
                return NotFound();
            }

            return userProfileInfo;

            //return await (from ex in _context.UserProfiles
            //              where ex.UserId == UserId
            //              select new UserProfile_Dto
            //              {
            //                  UserID = ex.UserId,
            //                  FirstName = ex.FirstName,
            //                  LastName = ex.LastName,
            //                  SecondaryEmail = ex.SecondaryEmail,
            //                  MailingAddress = ex.MailingAddress,
            //                  Phone = ex.Phone,
            //                  City = ex.City,
            //                  State = ex.State,
            //                  Employer = ex.Employer,
            //                  WorkAddress = ex.WorkAddress,
            //                  WorkPhone = ex.WorkPhone
            //              }).ToListAsync();
        }
    }
}
