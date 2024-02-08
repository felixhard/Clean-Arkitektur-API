using Application.Dtos.AnimalUsersDto;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.AnimalUsers.GetAll
{
    public class GetAllAnimalUsersQueryHandler : IRequestHandler<GetAllAnimalUsersQuery, List<GetAllAnimalUsersDto>>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public GetAllAnimalUsersQueryHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<List<GetAllAnimalUsersDto>> Handle(GetAllAnimalUsersQuery request, CancellationToken cancellationToken)
        {
            List<GetAllAnimalUsersDto> allAnimalUsers = await _animalUserRepository.GetAllAnimalUsers();
            return allAnimalUsers;
        }
    }
}
