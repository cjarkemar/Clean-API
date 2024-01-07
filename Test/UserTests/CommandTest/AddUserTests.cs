
using Application.Commands.Users.Register;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Repositories.Users;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Test.UserTests.CommandTest
{
    [TestFixture]
    public class AddUserTests
    {
        [Test]
        public async Task Handle_Add_User()
        {
            //Arrange
            var username = "TestaAnvändare";
            var password = "lösen";
            var role = "admin";

            var dto = new UserDto
            {
                UserName = username,
                Password = password,
                Role = role,
                Authorized = true
            };

            var user = new User { Authorized = true, Password = password, Username = username };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.AddUser(It.IsAny<User>())).ReturnsAsync(user);

            var handler = new AddUserCommandHandler(userRepositoryMock.Object);
            var command = new AddUserCommand(username, password);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Username.Equals(username));
            Assert.That(result, Is.TypeOf<User>());
        }
    }
}
