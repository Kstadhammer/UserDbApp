using System.Text.Json;
using Business.Interfaces;
using Business.Models;
using Business.Models.DTOs;
using Business.Services;
using Microsoft.VisualBasic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

//used https://www.roundthecode.com/dotnet-tutorials/moq-mocking-objects-xunit-dotnet for some help
//also Claud AI for debugging and help with the code and error handling
//i tried using Microsoft.VisualStudio.TestTools.UnitTesting but it was not working so i switched to xunit as in the videos from Hans

namespace Business.Test.Services;

//testing for user service using xunit and moq for the file service and the user service
public class UserServiceTests
{
    private readonly IUserService _userService;
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly List<User> _testUsers;

    //constructor for the test class
    public UserServiceTests()
    {
        _fileServiceMock = new Mock<IFileService>();

        //set up the file service mock to return an empty list of users
        //this is to test the error handling in the user service
        //if the file is empty, the user service should return an empty list of users
        //i got some help from Claude to implement this, since i was getting an error
        //when i tried to use the same instance of the file service in the user service

        _fileServiceMock.Setup(x => x.GetFileContent()).Returns("[]");
        _userService = new UserService(_fileServiceMock.Object);
        _testUsers = new List<User>
        {
            //test data for the user service
            new User
            {
                Id = "1",
                FirstName = "Kim",
                LastName = "Hammerstad",
                Email = "kim@domain.com ",
                PhoneNumber = "1234567890",
                Address = "Kimberlyveien 12",
                PostalCode = "00001",
                City = "Helsinki",
            },
        };
    }

    [Fact]
    //testing the create user method to add a new user to the file
    public void CreateUser_ShouldAddANewUser()
    {
        //arrange
        //test data for the user service
        //new user to add to the file

        var userDto = new UserDto
        {
            FirstName = "Kimberly",
            LastName = "Hammerstadly",
            Email = "kimberly@domain.com ",
            PhoneNumber = "1234567890",
            Address = "Kimberlyveien 11",
            PostalCode = "00002",
            City = "Helsingborg",
        };
        _fileServiceMock
            .Setup(x => x.GetFileContent())
            .Returns(JsonSerializer.Serialize(_testUsers));

        //act
        _userService.CreateUser(userDto);

        //assert
        //check if the file is saved with the new user added
        _fileServiceMock.Verify(x => x.SaveUserToFile(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    //test the get users method to return all users from the file
    public void GetUsers_ShouldReturnAllUsers()
    {
        //arrange
        _fileServiceMock
            .Setup(x => x.GetFileContent())
            .Returns(JsonSerializer.Serialize(_testUsers));

        //act
        var result = _userService.GetUsers().ToList();

        //assert
        //check if the result is a list with one user
        Assert.Single(result);
        //check if the user is the same as the one in the test data
        Assert.Equal("Kim", result[0].FirstName);
        Assert.Equal("Hammerstad", result[0].LastName);
        Assert.Equal("Kimberlyveien 12", result[0].Address);
    }

    [Fact]
    public void EditUser_ShouldUpdateAnExistingUser()
    {
        //arrange
        //test data for the user service
        //user to update with the new data

        _fileServiceMock
            .Setup(x => x.GetFileContent())
            .Returns(JsonSerializer.Serialize(_testUsers));

        var userDto = new UserDto
        {
            FirstName = "Kimberly updated",
            LastName = "Hammerstadly updated",
            Email = "kimberly@domain.com updated",
            PhoneNumber = "1234567890 updated",
            Address = "Kimberlyveien 11 updated",
            PostalCode = "00002 updated",
            City = "Helsingborg updated",
        };

        //act
        //edit the user with the new data

        _userService.EditUser("1", userDto);

        //assert
        //check if the file is saved with the updated user
        _fileServiceMock.Verify(x => x.SaveUserToFile(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void DeleteUser_ShouldRemoveUser()
    {
        //arrange
        //test data for the user service
        //user to remove from the file

        _fileServiceMock
            .Setup(x => x.GetFileContent())
            .Returns(JsonSerializer.Serialize(_testUsers));

        //act
        //delete the user from the file
        _userService.DeleteUser("1");

        //assert

        //check if the file is saved with the updated user
        _fileServiceMock.Verify(
            x => x.SaveUserToFile(It.Is<string>(s => !s.Contains("Kim"))),
            Times.Once
        );
    }
}
