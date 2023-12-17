using Domain.Models.Animal;
using Infrastructure.Database.RealDatabase;
using MediatR;


namespace Application.Commands.Birds
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly RealDatabase _realDatabase;

        public DeleteBirdByIdCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _realDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id)!;

            if (birdToDelete != null)
            {
                _realDatabase.Birds.Remove(birdToDelete);
            }
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(birdToDelete);
        }
    }
}
