// AddUserCommand
using System;
using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Users.Register
{
    public class AddUserCommand : IRequest<User>
    {
        public AddUserCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        public string UserName { get; }
        public string Password { get; }
    }
}

