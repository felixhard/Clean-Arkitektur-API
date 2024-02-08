using Application.Queries.Cats.GetById;
using Infrastructure.Database;
using Application.Commands.Animals.Cats.DeleteCat;
using Domain.Models.Animals.Cats;
using FakeItEasy;
using Infrastructure.Repositories.Animals.Cats;
using Microsoft.Extensions.Logging.Abstractions;
using Application.Commands.Animals.Birds.DeleteBird;
using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class TestToDeleteCat
    {
        [Test]
        public async Task Handle_DeleteCat_Corect_Id()
        {
            //Arrange
            Guid id = new Guid("158a07b7-27fe-4322-8a5e-4c0a38fc3bb0");
            var cat = new Cat
            {
                AnimalId = id,
                Name = "Tom",
                Breed = "Skogskatt",
                Weight = 4,
                LikesToPlay = true
            };
            var catRepository = A.Fake<ICatRepository>();
            var handler = new DeleteCatByIdCommandHandler(catRepository);
            A.CallTo(() => catRepository.DeleteCat(cat.AnimalId)).Returns(cat);

            var command = new DeleteCatByIdCommand(cat.AnimalId);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name.Equals("Tom"));
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.AnimalId.Equals(cat.AnimalId));
            A.CallTo(() => catRepository.DeleteCat(cat.AnimalId)).MustHaveHappened();
        }
    }
}
