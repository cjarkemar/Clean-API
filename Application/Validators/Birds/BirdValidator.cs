// BirdValidator
using System;
using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Birds
{
    public class BirdValidator : AbstractValidator<BirdDto>
    {
        public BirdValidator()
        {
            RuleFor(bird => bird.Name)
                .NotEmpty().WithMessage("Bird Name can not be empty")
                .NotNull().WithMessage("Bird Name can not be NULL")
                .NotEqual("string", StringComparer.OrdinalIgnoreCase);
        }
    }
}

