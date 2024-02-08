using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AnimalUsers.Update
{
    public class UpdateAnimalUserByIdCommandHandler : IRequestHandler<UpdateAnimalUserByIdCommand, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public async Task<AnimalUser> Handle(UpdateAnimalUserByIdCommand request, CancellationToken cancellationToken)
        {
            AnimalUser animalUserToUpdate = _animalUserRepository.GetAnimalUserByID(request.Id).Result;

            animalUserToUpdate.AnimalId = request.AnimalUserToUpdate.AnimalId;
            animalUserToUpdate.UserId = request.AnimalUserToUpdate.UserId;

            var updatedAnimalUser = await _animalUserRepository.UpdateAnimalUser(animalUserToUpdate);

            return updatedAnimalUser;
        }
    }
}
