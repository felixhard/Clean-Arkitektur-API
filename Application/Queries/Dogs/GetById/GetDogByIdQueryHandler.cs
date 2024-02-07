using MediatR;
using Infrastructure.Database;
using Domain.Models;
using Application.Queries.Dogs.GetById;
using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public GetDogByIdQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = await _dogRepository.GetDogById(request.Id);

            if (wantedDog == null)
            {
                return null!;
            }

            return wantedDog;
        }
    }
}