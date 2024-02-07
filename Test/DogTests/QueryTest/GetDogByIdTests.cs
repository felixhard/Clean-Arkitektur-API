using Application.Queries.Dogs.GetById;
using Domain.Models.Animals.Dogs;
using FakeItEasy;
using Infrastructure.Repositories.Animals.Dogs;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetDogByIdTests
    {
        [Test]
        public async Task Handle_ValidId_ReturnCorrectDog()
        {
            var guid = Guid.NewGuid();

            var dog = new Dog { Name = "Max", Breed = "Persson" };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new GetDogByIdQueryHandler(dogRepository);

            A.CallTo(() => dogRepository.GetDogById(guid)).Returns(dog);

            var command = new GetDogByIdQuery(guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Dog>());
            Assert.That(result.Name.Equals("Max"));

        }

    }
}