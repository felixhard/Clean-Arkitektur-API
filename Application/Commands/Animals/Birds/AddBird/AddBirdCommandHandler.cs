using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public AddBirdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            var BirdToCreate = new Bird
            {
                AnimalId = Guid.NewGuid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly,
                Color = request.NewBird.Color
            };
            var createdBird = await _birdRepository.AddBird(BirdToCreate);

            return createdBird;
        }
    }
}