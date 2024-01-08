using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public DeleteBirdByIdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = await _birdRepository.DeleteBirdById(request.Id);

            return birdToDelete;
        }
    }
}