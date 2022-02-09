using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;

namespace My2Cents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [Route("Info")]
        [HttpGet]
        public async Task<UserProfile> GetUserInfo(int UserId)
        {
            var userProfileInfo = await _repository.GetUserInfo(UserId);

            return userProfileInfo;
        }

        [HttpPost("Info")]
        public async Task<UserProfile> PostNewUserInfo(UserProfileDto profile)
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
            var newUserProfileInfo = await _repository.PostNewUserInfo(userProfile);

            return newUserProfileInfo;
        }
    }
}
