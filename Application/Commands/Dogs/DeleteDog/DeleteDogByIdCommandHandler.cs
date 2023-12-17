using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database.RealDatabase;
using MediatR;


namespace Application.Commands.Dogs
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly RealDatabase _realDatabase;

        public DeleteDogByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _realDatabase.Dogs.FirstOrDefault(dogs => dogs.Id == request.Id)!;

            if (dogToDelete != null)
            {
                _realDatabase.Dogs.Remove(dogToDelete);
            }
            _realDatabase.SaveChangesAsync(cancellationToken);
            return Task.FromResult(dogToDelete);
        }
    }
}
