using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Users.UpdateUsers
{
    public class UpdateUserByIdCommand : IRequest<User>
    {
        public UpdateUserByIdCommand(UserDto userToUpdate, Guid id)
        {
            UserToUpdate = userToUpdate;
            Id = id;
        }

        public UserDto UserToUpdate { get; }
        public Guid Id { get; }

    }
}