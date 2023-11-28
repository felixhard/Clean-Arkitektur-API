using Domain.Models.Dogs;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(Guid dogID)
        {
            ID = dogID;
        }
        public Guid ID { get; set; }

    }
}
