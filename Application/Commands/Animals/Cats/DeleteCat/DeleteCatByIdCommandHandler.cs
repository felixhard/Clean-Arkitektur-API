using MediatR;
using Infrastructure.Database;
using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using Application.Commands.Animals.Dogs.DeleteDog;
using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;

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
            Cat catToDelete = await _catRepository.DeleteCat(request.Id);
            if (catToDelete == null)
            {
                return null!;
            }
            return catToDelete;
        }
    }

}
