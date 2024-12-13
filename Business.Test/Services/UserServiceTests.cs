using Business.Interfaces;
using Moq;

namespace Business.Test.Services;

public class UserServiceTests
{
    private IUserService _userService;

    private Mock<IFileService> _fileServiceMock;
}
