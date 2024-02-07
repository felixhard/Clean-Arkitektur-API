using Infrastructure.Database;
using Application.Queries.Cats.GetById;
using Application.Dtos.AnimalDtos.CatDto;
using Application.Commands.Animals.Cats.AddCat;
using Domain.Models.Animals.Cats;
using FakeItEasy;
using Infrastructure.Repositories.Animals.Cats;
using Microsoft.Extensions.Logging.Abstractions;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTest
    {
        [Test]
        public async Task Handle_Add_Cat_To_Database()
        {
            // Arrange
            var cat = new Cat { AnimalId = Guid.NewGuid(), Name = "Krister", Breed = "Skogskatt", Weight = 4, LikesToPlay = true };

            var catRepository = A.Fake<ICatRepository>();
            A.CallTo(() => catRepository.AddCat(A<Cat>._)).Returns(cat);

            var handler = new AddCatCommandHandler(catRepository);

            var dto = new CatDto
            {
                Name = "Krister",
                Breed = "Skogskatt",
                Weight = 4,
                LikesToPlay = true
            };

            var command = new AddCatCommand(dto);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name.Equals("Krister"));
            Assert.That(result, Is.TypeOf<Cat>());
        }
    }
}
