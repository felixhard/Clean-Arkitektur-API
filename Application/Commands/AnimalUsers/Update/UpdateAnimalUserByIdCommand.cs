using Application.Dtos.AnimalUserDto;
using Domain.Models.AnimalUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AnimalUsers.Update
{
    public class UpdateAnimalUserByIdCommand : IRequest<AnimalUser>
    {
        public UpdateAnimalUserByIdCommand(AnimalUserDto animalUserToUpdate, Guid id)
        {
            AnimalUserToUpdate = animalUserToUpdate;
            Id = id;
        }
        public AnimalUserDto AnimalUserToUpdate { get; }
        public Guid Id { get; }
    }
}
