using Application.Dtos.AnimalDtos.CatDto;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<CatDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name).NotEmpty()
                    .WithMessage("Cat name cannot be empty B.F.A.M")
                    .NotNull().WithMessage("Cat name cannot be NULL");

        }

    }
}
