using Business.Models;

namespace Business.Interfaces;

public interface IUserService
{
    void CreateUser(User user);
    IEnumerable<User> GetUsers();
}
