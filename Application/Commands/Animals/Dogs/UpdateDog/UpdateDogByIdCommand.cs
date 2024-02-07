using Application.Dtos.AnimalDtos.DogDto;
using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand : IRequest<Dog>
    {
        public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            Id = id;
        }

        public DogDto UpdatedDog { get; }
        public Guid Id { get; }
    }
}
