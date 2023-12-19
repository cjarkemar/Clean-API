// AddUserCommand
using System;
using Application.Dtos;
using Domain.Models;
using Domain.Models.User;
using MediatR;

namespace Application.Commands.Users
{
    public class RegisterUserCommand : IRequest<User>
    {
        public RegisterUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }

        public UserDto NewUser { get; }
    }
}

