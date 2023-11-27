using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            // Find the dog to delete by ID
            Dog dogToDelete = _mockDatabase.Dogs.FirstOrDefault(d => d.Id == request.DogId)!;

            // Check if the dog exists
            if (dogToDelete == null)
            {
                // Dog not found, return false or handle differently
                return Task.FromResult<Dog>(null);
            }

            // Remove the dog from the database
            _mockDatabase.Dogs.Remove(dogToDelete);

            // Return true to indicate successful deletion
            return Task.FromResult(dogToDelete);
        }
    }
}
