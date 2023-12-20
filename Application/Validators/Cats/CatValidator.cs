using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<CatDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name).NotEmpty().WithMessage("Cat name cant be empty")
                .NotNull().WithMessage("Cat name cant be NULL");

            RuleFor(cat => cat.LikesToPlay).NotEmpty().WithMessage("LikesToPlay cant be empty")
                .NotNull().WithMessage("LikesToPlay cant be NULL");
        }
    }
}