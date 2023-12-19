using Application.Dtos;
using Domain.Models;
using Domain.Models.User;
using MediatR;

namespace Application.Queries.Users
{
    public class LoginUserQuery : IRequest<string>
    {
        public LoginUserQuery(UserDto loginUser)
        {
            LoginUser = loginUser;
        }

        public UserDto LoginUser { get; }
    }
}
