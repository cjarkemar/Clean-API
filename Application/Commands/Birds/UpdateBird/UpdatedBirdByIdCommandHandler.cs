using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Commands.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public UpdateBirdByIdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = await _birdRepository.GetBirdById(request.Id);

            if (birdToUpdate == null)
            {
                return null!;
            }

            birdToUpdate.Name = request.BirdToUpdate.Name;
            birdToUpdate.CanFly = request.BirdToUpdate.CanFly;

            var updatedBird = await _birdRepository.UpdateBird(birdToUpdate);

            return updatedBird;
        }
    }
}