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

        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = Task.Run(() => _dogRepository.GetDogById(request.Id, cancellationToken)).Result;

            return Task.FromResult(wantedDog);
        }
    }
}
