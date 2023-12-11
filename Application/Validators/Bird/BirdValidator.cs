using Application.Dtos.AnimalDtos.BirdDto;
using FluentValidation;

namespace Application.Validators.Bird
{
    public class BirdValidator : AbstractValidator<BirdDto>
    {
        public BirdValidator()
        {
            RuleFor(bird => bird.Name).NotEmpty()
                    .WithMessage("Bird name cannot be empty B.F.A.M")
                    .NotNull().WithMessage("Bird name cannot be NULL");

        }

    }
}
