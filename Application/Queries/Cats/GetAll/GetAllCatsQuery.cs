using Domain.Models.Cats;
using MediatR;

namespace Application.Queries.Cats.GetAll
{
    public class GetAllCatsQuery : IRequest<List<Cat>>
    {
    }
}
