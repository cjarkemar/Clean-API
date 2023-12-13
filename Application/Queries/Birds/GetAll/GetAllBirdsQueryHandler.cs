using Application.Queries.Birds.GetAll;
using Infrastructure.Database;
using MediatR;
using Domain.Models.Animal;

namespace Application.Queries.Birds
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly RealDatabase _realDatabase;

        public GetAllBirdsQueryHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsFromRealDatabase = _realDatabase.Birds.ToList();
            return Task.FromResult(allBirdsFromRealDatabase);
        }
    }
}

