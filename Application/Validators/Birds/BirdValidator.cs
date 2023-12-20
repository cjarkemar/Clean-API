using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Bird
{
    public class BirdValidator : AbstractValidator<BirdDto>
    {
        public BirdValidator()
        {
            RuleFor(bird => bird.Name).NotEmpty().WithMessage("Bird name cant be empty")
                .NotNull().WithMessage("Bird name cant be NULL");

            RuleFor(bird => bird.CanFly).NotEmpty().WithMessage("CanFly cant be empty")
                .NotNull().WithMessage("CanFly cant be NULL");
        }
    }
}