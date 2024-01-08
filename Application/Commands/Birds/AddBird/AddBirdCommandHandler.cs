using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public AddBirdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToCreate = new()

            {
                Color = request.NewBird.Color,
                AnimalId = Guid.NewGuid(),
                CanFly = request.NewBird.CanFly,
                Name = request.NewBird.Name



            };

            var createdBird = await _birdRepository.AddBird(birdToCreate, request.UserId);

            return createdBird;
        }
    }
}