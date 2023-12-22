using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Repositories.Cats;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class UpdateCatTests
    {
        [Test]
        public async Task Handle_Update_Correct_Cat_By_Id()
        {
            // Arrange
            var guid = new Guid("ab8c99a5-07d2-5723-83a9-8ef6ec622220");
            var cat = new Cat { AnimalId = guid, Name = "AmandaTheUglyCat", LikesToPlay = true };
            var catDto = new CatDto { Name = "CJTheGreatCat", LikesToPlay = true };

            var catRepositoryMock = new Mock<ICatRepository>();
            catRepositoryMock.Setup(repo => repo.GetCatById(guid)).ReturnsAsync(cat);
            catRepositoryMock.Setup(repo => repo.UpdateCat(cat)).ReturnsAsync(cat);

            var handler = new UpdateCatByIdCommandHandler(catRepositoryMock.Object);
            var command = new UpdateCatByIdCommand(catDto, guid);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("CJTheGreatCat"));
            Assert.That(result.LikesToPlay, Is.True);
            Assert.That(result, Is.TypeOf<Cat>());


        }
    }
}
