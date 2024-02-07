using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.DeleteBird
{
    public class DeleteBirdByIdCommand : IRequest<Bird>
    {
        public DeleteBirdByIdCommand(Guid birdId)
        {
            Id = birdId;
        }
        public Guid Id { get; set; }

    }
}
