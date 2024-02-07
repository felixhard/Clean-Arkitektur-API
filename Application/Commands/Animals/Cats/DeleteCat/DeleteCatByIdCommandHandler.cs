using MediatR;
using Infrastructure.Database;
using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;

namespace Application.Commands.Animals.Cats.DeleteCat
{
    public class DeleteCatByIdCommandHandler : IRequestHandler<DeleteCatByIdCommand, Cat>
    {
        private readonly ICatRepository _catRepository;

        public DeleteCatByIdCommandHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Cat> Handle(DeleteCatByIdCommand request, CancellationToken cancellationToken)
        {
            Cat catToDelete = _catRepository.GetCatById(request.Id).Result;

            var deletedCat = await _catRepository.DeleteCat(catToDelete);

            return deletedCat;
        }
    }

}
