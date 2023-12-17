using Domain.Models;
using Infrastructure.Database.RealDatabase;
using MediatR;


namespace Application.Commands.Cats
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly RealDatabase _realDatabase;

        public DeleteCatByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _realDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id)!;

            if (catToDelete != null)
            {
                _realDatabase.Cats.Remove(catToDelete);
            }

            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(catToDelete);
        }
    }
}
