
using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Queries.Birds.GetAll
{
    internal sealed class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly IBirdRepository _birdRepository;

        public GetAllBirdsQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirds = await _birdRepository.GetAllBirdsAsync();


            return allBirds;
        }
    }
}