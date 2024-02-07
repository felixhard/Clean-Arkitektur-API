using Application.Dtos.UserDtos;
using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.Update
{
    public class UpdateUserCommand : IRequest<User>
    {
        public UpdateUserCommand(UserCredentialsDto userToUpdate, Guid id)
        {
            UserToUpdate = userToUpdate;
            Id = id;
        }
        public UserCredentialsDto UserToUpdate { get; }
        public Guid Id { get; }
    }
}