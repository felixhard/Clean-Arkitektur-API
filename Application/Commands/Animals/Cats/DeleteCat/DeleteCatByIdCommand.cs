using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.DeleteCat
{
    public class DeleteCatByIdCommand : IRequest<Cat>
    {
        public DeleteCatByIdCommand(Guid catId)
        {
            Id = catId;
        }
        public Guid Id { get; set; }

    }
}
