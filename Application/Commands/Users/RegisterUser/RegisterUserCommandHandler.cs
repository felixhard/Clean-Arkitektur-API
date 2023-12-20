using Domain.Models;
using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User userToCreate = new()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = hashedPassword,
                Authorized = true,
                Role = "NewUser"
            };

            return await _userRepository.RegisterUser(userToCreate); ;
        }
    }
}