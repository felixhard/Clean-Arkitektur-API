using Domain.Models.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(Guid dogId)
        {
            Id = dogId;
        }
        public Guid Id { get; set; }

    }
}
