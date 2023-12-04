using Application.Dtos.AnimalDtos.DogDto;
using FluentValidation;

namespace Application.Validators.Dog
{
    public class DogValidator : AbstractValidator<DogDto>
    {
        public DogValidator()
        {
            RuleFor(dog => dog.Name).NotEmpty()
                    .WithMessage("Dog name cannot be empty B.F.A.M")
                    .NotNull().WithMessage("Dog name cannot be NULL");

        }

    }
}
