using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure;

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
        public async Task<ActionResult<UserProfile>> GetUserInfo(int UserId)
        {

            var userProfileInfo = await _repository.GetUserInfo(UserId);

            if (userProfileInfo == null)
            {
                return NoContent();
            }    

            return userProfileInfo;
        }
    }
}
