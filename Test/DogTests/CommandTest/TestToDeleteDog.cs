using Application.Queries.Dogs.GetById;
using Infrastructure.Database;
using Application.Commands.Animals.Dogs.DeleteDog;
using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using FakeItEasy;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class TestToDeleteDog
    {
        [Test]
        public async Task Handle_DeleteDog_Corect_Id()
        {
            //Arrange
            Guid id = new Guid("262b33a9-27fe-4322-8a5e-4c0a38fc3bb0");
            var dog = new Dog
            {
                AnimalId = id,
                Name = "Max",
                Breed = "Golden",
                Weight = 4
            };
            var dogRepository = A.Fake<IDogRepository>();
            var handler = new DeleteDogByIdCommandHandler(dogRepository);
            A.CallTo(() => dogRepository.DeleteDog(dog.AnimalId)).Returns(dog);

            var command = new DeleteDogByIdCommand(dog.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name.Equals("Max"));
            Assert.That(result, Is.TypeOf<Dog>());
            Assert.That(result.AnimalId.Equals(dog.AnimalId));
            A.CallTo(() => dogRepository.DeleteDog(dog.AnimalId)).MustHaveHappened();
        }
    }
}
