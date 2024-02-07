using Domain.Models.Animals.Birds;
using MediatR;

namespace Application.Queries.Birds.GetAll
{
    public class GetAllBirdsQuery : IRequest<List<Bird>>
    {
    }
}
