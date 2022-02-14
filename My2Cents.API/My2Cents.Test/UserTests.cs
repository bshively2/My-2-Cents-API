using Microsoft.AspNetCore.Mvc;
using Moq;
using My2Cents.API.Controllers;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace My2Cents.Test
{
    public class UserTests
    {
        [Theory]
        [InlineData(1)]
        public async Task ValidGetUser(int userId)
        {
            // arrange
            ActionResult<IEnumerable<UserProfileDto>> profileDto = new UserProfileDto[]
            {
                new UserProfileDto()
                {
                    UserId = 1,
                    FirstName = "Sam",
                    LastName = "James",
                    SecondaryEmail = "s@j.com",
                    MailingAddress = "Some Address",
                    Phone = "999-999-9999",
                    City = "Some City",
                    State = "Some State",
                    Employer = "Some Employer",
                    WorkAddress = "Some Address",
                    WorkPhone = "999-999-9999",
                    Email = "s@j.com"
                }
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.GetUserInfo(userId)).ReturnsAsync(profileDto);
            UserController userController = new(_repository.Object);

            // act
            var result = await userController.GetUserInfo(userId);

            // assert
            Assert.Equal(profileDto, result);
        }

        [Theory]
        [InlineData(1, "a", "b", "a", "a", "1", "a", "a", "a", "a", "1")]
        public async Task InvalidUserPost(
            int userId,
            string firstName,
            string lastName,
            string secondaryEmail,
            string mailingAddress,
            string phone,
            string city,
            string state,
            string employer,
            string workAddress,
            string workPhone)
        {
            // arrange
            PostNewUserDto profileDto = new()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                SecondaryEmail = secondaryEmail,
                MailingAddress = mailingAddress,
                Phone = phone,
                City = city,
                State = state,
                Employer = employer,
                WorkAddress = workAddress,
                WorkPhone = workPhone
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.PostNewUserInfo(userId,
                firstName,
                lastName,
                secondaryEmail,
                mailingAddress,
                phone,
                city,
                state,
                employer,
                workAddress,
                workPhone)).ReturnsAsync(0);
            UserController userController = new(_repository.Object);

            // act
            var result = await userController.PostNewUserInfo(profileDto);

            // assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(1, "Matt", "Wilson", "a@g.com", "123 St", "999-999-9999", "Some City", "Some State", "Work", "123 St", "999-999-9999")]
        public async Task ValidUserPost(
            int userId,
            string firstName,
            string lastName,
            string secondaryEmail,
            string mailingAddress,
            string phone,
            string city,
            string state,
            string employer,
            string workAddress,
            string workPhone)
        {
            // arrange
            PostNewUserDto profileDto = new()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                SecondaryEmail = secondaryEmail,
                MailingAddress = mailingAddress,
                Phone = phone,
                City = city,
                State = state,
                Employer = employer,
                WorkAddress = workAddress,
                WorkPhone = workPhone
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.PostNewUserInfo(userId,
                firstName,
                lastName,
                secondaryEmail,
                mailingAddress,
                phone,
                city,
                state,
                employer,
                workAddress,
                workPhone)).ReturnsAsync(4);
            UserController userController = new(_repository.Object);

            // act
            var result = await userController.PostNewUserInfo(profileDto);

            // assert
            Assert.Equal(4, result);
        }


        [Theory]
        [InlineData(1, "Matt", "Wilson", "a@g.com", "123 St", "999-999-9999", "Some City", "Some State", "Work", "123 St", "999-999-9999")]
        public async Task ValidUserPut(
            int userId,
            string firstName,
            string lastName,
            string secondaryEmail,
            string mailingAddress,
            string phone,
            string city,
            string state,
            string employer,
            string workAddress,
            string workPhone)
        {
            // arrange
            UserProfileDto profileDto = new()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                SecondaryEmail = secondaryEmail,
                MailingAddress = mailingAddress,
                Phone = phone,
                City = city,
                State = state,
                Employer = employer,
                WorkAddress = workAddress,
                WorkPhone = workPhone
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.PutUserInfo(
                userId,
                firstName,
                lastName,
                secondaryEmail,
                mailingAddress,
                phone,
                city,
                state,
                employer,
                workAddress,
                workPhone)).ReturnsAsync(4);
            UserController userController = new(_repository.Object);

            // act
            var result = await userController.PutUserInfo(profileDto);

            // assert
            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1, "a", "b", "a", "a", "1", "a", "a", "a", "a", "1")]
        public async Task InvalidUserPut(
            int userId,
            string firstName,
            string lastName,
            string secondaryEmail,
            string mailingAddress,
            string phone,
            string city,
            string state,
            string employer,
            string workAddress,
            string workPhone)
        {
            // arrange
            UserProfileDto profileDto = new()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                SecondaryEmail = secondaryEmail,
                MailingAddress = mailingAddress,
                Phone = phone,
                City = city,
                State = state,
                Employer = employer,
                WorkAddress = workAddress,
                WorkPhone = workPhone
            };

            Mock<IRepository> _repository = new Mock<IRepository>();
            _repository.Setup(u => u.PutUserInfo(userId,
                firstName,
                lastName,
                secondaryEmail,
                mailingAddress,
                phone,
                city,
                state,
                employer,
                workAddress,
                workPhone)).ReturnsAsync(0);
            UserController userController = new(_repository.Object);

            // act
            var result = await userController.PutUserInfo(profileDto);

            // assert
            Assert.Equal(0, result);
        }
    }
}
