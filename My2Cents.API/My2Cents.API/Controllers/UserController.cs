using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("Info")]
        public async Task<ActionResult<IEnumerable<UserProfileDto>>> GetUserInfo([Required] int UserId)
        {
            var userProfileInfo = await _repository.GetUserInfo(UserId);

            if (userProfileInfo.Value == null)
            {
                return BadRequest();
            }
            else if (userProfileInfo.Value.Count() < 1)
            {
                return NoContent();
            }    

            return userProfileInfo;
        }

        [HttpPost("NewUser")]
        public async Task<UserProfile> PostNewUserInfo([FromBody, Required] UserProfileDto profile)
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

        [HttpPut("Update")]
        public async Task<UserProfile> PutUserInfo([FromBody, Required] UserProfileDto profile)
        {
            var updateUserProfileInfo = await _repository.PutUserInfo(profile);

            return updateUserProfileInfo;
        }
    }
}
