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

        public async Task<IEnumerable<UserProfile_Dto>> GetUserInfo(int UserId)
        {
            _logger.LogInformation($"GetUserInfo {UserId}", UserId);

            return await (from ex in _context.UserProfiles
                          where ex.UserId == UserId
                          select new UserProfile_Dto
                          {
                              UserID = ex.UserId,
                              FirstName = ex.FirstName,
                              LastName = ex.LastName,
                              Email = ex.Email,
                              SecondaryEmail = ex.SecondaryEmail,
                              MailingAddress = ex.MailingAddress,
                              Phone = (decimal)ex.Phone,
                              City = ex.City,
                              State = ex.State,
                              Employer = ex.Employer,
                              WorkAddress = ex.WorkAddress,
                              WorkPhone = (decimal)ex.WorkPhone
                          }).ToListAsync();
        }
    }
}
