using Domain.Models.Users;
using MediatR;

namespace Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public GetUserByIdQuery(Guid userID)
        {
            Id = userID;
        }
        public Guid Id { get; set; }
    }
}