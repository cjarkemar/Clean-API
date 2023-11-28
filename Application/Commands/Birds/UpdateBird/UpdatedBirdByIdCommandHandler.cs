using Domain.Models.Animal;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id)!;

            if (birdToUpdate != null)
            {
                birdToUpdate.Name = request.UpdatedBird.Name;
                birdToUpdate.CanFly = request.UpdatedBird.CanFly;
            }

            return Task.FromResult(birdToUpdate);
        }
    }
}

