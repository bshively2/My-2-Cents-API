using Moq;
using My2Cents.API.Controllers;
using My2Cents.DataInfrastructure;
using My2Cents.DataInfrastructure.Models;
using System.Threading.Tasks;
using Xunit;

namespace My2Cents.Test
{
    public class UserTests
    {
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
            UserProfile profile = new() { };

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
            _repository.Setup(u => u.PostNewUserInfo(profile)).ReturnsAsync(profile);
            UserController userController = new(_repository.Object);

            // act
            var result = await userController.PostNewUserInfo(profileDto);

            // assert
            Assert.Equal(profile, result);
        }
    }
}
