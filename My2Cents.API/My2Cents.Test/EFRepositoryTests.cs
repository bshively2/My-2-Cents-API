using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;

namespace My2Cents.Test
{
    public class EFRepositoryTests
    {
        Mock<IRepository> _repositoryMock = new();


        [Fact]
        public async Task GetTransactions_ShouldReturnTransaction_WhenItExists()
        {

            //Arrange
            var accountId = 2;

            var transactionDto = new List<TransactionDto>();
            transactionDto.Add(new(1, accountId, 306, "Bagels", DateTime.Now, "Yes", 306, "Checking", 10010));


            _repositoryMock.Setup(x => x.GetTransactions(accountId)).Returns(Task.FromResult((IEnumerable<TransactionDto>)transactionDto));

            //Act
            var actual = await _repositoryMock.Object.GetTransactions(accountId);
            var expected = transactionDto;

            //Assert
            Assert.Equal(expected, actual);


        }
    }
}