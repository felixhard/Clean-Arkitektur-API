using Application.Commands.Animals.Dogs.DeleteDog;
using Domain.Models.Animals.Dogs;
using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AnimalUsers.Delete
{
    public class DeleteAnimalUserByIdCommandHandler : IRequestHandler<DeleteAnimalUserByIdCommand, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public DeleteAnimalUserByIdCommandHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }
        public async Task<AnimalUser> Handle(DeleteAnimalUserByIdCommand request, CancellationToken cancellationToken)
        {
            AnimalUser animalUserToDelete = await _animalUserRepository.DeleteAnimalUser(request.Id);
            if (animalUserToDelete == null)
            {
                return null!;
            }
            return animalUserToDelete;
        }
    }
}
