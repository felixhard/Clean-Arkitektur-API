using Domain.Models.Users;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Users;
using Moq;

namespace Test.Repository.UserTests.UpdateUser
{
    [TestFixture]
    public class UpdateUserTests
    {
        private UserRepository _userRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Users.Update(It.IsAny<User>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }
        [Test]
        public async Task Values_Updated_Correctly()
        {
            // Arrange
            List<User> users =
            [
                new User() { Id = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { Id = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];

            var Id = new Guid("12345678-1234-5678-1234-567812345674");

            var userToUpdate = users.Where(user => user.Id == Id).FirstOrDefault()!;

            userToUpdate.Username = "updatedUsername";
            userToUpdate.Password = "updatedPassword123!";
            userToUpdate.Role = "updatedRole";

            // Act

            var result = await _userRepository.UpdateUser(userToUpdate);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Username, Is.EqualTo(userToUpdate.Username));
            Assert.That(result.Password, Is.EqualTo(userToUpdate.Password));
            Assert.That(result.Role, Is.EqualTo(userToUpdate.Role));
            _mockRealDatabase.Verify(db => db.Users.Update(It.IsAny<User>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}