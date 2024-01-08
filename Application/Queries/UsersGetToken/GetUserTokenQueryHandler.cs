
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Queries.UsersGetToken
{
    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery, string>
    {
        private readonly IUserRepository _userRepository;

        public GetUserTokenQueryHandler(Infrastructure.Database.RealDatabase.RealDatabase @object, IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {

            string token = await _userRepository.SignInUser(request.Username, request.Password);

            if (token == null)
            {
                return null!;
            }

            return token;

        }
    }
}