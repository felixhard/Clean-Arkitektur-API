using Application.Commands.Animals.Dogs.AddDog;
using Application.Dtos.AnimalDtos.DogDto;
using Domain.Models.Animals.Dogs;
using FakeItEasy;
using Infrastructure.Repositories.Animals.Dogs;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogTest
    {
        [Test]
        public async Task Test_To_Add_Dog_To_DB()
        {
            //Arrange
            var dog = new Dog { Name = "Krister", Breed = "Bulldog" };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new AddDogCommandHandler(dogRepository);

            A.CallTo(() => dogRepository.AddDog(dog)).Returns(dog);

            var dto = new DogDto();

            dto.Name = "Krister";
            dto.Breed = "Bulldog";
            dto.Weight = 17;

            var command = new AddDogCommand(dto);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name.Equals("Krister"));
            Assert.That(result, Is.TypeOf<Dog>());
        }
    }
}