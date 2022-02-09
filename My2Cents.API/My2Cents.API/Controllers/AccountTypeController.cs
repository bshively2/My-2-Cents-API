using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;

namespace My2Cents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IRepository _repository;

        public AccountTypeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Accounts")]
        public async Task<IEnumerable<AccountListDto>> GetUserAccounts(int UserId)
        {
            var userAccountList = await _repository.GetUserAccounts(UserId);

            return userAccountList;
        }
    }
}
