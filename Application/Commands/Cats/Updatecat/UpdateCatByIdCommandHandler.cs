using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly RealDatabase _realDatabase;

        public UpdateCatByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _realDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id)!;

            if (catToUpdate != null)
            {
                catToUpdate.Name = request.UpdatedCat.Name;
                catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;
            }
            _realDatabase.SaveChangesAsync(cancellationToken);
            return Task.FromResult(catToUpdate);
        }
    }
}

