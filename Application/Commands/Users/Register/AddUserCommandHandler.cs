using Domain.Models;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.Register
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User userToCreate = new()
            {
                UserId = Guid.NewGuid(),
                Username = request.UserName,
                Password = hashedPassword,
                Authorized = true,
                Role = "NewUser"
            };

            return await _userRepository.AddUser(userToCreate); ;
        }
    }
}