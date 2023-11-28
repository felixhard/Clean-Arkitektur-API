using Domain.Models.Dogs;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
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
