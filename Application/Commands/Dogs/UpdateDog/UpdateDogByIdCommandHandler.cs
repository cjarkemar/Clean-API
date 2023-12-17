using Domain.Models;
using Infrastructure.Database.RealDatabase;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly RealDatabase _realDatabase;

        public UpdateDogByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }
        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToUpdate = _realDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;

            if (dogToUpdate == null)
            {
                return Task.FromResult<Dog>(null);
            }

            dogToUpdate.Name = request.UpdatedDog.Name;

            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(dogToUpdate);
        }

    }
}
