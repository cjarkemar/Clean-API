// UserValidator
using System;
using Application.Dtos;
using FluentValidation;

namespace Application.Validators.User
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username cant be empty")
                .NotNull().WithMessage("Username cant be NULL");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password cant be empty")
                .NotNull().WithMessage("Password cant be NULL");
        }
    }
}