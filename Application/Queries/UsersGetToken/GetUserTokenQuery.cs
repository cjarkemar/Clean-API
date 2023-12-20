// GetUserTokenQuery
using System;
using MediatR;

namespace Application.Queries.UsersGetToken
{
    public class GetUserTokenQuery : IRequest<string>
    {
        public GetUserTokenQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; }
        public string Password { get; }
    }
}

