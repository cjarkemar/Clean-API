using Domain.Models;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.Cats
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteCatByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == request.Id);

            if (catToDelete != null)
            {
                _mockDatabase.Cats.Remove(catToDelete);
            }

            return Task.FromResult(catToDelete);
        }
    }
}
