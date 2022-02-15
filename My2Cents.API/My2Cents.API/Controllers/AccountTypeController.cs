using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult<IEnumerable<AccountListDto>>> GetUserAccounts([Required] int UserId)
        {
            var userAccountList = await _repository.GetUserAccounts(UserId);

            if (userAccountList.Value == null)
            {
                return BadRequest();
            }
            else if (userAccountList.Value.Count() < 1)
            {
                return NoContent();
            }

            return userAccountList;
        }

        [HttpGet("AccountsTypes")]
        public async Task<ActionResult<IEnumerable<AccountTypeDto>>> GetAccountTypes()
        {
            var accountTypes = await _repository.GetAccountTypes();

            if (accountTypes.Value == null)
            {
                return BadRequest();
            }
            else if (accountTypes.Value.Count() < 1)
            {
                return NoContent();
            }

            return accountTypes;
        }

        [HttpPost("NewAccount")]
        public async Task<int> PostUserAccount([FromBody, Required] AccountDto newAccount)
        {
            return await _repository.PostUserAccount(
                newAccount.UserId,
                newAccount.TotalBalance,
                newAccount.AccountTypeId,
                newAccount.Interest
                );
        }
    }
}
