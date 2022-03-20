using Microsoft.AspNetCore.Mvc;
using Moq;
using My2Cents.API.Controllers;
using My2Cents.DatabaseManagement;
using My2Cents.DataInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace My2Cents.Test
{
    public class AccountTypeTests
    {
        [Fact]
        public async Task ValidGetAccountTypes()
        {
            // arrange
            ActionResult<IEnumerable<AccountTypeDto>> accountTypeDto = new AccountTypeDto[]
            {
                new AccountTypeDto()
                {
                    AccountTypeId = 1,
                    AccountType1 = "Checking"
                },
                new AccountTypeDto()
                {
                    AccountTypeId = 2,
                    AccountType1 = "Savings"
                }
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.GetAccountTypes()).ReturnsAsync(accountTypeDto);
            AccountTypeController accountTypeController = new(_repository.Object);

            // act
            var result = await accountTypeController.GetAccountTypes();

            // assert
            Assert.Equal(accountTypeDto, result);
        }
    }
}
