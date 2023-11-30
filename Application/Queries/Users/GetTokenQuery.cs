using Domain.Models.Users;
using MediatR;

namespace Application.Queries.Users.GetToken
{
    public class GetTokenQuery : IRequest<User>
    {
        public GetTokenQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Guid Id { get; }
        public string Username { get; }
        public string Password { get; }
        public bool IsAuthorized { get; }
        public string Token { get; } = string.Empty;
    }
}