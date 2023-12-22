using Application.Queries.Cats.GetById;
using Domain.Models;
using Infrastructure.Repositories.Cats;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetCatByIdTests
    {
        [Test]
        public async Task Handle_ValidId_ReturnCorrectCat()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var cat = new Cat { Name = "Smulan" };

            var catRepositoryMock = new Mock<ICatRepository>();
            catRepositoryMock.Setup(repo => repo.GetCatById(guid)).ReturnsAsync(cat);

            var handler = new GetCatByIdQueryHandler(catRepositoryMock.Object);
            var command = new GetCatByIdQuery(guid);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.Name, Is.EqualTo("Smulan"));


        }
    }
}
