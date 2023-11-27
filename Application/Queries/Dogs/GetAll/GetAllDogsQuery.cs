using Domain.Models.Dogs;
using MediatR;

namespace Application.Queries.Dogs.GetAll
{
    public class GetAllDogsQuery : IRequest<List<Dog>>
    {
    }
}
