using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;

namespace My2Cents.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TransactionsController : ControllerBase
  {

    private readonly IRepository _repository;


    public TransactionsController(IRepository repository)
    {
      _repository = repository;
    }


    [HttpGet("{AccountId}")]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions(int AccountId)
    {
      var Account=await _repository.GetTransactions(AccountId);
      if (Account.Count() == 0)
        {
            return BadRequest("Account not found.");
        }
      return Ok(Account);
    }
  }
}
