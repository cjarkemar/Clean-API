using Domain.Models;
using Domain.Models.User;
using MediatR;

namespace Application.Queries.Users
{
    public class GetTokenForUserQuery : IRequest<string>
    {

        public Guid Id { get; }
        public string Username { get; }
        public string Password { get; }
        public bool IsAuthorized { get; }

        public GetTokenForUserQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }

        
    }
}
