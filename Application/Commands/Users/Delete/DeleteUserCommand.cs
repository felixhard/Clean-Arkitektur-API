using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.Delete
{
    public class DeleteUserCommand : IRequest<User>
    {
        public DeleteUserCommand(Guid userId)
        {
            Id = userId;
        }
        public Guid Id { get; set; }
    }
}