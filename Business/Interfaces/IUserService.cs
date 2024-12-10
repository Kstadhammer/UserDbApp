using Business.Models;
using Business.Models.DTOs;

namespace Business.Interfaces;

public interface IUserService
{
    void CreateUser(UserDto userDto);
    IEnumerable<UserResponseDto> GetUsers();
}
