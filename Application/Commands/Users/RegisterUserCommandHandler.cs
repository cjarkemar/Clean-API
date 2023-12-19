// AddUserCommandHandler
using Domain.Models;
using Domain.Models.User;
using Infrastructure.Database;
using Infrastructure.RepositoryPatternFiles.UserPattern;
using MediatR;

namespace Application.Commands.Users
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly RegisterUserCommandValidator _validator;

        public RegisterUserCommandHandler(IUserRepository userRepository, RegisterUserCommandValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerCommandValidation = _validator.Validate(request);

            if (!registerCommandValidation.IsValid)
            {
                var allErrors = registerCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            // Password hashing using BCrypt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password);


            // Here can we use something called AutoMapper, helps us convert Dtos to Domain Models...
            var userToCreate = new User
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.Username.ToLowerInvariant(),
                PasswordHash = hashedPassword,
            };

            var createdUser = _userRepository.RegisterUser(userToCreate);

            return createdUser;
        }
    }
}
