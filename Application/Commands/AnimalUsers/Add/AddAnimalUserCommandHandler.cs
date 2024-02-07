/*using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Commands.AnimalUsers.Add
{
    public class AddAnimalUserCommandHandler : IRequestHandler<AddAnimalUserCommand, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public AddAnimalUserCommandHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<AnimalUser> Handle(AddAnimalUserCommand request, CancellationToken cancellationToken)
        {

            var animalUserToCreate = new AnimalUser
            {
                Key = Guid.NewGuid(),
                AnimalId = request.AnimalUserDto.AnimalId,
                UserId = request.AnimalUserDto.UserId
            };

            var createdAnimalUser = await _animalUserRepository.CreateAnimalUser(animalUserToCreate);

            return createdAnimalUser;*/