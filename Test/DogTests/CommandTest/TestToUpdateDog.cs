using Application.Commands.Animals.Dogs.UpdateDog;
using Application.Dtos;
using Application.Dtos.AnimalDtos.DogDto;
using Domain.Models.Animals.Dogs;
using FakeItEasy;
using Infrastructure.Repositories.Animals.Dogs;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class TestToUpdateDog
    {
        [Test]
        public async Task Test_To_Update_Dog()
        {
            //Arrange

            var guid = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230");

            var dog = new Dog
            {
                AnimalId = new Guid("ce9b91e4-08d1-4628-82c1-8ef6ec623230"),
                Name = "Ari",
                Breed = "English Pointer",
                Weight = 25
            };

            var dogDto = new DogDto { Name = "Max", Breed = "Persson", Weight = 25 };

            var dogRepository = A.Fake<IDogRepository>();

            var handler = new UpdateDogByIdCommandHandler(dogRepository);

            A.CallTo(() => dogRepository.GetDogById(dog.AnimalId)).Returns(dog);

            A.CallTo(() => dogRepository.UpdateDog(dog)).Returns(dog);

            var command = new UpdateDogByIdCommand(dogDto, guid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AnimalId, Is.EqualTo(guid));
            Assert.That(result.Name.Equals("Max"));
            Assert.That(result.Breed.Equals("Persson"));
            Assert.That(result.Weight.Equals(25));
            Assert.That(result, Is.TypeOf<Dog>());
        }

    }
}