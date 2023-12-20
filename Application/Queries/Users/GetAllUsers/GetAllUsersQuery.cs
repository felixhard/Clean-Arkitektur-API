using Domain.Models;
using Domain.Models.Users;
using MediatR;

namespace Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}