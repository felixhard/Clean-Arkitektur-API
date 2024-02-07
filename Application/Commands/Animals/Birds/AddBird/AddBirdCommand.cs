using Application.Dtos.AnimalDtos.BirdDto;
using MediatR;
using Domain.Models.Animals.Birds;

namespace Application.Commands.Animals.Birds.AddBird
{
    public class AddBirdCommand : IRequest<Bird>
    {
        public AddBirdCommand(BirdDto newBird)
        {
            NewBird = newBird;
        }
        public BirdDto NewBird { get; }
    }
}