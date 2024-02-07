using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Queries.Cats.GetAll
{
    public class GetAllCatsQuery : IRequest<List<Cat>>
    {
    }
}
