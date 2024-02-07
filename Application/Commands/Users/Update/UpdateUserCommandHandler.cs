using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly UpdateUserCommandValidator _validator;
        public UpdateUserCommandHandler(IUserRepository userRepository, UpdateUserCommandValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUserCommandValidation = _validator.Validate(request);

            if (!updateUserCommandValidation.IsValid)
            {
                var allErrors = updateUserCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Update error: " + string.Join("; ", allErrors));
            }

            User userToUpdate = _userRepository.GetUserById(request.Id).Result;

            userToUpdate.Username = request.UserToUpdate.Username;
            userToUpdate.Password = request.UserToUpdate.Password;
            userToUpdate.Role = request.UserToUpdate.Role;

            var updatedUser = await _userRepository.UpdateUser(userToUpdate);

            return updatedUser;
        }
    }
}