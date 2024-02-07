using Application.Queries.Birds.GetById;
using Domain.Models.Animals.Birds;
using FakeItEasy;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdTests
    {

        [Test]
        public async Task Handle_ValidId_ReturnCorrectBird()
        {
            var guid = Guid.NewGuid();

            var bird = new Bird { Name = "Stina", Color = "Lila" };

            var birdRepository = A.Fake<IBirdRepository>();

            var handler = new GetBirdByIdQueryHandler(birdRepository);

            A.CallTo(() => birdRepository.GetBirdById(guid)).Returns(bird);

            var command = new GetBirdByIdQuery(guid);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Bird>());
            Assert.That(result.Name.Equals("Stina"));

        }
    }
}
