using Application.Queries.Dogs.GetAll;
using Domain.Models.Animals.Dogs;
using FakeItEasy;
using Infrastructure.Repositories.Animals.Dogs;
using NUnit.Framework.Legacy;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsTest
    {
        [Test]
        public async Task Handle_Get_All_Dogs_ReturnListAvDogs()
        {
            List<Dog> dogs = new List<Dog>
            {
                new Dog { Name = "Jonas", Breed = "Tax" , Weight = 27 },
                new Dog { Name = "Doris", Breed = "English Pointer" , Weight = 22 }
            };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new GetAllDogsQueryHandler(dogRepository);

            A.CallTo(() => dogRepository.GetAllDogs()).Returns(dogs);

            var command = new GetAllDogsQuery();

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Dog>>()); // result is a list of Dog objects
            Assert.That(result.Count, Is.EqualTo(dogs.Count));
            Assert.That(result, Is.EqualTo(dogs).AsCollection);//compare both lists directly for equality
        }
    }
}