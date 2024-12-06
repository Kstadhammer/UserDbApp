using System.Text.Json;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService : IUserService
{
    private readonly IFileService _fileService;
    private List<User> _users;

    public UserService(IFileService fileService)
    {
        _fileService = fileService;
        _users = new List<User>();
        LoadUsers();
    }

    private void LoadUsers()
    {
        try
        {
            string content = _fileService.GetFileContent();
            _users = JsonSerializer.Deserialize<List<User>>(content) ?? new List<User>();
        }
        catch (JsonException)
        {
            _users = new List<User>();
        }
    }

    public void CreateUser(User user)
    {
        user.Id = Guid.NewGuid().ToString();
        _users.Add(user);
        _fileService.SaveUserToFile(JsonSerializer.Serialize(_users));
        LoadUsers(); // Reload users after saving
    }

    public IEnumerable<User> GetUsers()
    {
        LoadUsers(); // Reload users from file before returning
        return _users;
    }

    //Got help from claude to fix the login method and also implenting it in IUserService

    public User? Login(string username, string password)
    {
        LoadUsers();
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
