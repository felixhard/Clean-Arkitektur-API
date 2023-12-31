﻿using Domain.Models.Birds;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public AddBirdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird BirdToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly,

            };


            _mockDatabase.Birds.Add(BirdToCreate);

            return Task.FromResult(BirdToCreate);
        }
    }
}