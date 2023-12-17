using Domain.Models;
using Infrastructure.RepositoryPatternFiles.DogsPattern;
using MediatR;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        //private readonly RealDatabase _realDatabase;
        private readonly IDogRepository _dogRepository;

        public GetDogByIdQueryHandler(IDogRepository dogRepository)
        { 
            //_realDatabase = realDatabase;
            _dogRepository = dogRepository;
        }

        public async Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            //Dog wantedDog = _realDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;
            //return Task.FromResult(wantedDog);

            Dog wantedDog = await _dogRepository.GetDogById(request.Id);

            if (wantedDog == null)
            {
                return null!;
            }
            return wantedDog;
        }
    }
}
