using Domain.Models.Animals.Birds;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Animals.Birds;
using Moq;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    internal class AddBirdTest
    {
        private BirdRepository _birdRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockRealDatabase.Setup(db => db.Birds.Add(It.IsAny<Bird>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
            _birdRepository = new BirdRepository(_mockRealDatabase.Object);
        }
        [Test]
        public async Task AddBird_Success()
        {
            // Arrange
            var birdToAdd = new Bird() { AnimalId = Guid.NewGuid(), Name = "TestBird3", Color = "Blue" };

            // Act
            var addedBird = await _birdRepository.AddBird(birdToAdd);

            // Assert
            Assert.That(addedBird.AnimalId, Is.EqualTo(birdToAdd.AnimalId));
            Assert.That(addedBird.Name, Is.EqualTo(birdToAdd.Name));
            Assert.That(addedBird, Is.Not.Null);
            _mockRealDatabase.Verify(db => db.Birds.Add(It.IsAny<Bird>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}
