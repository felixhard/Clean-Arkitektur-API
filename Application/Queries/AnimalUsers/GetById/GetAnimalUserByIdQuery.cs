using Domain.Models.AnimalUsers;
using MediatR;

namespace Application.Queries.AnimalUsers.GetById
{
    public class GetAnimalUserByIdQuery : IRequest<AnimalUser>
    {
        public GetAnimalUserByIdQuery(Guid animalUserId)
        {
            Id = animalUserId;
        }
        public Guid Id { get; set; }
    }
}
