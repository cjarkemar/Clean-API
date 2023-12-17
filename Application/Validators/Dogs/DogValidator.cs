using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Dogs
{
    public class DogValidator : AbstractValidator<DogDto>
    {
        public DogValidator()
        {
            RuleFor(dog => dog.Name)
                .NotEmpty().WithMessage("Dog name can not be empty")
                .NotNull().WithMessage("Dog name cant be NULL");
        }

    }
}