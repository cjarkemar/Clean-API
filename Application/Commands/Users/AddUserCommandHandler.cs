// AddUserCommandHandler
using Domain.Models;
using Domain.Models.User;
using Infrastructure.Database;
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
            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.Username
            };

            _realDatabase.Users.Add(userToCreate);
            _realDatabase.SaveChangesAsync(cancellationToken);

            return Task.FromResult(userToCreate);
        }
    }
}
