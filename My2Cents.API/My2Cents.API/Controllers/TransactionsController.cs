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


    [HttpGet("{userId}")]
    public async Task<IEnumerable<TransactionDto>> GetTransactions(int userId)
    {

      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      return await _repository.GetTransactions(userId);

    }

  }
}
