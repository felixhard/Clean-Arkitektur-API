using Domain.Models.Birds;
using Application.Dtos.AnimalDtos.BirdDto;
using MediatR;

namespace Application.Commands.Birds.AddBird
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