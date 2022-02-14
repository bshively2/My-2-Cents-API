using Moq;
using My2Cents.API.Controllers;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace My2Cents.Test
{
    public class UserAccountsTests
    {
        [Theory]
        [InlineData(1, 1000, 1, 5)]
        public async Task ValidUserAccountPost(
            int userId,
            decimal totalBalance,
            int accountTypeId,
            decimal interest)
        {
            // arrange
            AccountDto accountDto = new()
            {
                UserId = userId,
                TotalBalance = totalBalance,
                AccountTypeId = accountTypeId,
                Interest = interest
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.PostUserAccount(
                userId,
                totalBalance,
                accountTypeId,
                interest)).ReturnsAsync(4);
            AccountTypeController accountTypeController = new(_repository.Object);

            // act
            var result = await accountTypeController.PostUserAccount(accountDto);

            // assert
            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1, -1, 1, 5)]
        public async Task InvalidUserAccountPost(
            int userId,
            decimal totalBalance,
            int accountTypeId,
            decimal interest)
        {
            // arrange
            AccountDto accountDto = new()
            {
                UserId = userId,
                TotalBalance = totalBalance,
                AccountTypeId = accountTypeId,
                Interest = interest
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.PostUserAccount(
                userId,
                totalBalance,
                accountTypeId,
                interest)).ReturnsAsync(0);
            AccountTypeController accountTypeController = new(_repository.Object);

            // act
            var result = await accountTypeController.PostUserAccount(accountDto);

            // assert
            Assert.Equal(0, result);
        }
    }
}
