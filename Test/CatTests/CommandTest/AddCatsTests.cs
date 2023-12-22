using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Repositories.Cats;
using Moq;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTests
    {
        [Test]
        public async Task Handle_Add_Cat_To_Database()
        {
            // Arrange
            var cat = new Cat { Name = "Gustaf" };
            var requestGuid = Guid.NewGuid();

            var catRepositoryMock = new Mock<ICatRepository>();
            catRepositoryMock.Setup(repo => repo.AddCat(cat, requestGuid)).ReturnsAsync(cat);

            var handler = new AddCatCommandHandler(catRepositoryMock.Object);

            var dto = new CatDto
            {
                Name = "Gustaf",
                Breed = "Bergskatt",
                Weight = 9
            };

            var command = new AddCatCommand(dto, requestGuid);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Gustaf"));
            Assert.That(result, Is.TypeOf<Cat>());


        }
    }
}
