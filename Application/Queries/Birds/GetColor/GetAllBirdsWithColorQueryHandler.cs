using Domain.Models;
using Infrastructure.Repositories.Birds;
using MediatR;

namespace Application.Queries.Birds.GetColor
{
    public class GetAllBirdsWithColorQueryHandler : IRequestHandler<GetAllBirdsWithColorQuery, List<Bird>>
    {
        private readonly IBirdRepository _birdRepository;

        public GetAllBirdsWithColorQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetAllBirdsWithColorQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsWithColor = await _birdRepository.GetAllBirdsWithColor(request.Color);

            return allBirdsWithColor;
        }
    }
}