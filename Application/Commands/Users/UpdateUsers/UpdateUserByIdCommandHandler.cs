using Domain.Models;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.UpdateUsers
{
    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            User userToUpdate = await _userRepository.GetUserById(request.Id);

            if (userToUpdate == null)
            {
                return null!;
            }

            if (userToUpdate.Username != request.UserToUpdate.UserName) { userToUpdate.Username = request.UserToUpdate.UserName; }
            if (userToUpdate.Role != request.UserToUpdate.Role) { userToUpdate.Role = request.UserToUpdate.Role; }
            if (userToUpdate.Authorized != request.UserToUpdate.Authorized) { userToUpdate.Authorized = request.UserToUpdate.Authorized; }
            if (userToUpdate.Password != request.UserToUpdate.Password)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.UserToUpdate.Password);
                userToUpdate.Password = hashedPassword;
            }

            var updatedUser = await _userRepository.UpdateUser(userToUpdate);

            return updatedUser;
        }
    }
}