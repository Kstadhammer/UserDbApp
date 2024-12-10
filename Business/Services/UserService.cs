using System.Text.Json;
using Business.Interfaces;
using Business.Models;
using Business.Models.DTOs;

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

    // Had trouble with implementing UserDto and UserResponseDto,
    // So had some help from Claude AI to implement this
    // From the beginning i didn't use the UserDto and UserResponseDto,
    // I just used the User class directly.


    public void CreateUser(UserDto userDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            TimeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            Address = userDto.Address,
            PostalCode = userDto.PostalCode,
            City = userDto.City,
        };

        _users.Add(user);
        _fileService.SaveUserToFile(JsonSerializer.Serialize(_users));
        LoadUsers();
    }

    public IEnumerable<UserResponseDto> GetUsers()
    {
        LoadUsers();
        return _users.Select(user => new UserResponseDto
        {
            Id = user.Id,
            TimeCreated = user.TimeCreated,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            PostalCode = user.PostalCode,
            City = user.City,
        });
    }

    public UserResponseDto GetUserByFirstName(string firstName)
    {
        LoadUsers();
        var user = _users.FirstOrDefault(user => user.FirstName == firstName);
        if (user != null)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                TimeCreated = user.TimeCreated,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                PostalCode = user.PostalCode,
                City = user.City,
            };
        }
        return new UserResponseDto();
    }
}
