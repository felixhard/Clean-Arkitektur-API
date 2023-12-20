using Infrastructure.Database;
using Domain.Models.Users;
using Microsoft.Extensions.Configuration;

public class AuthRepository
{
    private readonly IConfiguration _configuration;
    private readonly MockDatabase _mockDatabase;

    public AuthRepository(IConfiguration configuration, MockDatabase mockDatabase)
    {
        _configuration = configuration;
        _mockDatabase = mockDatabase;
    }

    public User AuthenticateUser(string username, string password)
    {
        var user = _mockDatabase.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }
}