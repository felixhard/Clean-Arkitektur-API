using Domain.Models.Users;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Users;
using Moq;

namespace Test.Repository.UserTests.RegisterUser
{
    [TestFixture]
    public class RegisterUserTests
    {
        private UserRepository _userRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockRealDatabase.Setup(db => db.Users.Add(It.IsAny<User>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
            _userRepository = new UserRepository(_mockRealDatabase.Object);
        }
        [Test]
        public async Task RegisterUser_Success()
        {
            // Arrange
            var userToRegister = new User() { Id = Guid.NewGuid(), Username = "Necika2221!", Password = "pASSWROD12343", Authorized = true };

            // Act
            var registeredUser = await _userRepository.RegisterUser(userToRegister);

            // Assert
            Assert.That(registeredUser, Is.Not.Null);
            Assert.That(registeredUser.Id, Is.EqualTo(userToRegister.Id));
            Assert.That(registeredUser.Username, Is.EqualTo(userToRegister.Username));
            Assert.That(registeredUser.Password, Is.EqualTo(userToRegister.Password));
            _mockRealDatabase.Verify(db => db.Users.Add(It.IsAny<User>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}