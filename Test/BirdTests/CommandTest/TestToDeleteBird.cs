using Application.Queries.Birds.GetById;
using Infrastructure.Database;
using Application.Commands.Animals.Birds.DeleteBird;
using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using FakeItEasy;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class TestToDeleteBird
    {
        [Test]
        public async Task Handle_DeleteBird_Corect_Id()
        {
            //Arrange
            var bird = new Bird
            {
                AnimalId = Guid.NewGuid(),
                Name = "Hawk",
                Color = "Red",
                CanFly = true,
            };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new DeleteBirdByIdCommandHandler(birdRepository);

            A.CallTo(() => birdRepository.DeleteBird(bird.AnimalId)).Returns(bird);

            var command = new DeleteBirdByIdCommand(bird.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name.Equals("Hawk"));
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.AnimalId.Equals(bird.AnimalId));
            A.CallTo(() => birdRepository.DeleteBird(bird.AnimalId)).MustHaveHappened();
        }
    }
}
