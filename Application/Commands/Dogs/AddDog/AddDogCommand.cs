using Application.Dtos.DogDto;
using Domain.Models.Dogs;
using MediatR;

namespace Application.Commands.Dogs.AddDog
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
