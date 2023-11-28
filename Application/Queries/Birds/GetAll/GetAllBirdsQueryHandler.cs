using Application.Queries.Birds.GetAll;
using Infrastructure.Database;
using MediatR;
using Domain.Models.Animal;

namespace Application.Queries.Birds
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllBirdsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsFromMockDatabase = _mockDatabase.Birds;
            return Task.FromResult(allBirdsFromMockDatabase);
        }
    }
}

