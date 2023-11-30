using Infrastructure.Authentication;
using Infrastructure.Database;
using MediatR;
using Domain.Models.Users;

namespace Application.Queries.Users.GetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, User>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public GetTokenQueryHandler(MockDatabase mockDatabase, JwtTokenGenerator jwtTokenGenerator)
        {
            _mockDatabase = mockDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<User> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _mockDatabase.Users.FirstOrDefault(user => user.Username == request.Username)!;

            if (wantedUser.Authorized == true)
            {
                wantedUser.token = _jwtTokenGenerator.GenerateJwtToken(wantedUser);

                return Task.FromResult(wantedUser);
            }

            throw new NotImplementedException();
        }
    }
}