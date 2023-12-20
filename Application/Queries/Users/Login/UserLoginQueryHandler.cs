using Application.Authentication.Queries;
using Application.Queries.Users;
using Infrastructure.Authentication;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Authentication.Queries.Login
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, string>
    {
        private readonly AuthRepository _authServices;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserLoginQueryHandler(AuthRepository services, JwtTokenGenerator jwtTokenGenerator)
        {
            _authServices = services;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<string> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = _authServices.AuthenticateUser(request.Username, request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var token = _jwtTokenGenerator.GenerateJwtToken(user);

            return Task.FromResult(token);
        }
    }
}