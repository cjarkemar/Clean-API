
using MediatR;
using Infrastructure.RepositoryPatternFiles.Authorization;



namespace Application.Queries.Users
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IAuthorizeRepository _authRepository;

        public LoginUserQueryHandler(IAuthorizeRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _authRepository.AuthenticateUser(request.LoginUser.Username.ToLowerInvariant(), request.LoginUser.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            string token = _authRepository.GenerateJwtToken(user);

            return Task.FromResult(token);
        }
    }
}