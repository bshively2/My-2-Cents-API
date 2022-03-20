using Moq;
using My2Cents.API.Controllers;
using My2Cents.DatabaseManagement;
using My2Cents.DataInfrastructure.Models;
using System.Threading.Tasks;
using Xunit;

namespace My2Cents.Test
{
    public class TransactionTest
    {
        [Theory]
        [InlineData(-1, -1, -20)]
        public async Task InvalidBodyInPostTransactions(int from, int to, decimal amount)
        {
            // arrange
            Mock<IRepository> _repository = new();
            _repository.Setup(x => x.PostTransactionsAsync(from, to, amount)).ReturnsAsync(0);
            TransactionController transController = new(_repository.Object);
            Transfer_Dto transferbody = new(from, to, amount);

            // act
            var result = await transController.PostTransactionsAsync(transferbody);

            // assert
            Assert.Equal(0, result);
        }


        [Theory]
        [InlineData(2, 4, 300)]
        public async Task ValidBodyInPostTransactions(int from, int to, decimal amount)
        {
            // arrange
            Mock<IRepository> _repository = new();
            _repository.Setup(x => x.PostTransactionsAsync(from, to, amount)).ReturnsAsync(4);
            TransactionController transController = new(_repository.Object);
            Transfer_Dto transferbody = new(from, to, amount);

            // act
            var result = await transController.PostTransactionsAsync(transferbody);

            // assert
            Assert.Equal(4, result);
        }
    }
}