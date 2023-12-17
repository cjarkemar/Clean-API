using Application.Queries.Users;
using Domain.Models.User;
using Infrastructure.Database;
using Infrastructure.Database.RealDatabase;
using MediatR;
using Infrastructure.Authentication;
//BCrypt tillagt på application

namespace Application.Queries.Users.GetTokenFOrUserQueryHandler
{
    public class GetTokenForUserQueryHandler : IRequestHandler<GetTokenForUserQuery, string>
    {
        private readonly RealDatabase _realDatabase;
        private readonly GeneratorJwtToken _jwtTokenGenerator;

        public GetTokenForUserQueryHandler(RealDatabase realDatabase, GeneratorJwtToken jwtTokenGenerator)
        {
            _realDatabase = realDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<string> Handle(GetTokenForUserQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _realDatabase.Users.FirstOrDefault(user => user.Username == request.Username)!;

            if (wantedUser == null)
            {
                return Task.FromResult<string>(null!);
            }

            bool userPassword = BCrypt.Net.BCrypt.Verify(request.Password, wantedUser.Password);

            if (!userPassword)
            {
                return Task.FromResult<string>(null!);
            }

            var token = _jwtTokenGenerator.GenerateJwtToken(wantedUser);

            return Task.FromResult(token);

        }
    }
}