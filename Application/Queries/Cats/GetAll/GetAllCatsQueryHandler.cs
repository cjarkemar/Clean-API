using Domain.Models;
using Application.Queries.Cats.GetAll;
using Infrastructure.Database;
using MediatR;
using Infrastructure.RepositoryPatternFiles.CatsPattern;


namespace Application.Queries.Cats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        //private readonly RealDatabase _realDatabase;
        private readonly ICatRepository _catRepository;

        public GetAllCatsQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

    

        public Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromDatabase = Task.Run(() => _catRepository.GetAllCats(cancellationToken)).Result;

            return Task.FromResult(allCatsFromDatabase);
        }
    }
}

