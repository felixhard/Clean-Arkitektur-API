using Application.Commands.Animals.Birds.UpdateBird;
using Application.Dtos.AnimalDtos.BirdDto;
using Domain.Models.Animals.Birds;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class TestToUpdateBird
    {
        [Test]
        public async Task Handle_Update_Correct_Bird_By_Id()
        {
            //Arrange

            var guid = new Guid("58e05645-05ff-400b-9bab-f6db29b8c00d");

            var bird = new Bird
            {
                AnimalId = new Guid("58e05645-05ff-400b-9bab-f6db29b8c00d"),
                Name = "Charlie",
                Color = "Blue",
                CanFly = true,
            };

            var birdDto = new BirdDto { Name = "Ara", Color = "Red", CanFly = true };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new UpdateBirdByIdCommandHandler(birdRepository);

            A.CallTo(() => birdRepository.GetBirdById(bird.AnimalId)).Returns(bird);

            A.CallTo(() => birdRepository.UpdateBird(bird)).Returns(bird);

            var command = new UpdateBirdByIdCommand(birdDto, guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name.Equals("Ara"));
            Assert.That(result.Color.Equals("Red"));
            Assert.That(result.CanFly.Equals(true));
            Assert.That(result, Is.TypeOf<Bird>());
        }
    }
}
