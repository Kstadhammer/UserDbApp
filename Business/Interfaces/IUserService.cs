using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    void CreateUser(User user);
    IEnumerable<User> GetUsers();
    User? Login(string username, string password);
}
