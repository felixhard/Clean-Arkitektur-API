using Domain.Models.AnimalUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AnimalUsers.Delete
{
    public class DeleteAnimalUserByIdCommand : IRequest<AnimalUser>
    {
        public DeleteAnimalUserByIdCommand(Guid animalUserId)
        {
            Id = animalUserId;
        }
        public Guid Id { get; set; }
    }
}
