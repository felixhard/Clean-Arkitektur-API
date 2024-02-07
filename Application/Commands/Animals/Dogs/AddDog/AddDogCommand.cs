using Application.Dtos.AnimalDtos.DogDto;
using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.AddDog
{
    public class AddDogCommand : IRequest<Dog>
    {
        public AddDogCommand(DogDto newDog)
        {
            NewDog = newDog;
        }

        public DogDto NewDog { get; }
    }

}
