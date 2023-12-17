using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database.RealDatabase;
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
            //List<Dog> allDogsFromRealDatabase = _realDatabase.Dogs.ToList();
            
            List<Dog> alldogs = await _dogRepository.GetAllDogsAsync();

            //return Task.FromResult(allDogsFromRealDatabase);
            return alldogs;
        }
    }
}
