using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.Dogs
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
            Dog dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dogs => dogs.Id == request.Id);

            if (dogToDelete != null)
            {
                _mockDatabase.Dogs.Remove(dogToDelete);
            }

            return Task.FromResult(dogToDelete);
        }
    }
}
