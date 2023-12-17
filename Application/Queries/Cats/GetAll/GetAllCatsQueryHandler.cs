using Domain.Models;
using Application.Queries.Cats.GetAll;
using Infrastructure.Database.RealDatabase;
using MediatR;


namespace Application.Queries.Cats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly RealDatabase _realDatabase;

        public GetAllCatsQueryHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromRealDatabase = _realDatabase.Cats.ToList();
            return Task.FromResult(allCatsFromRealDatabase);
        }
    }
}

