using Application.Queries.Dogs.GetByBreedAndWeight;
using Domain.Models.Animals.Dogs;
using FakeItEasy;
using NUnit.Framework;
using Infrastructure.Repositories.Animals.Dogs;

namespace Test.DogTests.QueryTest
{
    public class GetDogsByBreedAndWeightTest
    {
        [Test]
        public async Task Handle_Returns_Dogs_By_Breed_And_Weight()
        {
            // Arrange
            var fakeDogsData = new List<Dog>
            {
                new Dog { Name = "Rex", Breed = "English Pointer", Weight = 25 },
                new Dog { Name = "Ari", Breed = "English Pointer", Weight = 25 },
                new Dog { Name = "Astor", Breed = "English Pointer", Weight = 35 },
                new Dog { Name = "Buster", Breed = "English Pointer", Weight = 22 },
                new Dog { Name = "Tom", Breed = "Bulldog", Weight = 27 },
                new Dog { Name = "Felix", Breed = "Bulldog", Weight = 19 },
            };

            var dogRepository = A.Fake<IDogRepository>();
            var handler = new GetDogsByBreedAndWeightQueryHandler(dogRepository);
            var request = new GetDogsByBreedAndWeightQuery { Weight = 25, Breed = "English Pointer" };

            A.CallTo(() => dogRepository.GetDogsByBreedAndWeight(
                    A<string>.That.Matches(breed => breed == "English Pointer"),
                    A<int?>.That.Matches(weight => weight == 25)
                ))
                .Returns(fakeDogsData.Where(b => b.Weight >= 25 && b.Breed == "English Pointer").ToList());

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Is.TypeOf<List<Dog>>());
        }

        [Test]
        public async Task Handle_Returns_Empty_List_When_No_Dogs_Found()
        {
            // Arrange
            var dogRepository = A.Fake<IDogRepository>();
            var handler = new GetDogsByBreedAndWeightQueryHandler(dogRepository);
            var request = new GetDogsByBreedAndWeightQuery { Weight = 25, Breed = "English Pointer" };

            A.CallTo(() => dogRepository.GetDogsByBreedAndWeight(
                    A<string>.That.Matches(breed => breed == "English Pointer"),
                    A<int?>.That.Matches(weight => weight == 25)
                ))
                .Returns(new List<Dog>());

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
