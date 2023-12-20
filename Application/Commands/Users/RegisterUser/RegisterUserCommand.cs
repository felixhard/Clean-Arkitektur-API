using Domain.Models;
using Domain.Models.Users;
using MediatR;

namespace Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommand : IRequest<User>
    {
        public RegisterUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; }
        public string Password { get; }
    }
}