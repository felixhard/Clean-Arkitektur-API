using Domain.Models.Birds;
using MediatR;

namespace Application.Queries.Birds.GetById
{
    public class GetBirdByIdQuery : IRequest<Bird>
    {
        public GetBirdByIdQuery(Guid birdId)
        {
            Id = birdId;
        }

        public Guid Id { get; }
    }
}
