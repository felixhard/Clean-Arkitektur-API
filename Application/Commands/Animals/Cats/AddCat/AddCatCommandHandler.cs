using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public AddCatCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat catToAdd = new()
            {
                AnimalId = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay,
                Breed = request.NewCat.Breed,
                Weight = request.NewCat.Weight
            };

            var createdCat = await _catRepository.AddCat(catToAdd);

            return createdCat;
        }
    }
}