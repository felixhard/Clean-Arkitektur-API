using Application.Dtos.AnimalDtos.BirdDto;
using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.UpdateBird
{
    public class UpdateBirdByIdCommand : IRequest<Bird>
    {
        public UpdateBirdByIdCommand(BirdDto updatedBird, Guid id)
        {
            UpdatedBird = updatedBird;
            Id = id;
        }

        public BirdDto UpdatedBird { get; }
        public Guid Id { get; }
    }
}
