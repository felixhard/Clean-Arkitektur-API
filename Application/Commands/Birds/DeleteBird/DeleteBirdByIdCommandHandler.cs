using MediatR;
using Infrastructure.Database;
using Domain.Models.Birds;
using Application.Commands.Birds;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == request.Id)!;
            _mockDatabase.Birds.Remove(birdToDelete);

            return Task.FromResult(birdToDelete);
        }
    }

}
