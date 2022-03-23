using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My2Cents.DatabaseManagement;
using My2Cents.DataInfrastructure.Models;

namespace My2Cents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository _repository;

        public TransactionController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<int> PostTransactionsAsync([FromBody] Transfer_Dto Record)
        {
            return await _repository.PostTransactionsAsync(Record.From, Record.To, Record.Amount);
        }
    }
}