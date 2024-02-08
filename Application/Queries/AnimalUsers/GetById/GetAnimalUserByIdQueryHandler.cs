using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using MediatR;

namespace Application.Queries.AnimalUsers.GetById
{
    public class GetAnimalUserByIdQueryHandler : IRequestHandler<GetAnimalUserByIdQuery, AnimalUser>
    {
        private readonly IAnimalUserRepository _animalUserRepository;

        public GetAnimalUserByIdQueryHandler(IAnimalUserRepository animalUserRepository)
        {
            _animalUserRepository = animalUserRepository;
        }

        public async Task<AnimalUser> Handle(GetAnimalUserByIdQuery request, CancellationToken cancellationToken)
        {
            AnimalUser wantedAnimalUser = await _animalUserRepository.GetAnimalUserByID(request.Id);
            return wantedAnimalUser;
        }
    }
}
