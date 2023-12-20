using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Queries.Cats.GetWeight
{
    public class GetCatsByWeightQueryOrBreedHandler : IRequestHandler<GetCatsByWeightOrBreedQuery, List<Cat>>
    {
        private readonly ICatRepository _catRepository;

        public GetCatsByWeightQueryOrBreedHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<List<Cat>> Handle(GetCatsByWeightOrBreedQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsWithWeight = await _catRepository.GetCatsByWeightBreed(request.Weight, request.Breed);

            return allCatsWithWeight;
        }
    }
}