using Application.Dtos.AnimalUserDto;
using Domain.Models.AnimalUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AnimalUsers.Add
{
    public class AddAnimalUserCommand : IRequest<AnimalUser>
    {
        public AddAnimalUserCommand(AnimalUserDto animalUserDto)
        {
            AnimalUserDto = animalUserDto;
        }
        public AnimalUserDto AnimalUserDto { get; }
    }
}
