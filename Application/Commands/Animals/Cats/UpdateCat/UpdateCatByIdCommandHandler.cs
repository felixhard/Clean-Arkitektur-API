using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.UpdateCat
{
    public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public UpdateCatByIdCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }
        public async Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToUpdate = _catRepository.GetCatById(request.Id).Result;

            catToUpdate.Name = request.UpdatedCat.Name;
            catToUpdate.Weight = request.UpdatedCat.Weight;
            catToUpdate.Breed = request.UpdatedCat.Breed;

            var updatedCat = await _catRepository.UpdateCat(catToUpdate);

            return updatedCat;
        }
    }
}
