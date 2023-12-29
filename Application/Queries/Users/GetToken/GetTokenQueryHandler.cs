using Domain.Models.Users;
using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Queries.Users.GetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, User>
    {
        //private readonly MockDatabase _mockDatabase;
        private readonly RealDatabase _realDatabase;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public GetTokenQueryHandler(RealDatabase realDatabase, JwtTokenGenerator jwtTokenGenerator)
        {
            //_mockDatabase = mockDatabase;
            _realDatabase = realDatabase;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<User> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = _realDatabase.Users.FirstOrDefault(user => user.Username == request.Username)!;

            if (wantedUser.Authorized == true)
            {
                wantedUser.Token = _jwtTokenGenerator.GenerateJwtToken(wantedUser);

                return Task.FromResult(wantedUser);
            }

            throw new NotImplementedException();
        }
    }
}