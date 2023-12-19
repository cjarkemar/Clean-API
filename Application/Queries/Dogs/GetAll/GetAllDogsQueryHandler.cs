using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using Infrastructure.RepositoryPatternFiles.DogsPattern;

namespace Application.Queries.Dogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {

        //private readonly RealDatabase _realDatabase;

        private readonly IDogRepository _dogRepository;


        public GetAllDogsQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromDatabase = Task.Run(() => _dogRepository.GetAllDogs(cancellationToken)).Result;
            return Task.FromResult(allDogsFromDatabase);
        }
    }
}
