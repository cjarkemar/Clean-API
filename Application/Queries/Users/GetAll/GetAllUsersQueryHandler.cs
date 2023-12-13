using Application.Queries.Users.GetAll;
using Domain.Models.User;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.GetAll.Users 
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly RealDatabase _realDatabase;

        public GetAllUsersQueryHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }
        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> allUsersFromRealDatabase = _realDatabase.Users.ToList();
            return Task.FromResult(allUsersFromRealDatabase);
        }
    }
}
