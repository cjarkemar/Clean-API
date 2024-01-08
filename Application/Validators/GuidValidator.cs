using FluentValidation;

namespace Application.Validators
{

    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(guid => guid).NotNull().WithMessage("Guid cant be NULL")
                .NotEmpty().WithMessage("Guid cant be empty")
                .NotEqual(Guid.Empty).WithMessage("Guid should not be empty");
        }

    }
}