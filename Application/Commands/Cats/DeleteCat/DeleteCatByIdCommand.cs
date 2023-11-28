using Domain.Models.Cats;
using MediatR;

namespace Application.Commands.Cats.DeleteCat
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
