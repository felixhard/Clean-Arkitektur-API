using Application.Commands.Users.Update;
using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User userToDelete = _userRepository.GetUserById(request.Id).Result;

            var deletedUser = await _userRepository.DeleteUser(userToDelete);

            return deletedUser;
        }
    }
}