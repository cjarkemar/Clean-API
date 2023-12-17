using Domain.Models;
using Infrastructure.Database.RealDatabase;
using MediatR;

namespace Application.Commands.Cats
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly RealDatabase _realDatabase;

        public AddCatCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat catToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay
            };

            _realDatabase.Cats.Add(catToCreate);
            _realDatabase.SaveChangesAsync(cancellationToken);
            return Task.FromResult(catToCreate);
        }
    }
}

