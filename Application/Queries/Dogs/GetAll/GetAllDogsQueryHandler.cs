using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Dogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly RealDatabase _realDatabase;

        public GetAllDogsQueryHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromRealDatabase = _realDatabase.Dogs.ToList();
            return Task.FromResult(allDogsFromRealDatabase);
        }
    }
}
