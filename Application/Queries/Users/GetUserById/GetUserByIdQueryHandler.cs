using Application.Queries.Users.GetUserById;
using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User wantedUser = await _userRepository.GetUserById(request.Id);
            return wantedUser;
        }
    }
}