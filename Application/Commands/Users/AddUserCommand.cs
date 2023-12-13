// AddUserCommand
using System;
using Application.Dtos;
using Domain.Models;
using Domain.Models.User;
using MediatR;

namespace Application.Commands.Users
{
    public class AddUserCommand : IRequest<User>
    {
        public AddUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }

        public UserDto NewUser { get; }
    }
}

