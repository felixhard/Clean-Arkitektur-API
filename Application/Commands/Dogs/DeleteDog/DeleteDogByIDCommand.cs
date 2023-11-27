using Domain.Models.Dogs;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIDCommand : IRequest<Dog>
    {
        public DeleteDogByIDCommand(Guid dogID)
        {
            ID = dogID;
        }
        public Guid ID { get; set; }

    }
}
