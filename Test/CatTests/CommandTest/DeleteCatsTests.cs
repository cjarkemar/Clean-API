using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using Infrastructure.Repositories.Cats;
using Moq;


namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatTests
    {
        [Test]
        public async Task Handle_Delete_Incorrect_Id()
        {
            // Arrange
            var cat = new Cat
            {
                Name = "AmandaTheUglyCat",
                AnimalId = Guid.NewGuid()
            };

            var catRepositoryMock = new Mock<ICatRepository>();
            catRepositoryMock.Setup(repo => repo.DeleteCatById(cat.AnimalId)).ReturnsAsync(cat);

            var handler = new DeleteCatByIdCommandHandler(catRepositoryMock.Object);
            var command = new DeleteCatByIdCommand(cat.AnimalId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("AmandaTheUglyCat"));
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.AnimalId, Is.EqualTo(cat.AnimalId));


        }
    }
}
