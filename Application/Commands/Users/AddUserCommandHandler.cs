// AddUserCommandHandler
using Domain.Models;
using Domain.Models.User;
using Infrastructure.Database.RealDatabase;
using MediatR;

namespace Application.Commands.Users
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly RealDatabase _realDatabase;

        public AddUserCommandHandler(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            string newhashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);

            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.Username,
                Password = newhashedPassword,
                Authorized = true,
                Role = "NewUser"
            };

            _realDatabase.Users.Add(userToCreate);

            return Task.FromResult(userToCreate);
        }
    }
}
