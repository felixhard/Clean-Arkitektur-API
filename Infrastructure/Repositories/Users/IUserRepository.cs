using Domain.Models.Users;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> UpdateUser(User userToUpdate);
        Task<User> DeleteUser(User userToDelete);
        Task<User> RegisterUser(User userToRegister);
    }
}