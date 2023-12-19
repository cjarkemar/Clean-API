using Domain.Models;
using Domain.Models.User;
using FluentValidation;
using Infrastructure.RepositoryPatternFiles.UserPattern;

namespace Application.Commands.Users
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(command => command.NewUser.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Must(BeUniqueUsername).WithMessage("Username is already taken.");
        }

        private bool BeUniqueUsername(string username)
        {
            // Check if the username is unique in the database
            List<User> allUsersFromDb = _userRepository.GetAllUsers().Result;
            return !allUsersFromDb.Any(user => user.Username == username);
        }
    }
}