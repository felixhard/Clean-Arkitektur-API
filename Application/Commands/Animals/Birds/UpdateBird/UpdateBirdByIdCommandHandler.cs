using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.UpdateBird
{
    public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;

        public UpdateBirdByIdCommandHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }
        public async Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToUpdate = _birdRepository.GetBirdById(request.Id).Result;

            birdToUpdate.Name = request.UpdatedBird.Name;
            birdToUpdate.CanFly = request.UpdatedBird.CanFly;
            birdToUpdate.Color = request.UpdatedBird.Color;

            var updatedBird = await _birdRepository.UpdateBird(birdToUpdate);

            return updatedBird;
        }
    }
}
