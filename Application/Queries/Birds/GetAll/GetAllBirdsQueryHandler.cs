using Application.Queries.Birds.GetAll;
using Domain.Models;
using MediatR;
using Infrastructure.RepositoryPatternFiles.BirdsPattern;
using Domain.Models.Animal;

namespace Application.Queries.Birds
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {

        //private readonly RealDatabase _realDatabase;

        private readonly IBirdRepository _birdRepository;


        public GetAllBirdsQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
        public async Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
           

            List<Bird> allbirds = await _birdRepository.GetAllBirdsAsync();

            //return Task.FromResult(allBirdsFromRealDatabase);
            return allbirds;
        }
    }
}
