using Domain.Models;
using Application.Queries.Cats.GetAll;
using Infrastructure.Database;
using MediatR;


namespace Application.Queries.Cats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllCatsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromMockDatabase = _mockDatabase.Cats;
            return Task.FromResult(allCatsFromMockDatabase);
        }
    }
}

