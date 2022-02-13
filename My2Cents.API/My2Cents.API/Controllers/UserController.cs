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
        public async Task<int> PostNewUserInfo([FromBody, Required] UserProfileDto profile)
        {
            
            return await _repository.PostNewUserInfo(
                profile.UserId,
                profile.FirstName,
                profile.LastName,
                profile.SecondaryEmail,
                profile.MailingAddress,
                profile.Phone,
                profile.City,
                profile.State,
                profile.Employer,
                profile.WorkAddress,
                profile.WorkPhone
                );
        }

        [HttpPut("Update")]
        public async Task<int> PutUserInfo([FromBody, Required] UserProfileDto profile)
        {
            return await _repository.PutUserInfo(
                profile.UserId,
                profile.FirstName,
                profile.LastName,
                profile.SecondaryEmail,
                profile.MailingAddress,
                profile.Phone,
                profile.City,
                profile.State,
                profile.Employer,
                profile.WorkAddress,
                profile.WorkPhone
                );
        }
    }
}
